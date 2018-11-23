
namespace MFW.Core
{
    public enum CallState
    {
        SIP_UNKNOWN,

        SIP_INCOMING_INVITE,        /* UAS received INVITE, from CC */
        SIP_INCOMING_CONNECTED,     /* from CC */

        SIP_CALL_HOLD,              /* local hold */
        SIP_CALL_HELD,              /* far site hold */
        SIP_CALL_DOUBLE_HOLD,       /* both far-site and local hold */


        SIP_OUTGOING_TRYING,         /* UAC get 100, from CC */
        SIP_OUTGOING_RINGING,       /* UAC get 180 from CC */
                                    //SIP_OUTGOING_ANSWERED,  /* UAC get 200 from CC */
        SIP_OUTGOING_CONNECTED,     /* from CC */
        SIP_OUTGOING_FAILURE,
        SIP_CALL_CLOSED,
        NULL_CALL
    }

}
