namespace MFW.Core
{
    public enum AutoDiscoveryStatus
    {
        UNKNOWN = 0
        ,SUCCESS                     /**< Initiates auto discovery successful. */
        ,FAILURE                      /**< Initiates auto discovery failed. */
        ,ERROR                         /**< Initiates auto discovery got an error. */
    }
}
