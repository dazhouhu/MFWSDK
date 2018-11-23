using log4net;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace MFW.Core
{
    public delegate void MFWEvent(Event evt);
    public sealed class MFWCore
    {
        #region Fields
        private static ILog log = LogManager.GetLogger("MFWCore");
        private static DeviceManager deviceManager = DeviceManager.GetInstance();
        private static PropertyManager propertyManager = PropertyManager.GetInstance();
        
        #endregion

        #region Constructors
        private static MFWCore instance = null;
        public static MFWCore GetInstance()
        {
            if (instance == null)
            {
                instance = new MFWCore();
            }
            return instance;
        }
        static MFWCore()
        {
            StartEventMonitor();

            var errno = ErrorNumber.OK;
            //注册回调函数
            errno = WrapperProxy.InstallCallback(addEventCallback, dispatchEventsCallback, addLogCallback, addDeviceCallback,
                    displayMediaStatisticsCallback, displayCallStatisticsCallback, displayCodecCapabilities, addAppCallback);
            if (ErrorNumber.OK != errno)
            {
                var errMsg = "Register callback functions failed. Error number = " + errno;
                log.Error(errMsg);
                throw new Exception(errMsg);
            }
            //预初始化
            errno = WrapperProxy.PreInitialize();
            if (ErrorNumber.OK != errno)
            {
                var msg = "Pre-initialization failed. Error number = " + errno.ToString();
                log.Error(msg);
                throw new Exception(msg);
            }
            //参数设定 KVList
            #region Default Properties
            var defaultProperties= new Dictionary<PropertyKey, string>()
            {
                {PropertyKey.PLCM_MFW_KVLIST_KEY_MINSYS,""},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_SIP_ProxyServer,""},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_SIP_Transport,"TCP"},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_SIP_ServerType,"standard"},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_SIP_Register_Expires_Interval,"300"},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_SIP_UserName,""},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_SIP_Domain,""},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_SIP_AuthorizationName,"soaktestuser"},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_SIP_Password,""},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_SIP_CookieHead,""},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_SIP_Base_Cred,""},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_SIP_AnonymousToken_Cred,"YWxpY2U6c2FtZXRpbWU="},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_SIP_Anonymous_Cred,"anonymous"},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_CallSettings_MaxCallNum,"6"},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_CallSettings_NetworkCallRate,"384"},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_CallSettings_AesEcription,"off"},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_CallSettings_DefaultAudioStartPort,"3230"},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_CallSettings_DefaultAudioEndPort,"3550"},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_CallSettings_DefaultVideoStartPort,"3230"},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_CallSettings_DefaultVideoEndPort,"3550"},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_CallSettings_SIPClientListeningPort,"5060"},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_CallSettings_SIPClientListeningTLSPort,"5061"},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_EnableSVC,"true"},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_LogLevel,"DEBUG"},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_User_Agent,"MFW_SDK"},
                {PropertyKey.PLCM_MFW_KVLIST_ICE_UserName,""},
                {PropertyKey.PLCM_MFW_KVLIST_ICE_Password,""},
                {PropertyKey.PLCM_MFW_KVLIST_ICE_TCPServer,"0.0.0.0:3478"},
                {PropertyKey.PLCM_MFW_KVLIST_ICE_UDPServer,"0.0.0.0:3478"},
                {PropertyKey.PLCM_MFW_KVLIST_ICE_TLSServer,"0.0.0.0:3478"},
                {PropertyKey.PLCM_MFW_KVLIST_ICE_Enable,"false"},
                {PropertyKey.PLCM_MFW_KVLIST_ICE_AUTHTOKEN_Enable,"false"},
                {PropertyKey.PLCM_MFW_KVLIST_ICE_INIT_AUTHTOKEN,""},
                {PropertyKey.PLCM_MFW_KVLIST_ICE_RTO,"100"},
                {PropertyKey.PLCM_MFW_KVLIST_ICE_RC,"7"},
                {PropertyKey.PLCM_MFW_KVLIST_ICE_RM,"16"},
                {PropertyKey.PLCM_MFW_KVLIST_QOS_ServiceType,""},
                {PropertyKey.PLCM_MFW_KVLIST_QOS_Audio,""},
                {PropertyKey.PLCM_MFW_KVLIST_QOS_Video,""},
                {PropertyKey.PLCM_MFW_KVLIST_QOS_Fecc,""},
                {PropertyKey.PLCM_MFW_KVLIST_QOS_Enable,"false"},
                {PropertyKey.PLCM_MFW_KVLIST_DBM_Enable,"false"},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_REG_ID,""},
                {PropertyKey.PLCM_MFW_KVLIST_LPR_Enable,"true"},
                {PropertyKey.PLCM_MFW_KVLIST_CERT_PATH,"./TLS Certificate/instance0/"},
                {PropertyKey.PLCM_MFW_KVLIST_CERT_CHECKFQDN,"false"},
                {PropertyKey.PLCM_MFW_KVLIST_HttpConnect_Enable,"false"},
                {PropertyKey.PLCM_MFW_KVLIST_SIP_HttpProxyServer,""},
                {PropertyKey.PLCM_MFW_KVLIST_SIP_HttpProxyPort,""},
                {PropertyKey.PLCM_MFW_KVLIST_SIP_HttpProxyUserName,""},
                {PropertyKey.PLCM_MFW_KVLIST_SIP_HttpPassword,""},
                {PropertyKey.PLCM_MFW_KVLIST_ICE_HttpProxyServer,""},
                {PropertyKey.PLCM_MFW_KVLIST_ICE_HttpProxyPort,""},
                {PropertyKey.PLCM_MFW_KVLIST_ICE_HttpProxyUserName,""},
                {PropertyKey.PLCM_MFW_KVLIST_ICE_HttpPassword,""},
                {PropertyKey.PLCM_MFW_KVLIST_MEDIA_HttpProxyServer,""},
                {PropertyKey.PLCM_MFW_KVLIST_MEDIA_HttpProxyPort,"80"},
                {PropertyKey.PLCM_MFW_KVLIST_MEDIA_HttpProxyUserName,""},
                {PropertyKey.PLCM_MFW_KVLIST_MEDIA_HttpPassword,""},
                {PropertyKey.PLCM_MFW_KVLIST_PRODUCT,"PLCM_MFW_IBM"},
                {PropertyKey.PLCM_MFW_KVLIST_AutoZoom_Enable,"false"},
                {PropertyKey.PLCM_MFW_KVLIST_TLSOffLoad_Enable,"false"},
                {PropertyKey.PLCM_MFW_KVLIST_TLSOffLoad_Host,""},
                {PropertyKey.PLCM_MFW_KVLIST_TLSOffLoad_Port,"0"},
                {PropertyKey.PLCM_MFW_KVLIST_HttpTunnel_Enable,"false"},
                {PropertyKey.PLCM_MFW_KVLIST_SIP_HttpTunnelProxyServer,""},
                {PropertyKey.PLCM_MFW_KVLIST_SIP_HttpTunnelProxyPort,"443"},
                {PropertyKey.PLCM_MFW_KVLIST_MEDIA_HttpTunnelProxyServer,""},
                {PropertyKey.PLCM_MFW_KVLIST_MEDIA_HttpTunnelProxyPort,"443"},
                {PropertyKey.PLCM_MFW_KVLIST_RTPMode,"RTP/AVP"},
                {PropertyKey.PLCM_MFW_KVLIST_TCPBFCPForced,"false"},
                {PropertyKey.PLCM_MFW_KVLIST_G729B_Enable,"false"},
                {PropertyKey.PLCM_MFW_KVLIST_SAML_Enable,"false"},
                {PropertyKey.PLCM_MFW_KVLIST_iLBCFrame,"30"},
                {PropertyKey.PLCM_MFW_KVLIST_BFCP_CONTENT_Enable,"true"},
                {PropertyKey.PLCM_MFW_KVLIST_SUPPORT_PORTRAIT_MODE,""},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_DisplayName,""},
                {PropertyKey.PLCM_MFW_KVLIST_FECC_Enable,"true"},
                {PropertyKey.PLCM_MFW_KVLIST_Comfortable_Noise_Enable,"true"},
                {PropertyKey.PLCM_MFW_KVLIST_SIP_Header_Compact_Enable,"false"},
                {PropertyKey.PLCM_MFW_KVLIST_KEY_MAXSYS,""},
                {PropertyKey.LocalAddr,""},
                {PropertyKey.CalleeAddr,""},
                {PropertyKey.AUDIO_INPUT_DEVICE,""},
                {PropertyKey.AUDIO_OUTPUT_DEVICE,""},
                {PropertyKey.AUDIO_OUTPUT_DEVICE_FOR_RINGTONE,""},
                {PropertyKey.VIDEO_INPUT_DEVICE,""},
                {PropertyKey.MONITOR_DEVICE,""},
                {PropertyKey.SOUND_INCOMING,"incoming.wav"},
                {PropertyKey.SOUND_CLOSED,"closed.wav"},
                {PropertyKey.SOUND_RINGING,"ringing.wav"},
                {PropertyKey.SOUND_HOLD,"hold.wav"},
                {PropertyKey.ICE_AUTH_TOKEN,""},
                {PropertyKey.LayoutType,"Presentation" }
            };
            #endregion

            propertyManager.SetProperties(defaultProperties);
            //初始化
            errno = WrapperProxy.Initialize();
            if (ErrorNumber.OK != errno)
            {
                var errMsg = "Initialize failed. Error number = " + errno;
                log.Error(errMsg);
                throw new Exception(errMsg);
            }
            var version = WrapperProxy.GetVersion();
            log.Info("**********************************************************************");
            log.Info("        PLCM MFW  App Initialized Successful ( version: " + version + " )");
            log.Info("**********************************************************************");

            //Get Devices
            var errNo = WrapperProxy.GetDevice(DeviceType.AUDIOINPUT);
            if (ErrorNumber.OK != errNo)
            {
                var errMsg = "Get audio input device failed. Error number = " + errNo;
                log.Error(errMsg);
                throw new Exception(errMsg);
            }
            errNo = WrapperProxy.GetDevice(DeviceType.VIDEOINPUT);
            if (ErrorNumber.OK != errNo)
            {
                var errMsg="Get video input device failed. Error number = " + errNo;
                log.Error(errMsg);
                throw new Exception(errMsg);
            }
            errNo = WrapperProxy.GetDevice(DeviceType.AUDIOOUTPUT);
            if (ErrorNumber.OK != errNo)
            {
                var errMsg = "Get audio output device failed. Error number = " + errNo;
                log.Error(errMsg);
                throw new Exception(errMsg);
            }
            errNo = WrapperProxy.GetDevice(DeviceType.MONITOR);
            if (ErrorNumber.OK != errNo)
            {
                var errMsg = "Get monitor device failed. Error number = " + errNo;
                log.Error(errMsg);
                throw new Exception(errMsg);
            }
        }
        #endregion

        #region Events
        public static event MFWEvent MFWEvent;
        internal static event MFWEvent InternalMFWEvent;
        #endregion

        #region Callback        
        private static AddEventCallback addEventCallback = new AddEventCallback(AddEventCallbackF);
         private static DispatchEventsCallback dispatchEventsCallback = new DispatchEventsCallback(DispatchEventsCallbackF);
         private static AddLogCallback addLogCallback = new AddLogCallback(AddLogCallbackF);
         private static AddDeviceCallback addDeviceCallback = new AddDeviceCallback(AddDeviceCallbackF);
         private static DisplayMediaStatisticsCallback displayMediaStatisticsCallback = new DisplayMediaStatisticsCallback(DisplayMediaStatisticsCallbackF);
         private static DisplayCallStatisticsCallback displayCallStatisticsCallback = new DisplayCallStatisticsCallback(DisplayCallStatisticsCallbackF);
         private static DisplayCodecCapabilities displayCodecCapabilities = new DisplayCodecCapabilities(DisplayCodecCapabilitiesF);
         private static AddAppCallback addAppCallback = new AddAppCallback(AddAppCallbackF);

        private static void AddEventCallbackF(IntPtr eventHandle, int callHandle, IntPtr placeId, int eventType, IntPtr callerName,
                 IntPtr calleeName, int userCode, IntPtr reason, int wndWidth, int wndHeight, bool plugDeviceStatus, IntPtr plugDeviceName, IntPtr deviceHandle, IntPtr ipAddress, int callMode,
                 int streamId, int activeSpeakerStreamId, int remoteVideoChannelNum, IntPtr remoteChannelDisplayName, bool isActiveSpeaker, int isTalkingFlag, IntPtr regID, IntPtr sipCallId, IntPtr version, IntPtr serialNumber, IntPtr notBefore, IntPtr notAfter,
                 IntPtr issuer, IntPtr subject, IntPtr signatureAlgorithm, IntPtr fingerPrintAlgorithm, IntPtr fingerPrint, IntPtr publickey, IntPtr basicContraints, IntPtr keyUsage, IntPtr rxtendedKeyUsage,
                 IntPtr subjectAlternateNames, IntPtr pemCert, bool isCertHostNameOK, int certFailReason, int certConfirmId, IntPtr transcoderTaskId, IntPtr transcoderInputFileName, int iceStatus, IntPtr sutLiteMessage, bool isVideoOK, IntPtr mediaIPAddr, int discoveryStatus)
         {
             var strplaceId = IntPtrHelper.IntPtrTostring(placeId);
             var strcallerName = IntPtrHelper.IntPtrTostring(callerName);
             var strcalleeName = IntPtrHelper.IntPtrTostring(calleeName);
             var strreason = IntPtrHelper.IntPtrTostring(reason);
             var strplugDeviceName = IntPtrHelper.IntPtrTostring(plugDeviceName);
             var strdeviceHandle = IntPtrHelper.IntPtrTostring(deviceHandle);
             var stripAddress = IntPtrHelper.IntPtrTostring(ipAddress);
             var strremoteChannelDisplayName = IntPtrHelper.IntPtrTostring(remoteChannelDisplayName);
             var strregID = IntPtrHelper.IntPtrTostring(regID);
             var strsipCallId = IntPtrHelper.IntPtrTostring(sipCallId);
             var strVersion = IntPtrHelper.IntPtrTostring(version);
             var strSerialNumber = IntPtrHelper.IntPtrTostring(serialNumber);
             var strNotBefore = IntPtrHelper.IntPtrTostring(notBefore);
             var strNotAfter = IntPtrHelper.IntPtrTostring(notAfter);
             var strIssuer = IntPtrHelper.IntPtrTostring(issuer);
             var strSubject = IntPtrHelper.IntPtrTostring(subject);
             var strSignatureAlgorithm = IntPtrHelper.IntPtrTostring(signatureAlgorithm);
             var strFingerPrintAlgorithm = IntPtrHelper.IntPtrTostring(fingerPrintAlgorithm);
             var strFingerPrint = IntPtrHelper.IntPtrTostring(fingerPrint);
             var strPublickey = IntPtrHelper.IntPtrTostring(publickey);
             var strBasicContraints = IntPtrHelper.IntPtrTostring(basicContraints);
             var strKeyUsage = IntPtrHelper.IntPtrTostring(keyUsage);
             var strExtendedKeyUsage = IntPtrHelper.IntPtrTostring(rxtendedKeyUsage);
             var strSubjectAlternateNames = IntPtrHelper.IntPtrTostring(subjectAlternateNames);
             var strPemCert = IntPtrHelper.IntPtrTostring(pemCert);
             var strtranscoderInputFileName = IntPtrHelper.IntPtrTostring(transcoderInputFileName);
             var strSUTLiteMessage = IntPtrHelper.IntPtrTostring(sutLiteMessage);
             var strMediaIPAddr = IntPtrHelper.IntPtrTostring(mediaIPAddr);
             Event evt = new Event(eventHandle, callHandle, strplaceId, (EventType)eventType, strcallerName,
                                 strcalleeName, userCode, strreason,
                                 wndWidth, wndHeight, plugDeviceStatus, strplugDeviceName, strdeviceHandle, stripAddress, (CallMode)callMode,
                                 streamId, activeSpeakerStreamId, remoteVideoChannelNum, strremoteChannelDisplayName, isActiveSpeaker, isTalkingFlag, strregID, strsipCallId,
                                 strVersion,
                                 strSerialNumber,
                                 strNotBefore,
                                 strNotAfter,
                                 strIssuer,
                                 strSubject,
                                 strSignatureAlgorithm,
                                 strFingerPrintAlgorithm,
                                 strFingerPrint,
                                 strPublickey,
                                 strBasicContraints,
                                 strKeyUsage,
                                 strExtendedKeyUsage,
                                 strSubjectAlternateNames,
                                 strPemCert,
                                 isCertHostNameOK,
                                 certFailReason,
                                 certConfirmId,
                                 transcoderTaskId,
                                 strtranscoderInputFileName,
                                 (ICEStatus)iceStatus,
                                 strSUTLiteMessage,
                                 isVideoOK,
                                 strMediaIPAddr,
                                 (AutoDiscoveryStatus)discoveryStatus);
            AddEvent(evt);
         }

        private static void DispatchEventsCallbackF()
         {
             DispatchEvents();
         }
        #region Events

        private static Queue<Event> queue = new Queue<Event>();
        private static AutoResetEvent autoEvent;
        private static object synObject = new object();
        private static bool isRunning = false;

        private static SynchronizationContext mainThreadSynContext;

        public static void StartEventMonitor()
        {
            autoEvent = new AutoResetEvent(false);
            isRunning = true;
            mainThreadSynContext=SynchronizationContext.Current;
            var thread = new Thread(() =>
            {
                while (isRunning)
                {
                    log.Info("handle the evt");
                    if (queue.Count <= 0)
                    {
                        lock (synObject)
                        {
                            log.Info("No evt, wait..");
                            autoEvent.WaitOne();
                        }
                    }
                    while (queue.Count > 0)
                    {
                        Event evt = null;
                        lock (synObject)
                        {
                            evt = queue.Dequeue();
                        }
                        // dispatch Event to proper modules
                        if (evt == null)
                        {
                            log.Error("Event is null!");
                            continue;
                        }
                        try
                        {
                            mainThreadSynContext.Post(new SendOrPostCallback(DoEvent), evt);

                        }
                        catch (Exception ex)
                        {
                            log.Error(ex.Message);
                        }
                        WrapperProxy.FreeEvent(evt.EventHandle);
                    }
                }
            });
            thread.Start();
        }
        public static void StopEventMonitor()
        {
            isRunning = false;
            DispatchEvents();
        }
        public static void DispatchEvents()
        {
            //lock (synObject)
            {
                log.Info("notify evt monitor to proceed the events");
                autoEvent.Set();
            }
        }
        public static void AddEvent(Event evt)
        {
            log.Info("addEvent, type is" + evt.EventType);
            //lock (synObject)
            {
                queue.Enqueue(evt);
                //autoEvent.Set();
            }
        }
        private static void DoEvent(object state)
        {
            var evt = state as Event;
            if(null == evt)
            {
                return;
            }
            log.Info(string.Format("EventType:{0},CallHandle:{1}",evt.EventType,evt.CallHandle));
            switch (evt.EventType)
            {
                #region Device
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
                        {   /*plug in a device*/
                            var device = new Device(DeviceType.VIDEOINPUT, deviceHandle, deviceName);
                            deviceManager.AddDevice(device);
                        }
                        else
                        {
                            deviceManager.RemoveDevice(deviceHandle);
                        }
                    }
                    break;   /* from MP */
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
                        {   /*plug in a device*/
                            var device = new Device(DeviceType.AUDIOINPUT, deviceHandle, deviceName);
                            deviceManager.AddDevice(device);
                        }
                        else
                        {
                            deviceManager.RemoveDevice(deviceHandle);
                        }
                    }
                    break;  /* from MP */
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
                        {   /*plug in a device*/
                            var device = new Device(DeviceType.AUDIOOUTPUT, deviceHandle, deviceName);
                            deviceManager.AddDevice(device);
                        }
                        else
                        {
                            deviceManager.RemoveDevice(deviceHandle);
                        }
                    }
                    break; /* from MP */
                case EventType.DEVICE_VOLUMECHANGED: break;  /* from MP */
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
                        {   /*plug in a device*/
                            var device = new Device(DeviceType.MONITOR, deviceHandle, deviceName);
                            deviceManager.AddDevice(device);
                        }
                        else
                        {
                            deviceManager.RemoveDevice(deviceHandle);
                        }
                    }
                    break;  /* from MP */
                    #endregion

                #region 不处理
                /*
                #region Register
                case EventType.UNKNOWN:break;
                case EventType.SIP_REGISTER_SUCCESS: break;
                case EventType.SIP_REGISTER_FAILURE: break;
                case EventType.SIP_REGISTER_UNREGISTERED:break;
                #endregion
                #region Call
                case EventType.SIP_CALL_INCOMING: break;
                case EventType.SIP_CALL_TRYING:break;
                case EventType.SIP_CALL_RINGING:break;
                case EventType.SIP_CALL_FAILURE:break;
                case EventType.SIP_CALL_CLOSED:break;
                case EventType.SIP_CALL_HOLD:break;
                case EventType.SIP_CALL_HELD:break;
                case EventType.SIP_CALL_DOUBLE_HOLD:break;
                case EventType.SIP_CALL_UAS_CONNECTED:break;
                case EventType.SIP_CALL_UAC_CONNECTED:break;
                #endregion
                #region Content
                case EventType.SIP_CONTENT_INCOMING:break;
                case EventType.SIP_CONTENT_CLOSED:break;
                case EventType.SIP_CONTENT_SENDING:break;
                case EventType.SIP_CONTENT_IDLE:break;
                case EventType.SIP_CONTENT_UNSUPPORTED:break;
                #endregion



                #region Stream
                case EventType.STREAM_VIDEO_LOCAL_RESOLUTIONCHANGED:break;
                case EventType.STREAM_VIDEO_REMOTE_RESOLUTIONCHANGED:break;
                #endregion

                case EventType.NETWORK_CHANGED: break;
                case EventType.MFW_INTERNAL_TIME_OUT: break;

                case EventType.REFRESH_ACTIVE_SPEAKER:break;
                case EventType.REMOTE_VIDEO_REFRESH:break;
                case EventType.REMOTE_VIDEO_CHANNELSTATUS_CHANGED:break;
                case EventType.REMOTE_VIDEO_DISPLAYNAME_UPDATE:break;
                case EventType.SIP_CALL_MODE_CHANGED:break;

                case EventType.SIP_CALL_MODE_UPGRADE_REQ:break;
                case EventType.IS_TALKING_STATUS_CHANGED:break;
                case EventType.CERTIFICATE_VERIFY:break;
                case EventType.TRANSCODER_FINISH:break;
                case EventType.ICE_STATUS_CHANGED:break;
                case EventType.SUTLITE_INCOMING_CALL:break;
                case EventType.SUTLITE_TERMINATE_CALL:break;
                case EventType.NOT_SUPPORT_VIDEOCODEC:break;

                case EventType.BANDWIDTH_LIMITATION:break;
                case EventType.MEDIA_ADDRESS_UPDATED:break;
                case EventType.AUTODISCOVERY_STATUS_CHANGED:break;
                */
                #endregion
            }

            InternalMFWEvent?.Invoke(evt);
            MFWEvent?.Invoke(evt);
        }
        #endregion


        private static void AddLogCallbackF(ulong timestamp, bool expired, int funclevel, ulong pid, ulong tid, IntPtr lev, IntPtr comp, IntPtr msg, int len)
         {
             var output = string.Empty;
             var level = IntPtrHelper.IntPtrToUTF8string(lev);
             var component = IntPtrHelper.IntPtrTostring(comp);
             var message = IntPtrHelper.IntPtrTostring(msg);
             if (string.IsNullOrEmpty(component))
             {
                 component = "wrapper";
             }
 
             output += string.Format("[PID:{0}][TID:{1}] ", pid, tid); ;
 
             for (int i = 0; i<funclevel; i++)
             {
                 output += "  ";
             }
             output += level.ToString();
 
             if (level == "DEBUG")
             {
                 log.Debug(output);
             }
             else if (level == "INFO")
             {
                 log.Info(output);
             }
             else if (level == "WARN")
             {
                 log.Warn(output);
             }
             else if (level == "ERROR")
             {
                 log.Error(output);
             }
             else
             {
                 log.Fatal(output);
             }
         }

        private static void AddAppCallbackF(IntPtr appHandle, IntPtr appNamePtr)
         {
             var appName = IntPtrHelper.IntPtrTostring(appNamePtr);
            log.Info("AddAppCallbackF: appHandle:" + appHandle + "  appName:" + appName);
            var device = new Device(DeviceType.APPLICATIONS, appHandle.ToString(), appName);
             deviceManager.AddDevice(device);
         }
 
 
         private static void AddDeviceCallbackF(int deviceType, IntPtr deviceHandlePtr, IntPtr deviceNamePtr)
         {
            if (deviceType < (int)DeviceType.APPLICATIONS)
            {
                var deviceHandle = IntPtrHelper.IntPtrToUTF8string(deviceHandlePtr);
                var deviceName = IntPtrHelper.IntPtrToUTF8string(deviceNamePtr);
                log.Info("AddDeviceCallback: deviceType:" + deviceType + "  deviceHandle:" + deviceHandle + "  deviceName:" + deviceName);
                var device = new Device((DeviceType)deviceType, deviceHandle, deviceName);
                deviceManager.AddDevice(device);
            }
            else
            {
                throw new Exception(string.Format("DeviceType:{0} 设备不支持",deviceType));
            }
        }


        private static void DisplayMediaStatisticsCallbackF(IntPtr channelNamePtr, IntPtr strParticipantNamePtr, IntPtr remoteSystemIdPtr, IntPtr callRatePtr, IntPtr packetsLostPtr, IntPtr packetLossPtr,
                 IntPtr videoProtocolPtr, IntPtr videoRatePtr, IntPtr videoRateUsedPtr, IntPtr videoFrameRatePtr, IntPtr videoPacketsLostPtr, IntPtr videoJitterPtr,
                 IntPtr videoFormatPtr, IntPtr errorConcealmentPtr, IntPtr audioProtocolPtr, IntPtr audioRatePtr, IntPtr audioPacketsLostPtr, IntPtr audioJitterPtr,
                 IntPtr audioEncryptPtr, IntPtr videoEncryptPtr, IntPtr feccEncryptPtr, IntPtr audioReceivedPacketPtr, IntPtr roundTripTimePtr,
                 IntPtr fullIntraFrameRequestPtr, IntPtr intraFrameSentPtr, IntPtr packetsCountPtr, IntPtr overallCPULoadPtr, IntPtr channelNumPtr)
         {
             var channelName = IntPtrHelper.IntPtrTostring(channelNamePtr);
             var strParticipantName = IntPtrHelper.IntPtrTostring(strParticipantNamePtr);
             var remoteSystemId = IntPtrHelper.IntPtrTostring(remoteSystemIdPtr);
             var callRate = IntPtrHelper.IntPtrTostring(callRatePtr);
             var packetsLost = IntPtrHelper.IntPtrTostring(packetsLostPtr);
             var packetLoss = IntPtrHelper.IntPtrTostring(packetLossPtr);
             var videoProtocol = IntPtrHelper.IntPtrTostring(videoProtocolPtr);
             var videoRate = IntPtrHelper.IntPtrTostring(videoRatePtr);
             var videoRateUsed = IntPtrHelper.IntPtrTostring(videoRateUsedPtr);
             var videoFrameRate = IntPtrHelper.IntPtrTostring(videoFrameRatePtr);
             var videoPacketsLost = IntPtrHelper.IntPtrTostring(videoPacketsLostPtr);
             var videoJitter = IntPtrHelper.IntPtrTostring(videoJitterPtr);
             var videoFormat = IntPtrHelper.IntPtrTostring(videoFormatPtr);
             var errorConcealment = IntPtrHelper.IntPtrTostring(errorConcealmentPtr);
             var audioProtocol = IntPtrHelper.IntPtrTostring(audioProtocolPtr);
             var audioRate = IntPtrHelper.IntPtrTostring(audioRatePtr);
             var audioPacketsLost = IntPtrHelper.IntPtrTostring(audioPacketsLostPtr);
             var audioJitter = IntPtrHelper.IntPtrTostring(audioJitterPtr);
             var audioEncrypt = IntPtrHelper.IntPtrTostring(audioEncryptPtr);
             var videoEncrypt = IntPtrHelper.IntPtrTostring(videoEncryptPtr);
             var feccEncrypt = IntPtrHelper.IntPtrTostring(feccEncryptPtr);
             var audioReceivedPacket = IntPtrHelper.IntPtrTostring(audioReceivedPacketPtr);
             var roundTripTime = IntPtrHelper.IntPtrTostring(roundTripTimePtr);
             var fullIntraFrameRequest = IntPtrHelper.IntPtrTostring(fullIntraFrameRequestPtr);
             var intraFrameSent = IntPtrHelper.IntPtrTostring(intraFrameSentPtr);
             var packetsCount = IntPtrHelper.IntPtrTostring(packetsCountPtr);
             var overallCPULoad = IntPtrHelper.IntPtrTostring(overallCPULoadPtr);
             var channelNum = IntPtrHelper.IntPtrTostring(channelNumPtr);
             /*
             MediaStatistics mediaStatistics = new MediaStatistics(new string[] { channelName, strParticipantName, remoteSystemId, callRate, packetsLost, packetLoss,
                     videoProtocol, videoRate, videoRateUsed, videoFrameRate, videoPacketsLost, videoJitter,
                     videoFormat, errorConcealment, audioProtocol, audioRate, audioPacketsLost, audioJitter,
                     audioEncrypt, videoEncrypt, feccEncrypt, audioReceivedPacket, roundTripTime, fullIntraFrameRequest, intraFrameSent, packetsCount, overallCPULoad, channelNum });
             log.Info("media channel number is " + mediaStatistics.getChannelNum());
             if (0 != mediaStatistics.getChannelNum())
             {
                 mediaStatisticsDisplay.displayMediaStatistics(mediaStatistics);
             }
             */
         }
        private static void DisplayCallStatisticsCallbackF(int timeInLastCall, int totalTime, int callPlaced, int callReceived, int callConnected)
         {
             /*
             CallStatistics callStatistics = new CallStatistics(timeInLastCall, totalTime, callPlaced, callReceived, callConnected);
             callStatisticsDisplay.displayCallStatistics(callStatistics);
             */
         }

        private static void DisplayCodecCapabilitiesF(IntPtr typePtr, IntPtr codecNamePtr)
         {
             /*
             var type = IntPtrHelper.IntPtrTostring(typePtr);
             var codecName = IntPtrHelper.IntPtrTostring(codecNamePtr);
             if (type == "audio")
             {
                 codecNameDisplay.displayAudioCodec(codecName);
             }
             else
             {
                 codecNameDisplay.displayVideoCodec(codecName);
             }
             */
         }
        #endregion

        #region 注册
        public static void Register(string sipServer, string username, string password, Panel owner,IDictionary<PropertyKey,string> properties=null)
        {
            #region Valid
            if(string.IsNullOrWhiteSpace(sipServer))
            {
                throw new Exception("服务地址必须");
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new Exception("用户名必须");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("密码必须");
            }
            if (null == owner)
            {
                throw new Exception("显示承载容器必须");
            }
            #endregion
            if (null!=properties)
            {
                propertyManager.SetProperties(properties);
            }
            var ps = new Dictionary<PropertyKey, string>()
            {
                { PropertyKey.PLCM_MFW_KVLIST_KEY_SIP_ProxyServer,sipServer },
                { PropertyKey.PLCM_MFW_KVLIST_KEY_SIP_UserName,username },
                { PropertyKey.PLCM_MFW_KVLIST_KEY_SIP_Password,password },
                { PropertyKey.PLCM_MFW_KVLIST_KEY_REG_ID, username + "@" + sipServer }
            };
            propertyManager.SetProperties(ps);
            var errno = WrapperProxy.UpdateConfig();
            if (errno != ErrorNumber.OK)
            {
                var errMsg = string.Format("配置失败, Errno={0}", errno);
                log.Error(errMsg);
                throw new Exception(errMsg);
            }
            errno =WrapperProxy.RegisterClient();
            if(errno != ErrorNumber.OK)
            {
                var errMsg = string.Format("Register failed, Errno={0}",errno);
                log.Error(errMsg);
                throw new Exception(errMsg);
            }
            new CallView(owner);
        }
        public static void Unregister()
        {
            WrapperProxy.UnregisterClient();
        }
        #endregion

        #region 呼叫
        public static void Dial(string callAddr, CallMode callMode)
        {
            log.Info("place call: callername:" + callAddr);
            int callHandleReference = 0;
            propertyManager.SetProperty(PropertyKey.CalleeAddr, callAddr);
            var errno = WrapperProxy.PlaceCall(callAddr, ref callHandleReference, callMode);
            if (errno != ErrorNumber.OK)
            {
                var errMsg = "Dial a Call failed. ErrorNum = " + errno;
                log.Error(errMsg);
                throw new Exception(errMsg);
            }
        }
        #endregion

        #region 析构函数
        /// <summary>
        /// 取消注册
        /// </summary>
        ~MFWCore()
        {
            WrapperProxy.UnregisterClient();
        }
        #endregion
    }
}
