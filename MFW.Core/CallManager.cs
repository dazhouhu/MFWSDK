using log4net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MFW.Core
{
    public class CallManager : BaseModel
    {
        #region Fields
        private ILog log = LogManager.GetLogger("MFW.CallManager");
        private static DeviceManager deviceManager = DeviceManager.GetInstance();
        private static PropertyManager propertyManager = PropertyManager.GetInstance();
        private static CallView callView = CallView.GetInstance();
        #endregion
        #region Constructors
        private static readonly object lockObj = new object();
        private static CallManager instance = new CallManager();
        private CallManager() {
            _callList.CollectionChanged += (sender, args) =>
            {
                CallsChanged?.Invoke(sender, args);
            };
            MFWCore.InternalMFWEvent += MFWEventHandle;
        }
        public static CallManager GetInstance()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new CallManager();
                    }
                }
            }
            return instance;
        }
        #endregion

        #region Properties
        private Call _currentCall;
        public Call CurrentCall
        {
            get { return _currentCall; }
            set
            {
                if(_currentCall !=value)
                {
                    _currentCall = value;
                    NotifyPropertyChanged("CurrentCall");
                }
            }
        }
        private ObservableCollection<Call> _callList = new ObservableCollection<Call>() { };
        public ObservableCollection<Call> CallList { get { return _callList; } }
        #endregion

        #region Events
        public event NotifyCollectionChangedEventHandler CallsChanged;
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
                        callView.ShowMessage( false, "注册失败", MessageBoxButtonsType.None, MessageBoxIcon.Error);
                    }
                    break;
                case EventType.SIP_REGISTER_UNREGISTERED:
                    {
                        callView.ShowMessage(false, "未注册", MessageBoxButtonsType.None, MessageBoxIcon.Error);
                    }
                    break;
                #endregion
                #region Call
                case EventType.SIP_CALL_INCOMING:
                    {
                        var call = new Call(evt.CallHandle)
                        {
                            CallName = evt.CallerName,
                            CallMode = evt.CallMode,
                            CallState = CallState.SIP_INCOMING_INVITE,
                            StartTime=DateTime.Now,
                            CallType= CallType.INCOMING
                        };
                        CallList.Add(call);

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
                            
                            evt.Call=call;
                            CurrentCall=call;
                            var localChannel = new Channel(call, 0, MediaType.LOCAL, false)
                            {
                                ChannelName = "本地视频"
                            };
                            call.AddChannel(localChannel);
                        };
                        Action hangupAction = () =>
                        {
                            log.Info(string.Format("不接听呼叫{0}", evt.CallerName));
                            WrapperProxy.TerminateCall(evt.CallHandle);
                        };
                        callView.ShowMessage(true, msg, MessageBoxButtonsType.AnswerHangup, MessageBoxIcon.Question
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
                            CallState = CallState.SIP_INCOMING_INVITE,
                            StartTime = DateTime.Now,
                            CallType = CallType.OUTGOING
                        };
                        CallList.Add(call);
                        evt.Call=call;
                        CurrentCall=call;
                        var localChannel = new Channel(call, 0, MediaType.LOCAL, false) {
                            ChannelName="本地视频"
                        };
                        call.AddChannel(localChannel);
                        var calleeName = evt.CalleeName;
                        if (string.IsNullOrWhiteSpace(evt.CalleeName))
                        {
                            calleeName = propertyManager.GetProperty(PropertyKey.CalleeAddr);
                        }
                        var msg = string.Format("尝试呼出【{0}】连接中...", calleeName);

                        Action hangupAction = () =>
                        {
                            log.Info(string.Format("挂断呼叫{0}", calleeName));
                            WrapperProxy.TerminateCall(evt.CallHandle);
                        };
                        callView.ShowMessage(false, msg, MessageBoxButtonsType.Hangup, MessageBoxIcon.Question
                                                    , hangupAction);

                    }
                    break;
                case EventType.SIP_CALL_RINGING:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        call.CallType = CallType.OUTGOING;
                        call.CallState = CallState.SIP_OUTGOING_RINGING;

                        if (call == CurrentCall)
                        {
                            var calleeName = evt.CalleeName;
                            if (string.IsNullOrWhiteSpace(evt.CalleeName))
                            {
                                calleeName = propertyManager.GetProperty(PropertyKey.CalleeAddr);
                            }
                            var msg = string.Format("呼出【{0}】响铃中...", calleeName);

                            Action hangupAction = () =>
                            {
                                log.Info(string.Format("挂断呼叫{0}", calleeName));
                                WrapperProxy.TerminateCall(evt.CallHandle);
                            };
                            callView.ShowMessage(false, msg, MessageBoxButtonsType.Hangup, MessageBoxIcon.Information
                                                        , hangupAction);
                        }
                    }
                    break;
                case EventType.SIP_CALL_FAILURE:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        call.StopTime = DateTime.Now;
                        call.CallType = CallType.OUTGOING;
                        call.CallState = CallState.SIP_OUTGOING_FAILURE;
                        call.Reason = string.IsNullOrEmpty(evt.Reason) ? "unknown reason" : evt.Reason;
                        if (call == CurrentCall)
                        {
                            var msg = string.Format("呼出【{0}】失败,原因:{1}", call.CallName, call.Reason);
                            log.Info(msg);
                            callView.ShowMessage(false, msg, MessageBoxButtonsType.None, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case EventType.SIP_CALL_CLOSED:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        call.Reason = string.IsNullOrEmpty(evt.Reason) ? "unknown reason" : evt.Reason;
                        call.UnconnectedTime = DateTime.Now;
                        call.StopTime = DateTime.Now;
                        call.CallState = CallState.SIP_CALL_CLOSED;

                        if (call == CurrentCall)
                        {
                            var msg = string.Format("呼出【{0}】关闭,原因:{1}", call.CallName, call.Reason);
                            log.Info(msg);
                            callView.ShowMessage(false, msg, MessageBoxButtonsType.None, MessageBoxIcon.Information);
                        }
                    }
                    break;
                case EventType.SIP_CALL_HOLD:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        call.CallState = CallState.SIP_CALL_HOLD;
                        if (call == CurrentCall)
                        {
                            var msg = string.Format("呼叫【{0}】中断保持，是否需要恢复通话？", call.CallName);
                            var yesAction = new Action(() =>
                            {
                                log.Info(string.Format("呼叫【{0}】中断恢复", call.CallName));
                                var errno = WrapperProxy.ResumeCall(call.CallHandle);
                                if (errno != ErrorNumber.OK)
                                {
                                    callView.ShowMessage(false, "恢复通话失败！", MessageBoxButtonsType.OK, MessageBoxIcon.Error);
                                }
                            });
                            Action noAction = () =>
                            {
                                log.Info(string.Format("挂断呼叫{0}", evt.CallerName));
                                WrapperProxy.TerminateCall(evt.CallHandle);
                            };
                            callView.ShowMessage(false, msg, MessageBoxButtonsType.YesNoCancel, MessageBoxIcon.Question
                                , yesAction, noAction);
                        }
                    }
                    break;
                case EventType.SIP_CALL_HELD:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        call.CallState = CallState.SIP_CALL_HELD;
                        if (call == CurrentCall)
                        {
                            var msg = string.Format("呼叫【{0}】被保持", call.CallName);
                            Action hangupAction = () =>
                            {
                                log.Info(string.Format("挂断呼叫{0}", evt.CallerName));
                                WrapperProxy.TerminateCall(evt.CallHandle);
                            };
                            callView.ShowMessage(false, msg, MessageBoxButtonsType.Hangup, MessageBoxIcon.Information, hangupAction);
                        }
                    }
                    break;
                case EventType.SIP_CALL_DOUBLE_HOLD:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        call.CallState = CallState.SIP_CALL_DOUBLE_HOLD;
                        if (call == CurrentCall)
                        {
                            var msg = string.Format("呼叫【{0}】双方中断保持，是否需要恢复通话？", call.CallName);
                            var yesAction = new Action(() =>
                            {
                                log.Info(string.Format("呼叫【{0}】中断恢复", call.CallName));
                                var errno = WrapperProxy.ResumeCall(call.CallHandle);
                                if (errno != ErrorNumber.OK)
                                {
                                    callView.ShowMessage(false, "恢复通话失败！", MessageBoxButtonsType.OK, MessageBoxIcon.Error);
                                }
                            });
                            Action noAction = () =>
                            {
                                log.Info(string.Format("挂断呼叫{0}", evt.CallerName));
                                WrapperProxy.TerminateCall(evt.CallHandle);
                            };
                            callView.ShowMessage(false, msg, MessageBoxButtonsType.YesNoCancel, MessageBoxIcon.Question
                                , yesAction, noAction);
                        }
                    }
                    break;
                case EventType.SIP_CALL_UAS_CONNECTED:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        log.Info(string.Format("呼入{0}接听通话中", call.CallName));
                        call.ConnectedTime = DateTime.Now;
                        call.CallType = CallType.INCOMING;
                        call.CallState = CallState.SIP_INCOMING_CONNECTED;
                        if (call == CurrentCall)
                        {
                            callView.HideMessage();
                        }
                    }
                    break;
                case EventType.SIP_CALL_UAC_CONNECTED:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        log.Info(string.Format("呼出{0}接听通话中", call.CallName));
                        call.ConnectedTime = DateTime.Now;
                        call.CallType = CallType.OUTGOING;
                        call.CallState = CallState.SIP_OUTGOING_CONNECTED;
                        if (call == CurrentCall)
                        {
                            callView.HideMessage();
                        }
                    }
                    break;
                #endregion
                #region Content
                case EventType.SIP_CONTENT_INCOMING:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        var contentChannel = call.GetContentChannel();
                        if (null != contentChannel)
                        {
                            call.RemoveChannel(contentChannel.ChannelID);
                        }
                        contentChannel = new Channel(call, evt.StreamId, MediaType.CONTENT);
                        call.AddChannel(contentChannel);
                        contentChannel.Size = new Size(evt.WndWidth, evt.WndHeight);
                        contentChannel.IsVideo = true;
                    }
                    break;
                case EventType.SIP_CONTENT_CLOSED:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        var contentChannel = call.GetContentChannel();
                        if (null != contentChannel)
                        {
                            call.RemoveChannel(contentChannel.ChannelID);
                        }
                    }
                    break;
                case EventType.SIP_CONTENT_SENDING:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                    }
                    break;
                case EventType.SIP_CONTENT_IDLE:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        call.IsContentSupported = true;
                    }
                    break;
                case EventType.SIP_CONTENT_UNSUPPORTED:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        call.IsContentSupported = false;
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
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        var localChannel=call.GetLocalChannel();
                        if (null != localChannel)
                        {
                            localChannel.Size = new Size(evt.WndWidth, evt.WndHeight);
                            localChannel.IsVideo = true;
                        }
                        if (call == CurrentCall)
                        {
                            callView.HideMessage();
                        }
                    }
                    break;
                case EventType.STREAM_VIDEO_REMOTE_RESOLUTIONCHANGED:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        var channel = call.GetChannel(evt.StreamId);
                        if (null != channel)
                        {
                            channel.Size = new Size(evt.WndWidth, evt.WndHeight);
                            channel.IsVideo = true;
                        }
                        if (call == CurrentCall)
                        {
                            callView.HideMessage();
                        }
                    }
                    break;
                #endregion

                case EventType.NETWORK_CHANGED: break;
                case EventType.MFW_INTERNAL_TIME_OUT: break;


                case EventType.REFRESH_ACTIVE_SPEAKER:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        call.ActiveSpeakerId = evt.ActiveSpeakerStreamId;
                        if (call == CurrentCall)
                        {
                            callView.HideMessage();
                        }
                    }
                    break;
                case EventType.REMOTE_VIDEO_REFRESH:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        call.CallName = evt.CallerName;
                        call.ClearRemoteChannels();
                        call.ChannelNumber = evt.RemoteVideoChannelNum;
                        call.ActiveSpeakerId = evt.ActiveSpeakerStreamId;
                        if (call == CurrentCall)
                        {
                            callView.HideMessage();
                        }
                    }
                    break;
                case EventType.REMOTE_VIDEO_CHANNELSTATUS_CHANGED:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        call.AddChannel(evt.StreamId, MediaType.REMOTE);
                        if(call.ActiveSpeakerId<=0)
                        {
                            call.ActiveSpeakerId = evt.StreamId;
                        }
                        if (call == CurrentCall)
                        {
                            callView.HideMessage();
                        }
                    }
                    break;
                case EventType.REMOTE_VIDEO_DISPLAYNAME_UPDATE:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        call.SetChannelName(evt.StreamId, evt.RemoteChannelDisplayName);
                        if (call == CurrentCall)
                        {
                            callView.HideMessage();
                        }
                    }
                    break;
                case EventType.SIP_CALL_MODE_CHANGED:
                    {
                        var call = GetCall(evt.CallHandle, true,evt);
                        evt.Call=call;
                        call.CallMode = evt.CallMode;
                        if (evt.CallMode == CallMode.AUDIOVIDEO_CALL)
                        {
                            call.IsAudioOnly = false;
                        }
                        else
                        {
                            call.IsAudioOnly = true;
                            call.IsContentSupported = false;
                        }
                        if (call == CurrentCall)
                        {
                            callView.HideMessage();
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

        #region Get Call
        public Call GetCall(int callHandle, bool isCreate = false,Event evt=null)
        {
            var call =_callList.FirstOrDefault(c => c.CallHandle == callHandle);
            if (null == call)
            {
                if (isCreate)
                {
                    call = new Call(callHandle)
                    {
                        CallHandle = callHandle,
                        CallName = evt.CalleeName,
                        CallMode = evt.CallMode,
                        ActiveSpeakerId = evt.ActiveSpeakerStreamId,
                        NetworkIP = evt.IPAddress,
                        Reason = evt.Reason,
                        ChannelNumber = evt.RemoteVideoChannelNum,
                        CallState = CallState.SIP_UNKNOWN,
                        CallType = CallType.UNKNOWN,
                        StartTime = DateTime.Now,
                    };
                    CallList.Add(call);
                }
            }
            return call;
        }

        public IList<Call> GetActiveCalls()
        {
            return _callList.Where(c => c.CallState == CallState.SIP_OUTGOING_CONNECTED
                                    || c.CallState == CallState.SIP_INCOMING_CONNECTED).ToList();
        }
        public IList<Call> GetUnestablishedCalls()
        {
            return _callList.Where(c => c.CallState == CallState.SIP_UNKNOWN).ToList();
        }
        public IList<Call> GetHeldCalls()
        {
            return _callList.Where(c => c.CallState == CallState.SIP_CALL_HELD).ToList();
        }
        public IList<Call> GetIncomingCall()
        {
            return _callList.Where(c => c.CallState == CallState.SIP_INCOMING_INVITE).ToList();
        }

        public Call GetCallByName(string callDisplayName)
        {
            return _callList.Where(c => c.CallName == callDisplayName).FirstOrDefault();
        }

        #endregion
        public void AddCall(Call call)
        {
            if (call.CallHandle != -1)
            {
                var c = GetCall(call.CallHandle);
                if (null == c)
                {
                    _callList.Add(call);
                }
            }
        }
        public void RemoveCall(Call call)
        {
            if (Contains(call.CallHandle))
            {
                _callList.Remove(call);
                CurrentCall = _callList.FirstOrDefault();
            }
        }

        public void ClearCalls()
        {
            _callList.Clear();
        }

        public bool Contains(int callHandle)
        {
            return _callList.Any(c => c.CallHandle == callHandle);
        }

        public string GetCallStateText(Call call, bool isActive = false)
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

        #region Call Methods
        public void Hangup(Call call=null)
        {
            if(null == call)
            {
                call = CurrentCall;
            }
            if(null != call)
            {
               var errno= WrapperProxy.TerminateCall(call.CallHandle);
                if(ErrorNumber.OK != errno)
                {
                    log.Error("Hangup Failed,errno="+errno);
                }
            }
        }
        #endregion
    }
}

