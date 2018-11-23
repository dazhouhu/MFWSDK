using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFW.Core
{
    public class Event
    {
        private IntPtr _eventHandle = IntPtr.Zero;
        private int _callHandle = -1;
        private Call _call;
        private EventType _eventType = EventType.UNKNOWN;
        private string _callerName;
        private string _calleeName;
        private int _userCode = -1;
        private string _reason;
        private int _wndWidth = 4;
        private int _wndHeight = 3; /*the default aspect ratio is 4:3*/
        private bool _plugDeviceStatus;
        private string _plugDeviceName;
        private string _deviceHandle;
        private string _ipAddress;
        private CallMode _callMode;

        private int _streamId;
        private int _activeSpeakerStreamId;
        private int _remoteVideoChannelNum;
        private string _remoteChannelDisplayName;
        private bool _isActiveSpeaker;
        private string _placeId;
        private int _isTalkingFlag;
        private string _regID;
        private string _sipCallId;

        private string _version;
        private string _serialNumber;
        private string _notBefore;
        private string _notAfter;
        private string _issuer;
        private string _subject;
        private string _signatureAlgorithm;
        private string _fingerPrintAlgorithm;
        private string _fingerPrint;
        private string _publickey;
        private string _basicContraints;
        private string _keyUsage;
        private string _extendedKeyUsage;
        private string _subjectAlternateNames;
        private string _pemCert;
        private bool _isCertHostNameOK;
        private int _certFailReason;
        private int _certConfirmId;
        private IntPtr _transcoderTaskId;
        private string _transcoderInputFileName;
        private ICEStatus _iceStatus;
        private string _sutLiteMessage;
        private bool _isVideoOK;
        private string _mediaIPAddr;
        private AutoDiscoveryStatus _discoveryStatus;


        public Event(IntPtr eventHandle, int callHandle, string placeId, EventType type, string callerName,
                string calleeName, int userCode, string reason,
                int wndWidth, int wndHeight,
                bool plugDeviceStatus, string plugDeviceName, string deviceHandle, string ipAddr, CallMode callMode,
                int streamId, int activeSpeakerStreamId, int remoteVideoChannelNum, string remoteChannelDisplayName, bool isActiveSpeaker, int isTalkingFlag, string regID,
                string sipCallId, string version, string serialNumber, string notBefore, string notAfter,
                string issuer, string subject, string signatureAlgorithm, string fingerPrintAlgorithm, string fingerPrint, string publickey, string basicContraints, string keyUsage,
                string extendedKeyUsage, string subjectAlternateNames, string pemCert, bool isCertHostNameOK, int certFailReason,
                int certConfirmId, IntPtr transcoderTaskId, string transcoderInputFileName, ICEStatus iceStatus, string sutLiteMessage, bool isVideoOK, string mediaIPAddr, AutoDiscoveryStatus discoveryStatus)
        {
            this._eventHandle = eventHandle;
            this._callHandle = callHandle;

            this._placeId = placeId;
            this._eventType = type;
            this._callerName = callerName;
            this._calleeName = calleeName;
            this._userCode = userCode;
            this._reason = reason;
            this._wndWidth = wndWidth;
            this._wndHeight = wndHeight;
            this._plugDeviceStatus = plugDeviceStatus;
            this._plugDeviceName = plugDeviceName;
            this._deviceHandle = deviceHandle;
            this._ipAddress = ipAddr;
            this._callMode = callMode;

            this._streamId = streamId;
            this._activeSpeakerStreamId = activeSpeakerStreamId;
            this._remoteVideoChannelNum = remoteVideoChannelNum;
            this._remoteChannelDisplayName = remoteChannelDisplayName;
            this._isActiveSpeaker = isActiveSpeaker;
            this._isTalkingFlag = isTalkingFlag;
            this._regID = regID;
            this._sipCallId = sipCallId;
            this._version = version;
            this._serialNumber = serialNumber;
            this._notBefore = notBefore;
            this._notAfter = notAfter;
            this._issuer = issuer;
            this._subject = subject;
            this._signatureAlgorithm = signatureAlgorithm;
            this._fingerPrintAlgorithm = fingerPrintAlgorithm;
            this._fingerPrint = fingerPrint;
            this._publickey = publickey;
            this._basicContraints = basicContraints;
            this._keyUsage = keyUsage;
            this._extendedKeyUsage = extendedKeyUsage;
            this._subjectAlternateNames = subjectAlternateNames;
            this._pemCert = pemCert;
            this._isCertHostNameOK = isCertHostNameOK;
            this._certFailReason = certFailReason;
            this._certConfirmId = certConfirmId;
            this._transcoderTaskId = transcoderTaskId;
            this._transcoderInputFileName = transcoderInputFileName;
            this._iceStatus = iceStatus;
            this._sutLiteMessage = sutLiteMessage;
            this._isVideoOK = isVideoOK;
            this._mediaIPAddr = mediaIPAddr;
            this._discoveryStatus = discoveryStatus;
        }

        public EventType EventType { get { return this._eventType; } }
        public IntPtr EventHandle { get { return this._eventHandle; } }
        public int CallHandle { get { return this._callHandle; } }
        public Call Call { get { return this._call; } set { this._call = value; } }
        public string CallerName { get { return this._callerName; } }
        public string CalleeName { get { return this._calleeName; } }
        public int WndWidth { get { return this._wndWidth; } }
        public int WndHeight { get { return this._wndHeight; } }
        public bool PlugDeviceStatus { get { return this._plugDeviceStatus; } }
        public string PlugDeviceName { get { return this._plugDeviceName; } }
        public string DeviceHandle { get { return this._deviceHandle; } }
        public string Reason { get { return this._reason; } }
        public string IPAddress { get { return this._ipAddress; } }
        public CallMode CallMode { get { return this._callMode; } }
        public int StreamId { get { return this._streamId; } }
        public int ActiveSpeakerStreamId { get { return this._activeSpeakerStreamId; } }
        public int RemoteVideoChannelNum { get { return this._remoteVideoChannelNum; } }
        public string RemoteChannelDisplayName { get { return this._remoteChannelDisplayName; } }
        public bool IsActiveSpeaker { get { return this._isActiveSpeaker; } }
        public string PlaceId { get { return this._placeId; } }
        public int IsTalkingFlag { get { return _isTalkingFlag; } }
        public string RegID { get { return this._regID; } }
        public string SipCallId { get { return this._sipCallId; } }
        public string Version { get { return this._version; } }
        public string SerialNumber { get { return this._serialNumber; } }
        public string NotBefore { get { return this._notBefore; } }
        public string NotAfter { get { return this._notAfter; } }
        public string Issuer { get { return this._issuer; } }
        public string Subject { get { return this._subject; } }
        public string SignatureAlgorithm { get { return this._signatureAlgorithm; } }
        public string FingerPrintAlgorithm { get { return this._fingerPrintAlgorithm; } }
        public string FingerPrint { get { return this._fingerPrint; } }
        public string Publickey { get { return this._publickey; } }
        public string BasicContraints { get { return this._basicContraints; } }
        public string KeyUsage { get { return this._keyUsage; } }
        public string ExtendedKeyUsage { get { return this._extendedKeyUsage; } }
        public string SubjectAlternateNames { get { return this._subjectAlternateNames; } }
        public string PemCert { get { return this._pemCert; } }
        public bool IsCertHostNameOK { get { return this._isCertHostNameOK; } }
        public int CertConfirmId { get { return this._certConfirmId; } }
        public int CertFailReason { get { return this._certFailReason; } }
        public string TranscoderInputFileName { get { return this._transcoderInputFileName; } }
        public IntPtr TranscoderTaskId { get { return this._transcoderTaskId; } }
        public ICEStatus ICEStatus { get { return this._iceStatus; } }
        public string SUTLiteMessage { get { return this._sutLiteMessage; } }
        public bool IsVideoOK { get { return this._isVideoOK; } }
        public string MediaIPAddr { get { return this._mediaIPAddr; } }
        public AutoDiscoveryStatus AutoDiscoveryStatus { get { return this._discoveryStatus; } }
    }
}
