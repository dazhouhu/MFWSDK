namespace MFW.Core
{
    public enum ErrorNumber
    {
        UNKNOWN = -1,                                    //(-1),
        OK,                                    //(0), /*sample code error number representing OK*/

        /*SDK error number*/
        ERR_INVALID_HANDLE,                                    //(1),
        ERR_MOREDATA,                                    //(2),
        ERR_INVALID_DEVICETYPE,                                    //(3),
        ERR_NOTIMPLEMENTED,                                    //(4),
        ERR_NOTSUPPORTED,                                    //(5),
        ERR_INVALID_MESSAGEQ,                                    //(6),
        ERR_INVALID_STREAMINFO,                                    //(7),
        ERR_INVALID_WND,                                    //(8),
        ERR_INTERNAL,                                    //(9),
        ERR_INVALIDCALL,                                    //(10),
        ERR_INVALID_PARAMETER,                                    //(11),
        ERR_WARNING_SENDING_CONTENT,                                    //(12),
        ERR_INVALID_DEVICE,                                    //(13),
        ERR_INVALID_CAPS,                                    //(14),
        ERR_INVALID_KVLIST,                                    //(15),
        ERR_UNSUPPORT_NEON,                                    //(16),
        ERR_GENERIC,                                    //(17),
        ERR_ENCRYPTION_CONFIG,                                    //(18),
        ERR_CALL_EXCEED_MAXIMUM_CALLS,                                    //(19),
        ERR_CALL_IN_REGISTERING,                                    //(20),
        ERR_CALL_INVALID_FORMAT,                                    //(21),
        ERR_CALL_NO_CONNECT,                                    //(22),
        ERR_CALL_HOST_UNKNOWN,                                    //(23),
        ERR_CALL_EXIST,                                    //(24),
        ERR_CALL_INVALID_OPERATION,                                    //(25),
        ERR_INVOKEAPI_INCALLBACK,                                    //(26),
        ERR_PLAYBACK_FILE_NON_EXIST,                                    //(27),
        //MORE...add SDK error code

        /*sample code error number, start from 129*/
        INVALID_CALLHANDLE = -1,                              //(0xffffffff),
        ERRNO_START = 128,                                    //(128),
        LOADDLL_FAIL,                                    //(ERRNO_START.getValue() + 1),
        LOADDLL_FUNC_FAIL,                                    //(ERRNO_START.getValue() + 2),
        KVLISTINST_NULL,                                    //(ERRNO_START.getValue() + 3),
        CALLBACK_NULL,                                    //(ERRNO_START.getValue() + 4),
        REGISTER_FAIL,                                    //(ERRNO_START.getValue() + 5),
        SHARE_CONTENT_FAIL,                                    //(ERRNO_START.getValue() + 6),
        UPDATECONFIG_FAIL,                                    //(ERRNO_START.getValue() + 7),
        NULL_CALLHANDLE,                                    //(ERRNO_START.getValue() + 8),
        NULL_DEVICE,                                    //(ERRNO_START.getValue() + 9),
        NULL_CALLEE_ADDR,                                    //(ERRNO_START.getValue() + 10),
        NULL_DEVICE_NAME                                    //(ERRNO_START.getValue() + 11);
                                                                        //MORE...add sample error code
    }
}
