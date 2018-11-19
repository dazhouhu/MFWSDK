using System;
using System.Runtime.InteropServices;
using System.Text;

namespace MFW.Core
{
    public class WrapperInterface
    {
        /**
         * Notify SDK to recycle event.
         * <ref>PLCM_Wrapper_Errno freeEvent(void* event);</ref>
         */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int freeEvent(IntPtr evt);
        /**
         * Store key-value pair into wrapper.
         * <ref>PLCM_Wrapper_Errno addProperty(PLCM_MFW_Key key, const char* value);</ref>
         * @param key Key in integer type.
         * @param value Value in string type.
         */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int addProperty(int key, string value);

        /**
         * Install event and log related callback functions to wrapper.
         * <ref>PLCM_Wrapper_Errno installCallback(addEventCallbackFPType addEvent, notifyCallbackFPType dispatchEvents,sysLogCallbackFPType addLog,
	addDeviceCallbackFPType addDevice, displayMediaStatisticsCallbackFPType displayMediaStatistics, displayCallStatisticsCallbackFPType displayCallStatistics,
	displayCodecNamesCallbackFPType displayCodecNamesCallback, addAppCallbackFPType addAppCallback);</ref>
         * @param addEvent Callback function for wrapper to add event in LAL.
         * @param dispatchEvents Callback function for wrapper to notify EventMonitor to dispatch events.
         * @param addLog Callback function for wrapper to deliver log message reported from lower layer.
         * @param getDeviceSize Callback function for wrapper to deliver device Enum size to LAL
         * @param getDeviceInfo Callback function for Wrapper to deliver device Info to LAL
         * @return ErrorNumber constant.
         */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int installCallback(AddEventCallback addEvent, DispatchEventsCallback dispatchEvents, AddLogCallback addLog,
                                            AddDeviceCallback addDevice, DisplayMediaStatisticsCallback displayMediaStatistics, DisplayCallStatisticsCallback displayCallStatistics,
                                            DisplayCodecCapabilities displayCodecNamesCallback, AddAppCallback addAppCallback);

        /**
	     * Pre-initialization of wrapper.
	     * <ref>PLCM_Wrapper_Errno preInitialize();</ref>
	     * @return ErrorNumber constant.
	     */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int preInitialize();

        /**
	     * Initial the MFW SDK instance. In this native method MFW initialize, set user info, register client, and get device enum are finished
	     * <ref>PLCM_Wrapper_Errno initialize();</ref>
	     * @return ErrorNumber constant.
	     */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int initialize();

        /**
	     * set audio input and output device
	     * <ref>PLCM_Wrapper_Errno setAudioDevice(PLCM_MFW_DeviceHandle micHandle,PLCM_MFW_DeviceHandle speakerHandle);</ref>
	     * @param micHandle audio input device handle, which is got from device Enum
	     * @param speakerHandle audio output device handle, which is got from device Enum
	     * @param callHandleReference
	     * @return ErrorNumber constant.
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int setAudioDevice(string micHandle, string speakerHandle);

        /**
		* set audio output device for ringtone
		* <ref>PLCM_Wrapper_Errno setAudioDeviceForRingtone(PLCM_MFW_DeviceHandle speakerHandle);</ref>
		* @param speakerHandle audio output device handle, which is got from device Enum
		* @param callHandleReference
		* @return ErrorNumber constant.
		* */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int setAudioDeviceForRingtone(string speakerHandle);

        /**
	     * set video input device
	     * <ref>PLCM_Wrapper_Errno setVideoDevice(PLCM_MFW_DeviceHandle cameraHandle);</ref>
	     * @param cameraHandle video input device handle, which is got from device Enum
	     * @return ErrorNumber constant.
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int setVideoDevice(string cameraHandle);

        /**
	     * Place a call, and retrieve the call handle.
	     * <ref>PLCM_Wrapper_Errno placeCall(const char* callee,int* CallHandle,PLCM_MFW_CallMode callMode);</ref>
	     * @param callee SIP address of callee.
	     * @param callHandleReference Call handle to be retrieved for the call.
	     * @return ErrorNumber constant.
	     */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int placeCall(string callee, ref int callHandle, int callMode);

        /**
	     * Terminate a call using its call handle.
	     * <ref>PLCM_Wrapper_Errno terminateCall(int callHandle);</ref>
	     * @param callHandle Call handle.
	     * @return ErrorNumber constant.
	     */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int terminateCall(int callHandle);

        /**
	     * Answer an incoming call using its call handle.
	     * <ref>PLCM_Wrapper_Errno answerCall(int callHandle,PLCM_MFW_CallMode callMode, const char* authToken, const char* CryptoSuiteType, const char* SRTPKey, bool SUTLiteEnable);</ref>
	     * @param callHandle Call handle.
	     * @return ErrorNumber constant.
	     */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int answerCall(int callHandle, int callMode, string authToken, string CryptoSuiteType, string SRTPKey, bool SUTLiteEnable);

        /**
	     * Reject an incoming call using its call handle.
	     * <ref>PLCM_Wrapper_Errno rejectCall(int callHandle, int userCode, const char* reason);</ref>
	     * @param callHandle Call handle.
	     * @return ErrorNumber constant.
	     */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rejectCall(int callHandle);

        /**
	     * set local and remote window handle to SDK
	     * <ref>PLCM_Wrapper_Errno setStreamInfo(PLCM_MFW_MediaType mediaType, int streamId, int callHandle, PLCM_MFW_Wnd wnd, int x, int y,  int width, int height);</ref>
	     * @param mediaType: 1-local,2-remote
	     * @param wnd: remote or local window handle
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int setStreamInfo(int mediaType, int streamId, int callHandle, IntPtr wnd, int x, int y, int width, int height);

        /**
	     * detach local, remote and PIP window
	     * <ref>PLCM_Wrapper_Errno detachStreamWnd(PLCM_MFW_MediaType mediaType, int streamId, int callHandle);</ref>
	     * @param mediaType: 1-local,2-remote
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int detachStreamWnd(int mediaType, int streamId, int callHandle);

        //public static extern int separateStreamWnd(int mediaType, IntPtr wnd, int width, int height, boolean setPip);

        /**
	     * resize local, remote and PIP window
	     * 
	     * @param mediaType: 1-local,2-remote
	     * @param wnd window handle
	     * */
        //public static extern int resizeStreamWnd(int mediaType, IntPtr wnd, int x, int y, int width, int height);

        /**
	     * release the call
	     * */
        //public static extern int releaseCall(IntPtr callHandle);

        /**
	     * hold a call
	     * <ref>PLCM_Wrapper_Errno holdCall(int callHandle);</ref>
	     * @param callHandle Call handle.
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int holdCall(int callHandle);

        /**
	     * resume a call
	     * <ref>PLCM_Wrapper_Errno resumeCall(int callHandle);</ref>
	     * @param callHandle Call handle.
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int resumeCall(int callHandle);

        /**
	     * mute/unmute a call
	     * <ref>PLCM_Wrapper_Errno muteMic(int callhandle, bool mute);</ref>
	     * @param callHandle Call handle.
	     * @param mute boolean, mute/unmute a call
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int muteMic(int callhandle, bool mute);

        /**
         * <ref>PLCM_Wrapper_Errno muteSpeaker(bool mute);</ref>
         */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int muteSpeaker(bool mute);

        /**
         * <ref>PLCM_Wrapper_Errno setMicVolume(unsigned int volume);</ref>
         */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int setMicVolume(uint volume);

        /**
         * <ref>unsigned int getMicVolume();</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint getMicVolume();

        /**
	     * set speaker volume
	     * <ref>PLCM_Wrapper_Errno setSpeakerVolume(unsigned int volume);</ref>
	     * @param volume
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int setSpeakerVolume(uint volume);

        /**
         * <ref>unsigned int getSpeakerVolume();</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint getSpeakerVolume();

        /**
	     * register client
         * <ref>PLCM_Wrapper_Errno registerClient();</ref>
	     * **/
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int registerClient();

        /**
         * <ref>PLCM_Wrapper_Errno unregisterClient();</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void unregisterClient();

        /**
	     * update config
         * <ref>PLCM_Wrapper_Errno updateConfig();</ref>
	     * **/
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int updateConfig();

        /**
	     * start to share content
         * <ref>PLCM_Wrapper_Errno startShareContent(int callhandle, PLCM_MFW_DeviceHandle deviceHandle,PLCM_MFW_Wnd wnd);</ref>
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int startShareContent(int callhandle, string deviceHandle, IntPtr appWndHandle);

        /**
	     * start to BFCP content
         * <ref>PLCM_Wrapper_Errno startBFCPContent(int callhandle);</ref>
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int startBFCPContent(int callhandle);

        /**
	     * stop to share content
         * <ref>PLCM_Wrapper_Errno stopShareContent(int callhandle);</ref>
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int stopShareContent(int callhandle);

        /**
         * <ref>PLCM_Wrapper_Errno setContentBuffer(PLCM_MFW_Image_Format format, void *buffer, int offset, int length, int width, int height, unsigned int timestamp);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int setContentBuffer(int format, int width, int height);

        /**
	     * destroy when exit application
         * <ref>PLCM_Wrapper_Errno destroyExit();</ref>
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int destroyExit();

        /**
	     * get media statistics
         * <ref>PLCM_Wrapper_Errno getMediaStatistics(int callhandle);</ref>
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getMediaStatistics(int callhandle);

        /**
	     * get call statistics
         * <ref>PLCM_Wrapper_Errno getCallStatistics();</ref>
	     * **/
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getCallStatistics();

        /**
	     * get version
         * <ref>const char* getVersion();</ref>
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr getVersion();

        /**
	     * set FECC
         * <ref>PLCM_Wrapper_Errno sendFECCKey(int callhandle, PLCM_MFW_FECC_KEY key, PLCM_MFW_FECC_ACTION action);</ref>
	     * **/
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int sendFECCKey(int callhandle, int key, int action);

        /**
	     * send DTMF key
         * <ref>PLCM_Wrapper_Errno sendDTMFKey(int callhandle, PLCM_MFW_DTMF_KEY key);</ref>
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int sendDTMFKey(int callHandle, int key);

        /**
	     * get Device enum
         * <ref>PLCM_Wrapper_Errno getDeviceEnum(PLCM_MFW_DeviceType deviceTyp);</ref>
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getDeviceEnum(int deviceType);

        /**
	     * get codec capabilities
         * <ref>PLCM_Wrapper_Errno getSupportedCapabilities();</ref>
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getSupportedCapabilities();

        /**
	     * set the codecs enable
         * <ref>PLCM_Wrapper_Errno setCapabilitiesEnable(int size, const char* type, const char* name, const char* regId);</ref>
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int setCapabilitiesEnable(int size, string type, string name, string tagID);

        /**
	     * set the codecs preferences list
         * <ref>PLCM_Wrapper_Errno setPreferencesCapabilities(int size, const char* type, const char* name, const char* regId);</ref>
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int setPreferencesCapabilities(int size, string type, string name, string tagID);

        /**
	     * mute/unmute local video
	     * <ref>PLCM_Wrapper_Errno MuteLocalVideo(bool hide);</ref>
	     * @param hide boolean, true means hide, false means display
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MuteLocalVideo(bool hide);

        /**
	     * to get the application list
         * <ref>PLCM_Wrapper_Errno getApplicationInfo();</ref>
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getApplicationInfo();

        /**
	     * start camera
         * <ref>PLCM_Wrapper_Errno startCamera();</ref>
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int startCamera();

        /**
	     * stop camera
         * <ref>PLCM_Wrapper_Errno stopCamera();</ref>
	     * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int stopCamera();

        /**
         * <ref>PLCM_Wrapper_Errno startRecord(int callHandle, PLCM_MFW_RecordType pipeId, const char* filePath);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int startRecord(int callHandle, int pipeId, string filePath);

        /**
         * <ref>PLCM_Wrapper_Errno stopRecord(int callHandle);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int stopRecord(int callHandle);

        /**
         * <ref>PLCM_Wrapper_Errno pauseRecord(int callHandle);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int pauseRecord(int callHandle);

        /**
         * <ref>PLCM_Wrapper_Errno resumeRecord(int callHandle);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int resumeRecord(int callHandle);

        /**
         * <ref>PLCM_Wrapper_Errno startPlayback(const char* filePath);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int startPlayback(string filePath);

        /**
         * <ref>PLCM_Wrapper_Errno stopPlayback();</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int stopPlayback();

        /**
         * <ref>PLCM_Wrapper_Errno pausePlayback();</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int pausePlayback();

        /**
         * <ref>PLCM_Wrapper_Errno resumePlayback();</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int resumePlayback();

        /**
         * <ref>PLCM_Wrapper_Errno	setPlayPosition(int percent);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int setPlayPosition(int percent);

        /**
         * <ref>PLCM_Wrapper_Errno getPlayPosition(int* percent);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getPlayPosition(ref int percent);

        /**
         * <ref>PLCM_Wrapper_Errno getFileDuration(int* seconds);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getFileDuration(ref int seconds);

        /**
         * <ref>PLCM_Wrapper_Errno getRecordStatus(int callhandle, int* status, int* pipeId, char* fileName);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getRecordStatus(int callhandle, ref int status, ref int pipeId, string fileName);

        /**
         * <ref>PLCM_Wrapper_Errno setRemoteOneSVCVideoStream(int callhandle, PLCM_MFW_VIDEO_SELECT_MODE selectMode, int streamId, bool isActiveSpeaker);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int setRemoteOneSVCVideoStream(int callhandle, int selectMode, int streamId, bool isActiveSpeaker);

        /**
         * <ref>PLCM_Wrapper_Errno setRemoteVideoStreamNumber(int callHandle, PLCM_MFW_VIDEO_SELECT_MODE selectMode, int streamNumber);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int setRemoteVideoStreamNumber(int callhandle, int selectMode, int streamNumber);

        /**
         * <ref>PLCM_Wrapper_Errno startPlayAlert(const char* filePath, bool loop, int interval);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int startPlayAlert(string filePath, bool loop, int interval);

        /**
         * <ref>PLCM_Wrapper_Errno stopPlayAlert();</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int stopPlayAlert();

        /**
         * <ref>PLCM_Wrapper_Errno changeCallMode(int callHandle, PLCM_MFW_CallMode callmode);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int changeCallMode(int callHandle, int callmode);

        /**
         * <ref>PLCM_Wrapper_Errno popupCameraPropertyAdvancedSettings(PLCM_MFW_Wnd winHandle);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int popupCameraPropertyAdvancedSettings(IntPtr winHandle);

        /**
         * <ref>PLCM_Wrapper_Errno setCertificateChoice(const char* certFingerPrint, int confirmId, PLCM_MFW_CERTIFICATE_CHOICE userChoice);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int setCertificateChoice(string certFingerPrint, int confirmId, int userChoice);

        /**
         * <ref>PLCM_Wrapper_Errno setConfigFilePath(const char* filePath);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int setConfigFilePath(string filePath);

        /**
         * <ref>PLCM_MFW_TranscoderTaskHandle startTranscoder(int audioOnly, PLCM_MFW_Transcoder_LayoutType layoutType, PLCM_MFW_Transcoder_ResolutionFormat resoFormat,int bitRate,
													 int frameRate,int keyFrameInterval, const char* inputFileName, const char* outputFileName, PLCM_Wrapper_Errno* errNo );</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr startTranscoder(int audioOnly, int layoutType, int resoFormat, int bitRate,
                 int frameRate, int keyFrameInterval, string inputFileName, string outputFileName, ref int errNo);

        /**
         * <ref>PLCM_Wrapper_Errno stopTranscoder(PLCM_MFW_TranscoderTaskHandle taskHandle);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int stopTranscoder(IntPtr taskHandle);

        /**
         * <ref>PLCM_Wrapper_Errno pauseTranscoder(PLCM_MFW_TranscoderTaskHandle taskHandle);</ref>
         * */
        //public static extern int pauseTranscoder(IntPtr taskHandle);
        /**
         * <ref>PLCM_Wrapper_Errno resumeTranscoder(PLCM_MFW_TranscoderTaskHandle taskHandle);</ref>
         * */
        //public static extern int resumeTranscoder( IntPtr taskHandle);

        /**
         * <ref>PLCM_Wrapper_Errno getProgressOfTranscoder(PLCM_MFW_TranscoderTaskHandle taskHandle, int* percentage);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getProgressOfTranscoder(IntPtr taskHandle, ref int percentage);

        /**
         * <ref>PLCM_Wrapper_Errno setCallStream(PLCM_MFW_CallStreamType type, const char* filePath);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int setCallStream(int type, string filePath);

        /**
         * <ref>PLCM_Wrapper_Errno clearCallStream(PLCM_MFW_CallStreamType type);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int clearCallStream(int type);

        /**
         * <ref>PLCM_Wrapper_Errno 
         * (int callHandle, writeCallbackFPType callBack, PLCM_MFW_RecordWaveFormat format, int interval);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int enableRecordAudioStreamCallback(int callHandle, RecordAudioStreamCallback callBack, int format, int interval);

        /**
         * <ref>PLCM_Wrapper_Errno disableRecordAudioStreamCallback(int callHandle);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int disableRecordAudioStreamCallback(int callHandle);

        /**
         * <ref>PLCM_Wrapper_Errno setStaticImage(void *buffer, int length, int width, int height);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int setStaticImage(IntPtr buffer, int length, int width, int height);

        /**
         * <ref>PLCM_Wrapper_Errno enableMediaQoE(	videoDataCapturedFPType videoDataCaptured, 
											videoDataRenderedFPType videoDataRendered, 
											speakerDataReceivedFPType speakerDataReceived,
											microphoneDataSentFPType microphoneDataSent, 
											dataEncodedFPType dataEncoded, 
											dataDecodedFPType dataDecoded, 
											rtpPacketReceivedFPType rtpPacketReceived, 
											rtpPacketSentFPType rtpPacketSent, 
											PLCM_MFW_QoE_Type type);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int enableMediaQoE(VideoDataCapturedCallback videoDataCaptured,
                                            VideoDataRenderedCallback videoDataRendered,
                                            SpeakerDataReceivedCallback speakerDataReceived,
                                            MicrophoneDataSentCallback microphoneDataSent,
                                            DataEncodedCallback dataEncoded,
                                            DataDecodedCallback dataDecoded,
                                            RtpPacketReceivedCallback rtpPacketReceived,
                                            RtpPacketSentCallback rtpPacketSent,
                                            int type);

        /**
         * <ref>PLCM_Wrapper_Errno disableMediaQoE(PLCM_MFW_QoE_Type type);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int disableMediaQoE(int type);

        /**
         * <ref>PLCM_Wrapper_Errno startHttpTunnelAutoDiscovery(const char* destAddress, const char* destPort, const char* regId, const char* destUser);</ref>
         * */
        [DllImport("wrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int startHttpTunnelAutoDiscovery(string destAddress, string destPort, string regId, string destUser);
    }

    #region CallBack
    #region addEventCallbackFPType
    /**
      * #if defined(IOS)
            typedef void(*addEventCallbackFPType)(PLCM_MFW_Event* eventHandle);
        #else
            typedef void(* addEventCallbackFPType)(void*, int, const char*, PLCM_MFW_EventType, const char*,
            const char*, int, const char*, int, int, bool, const char*, PLCM_MFW_DeviceHandle, const char*, PLCM_MFW_CallMode,
            int, int, int, const char*, bool, int, const char*, const char*, const char*, const char*, const char*, const char*,
            const char*, const char*, const char*, const char*, const char*, const char*, const char*, const char*, const char*,
            const char*, const char*, bool, int, int, PLCM_MFW_TranscoderTaskHandle, const char*, int ICEStatus, const char* SUTLiteMessage, bool IsVideoOK, const char* MediaIPAddr, int DiscoveryStatus);
        #endif
     **/
    /* Callback function implementation for C++ wrapper to add Event instance*/
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void AddEventCallback(IntPtr eventHandle, int callHandle, IntPtr placeId, int type, IntPtr callerName,
                IntPtr calleeName, int userCode, IntPtr reason, int wndWidth, int wndHeight, bool plugDeviceStatus, IntPtr plugDeviceName, IntPtr deviceHandle, IntPtr ipAddress, int callMode,
                int streamId, int activeSpeakerStreamId, int remoteVideoChannelNum, IntPtr remoteChannelDisplayName, bool isActiveSpeaker, int isTalkingFlag, IntPtr regID, IntPtr sipCallId, IntPtr Version, IntPtr SerialNumber, IntPtr NotBefore, IntPtr NotAfter,
                IntPtr Issuer, IntPtr Subject, IntPtr SignatureAlgorithm, IntPtr FingerPrintAlgorithm, IntPtr FingerPrint, IntPtr Publickey, IntPtr BasicContraints, IntPtr KeyUsage, IntPtr ExtendedKeyUsage,
                IntPtr SubjectAlternateNames, IntPtr PemCert, bool isCertHostNameOK, int certFailReason, int certConfirmId, IntPtr transcoderTaskId, IntPtr transcoderInputFileName, int ICEStatus, IntPtr SUTLiteMessage, bool IsVideoOK, IntPtr MediaIPAddr, int DiscoveryStatus);

    #endregion
    #region notifyCallbackFPType
    /**
     * typedef void (*notifyCallbackFPType)(); //notify function FP
    **/
    /* Callback function implementation for C++ wrapper to notify Events had been added.*/

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DispatchEventsCallback();
    #endregion
    #region sysLogCallbackFPType
    /**
     * typedef void (*sysLogCallbackFPType)(unsigned long long, bool, int, unsigned long, unsigned long, const char*, const char*, const char*, int); /*system log function FP
    **/
    /* Callback function implementation for C++ wrapper to add log message.*/

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void AddLogCallback(ulong timestamp, bool expired, int funclevel, ulong pid, ulong tid, IntPtr level, IntPtr component, IntPtr message, int len);
    #endregion
    #region addDeviceCallbackFPType
    /**
     * typedef void (*addDeviceCallbackFPType)(int,PLCM_MFW_DeviceHandle,char*); /*deliver deviceType, deviceSize, 
                                                                           deviceHandle and deviceName to LAL, 
                                                                           and in LAL java will create an device instance

    */
    /* Callback function implementation for C++ wrapper to add Device instance.*/
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void AddDeviceCallback(int deviceType, IntPtr deviceHandle, IntPtr deviceName);
    #endregion
    #region displayMediaStatisticsCallbackFPType
    /**
     * #if defined(IOS)
        typedef void (*displayMediaStatisticsCallbackFPType)(PLCM_MFW_MediaStatistics* pMediaStatistics, char* channelNum);
        #else
        typedef void (*displayMediaStatisticsCallbackFPType)(char* channelName, char* participantName, char* remoteSystemId, char* callRate,
                      char* packetsLost, char* packetLoss,char* videoProtocal, char* videoRate, char* videoRateUsed, char* videoFrameRate,
                      char* videoPackageLost,char* videoJitter, char* videoFormat, char* errorConcealment, char* audioProtocal, char* audioRate,
                      char* audioPacketsLost, char* audioJitter,char* audioEncrypt, char* videoEncrypt, char* feccEncrypt, char* audioReceivedPacket,
                      char* roundTripTime,char* fullIntraFrameRequest, char* intraFrameSent, char* packetsCount, char* overallCPULoad, char* sizeStr);
        #endif
     **/
    /* call back interface to get media statistics from SDK */
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DisplayMediaStatisticsCallback(IntPtr channelName, IntPtr strParticipantName, IntPtr remoteSystemId, IntPtr callRate, IntPtr packetsLost, IntPtr packetLoss,
                IntPtr videoProtocol, IntPtr videoRate, IntPtr videoRateUsed, IntPtr videoFrameRate, IntPtr videoPacketsLost, IntPtr videoJitter,
                IntPtr videoFormat, IntPtr errorConcealment, IntPtr audioProtocol, IntPtr audioRate, IntPtr audioPacketsLost, IntPtr audioJitter,
                IntPtr audioEncrypt, IntPtr videoEncrypt, IntPtr feccEncrypt, IntPtr audioReceivedPacket, IntPtr roundTripTime,
                IntPtr fullIntraFrameRequest, IntPtr intraFrameSent, IntPtr packetsCount, IntPtr overallCPULoad, IntPtr channelNum);

    #endregion
    #region displayCallStatisticsCallbackFPType
    /**
     * typedef void (*displayCallStatisticsCallbackFPType)(int, int, int, int, int);
     **/
    /* call back interface to get call statistics from SDK*/
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DisplayCallStatisticsCallback(int timeInLastCall, int totalTime, int callPlaced, int callReceived, int callConnected);
    #endregion
    #region displayCodecNamesCallbackFPType
    /**
     * typedef void (*displayCodecNamesCallbackFPType)(const char*, const char*);
     **/
    /*call back interface to get codec capabilities from SDK*/
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DisplayCodecCapabilities(IntPtr type, IntPtr codecName);
    #endregion
    #region addAppCallbackFPType
    /**
     * typedef void (*addAppCallbackFPType)(PLCM_MFW_Wnd, char*);
     **/
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void AddAppCallback(IntPtr appHandle, IntPtr appName);
    #endregion

    #region writeCallbackFPType
    /**
     * typedef void (*writeCallbackFPType)(void *, int);
     **/
    public delegate void RecordAudioStreamCallback(IntPtr buf, int len);
    #endregion
    #region videoDataCapturedFPType
    /**
     * typedef void (*videoDataCapturedFPType)(PLCM_MFW_CallHandle callHandle, void* data, int len, int width, int height, PLCM_MFW_QoE_Capture_Type type);
     **/
    public delegate void VideoDataCapturedCallback(IntPtr callHandle, IntPtr data, int len, int width, int height, int type);
    #endregion
    #region videoDataRenderedFPType
    /**
     * typedef void (*videoDataRenderedFPType)(PLCM_MFW_CallHandle callHandle, void* data, int len, int streamId, int width, int height);
     **/
    public delegate void VideoDataRenderedCallback(IntPtr callHandle, IntPtr data, int len, int streamId, int width, int height);
    #endregion
    #region speakerDataReceivedFPType
    /**
     * typedef void (*speakerDataReceivedFPType)(PLCM_MFW_CallHandle callHandle, void* leftchannel, void* rightchannel, int len, int samplerate, bool stereo);
     **/
    public delegate void SpeakerDataReceivedCallback(IntPtr callHandle, IntPtr leftchannel, IntPtr rightchannel, int len, int samplerate, bool stereo);
    #endregion
    #region microphoneDataSentFPType
    /**
     * typedef void (*microphoneDataSentFPType)(PLCM_MFW_CallHandle callHandle, void* leftchannel, void* rightchannel, int len, int samplerate, bool stereo);
     **/
    public delegate void MicrophoneDataSentCallback(IntPtr callHandle, IntPtr leftchannel, IntPtr rightchannel, int len, int samplerate, bool stereo);
    #endregion
    #region dataEncodedFPType
    /**
     * typedef void (*dataEncodedFPType)(PLCM_MFW_CallHandle callHandle, int streamId, int userId, void* data, int len, PLCM_MFW_QoE_MediaType packetType, const char* codecName);
     **/
    public delegate void DataEncodedCallback(IntPtr callHandle, int streamId, int userId, IntPtr data, int len, int packetType, string codecName);
    #endregion
    #region dataDecodedFPType
    /**
     * typedef void (*dataDecodedFPType)(PLCM_MFW_CallHandle callHandle, int streamId, int userId, void* data, int len, PLCM_MFW_QoE_MediaType packetType, const char* codecName);
     **/
    public delegate void DataDecodedCallback(IntPtr callHandle, int streamId, int userId, IntPtr data, int len, int packetType, string codecName);
    #endregion
    #region rtpPacketReceivedFPType
    /**
     * typedef void (*rtpPacketReceivedFPType)(PLCM_MFW_CallHandle callHandle, int streamId, int userId, void* data, int len, PLCM_MFW_QoE_MediaType packetType, const char* codecName);
     **/
    public delegate void RtpPacketReceivedCallback(IntPtr callHandle, int streamId, int userId, IntPtr data, int len, int packetType, string codecName);
    #endregion
    #region rtpPacketSentFPType
    /**
     * typedef void (*rtpPacketSentFPType)(PLCM_MFW_CallHandle callHandle, int streamId, int userId, void* data, int len, PLCM_MFW_QoE_MediaType packetType, const char* codecName);
     **/
    public delegate void RtpPacketSentCallback(IntPtr callHandle, int streamId, int userId, IntPtr data, int len, int packetType, string codecName);
    #endregion
    #endregion
}
