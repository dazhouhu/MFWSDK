namespace MFW.Core
{
    public enum ICEStatus
    {
        IDLE = 0
        ,FAIL_CONN_TURN                        /**< Connection to TURN Server failed. */
        ,FAIL_CONNECTIVITY_CHECK               /**< ICE Connectivity check failure. */
        ,FAIL_TOKEN_AUTHENTICATION_WITH_TURN   /**< Token Authentication failed with TURN Server. */
        ,FAIL_ALLOCATION_TIMEOUT               /**< ICE ALLOCATION time-out. */
        ,FAIL_CONN_TURN_BY_PROXY               /**< HttpConnect feature is available for ICE but the ICE client failed to connect to TURN through the Proxy. */
        ,FAIL_ACTIVE_NODE_DOWN                 /**< The active node in the running call went down in the TURN cluster. */
    }
}
