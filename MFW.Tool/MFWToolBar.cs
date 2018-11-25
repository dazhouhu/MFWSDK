using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MFW.Core;
using MFW.Tool.UX;

namespace MFW.Tool
{
    public partial class MFWToolBar : UserControl
    {
        #region Fields
        private Panel ownerPnl;
        private Call _currentCall;
        private CallManager callManager = CallManager.GetInstance();
        private DeviceManager deviceManager = DeviceManager.GetInstance();
        #endregion

        #region Constructors
        private static readonly object lockObj = new object();
        private static MFWToolBar instance = null;
        public MFWToolBar()
        {
            InitializeComponent();
        }
        public static MFWToolBar GetInstance()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new MFWToolBar();
                    }
                }
            }
            return instance;
        }
        #endregion

        #region BindPanel
        public void BindPanel(Panel pnl)
        {
            if (null == pnl)
            {
                throw new Exception("父控件必须");
            }
            pnl.Controls.Add(this);
            ownerPnl = pnl;

            this.Dock = DockStyle.Bottom;
            //this.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            this.Width = ownerPnl.Width;
            ownerPnl.SizeChanged += (sender, args) =>
            {
                this.Width = ownerPnl.Width;
            };
        }
        #endregion

        #region ToolBar
        private void MFWToolBar_Load(object sender, EventArgs e)
        {
            bindDeviceStatus();
            deviceManager.DevicesChanged += (obj, args) => {
                bindDeviceStatus();
            };
            callManager.PropertyChanged += (obj, args) =>
            {
                switch(args.PropertyName)
                {
                    case "CurrentCall":
                        {
                            if(null != _currentCall)
                            {
                                _currentCall.PropertyChanged -= OnCallPropertyChangedHandle;
                            }
                            _currentCall = callManager.CurrentCall;
                            if(null != _currentCall)
                            {
                                _currentCall.PropertyChanged += OnCallPropertyChangedHandle;
                            }
                            bindDeviceStatus();
                        }
                        break;
                }
            };
        }
        private void OnCallPropertyChangedHandle(object sender, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
                case "CallState": break;
                case "IsAudioOnly": break;
                case "IsContentSupported": break;
                    {
                        bindDeviceStatus();
                    }
                    break;
            }
        }

        private void bindDeviceStatus()
        {
            #region Device Init
            if (null != deviceManager.CurrentAudioInputDevice)
            {
                this.btnMic.Enabled = true;
                this.btnMic.Image = Properties.Resources.mic;
                var volume = MFWCore.GetMicVolume();
                this.tbMicVolume.Value = volume;
                this.tbMicVolume.LostFocus += (obj, args) => { this.tbMicVolume.Hide(); };
            }
            else
            {
                this.btnMic.Enabled = false;
                this.btnMic.Image = Properties.Resources.mic_mute;
                this.tbMicVolume.Value = 0;
            }
            if (null != deviceManager.CurrentAudioOutputDevice)
            {
                this.btnSpeaker.Enabled = true;
                this.btnSpeaker.Image = Properties.Resources.speaker;
                var volume = MFWCore.GetSpeakerVolume();
                this.tbSpeakerVolume.Value = volume;
                this.tbSpeakerVolume.LostFocus += (obj, args) => { this.tbSpeakerVolume.Hide(); };
            }
            else
            {
                this.btnSpeaker.Enabled = false;
                this.btnSpeaker.Image = Properties.Resources.speaker_mute;
                this.tbSpeakerVolume.Value = 0;
            }
            if (null != deviceManager.CurrentVideoInputDevice && null != callManager.CurrentCall)
            {
                this.btnCamera.Enabled = true;
                switch (callManager.CurrentCall.CallMode)
                {
                    case CallMode.AUDIOVIDEO_CALL:
                        {
                            this.btnCamera.Image = Properties.Resources.camera;
                            if (callManager.CurrentCall.IsContentSupported)
                            {
                                this.btnShare.Enabled = true;
                                this.btnShare.Image = Properties.Resources.share;
                            }
                            else
                            {
                                this.btnShare.Enabled = false;
                                this.btnShare.Image = Properties.Resources.share_mute;
                            }
                        }
                        break;
                    case CallMode.AUDIO_CALL:
                        {
                            this.btnCamera.Image = Properties.Resources.camera_mute;
                            this.btnShare.Enabled = false;
                            this.btnShare.Image = Properties.Resources.share_mute;
                        }
                        break;
                }
            }
            else
            {
                this.btnCamera.Enabled = false;
                this.btnCamera.Image = Properties.Resources.camera_mute;
                this.btnShare.Enabled = false;
                this.btnShare.Image = Properties.Resources.share_mute;
            }
            #endregion
        }
        private void btnSignal_Click(object sender, EventArgs e)
        {

        }

        private void btnMic_Click(object sender, EventArgs e)
        {
            tbMicVolume.Show();
            tbMicVolume.Focus();
            tbMicVolume.BringToFront();
            tbMicVolume.Left = btnMic.Left + 10;
            tbMicVolume.Top = this.Height - 80 - 158;
        }

        private void btnSpeaker_Click(object sender, EventArgs e)
        {
            tbSpeakerVolume.Show();
            tbSpeakerVolume.Focus();
            tbSpeakerVolume.BringToFront();
            tbSpeakerVolume.Left = btnSpeaker.Left + 10;
            tbSpeakerVolume.Top = this.Height - 80 - 158;
        }
        private bool _muteCamera = true;
        public bool MuteCamera
        {
            get { return _muteCamera; }
            set
            {
                if (_muteCamera != value)
                {
                    _muteCamera = value;
                    btnCamera.Image = _muteCamera ? Properties.Resources.camera_mute : Properties.Resources.camera;
                }
            }
        }
        private void btnCamera_Click(object sender, EventArgs e)
        {
            if (true == MuteCamera)
            {
                if (ErrorNumber.OK == MFWCore.StartCamera())
                {
                    MuteCamera = false;
                }
                else
                {
                    UXMessageMask.ShowMessage(ownerPnl, false, "启动摄像头失败！", MessageBoxButtonsType.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (ErrorNumber.OK == MFWCore.StopCamera())
                {
                    MuteCamera = true;
                }
                else
                {
                    UXMessageMask.ShowMessage(ownerPnl, false, "关闭摄像头失败！", MessageBoxButtonsType.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            if (null == _currentCall)
                return;
            var contentSelectWin = new ContentSelectPanel()
            {
                Monitors = deviceManager.GetDevicesByType(DeviceType.MONITOR),
                Apps = deviceManager.GetDevicesByType(DeviceType.APPLICATIONS),
                OKAction = (type, format, monitor, app) => {
                    switch (type)
                    {
                        case "Monitor":
                            {
                                var errno = MFWCore.StartShareContent(_currentCall, monitor, app);
                                if (errno != ErrorNumber.OK)
                                {
                                    MessageBox.Show(this, "共享内容失败！", "消息框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                            break;
                        case "BFCP":
                            {
                                var width = Screen.PrimaryScreen.Bounds.Width;
                                var height = Screen.PrimaryScreen.Bounds.Height;
                                MFWCore.SetContentBuffer(format, width, height);
                                var errno = MFWCore.StartBFCPContent(_currentCall);
                                if (errno != ErrorNumber.OK)
                                {
                                    MessageBox.Show(this, "共享内容失败！", "消息框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                            break;
                    }
                    return true;
                },
                OnCancel = () => { }
            };
            UXMessageMask.ShowForm(ownerPnl, contentSelectWin);
        }

        private void btnAttender_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "实现中", "消息框", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            moreMenu.Show(btnMore, new Point(0, 0), ToolStripDropDownDirection.AboveRight);

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
        #endregion
        #region Menu
        private void menuItemDTMF_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "暂时不实现", "消息框", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void menuItemFECC_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "暂时不实现", "消息框", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void menuItemP_Click(object sender, EventArgs e)
        {
            MFWCore.SetLayout(LayoutType.Presentation);
        }

        private void menuItemVAS_Click(object sender, EventArgs e)
        {
            MFWCore.SetLayout(LayoutType.VAS);
        }

        private void menuItemCP_Click(object sender, EventArgs e)
        {
            MFWCore.SetLayout(LayoutType.ContinuousPresence);
        }
        #endregion

        private void tbMicVolume_ValueChanged(object sender, EventArgs e)
        {
            if (null == _currentCall)
                return;
            var volume = tbMicVolume.Value;
            if (0 == volume)
            {
                if (ErrorNumber.OK == MFWCore.MuteMic(_currentCall, true))
                {
                    this.btnMic.Image = Properties.Resources.mic_mute;
                }
            }
            else
            {
                if (ErrorNumber.OK == MFWCore.MuteMic(_currentCall, false))
                {
                    this.btnMic.Image = Properties.Resources.mic;
                }
            }
            if (ErrorNumber.OK != MFWCore.SetMicVolume(volume))
            {
                Action okAction = () =>
                {
                    volume = MFWCore.GetMicVolume();
                    this.tbMicVolume.Value = volume;
                };
                UXMessageMask.ShowMessage(ownerPnl, false, "设置麦克风音量失败!", MessageBoxButtonsType.OK, MessageBoxIcon.Error
                                            , okAction);
            }
        }

        private void tbSpeakerVolume_ValueChanged(object sender, EventArgs e)
        {
            var volume = tbSpeakerVolume.Value;
            if (0 == volume)
            {
                if (ErrorNumber.OK == MFWCore.MuteSpeaker(true))
                {
                    this.btnSpeaker.Image = Properties.Resources.speaker_mute;
                }
            }
            else
            {
                if (ErrorNumber.OK == MFWCore.MuteSpeaker(false))
                {
                    this.btnSpeaker.Image = Properties.Resources.speaker;
                }
            }
            if (ErrorNumber.OK != MFWCore.SetSpeakerVolume(volume))
            {
                if (MessageBox.Show(this, "设置麦克风音量失败!", "消息框", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    volume = MFWCore.GetSpeakerVolume();
                    this.tbSpeakerVolume.Value = volume;
                }
            }
        }
    }
}
