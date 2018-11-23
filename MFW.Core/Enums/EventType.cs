namespace MFW.Core
{
    public enum EventType
    {
        UNKNOWN,

        SIP_REGISTER_SUCCESS,                       /*1 with SIP server from CC*/
        SIP_REGISTER_FAILURE,                       /*2 from CC */
        SIP_REGISTER_UNREGISTERED,                  /*3 Unregister client. */

        SIP_CALL_INCOMING,                          /*4 UAS received INVITE, from CC */
        SIP_CALL_TRYING,                            /*5< A SIP call is trying. */
        SIP_CALL_RINGING,                           /*6 UAC get 180 from CC */
        SIP_CALL_FAILURE,                           /*7 from CC */
        SIP_CALL_CLOSED,                            /* 8UAS get terminated from CC */
        SIP_CALL_HOLD,                              /* 9local hold */
        SIP_CALL_HELD,                              /* 10far site hold */
        SIP_CALL_DOUBLE_HOLD,                       /* 11both far-site and local hold */
        SIP_CALL_UAS_CONNECTED,                     /* 12from CC */
        SIP_CALL_UAC_CONNECTED,                     /* 13from CC */

        SIP_CONTENT_INCOMING,                       /*14from MP*/
        SIP_CONTENT_CLOSED,                         /*15*/
        SIP_CONTENT_SENDING,                        /*16*/
        SIP_CONTENT_IDLE,                           /*17Indicates SIP content is idle & not sent now*/
        SIP_CONTENT_UNSUPPORTED,                    /*18*/

        DEVICE_VIDEOINPUTCHANGED,                   /* 19from MP */
        DEVICE_AUDIOINPUTCHANGED,                   /* 20from MP */
        DEVICE_AUDIOOUTPUTCHANGED,                  /* 21from MP */
        DEVICE_VOLUMECHANGED,                       /* 22from MP */
        DEVICE_MONITORINPUTSCHANGED,                /* 23from MP */

        STREAM_VIDEO_LOCAL_RESOLUTIONCHANGED,       /*24from MP*/
        STREAM_VIDEO_REMOTE_RESOLUTIONCHANGED,      /*25from MP*/

        NETWORK_CHANGED,                            /* 26when network is changed or lost. */
        MFW_INTERNAL_TIME_OUT,                      /* 27if receive this notification, there is an fatal error in mfw, app should show warning message then exit app. */
        REFRESH_ACTIVE_SPEAKER,                     /* 28SVC msg */
        REMOTE_VIDEO_REFRESH,                       /* 29SVC msg */

        REMOTE_VIDEO_CHANNELSTATUS_CHANGED,         /* 30SVC msg */
        REMOTE_VIDEO_DISPLAYNAME_UPDATE,            /* 31Remote video status is changed. */
        SIP_CALL_MODE_CHANGED,                      /*32Indicates call mode is changed. */
        SIP_CALL_MODE_UPGRADE_REQ,                  /*33Indicates receiving an audio-video call upgrade request. */
        IS_TALKING_STATUS_CHANGED,                  /*34*/
        CERTIFICATE_VERIFY,                         /*35 Certifate needs user trust.*/
        TRANSCODER_FINISH,                          /*36 transcoding finish*/
        ICE_STATUS_CHANGED,                         /*37 Notify ICE status. */
        SUTLITE_INCOMING_CALL,                      /*38 Notify SUTLite incoming call. */
        SUTLITE_TERMINATE_CALL,                     /*39 Notify SUTLite terminate call. */

        NOT_SUPPORT_VIDEOCODEC,                     /*40 Video call is not supported for video codec is not supported. */
        BANDWIDTH_LIMITATION,                       /*41 Notify network bandwidth is limitation status. */
        MEDIA_ADDRESS_UPDATED,                      /*42 Notify media IP address updated. */
        AUTODISCOVERY_STATUS_CHANGED                /*43 Notify http tunnel auto discovery status changed. */
                                                   //MORE...
    }
}
