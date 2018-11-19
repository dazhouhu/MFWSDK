using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFW.Core
{
    public class WrapperProxy
    {
        public static ErrorNumber FreeEvent(IntPtr evt)
        {
            return (ErrorNumber)WrapperInterface.freeEvent(evt);
        }
        public static ErrorNumber SetProperty(PropertyKey key, string value)
        {
            return (ErrorNumber)WrapperInterface.addProperty((int)key, value);
        }

        public static ErrorNumber InstallCallback(AddEventCallback addEvent, DispatchEventsCallback dispatchEvents, AddLogCallback addLog,
                                            AddDeviceCallback addDevice, DisplayMediaStatisticsCallback displayMediaStatistics, DisplayCallStatisticsCallback displayCallStatistics,
                                            DisplayCodecCapabilities displayCodecNamesCallback, AddAppCallback addAppCallback)
        {
            return (ErrorNumber)WrapperInterface.installCallback(addEvent, dispatchEvents, addLog, addDevice, displayMediaStatistics, displayCallStatistics, displayCodecNamesCallback, addAppCallback);
        }

        public static ErrorNumber PreInitialize()
        {
            return (ErrorNumber)WrapperInterface.preInitialize();
        }

        public static ErrorNumber Initialize()
        {
            return (ErrorNumber)WrapperInterface.initialize();
        }

        public static ErrorNumber SetAudioDevice(string micHandle, string speakerHandle)
        {
            return (ErrorNumber)WrapperInterface.setAudioDevice(micHandle, speakerHandle);
        }

        public static ErrorNumber SetAudioDeviceForRingtone(string speakerHandle)
        {
            return (ErrorNumber)WrapperInterface.setAudioDeviceForRingtone(speakerHandle);
        }

        public static ErrorNumber SetVideoDevice(string cameraHandle)
        {
            return (ErrorNumber)WrapperInterface.setVideoDevice(cameraHandle);
        }

        public static ErrorNumber PlaceCall(string callee, ref int callHandle, CallMode callMode)
        {
            return (ErrorNumber)WrapperInterface.placeCall(callee, ref callHandle, (int)callMode);
        }

        public static ErrorNumber TerminateCall(int callHandle)
        {
            return (ErrorNumber)WrapperInterface.terminateCall(callHandle);
        }

        public static ErrorNumber AnswerCall(int callHandle, CallMode callMode, string authToken,  string cryptoSuiteType, string srtpKey, bool sutLiteEnable)
        {
            return (ErrorNumber)WrapperInterface.answerCall(callHandle, (int)callMode, authToken, cryptoSuiteType, srtpKey, sutLiteEnable);
        }

        public static ErrorNumber RejectCall(int callHandle)
        {
            return (ErrorNumber)WrapperInterface.rejectCall(callHandle);
        }

        public static ErrorNumber AttachStreamWnd(MediaType mediaType, int streamId, int callHandle, IntPtr windowHandle, int x, int y, int width, int height)
        {
            return (ErrorNumber)WrapperInterface.setStreamInfo((int)mediaType, streamId, callHandle, windowHandle, x, y, width, height);
        }

        public static ErrorNumber DetachStreamWnd(MediaType mediaType, int streamId, int callHandle)
        {
            return (ErrorNumber)WrapperInterface.detachStreamWnd((int)mediaType, streamId, callHandle);
        }
        
        public static ErrorNumber HoldCall(int callHandle)
        {
            return (ErrorNumber)WrapperInterface.holdCall(callHandle);
        }

        public static ErrorNumber ResumeCall(int callHandle)
        {
            return (ErrorNumber)WrapperInterface.resumeCall(callHandle);
        }

        public static ErrorNumber MuteMic(int callhandle, bool isMute)
        {
            return (ErrorNumber)WrapperInterface.muteMic(callhandle, isMute);
        }

        public static ErrorNumber MuteSpeaker(bool isMute)
        {
            return (ErrorNumber)WrapperInterface.muteSpeaker(isMute);
        }
        
        public static ErrorNumber SetMicVolume(int volume)
        {
            return (ErrorNumber)WrapperInterface.setMicVolume((uint)volume);
        }

        public static int GetMicVolume()
        {
            return (int)WrapperInterface.getMicVolume();
        }

        public static ErrorNumber SetSpeakerVolume(int volume)
        {
            return (ErrorNumber)WrapperInterface.setSpeakerVolume((uint)volume);
        }
        
        public static int GetSpeakerVolume()
        {
            return (int)WrapperInterface.getSpeakerVolume();
        }
        public static ErrorNumber RegisterClient()
        {
            return (ErrorNumber)WrapperInterface.registerClient();
        }
        public static void UnregisterClient()
        {
            WrapperInterface.unregisterClient();
        }
        
        public static ErrorNumber UpdateConfig()
        {
            return (ErrorNumber)WrapperInterface.updateConfig();
        }

        public static ErrorNumber StartShareContent(int callhandle, string deviceHandle, IntPtr appWndHandle)
        {
            return (ErrorNumber)WrapperInterface.startShareContent(callhandle, deviceHandle, appWndHandle);
        }

         public static ErrorNumber StartBFCPContent(int callhandle)
        {
            return (ErrorNumber)WrapperInterface.startBFCPContent(callhandle);
        }
        
        public static ErrorNumber StopShareContent(int callhandle)
        {
            return (ErrorNumber)WrapperInterface.stopShareContent(callhandle);
        }
        
        public static ErrorNumber SetContentBuffer(ImageFormat format, int width, int height)
        {
            return (ErrorNumber)WrapperInterface.setContentBuffer((int)format, width, height);
        }
        
        public static ErrorNumber DestroyExit()
        {
            return (ErrorNumber)WrapperInterface.destroyExit();
        }
        
        public static ErrorNumber GetMediaStatistics(int callhandle)
        {
            return (ErrorNumber)WrapperInterface.getMediaStatistics(callhandle);
        }
        
        public static ErrorNumber GetCallStatistics()
        {
            return (ErrorNumber)WrapperInterface.getCallStatistics();
        }
        
        public static string GetVersion()
        {
            var intPtrVersion= WrapperInterface.getVersion();
            return IntPtrHelper.IntPtrToUTF8string(intPtrVersion);
        }

        public static ErrorNumber SendFECCKey(int callhandle, FECCKey key, FECCAction action)
        {
            return (ErrorNumber)WrapperInterface.sendFECCKey(callhandle, (int)key, (int)action);
        }
        
        public static ErrorNumber SendDTMFKey(int callHandle, DTMFKey key)
        {
            return (ErrorNumber)WrapperInterface.sendDTMFKey(callHandle, (int)key);
        }

        public static ErrorNumber GetDeviceEnum(DeviceType deviceType)
        {
            return (ErrorNumber)WrapperInterface.getDeviceEnum((int)deviceType);
        }

        public static ErrorNumber GetSupportedCapabilities()
        {
            return (ErrorNumber)WrapperInterface.getSupportedCapabilities();
        }
        
        public static ErrorNumber SetCapabilitiesEnable(int size, string type, string name, string tagID)
        {
            return (ErrorNumber)WrapperInterface.setCapabilitiesEnable(size, type, name, tagID);
        }
        
        public static ErrorNumber SetPreferencesCapabilities(int size, string type, string name, string tagID)
        {
            return (ErrorNumber)WrapperInterface.setPreferencesCapabilities(size, type, name, tagID);
        }
        
        public static ErrorNumber MuteLocalVideo(bool isMute)
        {
            return (ErrorNumber)WrapperInterface.MuteLocalVideo(isMute);
        }
        
        public static ErrorNumber GetApplicationInfo()
        {
            return (ErrorNumber)WrapperInterface.getApplicationInfo();
        }
        
        public static ErrorNumber StartCamera()
        {
            return (ErrorNumber)WrapperInterface.startCamera();
        }
        
        public static ErrorNumber StopCamera()
        {
            return (ErrorNumber)WrapperInterface.stopCamera();
        }
        
        public static ErrorNumber StartRecord(int callHandle, RecordPipeType pipeType, string filePath)
        {
            return (ErrorNumber)WrapperInterface.startRecord(callHandle, (int)pipeType, filePath);
        }
        
        public static ErrorNumber StopRecord(int callHandle)
        {
            return (ErrorNumber)WrapperInterface.stopRecord(callHandle);
        }
        
        public static ErrorNumber PauseRecord(int callHandle)
        {
            return (ErrorNumber)WrapperInterface.pauseRecord(callHandle);
        }

        public static ErrorNumber ResumeRecord(int callHandle)
        {
            return (ErrorNumber)WrapperInterface.resumeRecord(callHandle);
        }
        
        public static ErrorNumber StartPlayback(string filePath)
        {
            return (ErrorNumber)WrapperInterface.startPlayback(filePath);
        }
        
        public static ErrorNumber StopPlayback()
        {
            return (ErrorNumber)WrapperInterface.stopPlayback();
        }
        
        public static ErrorNumber PausePlayback()
        {
            return (ErrorNumber)WrapperInterface.pausePlayback();
        }
        
        public static ErrorNumber ResumePlayback()
        {
            return (ErrorNumber)WrapperInterface.resumePlayback();
        }
        
        public static ErrorNumber SetPlayPosition(int percent)
        {
            return (ErrorNumber)WrapperInterface.setPlayPosition(percent);
        }
        
        public static ErrorNumber GetPlayPosition(ref int percent)
        {
            return (ErrorNumber)WrapperInterface.getPlayPosition(ref percent);
        }
        
        public static ErrorNumber GetFileDuration(ref int seconds)
        {
            return (ErrorNumber)WrapperInterface.getFileDuration(ref seconds);
        }


        public static ErrorNumber GetRecordStatus(int callhandle, ref int status, ref int pipeType, string fileName)
        {
            return (ErrorNumber)WrapperInterface.getRecordStatus(callhandle, ref status,  ref pipeType, fileName);
        }
        
        public static ErrorNumber SetRemoteOneSVCVideoStream(int callhandle, int selectMode, int streamId, bool isActiveSpeaker)
        {
            return (ErrorNumber)WrapperInterface.setRemoteOneSVCVideoStream(callhandle, selectMode, streamId, isActiveSpeaker);
        }


        public static ErrorNumber SetRemoteVideoStreamNumber(int callhandle, int selectMode, int streamNumber)
        {
            return (ErrorNumber)WrapperInterface.setRemoteVideoStreamNumber(callhandle, selectMode, streamNumber);
        }


        public static ErrorNumber StartPlayAlert(string filePath, bool isLoop, int interval)
        {
            return (ErrorNumber)WrapperInterface.startPlayAlert(filePath, isLoop, interval);
        }
        
        public static ErrorNumber StopPlayAlert()
        {
            return (ErrorNumber)WrapperInterface.stopPlayAlert();
        }
        
        public static ErrorNumber ChangeCallMode(int callHandle, CallMode callmode)
        {
            return (ErrorNumber)WrapperInterface.changeCallMode(callHandle, (int)callmode);
        }
        
        public static ErrorNumber PopupCameraPropertyAdvancedSettings(IntPtr winHandle)
        {
            return (ErrorNumber)WrapperInterface.popupCameraPropertyAdvancedSettings(winHandle);
        }
        
        public static ErrorNumber SetCertificateChoice(string certFingerPrint, int confirmId,CertificateChoiceType userChoice)
        {
            return (ErrorNumber)WrapperInterface.setCertificateChoice(certFingerPrint, confirmId,(int) userChoice);
        }
        
        public static ErrorNumber SetConfigFilePath(string filePath)
        {
            return (ErrorNumber)WrapperInterface.setConfigFilePath(filePath);
        }
        
        public static IntPtr StartTranscoder(int audioOnly, LayoutType layoutType, int resoFormat, int bitRate,
                 int frameRate, int keyFrameInterval, string inputFileName, string outputFileName, ref int errNo)
        {
            return WrapperInterface.startTranscoder(audioOnly, (int)layoutType, resoFormat, bitRate, frameRate, keyFrameInterval, inputFileName, outputFileName, ref errNo);
        }

        public static ErrorNumber StopTranscoder(IntPtr taskHandle)
        {
            return (ErrorNumber)WrapperInterface.stopTranscoder(taskHandle);
        }

        public static ErrorNumber GetProgressOfTranscoder(IntPtr taskHandle, ref int percentage)
        {
            return (ErrorNumber)WrapperInterface.getProgressOfTranscoder(taskHandle, ref percentage);
        }

        public static ErrorNumber SetCallStream(CallStreamType type, string filePath)
        {
            return (ErrorNumber)WrapperInterface.setCallStream((int)type, filePath);
        }
        
        public static ErrorNumber ClearCallStream(CallStreamType type)
        {
            return (ErrorNumber)WrapperInterface.clearCallStream((int)type);
        }
        
        public static ErrorNumber EnableRecordAudioStreamCallback(int callHandle, RecordAudioStreamCallback callBack, int format, int interval)
        {
            return (ErrorNumber)WrapperInterface.enableRecordAudioStreamCallback(callHandle, callBack, format, interval);
        }


        public static ErrorNumber DisableRecordAudioStreamCallback(int callHandle)
        {
            return (ErrorNumber)WrapperInterface.disableRecordAudioStreamCallback(callHandle);
        }
        
        public static ErrorNumber SetStaticImage(IntPtr buffer, int length, int width, int height)
        {
            return (ErrorNumber)WrapperInterface.setStaticImage(buffer, length, width, height);
        }

        public static ErrorNumber EnableMediaQoE(VideoDataCapturedCallback videoDataCaptured,
                                            VideoDataRenderedCallback videoDataRendered,
                                            SpeakerDataReceivedCallback speakerDataReceived,
                                            MicrophoneDataSentCallback microphoneDataSent,
                                            DataEncodedCallback dataEncoded,
                                            DataDecodedCallback dataDecoded,
                                            RtpPacketReceivedCallback rtpPacketReceived,
                                            RtpPacketSentCallback rtpPacketSent,
                                            QoEType type)
        {
            return (ErrorNumber)WrapperInterface.enableMediaQoE(videoDataCaptured, videoDataRendered, speakerDataReceived, microphoneDataSent, dataEncoded, dataDecoded, rtpPacketReceived, rtpPacketSent, (int)type);
        }

        public static ErrorNumber DisableMediaQoE(QoEType type)
        {
            return (ErrorNumber)WrapperInterface.disableMediaQoE((int)type);
        }
        public static ErrorNumber startHttpTunnelAutoDiscovery(string destAddress, string destPort, string regId, string destUser)
        {
            return (ErrorNumber)WrapperInterface.startHttpTunnelAutoDiscovery(destAddress, destPort, regId, destUser);

        }
    }    
}
