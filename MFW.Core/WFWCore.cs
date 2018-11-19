using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFW.Core
{
    public class MFWCore
    {
        #region Callback        
        private static AddEventCallback addEventCallback = new AddEventCallback(AddEventCallbackF);
        private static DispatchEventsCallback dispatchEventsCallback = new DispatchEventsCallback(DispatchEventsCallbackF);
        private static AddLogCallback addLogCallback = new AddLogCallback(AddLogCallbackF);
        private static AddDeviceCallback addDeviceCallback = new AddDeviceCallback(AddDeviceCallbackF);
        private static DisplayMediaStatisticsCallback displayMediaStatisticsCallback = new DisplayMediaStatisticsCallback(DisplayMediaStatisticsCallbackF);
        private static DisplayCallStatisticsCallback displayCallStatisticsCallback = new DisplayCallStatisticsCallback(DisplayCallStatisticsCallbackF);
        private static DisplayCodecCapabilities displayCodecCapabilities = new DisplayCodecCapabilities(DisplayCodecCapabilitiesF);
        private static AddAppCallback addAppCallback = new AddAppCallback(AddAppCallbackF);

        public static void AddEventCallbackF(IntPtr eventHandle, int callHandle, IntPtr placeId, int eventType, IntPtr callerName,
                IntPtr calleeName, int userCode, IntPtr reason, int wndWidth, int wndHeight, bool plugDeviceStatus, IntPtr plugDeviceName, IntPtr deviceHandle, IntPtr ipAddress, int callMode,
                int streamId, int activeSpeakerStreamId, int remoteVideoChannelNum, IntPtr remoteChannelDisplayName, bool isActiveSpeaker, int isTalkingFlag, IntPtr regID, IntPtr sipCallId, IntPtr version, IntPtr serialNumber, IntPtr notBefore, IntPtr notAfter,
                IntPtr issuer, IntPtr subject, IntPtr signatureAlgorithm, IntPtr fingerPrintAlgorithm, IntPtr fingerPrint, IntPtr publickey, IntPtr basicContraints, IntPtr keyUsage, IntPtr rxtendedKeyUsage,
                IntPtr subjectAlternateNames, IntPtr pemCert, bool isCertHostNameOK, int certFailReason, int certConfirmId, IntPtr transcoderTaskId, IntPtr transcoderInputFileName, int iceStatus, IntPtr sutLiteMessage, bool isVideoOK, IntPtr mediaIPAddr, int discoveryStatus)
        {
            // add Event to EventMonitor
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
            eventMonitor.AddEvent(evt);
        }

        public static void DispatchEventsCallbackF()
        {
            // tell EventMonitor to dispatch Event
            eventMonitor.DispatchEvents();
        }

        public static void AddLogCallbackF(ulong timestamp, bool expired, int funclevel, ulong pid, ulong tid, IntPtr lev, IntPtr comp, IntPtr msg, int len)
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

            for (int i = 0; i < funclevel; i++)
            {
                output += "--";
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

        public static void AddAppCallbackF(IntPtr appHandle, IntPtr appNamePtr)
        {
            var appName = IntPtrHelper.IntPtrTostring(appNamePtr);
            Device device = null;
            string resultDeviceName = appName;
            device = new Device(DeviceTypeEnum.APPLICATIONS, null, resultDeviceName, appHandle);
            deviceManager.AddApp(device);/*add device to device manger's hash table*/
            log.Info("application name is " + device.DeviceName);
            // lalProperties.displayProperty(PropertyEnum.APPLICATIONS, device.getDeviceName());
        }


        public static void AddDeviceCallbackF(int deviceType, IntPtr deviceHandlePtr, IntPtr deviceNamePtr)
        {
            var deviceHandle = IntPtrHelper.IntPtrToUTF8string(deviceHandlePtr);
            var deviceName = IntPtrHelper.IntPtrToUTF8string(deviceNamePtr);
            log.Info("AddDeviceCallback: deviceType:" + deviceType + "  deviceHandle:" + deviceHandle + "  deviceName:" + deviceName);
            Device device = null;
            string resultDeviceName = deviceName + "(" + deviceManager.GetDeviceCount() + ")";
            device = new Device((DeviceTypeEnum)deviceType, deviceHandle, resultDeviceName, IntPtr.Zero);
            if (null != device)
            {
                deviceManager.AddDevice(device);/*add device to device manger's hash table*/
            }
            else
            {
                log.Error("add a null device");
            }
        }


        public static void DisplayMediaStatisticsCallbackF(IntPtr channelNamePtr, IntPtr strParticipantNamePtr, IntPtr remoteSystemIdPtr, IntPtr callRatePtr, IntPtr packetsLostPtr, IntPtr packetLossPtr,
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
        public static void DisplayCallStatisticsCallbackF(int timeInLastCall, int totalTime, int callPlaced, int callReceived, int callConnected)
        {
            /*
            CallStatistics callStatistics = new CallStatistics(timeInLastCall, totalTime, callPlaced, callReceived, callConnected);
            callStatisticsDisplay.displayCallStatistics(callStatistics);
            */
        }

        public static void DisplayCodecCapabilitiesF(IntPtr typePtr, IntPtr codecNamePtr)
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

        public static void Init()
        {

        }
    }
}
