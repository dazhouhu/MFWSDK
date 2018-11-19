namespace MFW.Core
{
    public enum RecordPipeType
    {
        UNKNOWN = 0

        ,ARX    		/**< Remote audio stream.  */
        ,ATX   		/**< Local audio stream. */
        ,PVRX      	/**< Remote video stream. */
        ,PVTX  		/**< Local video stream. */
        ,CRX    		/**< Remote content stream. */
        ,CTX   		/**< Local content stream. */
        ,AVRX        /**< Mixed remote audio and video stream. */
        ,AVTX        /**< Mixed local audio and video streams. */
        ,ATRX        /**< Mixed local and remote audio streams. */
        ,ATRX_PVRX   /**< Mixed local and remote audio streams and remote video stream. */
    }
}
