
namespace MFW.Core
{ 
    public enum CallEventState
    {
        UNKNOWN,

        INCOMING_INVITE,                    /* UAS received an incoming call. */
        INCOMING_CLOSED,                    /* UAS received the call terminated. */
        INCOMING_CONNECTED,                 /* UAS received the call connected. */
        INCOMING_HOLD,                      /* The call is holding by local site. */
        INCOMING_HELD,                      /* The call is holding by far site. */
        INCOMING_DOUBLE_HOLD,               /* The call is holding by both far site and local site. */
        INCOMING_CALL_FARSITE_MIC_MUTE,     /* Far site has muted micphone. */
        INCOMING_CALL_FARSITE_MIC_UNMUTE,   /* Far site has unmuted micphone. */

        INCOMING_CONTENT,
        CONTENT_SENDING,
        CONTENT_CLOSED,
        CONTENT_UNSUPPORTED,
        CONTENT_IDLE,


        OUTGOING_RINGING,               /* UAC received far site is ringing.*/
        OUTGOING_FAILURE,               /* from CC */
        OUTGOING_CONNECTED,             /* from CC */

        LOCAL_RESOLUTION_CHANGED,       /* Local video stream resolution is changed.*/
        REMOTE_RESOLUTION_CHANGED,

        SIP_REGISTER_SUCCESS,           /* Register to sip server succeed. */
        SIP_REGISTER_FAILURE,           /* Register to sip server failed. */
        SIP_UNREGISTERED,               /* Unregister to sip server. */

        NETWORK_CHANGED,                /* Network changed or lost.*/
        CALL_AUDIO_ONLY_TRUE,           /* The call is audio only.*/
        CALL_AUDIO_ONLY_FALSE,          /* The call is not audio only.*/
        MFW_INTERNAL_TIME_OUT,

        //SVC
        REFRESH_ACTIVE_SPEAKER,
        REFRESH_LAYOUT,
        CHANNEL_STATUS_UPDATE,
        DISPLAYNAME_UPDATE,
        CALL_MODE_UPGRADE_REQ,
        DEVICE_VIDEOINPUT,
        CERTIFICATE_VERIFY,
        TRANSCODER_FINISH,
        ICE_STATUS_CHANGED,
        AUTODISCOVERY_SUCCESS,
        AUTODISCOVERY_FAILURE,
        AUTODISCOVERY_ERROR,

        SIP_CALL_TRYING    //add
    }
}
