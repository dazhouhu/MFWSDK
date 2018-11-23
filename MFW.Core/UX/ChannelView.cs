using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace MFW.Core
{
    public partial class ChannelView : UserControl
    {
        #region Fields
        private ILog log = LogManager.GetLogger("ChannelView");
        private Channel _channel;
        #endregion

        #region Constructors
        public ChannelView(Channel channel)
        {
            InitializeComponent();
            _channel = channel;
            _channel.PropertyChanged += OnPropertyChangedEventHandler;
            this.Disposed += OnDisposed;
        }
        #endregion

        #region Properties
        public bool IsShowBar
        {
            set
            {
                lblName.Visible = !value;
                pnlBtns.Visible = value;
                lblChannelName.Visible = value;
                btnAudio.Visible = value;
                btnVideo.Visible = value;
                PaintView();
            }
        }
        #endregion
        private void OnPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "ChannelName":
                    {
                        this.lblName.Text = _channel.ChannelName;
                        this.lblChannelName.Text = _channel.ChannelName;
                    }
                    break;
                case "IsVideo":
                    {
                        btnVideo.Image = _channel.IsVideo ? MFW.Core.Assets.MFWResource.camera : MFW.Core.Assets.MFWResource.camera_mute;

                        RenderVedio();
                    }
                    break;
                case "IsAudio":
                    {
                        btnAudio.Image = _channel.IsAudio ? MFW.Core.Assets.MFWResource.speaker : MFW.Core.Assets.MFWResource.speaker_mute;
                    }
                    break;
                case "IsActive":
                    {
                    }
                    break;
                case "Size":
                    {

                        PaintView();
                    }
                    break;
            }
        }

        private void ChannelView_Load(object sender, EventArgs e)
        {
            this.lblName.Text = _channel.ChannelName;
            this.lblChannelName.Text = _channel.ChannelName;

            btnVideo.Image = _channel.IsVideo ? MFW.Core.Assets.MFWResource.camera : MFW.Core.Assets.MFWResource.camera_mute;
            btnAudio.Image = _channel.IsAudio ? MFW.Core.Assets.MFWResource.speaker : MFW.Core.Assets.MFWResource.speaker_mute;

            this.IsShowBar = !_channel.IsActive;

            RenderVedio();
        }
        private void OnDisposed(object sender, EventArgs e)
        {
            try
            {
                switch (_channel.MediaType)
                {
                    case MediaType.LOCAL:
                        {
                            var errno = WrapperProxy.DetachStreamWnd(MediaType.LOCAL, _channel.ChannelID, _channel.Call.CallHandle);
                            if (ErrorNumber.OK != errno)
                            {
                                log.Error("本地视频卸载失败");
                            }
                        }
                        break;
                    case MediaType.REMOTE:
                        {
                            var errno = WrapperProxy.DetachStreamWnd(MediaType.REMOTE, _channel.ChannelID, _channel.Call.CallHandle);
                            if (ErrorNumber.OK != errno)
                            {
                                log.Error("远程视频卸载失败");
                            }
                        }
                        break;
                    case MediaType.CONTENT:
                        {
                            var errno = WrapperProxy.DetachStreamWnd(MediaType.CONTENT, _channel.ChannelID, _channel.Call.CallHandle);
                            if (ErrorNumber.OK != errno)
                            {
                                log.Error("共享视频卸载失败");
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ChannelView_SizeChanged(object sender, EventArgs e)
        {
            PaintView();
        }

        private void PaintView()
        {
            var streamWidth = _channel.Size.Width;
            var streamHeight = _channel.Size.Height;
            int ratio_w = 0;
            int ratio_h = 0;
            if (streamWidth * 9 == streamHeight * 16)
            {
                log.Info("resizeResolutionChange: 16:9");
                ratio_w = 16;
                ratio_h = 9;
            }
            else if (streamWidth * 3 == streamHeight * 4)
            {
                log.Info("resizeResolutionChange: 4:3");
                ratio_w = 4;
                ratio_h = 3;
            }
            else
            {
                ratio_w = streamWidth;
                ratio_h = streamHeight;
                log.Warn("resizeResolutionChange: not normal aspect ratio.");
            }
            var hostWidth = this.Width;
            var hostHeight = this.Height - (_channel.IsActive ? 0 : 40);
            var viewHeight = hostHeight;
            var viewWidth = hostHeight * ratio_w / ratio_h;

            if (viewWidth > hostWidth)
            {
                viewWidth = hostWidth;
                viewHeight = viewWidth * ratio_h / ratio_w;
            }
            this.pnlVideo.Width = (int)viewWidth;
            this.pnlVideo.Height = (int)viewHeight;
            var x = (hostWidth - pnlVideo.Width) / 2;
            var y = (hostHeight - pnlVideo.Height) / 2;
            this.pnlVideo.Left = x;
            this.pnlVideo.Top = y;
        }


        private void RenderVedio()
        {
            try
            {
                var hwnd = pnlVideo.Handle;
                if (_channel.IsVideo)
                {
                    switch (_channel.MediaType)
                    {
                        case MediaType.LOCAL:
                            {
                                var errno = WrapperProxy.AttachStreamWnd(MediaType.LOCAL, _channel.ChannelID,_channel.Call.CallHandle, hwnd,0,0, this.pnlVideo.Width, this.pnlVideo.Height - 40);
                                if (ErrorNumber.OK!=errno)
                                {
                                    log.Error("本地视频附加失败");
                                }
                            }
                            break;
                        case MediaType.REMOTE:
                            {
                                var errno = WrapperProxy.AttachStreamWnd(MediaType.REMOTE, _channel.ChannelID, _channel.Call.CallHandle, hwnd, 0, 0, this.pnlVideo.Width, this.pnlVideo.Height - 40);
                                if (ErrorNumber.OK != errno)
                                {
                                    log.Error("远程视频附加失败");
                                }
                            }
                            break;
                        case MediaType.CONTENT:
                            {
                                var errno = WrapperProxy.AttachStreamWnd(MediaType.CONTENT, _channel.ChannelID, _channel.Call.CallHandle, hwnd, 0, 0, this.pnlVideo.Width, this.pnlVideo.Height - 40);
                                if (ErrorNumber.OK != errno)
                                {
                                    log.Error("共享视频附加失败");
                                }
                            }
                            break;

                    }
                }
                else  //音频
                {
                    switch (_channel.MediaType)
                    {
                        case MediaType.LOCAL:
                            {
                                var errno = WrapperProxy.DetachStreamWnd(MediaType.LOCAL, _channel.ChannelID, _channel.Call.CallHandle);
                                if (ErrorNumber.OK != errno)
                                {
                                    log.Error("本地视频卸载失败");
                                }
                            }
                            break;
                        case MediaType.REMOTE:
                            {
                                var errno = WrapperProxy.DetachStreamWnd(MediaType.REMOTE, _channel.ChannelID, _channel.Call.CallHandle);
                                if (ErrorNumber.OK != errno)
                                {
                                    log.Error("远程视频卸载失败");
                                }
                            }
                            break;
                        case MediaType.CONTENT:
                            {
                                var errno = WrapperProxy.DetachStreamWnd(MediaType.CONTENT, _channel.ChannelID, _channel.Call.CallHandle);
                                if (ErrorNumber.OK != errno)
                                {
                                    log.Error("共享视频卸载失败");
                                }
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}

