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
using System.Collections.Specialized;

namespace MFW.Core
{
    public partial class CallView : UserControl
    {
        #region Field
        private ILog log = LogManager.GetLogger("MFW.CallView");
        private static DeviceManager deviceManager = DeviceManager.GetInstance();
        private static PropertyManager propertyManager = PropertyManager.GetInstance();
        private Call _currentCall=null;
        private Dictionary<Channel, ChannelView> channelViews = new Dictionary<Channel, ChannelView>();
        private Panel ownerPnl;
        private Channel localChannel;
        private Channel contentChannel;
        #endregion
        #region Constructors
        public CallView(Panel owner)
        {
            InitializeComponent();
            owner.Controls.Add(this);
            ownerPnl = owner;

            this.Dock = DockStyle.Fill;
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            MFWCore.InternalMFWEvent += MFWEventHandle;
        }
        #endregion

        #region Properties
        #endregion

        #region MFWEvent
        private void MFWEventHandle(Event evt)
        {
            switch (evt.EventType)
            {
                #region Register
                case EventType.UNKNOWN: break;
                case EventType.SIP_REGISTER_SUCCESS: break;
                case EventType.SIP_REGISTER_FAILURE:
                    {
                        UXMessageMask.ShowMessage(ownerPnl, false, "注册失败", MessageBoxButtonsType.None, MessageBoxIcon.Error);
                    }
                    break;
                case EventType.SIP_REGISTER_UNREGISTERED:
                    {
                        UXMessageMask.ShowMessage(ownerPnl, false, "未注册", MessageBoxButtonsType.None, MessageBoxIcon.Error);
                    }
                    break;
                #endregion
                #region Call
                case EventType.SIP_CALL_INCOMING:
                    {
                        var msg = string.Format("【{0}】呼入中，是否接听？", evt.CallerName);

                        var callStateText = GetCallStateText(_currentCall, true);
                        if (!string.IsNullOrEmpty(callStateText))
                        {
                            msg += '\n' + callStateText;
                            msg += '\n' + "接听将挂断当前通话。";
                        }
                        Action answerAction = () =>
                        {
                            log.Info(string.Format("接听呼叫{0}", evt.CallerName));
                            if (!string.IsNullOrEmpty(callStateText))
                            {
                                log.Info(string.Format("挂断呼叫{0}", _currentCall.CallName));
                                WrapperProxy.TerminateCall(_currentCall.CallHandle);
                            }
                            var call = new Call(evt.CallHandle)
                            {
                                CallName = evt.CallerName,
                                CallMode = evt.CallMode,
                                CallState = CallState.SIP_INCOMING_INVITE
                            };
                            evt.Call = call;
                            localChannel = new Channel(evt.Call, 0, MediaType.LOCAL, false);
                            evt.Call.AddChannel(localChannel);
                            SetCurrentCall(call);
                        };
                        Action hangupAction = () =>
                        {
                            log.Info(string.Format("不接听呼叫{0}", evt.CallerName));
                            WrapperProxy.TerminateCall(evt.CallHandle);
                        };
                        UXMessageMask.ShowMessage(ownerPnl, true, msg, MessageBoxButtonsType.AnswerHangup, MessageBoxIcon.Question
                                                    , answerAction, hangupAction);

                    }
                    break;
                case EventType.SIP_CALL_TRYING:
                    {
                        var callStateText = GetCallStateText(_currentCall, true);
                        if (!string.IsNullOrEmpty(callStateText))
                        {
                            log.Info(string.Format("挂断呼叫{0}", _currentCall.CallName));
                            WrapperProxy.TerminateCall(_currentCall.CallHandle);
                        }
                        var call = new Call(evt.CallHandle)
                        {
                            CallName = evt.CallerName,
                            CallMode = evt.CallMode,
                            CallState = CallState.SIP_INCOMING_INVITE
                        };
                        evt.Call = call;
                        localChannel = new Channel(evt.Call, 0, MediaType.LOCAL, false);
                        evt.Call.AddChannel(localChannel);
                        SetCurrentCall(call);
                        var msg = string.Format("尝试呼出【{0}】中...", evt.CallerName);

                        Action hangupAction = () =>
                        {
                            log.Info(string.Format("挂断呼叫{0}", evt.CallerName));
                            WrapperProxy.TerminateCall(evt.CallHandle);
                        };
                        UXMessageMask.ShowMessage(ownerPnl, false, msg, MessageBoxButtonsType.Hangup, MessageBoxIcon.Question
                                                    , hangupAction);

                    }
                    break;
                case EventType.SIP_CALL_RINGING:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        evt.Call.CallState = CallState.SIP_OUTGOING_RINGING;
                        var msg = string.Format("呼出【{0}】响铃中...", evt.Call.CallName);

                        Action hangupAction = () =>
                        {
                            log.Info(string.Format("挂断呼叫{0}", evt.CallerName));
                            WrapperProxy.TerminateCall(evt.CallHandle);
                        };
                        UXMessageMask.ShowMessage(ownerPnl, false, msg, MessageBoxButtonsType.Hangup, MessageBoxIcon.Information
                                                    , hangupAction);
                    }
                    break;
                case EventType.SIP_CALL_FAILURE:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        evt.Call.CallState = CallState.SIP_OUTGOING_FAILURE;
                        evt.Call.Reason = string.IsNullOrEmpty(evt.Reason) ? "unknown reason" : evt.Reason;
                        var msg = string.Format("呼出【{0}】失败,原因:{1}", evt.Call.CallName, evt.Call.Reason);
                        log.Info(msg);
                        UXMessageMask.ShowMessage(ownerPnl, false, msg, MessageBoxButtonsType.None, MessageBoxIcon.Error);
                        evt.Call.CallState = CallState.SIP_OUTGOING_FAILURE;
                    }
                    break;
                case EventType.SIP_CALL_CLOSED:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        evt.Call.Reason = string.IsNullOrEmpty(evt.Reason) ? "unknown reason" : evt.Reason;
                        var msg = string.Format("呼出【{0}】关闭,原因:{1}", evt.Call.CallName, evt.Call.Reason);
                        log.Info(msg);
                        UXMessageMask.ShowMessage(ownerPnl, false, msg, MessageBoxButtonsType.None, MessageBoxIcon.Information);
                        evt.Call.CallState = CallState.SIP_CALL_CLOSED;
                    }
                    break;
                case EventType.SIP_CALL_HOLD:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        var msg = string.Format("呼叫【{0}】中断保持，是否需要恢复通话？", evt.Call.CallName);
                        var yesAction = new Action(() =>
                        {
                            log.Info(string.Format("呼叫【{0}】中断恢复", evt.Call.CallName));
                            var errno = WrapperProxy.ResumeCall(evt.Call.CallHandle);
                            if (errno != ErrorNumber.OK)
                            {
                                UXMessageMask.ShowMessage(ownerPnl, false, "恢复通话失败！", MessageBoxButtonsType.OK, MessageBoxIcon.Error);
                            }
                        });
                        Action noAction = () =>
                        {
                            log.Info(string.Format("挂断呼叫{0}", evt.CallerName));
                            WrapperProxy.TerminateCall(evt.CallHandle);
                        };
                        UXMessageMask.ShowMessage(ownerPnl, false, msg, MessageBoxButtonsType.YesNoCancel, MessageBoxIcon.Question
                            , yesAction, noAction);
                        evt.Call.CallState = CallState.SIP_CALL_HOLD;
                    }
                    break;
                case EventType.SIP_CALL_HELD:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        var msg = string.Format("呼叫【{0}】被保持", evt.Call.CallName);
                        Action hangupAction = () =>
                        {
                            log.Info(string.Format("挂断呼叫{0}", evt.CallerName));
                            WrapperProxy.TerminateCall(evt.CallHandle);
                        };
                        UXMessageMask.ShowMessage(ownerPnl, false, msg, MessageBoxButtonsType.Hangup, MessageBoxIcon.Information, hangupAction);
                        evt.Call.CallState = CallState.SIP_CALL_HELD;
                    }
                    break;
                case EventType.SIP_CALL_DOUBLE_HOLD:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        var msg = string.Format("呼叫【{0}】双方中断保持，是否需要恢复通话？", evt.Call.CallName);
                        var yesAction = new Action(() =>
                        {
                            log.Info(string.Format("呼叫【{0}】中断恢复", evt.Call.CallName));
                            var errno = WrapperProxy.ResumeCall(evt.Call.CallHandle);
                            if (errno != ErrorNumber.OK)
                            {
                                UXMessageMask.ShowMessage(ownerPnl, false, "恢复通话失败！", MessageBoxButtonsType.OK, MessageBoxIcon.Error);
                            }
                        });
                        Action noAction = () =>
                        {
                            log.Info(string.Format("挂断呼叫{0}", evt.CallerName));
                            WrapperProxy.TerminateCall(evt.CallHandle);
                        };
                        UXMessageMask.ShowMessage(ownerPnl, false, msg, MessageBoxButtonsType.YesNoCancel, MessageBoxIcon.Question
                            , yesAction, noAction);
                        evt.Call.CallState = CallState.SIP_CALL_DOUBLE_HOLD;
                    }
                    break;
                case EventType.SIP_CALL_UAS_CONNECTED:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        log.Info(string.Format("呼入{0}接听通话中", evt.Call.CallName));
                        evt.Call.CallState = CallState.SIP_INCOMING_CONNECTED;
                        UXMessageMask.HideMessage(ownerPnl);
                    }
                    break;
                case EventType.SIP_CALL_UAC_CONNECTED:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        log.Info(string.Format("呼出{0}接听通话中", evt.Call.CallName));
                        evt.Call.CallState = CallState.SIP_OUTGOING_CONNECTED;
                        UXMessageMask.HideMessage(ownerPnl);
                    }
                    break;
                #endregion
                #region Content
                case EventType.SIP_CONTENT_INCOMING:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        if (null != contentChannel)
                        {
                            evt.Call.RemoveChannel(contentChannel.ChannelID);
                        }
                        contentChannel = new Channel(evt.Call, evt.StreamId, MediaType.CONTENT);
                        evt.Call.AddChannel(contentChannel);
                        contentChannel.Size = new Size(evt.WndWidth, evt.WndHeight);
                    }
                    break;
                case EventType.SIP_CONTENT_CLOSED:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        if (null != contentChannel)
                        {
                            evt.Call.RemoveChannel(contentChannel.ChannelID);
                            contentChannel = null;
                        }
                    }
                    break;
                case EventType.SIP_CONTENT_SENDING:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                    }
                    break;
                case EventType.SIP_CONTENT_IDLE:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        evt.Call.IsContentSupported = true;
                    }
                    break;
                case EventType.SIP_CONTENT_UNSUPPORTED:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        evt.Call.IsContentSupported = false;
                    }
                    break;
                #endregion

                #region Device
                /*
                case EventType.DEVICE_VIDEOINPUTCHANGED:
                {
                    string deviceName = evt.PlugDeviceName;
                    string deviceHandle = evt.DeviceHandle;
                    if (string.IsNullOrWhiteSpace(deviceName)
                        || string.IsNullOrWhiteSpace(deviceHandle))
                    {
                        return;
                    }
                    if (true == evt.PlugDeviceStatus)
                    { 
                        var device = new Device(DeviceType.VIDEOINPUT, deviceHandle, deviceName);
                        deviceManager.AddDevice(device);
                    }
                    else
                    {
                        deviceManager.RemoveDevice(deviceHandle);
                    }
                }
                break;  
                case EventType.DEVICE_AUDIOINPUTCHANGED:
                {
                    string deviceName = evt.PlugDeviceName;
                    string deviceHandle = evt.DeviceHandle;
                    if (string.IsNullOrWhiteSpace(deviceName)
                        || string.IsNullOrWhiteSpace(deviceHandle))
                    {
                        return;
                    }
                    if (true == evt.PlugDeviceStatus)
                    {  
                        var device = new Device(DeviceType.AUDIOINPUT, deviceHandle, deviceName);
                        deviceManager.AddDevice(device);
                    }
                    else
                    {
                        deviceManager.RemoveDevice(deviceHandle);
                    }
                }
                break; 
                case EventType.DEVICE_AUDIOOUTPUTCHANGED:
                {
                    string deviceName = evt.PlugDeviceName;
                    string deviceHandle = evt.DeviceHandle;
                    if (string.IsNullOrWhiteSpace(deviceName)
                        || string.IsNullOrWhiteSpace(deviceHandle))
                    {
                        return;
                    }
                    if (true == evt.PlugDeviceStatus)
                    {  
                        var device = new Device(DeviceType.AUDIOOUTPUT, deviceHandle, deviceName);
                        deviceManager.AddDevice(device);
                    }
                    else
                    {
                        deviceManager.RemoveDevice(deviceHandle);
                    }
                }
                break; 
                case EventType.DEVICE_VOLUMECHANGED: break;  
                case EventType.DEVICE_MONITORINPUTSCHANGED:
                {
                    string deviceName = evt.PlugDeviceName;
                    string deviceHandle = evt.DeviceHandle;
                    if (string.IsNullOrWhiteSpace(deviceName)
                        || string.IsNullOrWhiteSpace(deviceHandle))
                    {
                        return;
                    }
                    if (true == evt.PlugDeviceStatus)
                    {  
                        var device = new Device(DeviceType.MONITOR, deviceHandle, deviceName);
                        deviceManager.AddDevice(device);
                    }
                    else
                    {
                        deviceManager.RemoveDevice(deviceHandle);
                    }
                }
                break;  
                */
                #endregion

                #region Stream
                case EventType.STREAM_VIDEO_LOCAL_RESOLUTIONCHANGED:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        localChannel.Size = new Size(evt.WndWidth, evt.WndHeight);
                    }
                    break;
                case EventType.STREAM_VIDEO_REMOTE_RESOLUTIONCHANGED:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        var channel = evt.Call.GetChannel(evt.StreamId);
                        if (null != channel)
                        {
                            channel.Size = new Size(evt.WndWidth, evt.WndHeight);
                        }
                    }
                    break;
                #endregion

                case EventType.NETWORK_CHANGED: break;
                case EventType.MFW_INTERNAL_TIME_OUT: break;


                case EventType.REFRESH_ACTIVE_SPEAKER:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        evt.Call.ActiveSpeakerId = evt.ActiveSpeakerStreamId;
                    }
                    break;
                case EventType.REMOTE_VIDEO_REFRESH:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        evt.Call.CallName = evt.CallerName;
                        evt.Call.ClearRemoteChannels();
                        evt.Call.ChannelNumber = evt.RemoteVideoChannelNum;
                        evt.Call.ActiveSpeakerId = evt.ActiveSpeakerStreamId;

                    }
                    break;
                case EventType.REMOTE_VIDEO_CHANNELSTATUS_CHANGED:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        evt.Call.AddChannel(evt.StreamId, MediaType.REMOTE);
                        if (evt.IsActiveSpeaker)
                        {
                            evt.Call.ActiveSpeakerId = evt.StreamId;
                        }
                    }
                    break;
                case EventType.REMOTE_VIDEO_DISPLAYNAME_UPDATE:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        evt.Call.SetChannelName(evt.StreamId, evt.RemoteChannelDisplayName);
                    }
                    break;
                case EventType.SIP_CALL_MODE_CHANGED:
                    {
                        if (null == _currentCall || evt.CallHandle != _currentCall.CallHandle)
                        {
                            return;
                        }
                        evt.Call = _currentCall;
                        evt.Call.CallMode = evt.CallMode;
                        if (evt.CallMode == CallMode.AUDIOVIDEO_CALL)
                        {
                            evt.Call.IsAudioOnly = false;
                        }
                        else
                        {
                            evt.Call.IsAudioOnly = true;
                            evt.Call.IsContentSupported = false;
                        }
                    }
                    break;

                case EventType.SIP_CALL_MODE_UPGRADE_REQ: break;
                case EventType.IS_TALKING_STATUS_CHANGED: break;
                case EventType.CERTIFICATE_VERIFY: break;
                case EventType.TRANSCODER_FINISH: break;
                case EventType.ICE_STATUS_CHANGED: break;
                case EventType.SUTLITE_INCOMING_CALL: break;
                case EventType.SUTLITE_TERMINATE_CALL: break;
                case EventType.NOT_SUPPORT_VIDEOCODEC: break;

                case EventType.BANDWIDTH_LIMITATION: break;
                case EventType.MEDIA_ADDRESS_UPDATED: break;
                case EventType.AUTODISCOVERY_STATUS_CHANGED: break;
            }
        }
        #endregion

        private string GetCallStateText(Call call,bool isActive=false)
        {
            var msg = string.Empty;
            if (null != call)
            {
                switch (_currentCall.CallState)
                {
                    case CallState.SIP_UNKNOWN:
                    case CallState.NULL_CALL:
                        break;
                    case CallState.SIP_OUTGOING_FAILURE:
                        {
                            if (!isActive)
                            {
                                msg = string.Format("【{0}】呼出失败", _currentCall.CallName);
                            }
                        }
                        break;
                    case CallState.SIP_CALL_CLOSED:
                        {
                            if (!isActive)
                            {
                                msg = string.Format("【{0}】呼出关闭", _currentCall.CallName);
                            }
                        }
                        break;
                    case CallState.SIP_INCOMING_INVITE:
                        msg = string.Format("【{0}】正在呼入响铃中", _currentCall.CallName);
                        break;
                    case CallState.SIP_INCOMING_CONNECTED:
                        msg = string.Format("【{0}】正在呼入通话中", _currentCall.CallName);
                        break;
                    case CallState.SIP_CALL_HOLD:
                        msg = string.Format("【{0}】正在主动保持连接中", _currentCall.CallName);
                        break;
                    case CallState.SIP_CALL_HELD:
                        msg = string.Format("【{0}】正在被动保持连接中", _currentCall.CallName);
                        break;
                    case CallState.SIP_CALL_DOUBLE_HOLD:
                        msg = string.Format("【{0}】正在双方保持连接中", _currentCall.CallName);
                        break;
                    case CallState.SIP_OUTGOING_TRYING:
                        msg = string.Format("【{0}】正在尝试呼出中", _currentCall.CallName);
                        break;
                    case CallState.SIP_OUTGOING_RINGING:
                        msg = string.Format("【{0}】正在呼出响铃中", _currentCall.CallName);
                        break;
                    case CallState.SIP_OUTGOING_CONNECTED:
                        msg = string.Format("【{0}】正在呼出通话中", _currentCall.CallName);
                        break;
                }
            }
            return msg;
        }

        #region SetCall
        private void SetCurrentCall(Call call)
        {
            if(null != _currentCall)
            {

            }
            this.Controls.Clear();
            _currentCall = call;
            if(null != _currentCall)
            {
                _currentCall.PropertyChanged += OnCallPropertyChangedHandle;
                _currentCall.Channels.CollectionChanged += OnChannelsCllectionChangedHandle;
            }
        }
        #region CallBack
        private void OnCallPropertyChangedHandle(object sender, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
                case "CallHandle":break;
                case "CallName":break;
                case "CallState":break;
                case "CurrentChannel": 
                    {
                        ViewRender();
                    }
                    break;                
            }

        }
        private void OnChannelsCllectionChangedHandle(object sender, NotifyCollectionChangedEventArgs args)
        {
            #region ChannelView
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        foreach (var item in args.NewItems)
                        {
                            var channel = item as Channel;
                            if (null != channel)
                            {
                                var channelView = new ChannelView(channel);
                                channelViews.Add(channel, channelView);
                                this.Controls.Add(channelView);
                                switch(channel.MediaType)
                                {
                                    case MediaType.LOCAL: localChannel = channel;break;
                                    case MediaType.CONTENT:contentChannel = channel;break;
                                }
                            }
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    {
                        foreach (var item in args.OldItems)
                        {
                            var channel = item as Channel;
                            if (channelViews.ContainsKey(channel))
                            {
                                var channelView = channelViews[channel];
                                if (null != channelView)
                                {
                                    this.Controls.Remove(channelView);
                                    channelView.Dispose();
                                }
                                channelViews.Remove(channel);
                                switch (channel.MediaType)
                                {
                                    case MediaType.LOCAL: localChannel = null; break;
                                    case MediaType.CONTENT: contentChannel = null; break;
                                }
                            }
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Reset: break;
                case NotifyCollectionChangedAction.Move: break;
                case NotifyCollectionChangedAction.Replace: break;
            }
            #endregion

            ViewRender();
        }
        #endregion

        #endregion

        #region View Render
        private void ViewRender()
        {
            if (null == _currentCall || channelViews.Count <= 0)
            {
                return;
            }
            var layoutType = propertyManager.GetProperty(PropertyKey.LayoutType);

            var viewWidth = this.Width;
            var viewHeight = this.Height;
            var ratioWidth = 320;
            var ratioHeight = 240;
            var cellWidth = ratioWidth;
            var cellHeight = ratioHeight;

            var cols = viewWidth / cellWidth;
            var rows = viewHeight / cellHeight;

            var activeChannel = contentChannel;
            #region ActiveChannel
            if(null== activeChannel)
            {
                activeChannel = contentChannel;
            }
            if(null == activeChannel)
            {
                activeChannel = _currentCall.Channels.FirstOrDefault();
            }
            if(null == activeChannel)
            {
                return;
            }
            #endregion

            switch (layoutType)
            {
                case "VAS":
                    {
                        #region VAS
                        var activeView = channelViews.Where(cv => cv.Key == activeChannel).Select(cv => cv.Value).FirstOrDefault();
                        if (null != activeView)
                        {
                            activeView.Location = new Point(0, 0);
                            activeView.Size = new Size(viewWidth,viewHeight);
                            activeView.SendToBack();
                        }

                        LocateChannel(rows, cols, viewWidth, viewHeight,cellWidth,cellHeight
                            , channelViews.Where(cv => cv.Key != activeChannel).Select(cv => cv.Value).ToList());
                        #endregion
                    }
                    break;
                case "ContinuousPresence":
                    {
                        #region ContinuousPresence
                        var cRows =0;
                        var cCols = 0;
                        if (rows <= cols)
                        {
                            switch (channelViews.Count)
                            {
                                case 0: cRows = 0; cCols = 0; break;
                                case 1: cRows = 1; cCols = 1; break;
                                case 2: cRows = 1; cCols = 2; break;
                                case 3: cRows = 2; cCols = 2; break;
                                case 4: cRows = 2; cCols = 2; break;
                                case 5: cRows = 2; cCols = 3; break;
                                case 6: cRows = 2; cCols = 3; break;
                                case 7: cRows = 3; cCols = 3; break;
                                case 8: cRows = 3; cCols = 3; break;
                                case 9: cRows = 3; cCols = 3; break;
                                case 10: cRows = 3; cCols = 4; break;
                                case 11: cRows = 3; cCols = 4; break;
                                case 12: cRows = 3; cCols = 4; break;
                                case 13: cRows = 4; cCols = 4; break;
                                case 14: cRows = 4; cCols = 4; break;
                                case 15: cRows = 4; cCols = 4; break;
                                case 16: cRows = 4; cCols = 4; break;
                            }
                        }
                        else
                        {
                            switch (channelViews.Count)
                            {
                                case 0: cRows = 0; cCols = 0; break;
                                case 1: cRows = 1; cCols = 1; break;
                                case 2: cRows = 2; cCols = 1; break;
                                case 3: cRows = 2; cCols = 2; break;
                                case 4: cRows = 2; cCols = 2; break;
                                case 5: cRows = 3; cCols = 2; break;
                                case 6: cRows = 3; cCols = 2; break;
                                case 7: cRows = 3; cCols = 3; break;
                                case 8: cRows = 3; cCols = 3; break;
                                case 9: cRows = 3; cCols = 3; break;
                                case 10: cRows = 4; cCols = 3; break;
                                case 11: cRows = 4; cCols = 3; break;
                                case 12: cRows = 4; cCols = 3; break;
                                case 13: cRows = 4; cCols = 4; break;
                                case 14: cRows = 4; cCols = 4; break;
                                case 15: cRows = 4; cCols = 4; break;
                                case 16: cRows = 4; cCols = 4; break;
                            }
                        }
                        var x = 0;
                        int y = 0;
                        var i = 0;
                        var cWidth = viewWidth / cCols;
                        var cHeight = viewHeight / cRows;
                        foreach(var view in channelViews.Values)
                        {
                            view.Location = new Point(x, y);
                            view.Size = new Size(cWidth, cHeight);
                            view.BringToFront();
                            x = x + cellWidth;
                            i++;
                            if (i % 4 == 0)
                            {
                                x = 0;
                                y = y + cHeight;
                            }
                        }
                        #endregion
                    }
                    break;
                case "Presentation":
                    {
                        #region ContinuousPresence
                        var locate=LocateChannel(rows, cols, viewWidth, viewHeight, cellWidth, cellHeight
                            , channelViews.Where(cv => cv.Key != activeChannel).Select(cv => cv.Value).ToList());
                        var activeView = channelViews.Where(cv => cv.Key == activeChannel).Select(cv=>cv.Value).FirstOrDefault();
                        if(null != activeView)
                        {
                            activeView.Location = new Point(0, 0);
                            activeView.Size = new Size(locate.X, locate.Y);
                            activeView.BringToFront();
                        }
                        #endregion
                    }
                    break;
            }
        }
        private Point LocateChannel(int rows,int cols,int x,int y,int cellWidth,int cellHeight,IList<ChannelView> channelViews)
        {
            if(channelViews.Count<=0 || rows<=0 || cols<=0)
            {
                return new Point(x, y);
            }
            if(rows<=cols) 
            {
                if(channelViews.Count<= rows)
                {
                    var i = 0;
                    foreach(var view in channelViews)
                    {
                        i++;
                        view.Location = new Point(x-cellWidth,y-i*cellHeight);
                        view.Size = new Size(cellWidth, cellHeight);
                        view.BringToFront();
                    }
                    return new Point(x-cellWidth,y);
                }
                else if(channelViews.Count<= cols)
                {
                    var i = 0;
                    foreach (var view in channelViews)
                    {
                        i++;
                        view.Location = new Point(x - i*cellWidth, y - cellHeight);
                        view.Size = new Size(cellWidth, cellHeight);
                        view.BringToFront();
                    }
                    return new Point(x, y-cellHeight);
                }
                else if(channelViews.Count<cols+rows)
                {
                    var i = 0;
                    foreach (var view in channelViews)
                    {
                        i++;
                        var rowindex = 1;
                        var colIndex = 1;
                        if (i > rows)
                        {
                            colIndex = i-rows;
                            rowindex = 1;
                        }
                        else
                        {
                            colIndex = 1;
                            rowindex = i;
                        }
                        view.Location = new Point(x - colIndex * cellWidth, y - rowindex*cellHeight);
                        view.Size = new Size(cellWidth, cellHeight);
                        view.BringToFront();
                    }
                    return new Point(x-cellWidth, y - cellHeight);
                }
                else
                {
                   return LocateChannel(rows - 1, cols - 1, x - cellWidth, y - cellHeight, cellWidth, cellHeight, channelViews.Skip(rows + cols - 1).ToList());
                }
            }
            else
            {
                if (channelViews.Count <= cols)
                {
                    var i = 0;
                    foreach (var view in channelViews)
                    {
                        i++;
                        view.Location = new Point(x - i * cellWidth, y - cellHeight);
                        view.Size = new Size(cellWidth, cellHeight);
                        view.BringToFront();
                    }
                    return new Point(x, y - cellHeight);
                }
                else if (channelViews.Count <= rows)
                {
                    var i = 0;
                    foreach (var view in channelViews)
                    {
                        i++;
                        view.Location = new Point(x - cellWidth, y - i * cellHeight);
                        view.Size = new Size(cellWidth, cellHeight);
                        view.BringToFront();
                    }
                    return new Point(x - cellWidth, y);
                }
                else if (channelViews.Count < cols + rows)
                {
                    var i = 0;
                    foreach (var view in channelViews)
                    {
                        i++;
                        var rowindex = 1;
                        var colIndex = 1;
                        if (i > cols)
                        {
                            colIndex = 1;
                            rowindex = i-cols;
                        }
                        else
                        {
                            colIndex = i;
                            rowindex = 1;
                        }
                        view.Location = new Point(x - colIndex * cellWidth, y - rowindex * cellHeight);
                        view.Size = new Size(cellWidth, cellHeight);
                        view.BringToFront();
                    }
                    return new Point(x - cellWidth, y - cellHeight);
                }
                else
                {
                   return  LocateChannel(rows - 1, cols - 1, x - cellWidth, y - cellHeight, cellWidth, cellHeight, channelViews.Skip(rows + cols - 1).ToList());
                }
            }
        }
        #endregion
    }
}
