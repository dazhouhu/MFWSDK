namespace MFW.Core
{
    public enum EventType
    {
        UNKNOWN = 0

        ,SIP_REGISTER_SUCCESS   			/**< Successful registered to SIP server. */
        ,SIP_REGISTER_FAILURE   				/**< Failed to register to SIP server. */
        ,SIP_REGISTER_UNREGISTERED            /**< Unregistered to SIP server. */

        ,SIP_CALL_INCOMING  					/**< A SIP call is coming. */
        ,SIP_CALL_TRYING                      /**< A SIP call is trying. */
        ,SIP_CALL_RINGING                     /**< Far end  is ringing. */
        ,SIP_CALL_FAILURE                     /**< A SIP call has failed.  */
        ,SIP_CALL_CLOSED       				/**< A SIP Call has closed. */
        ,SIP_CALL_HOLD       					/**< A SIP Call is held by local side. */
        ,SIP_CALL_HELD       					/**< A SIP Call is held by remote side. */
        ,SIP_CALL_DOUBLE_HOLD       			/**< A SIP Call is held by both sides. */
        ,SIP_CALL_UAS_CONNECTED   			/**< A SIP Call is connected on callee side. */
        ,SIP_CALL_UAC_CONNECTED  				/**< A SIP Call is connected on caller side. */

        ,SIP_CONTENT_INCOMING					/**< SIP content is coming. */
        ,SIP_CONTENT_CLOSED					/**< SIP incoming content is closed. */
        ,SIP_CONTENT_SENDING					/**< SIP content is being sent. */
        ,SIP_CONTENT_IDLE						/**< SIP content is idle or not being sent. */
        ,SIP_CONTENT_UNSUPPORTED				/**< SIP content is not supported. */

        ,DEVICE_VIDEOINPUTCHANGED   			/**< Video input device is changed. */
        ,DEVICE_AUDIOINPUTCHANGED 			/**< Audio input device is changed. */
        ,DEVICE_AUDIOOUTPUTCHANGED 			/**< Audio output device is changed. */
        ,DEVICE_VOLUMECHANGED   				/**< Not used for now. Volume of audio output device changed. */
        ,DEVICE_MONITORINPUTSCHANGED  		/**< Monitor input device is changed. */

        ,STREAM_VIDEO_LOCAL_RESOLUTIONCHANGED /**< Local video stream is ready to display with the resolution. */
        ,STREAM_VIDEO_REMOTE_RESOLUTIONCHANGED/**< Remote video stream is ready to display with the resolution. */

        ,NETWORK_CHANGED                      /**< Network connectivity is changed or lost. */

        ,INTERNAL_TIME_OUT                    /**< Exchange message timeout in SDK internal components after user application invokes a function. */

        ,REFRESH_ACTIVE_SPEAKER               /**< The active speaker in the SVC conference is changed. */
        ,REMOTE_VIDEO_REFRESH                 /**< A number of remote streams arrived in the call. */
        ,REMOTE_VIDEO_STATUSCHANGED			/**< The remote stream arrived in the call. */
        ,REMOTE_VIDEO_DISPLAYNAME_UPDATE      /**< The remote stream participant's name in SVC conference is changed. */

        ,SIP_CALL_MODE_CHANGED                /**< Indicates call mode is changed. */
        ,SIP_CALL_MODE_UPGRADE_REQ            /**< Indicates receiving an audio-video call upgrade request. */

        ,TALKING_STATUS_CHANGED				/**< Indicates talking status changed. */

        ,CERTIFICATE_VERIFY                   /**< Certificate needs user trust.*/
        ,TRANSCODER_FINISH                    /**< Transcoder finished.*/

        ,ICE_STATUS_CHANGED                   /**< Notify ICE status. */

        ,SUTLITE_INCOMING_CALL               /**< Notify SUTLite incoming call. Only applicable for Windows and Mac. */
        ,SUTLITE_TERMINATE_CALL              /**< Notify SUTLite terminate call. Only applicable for Windows and Mac. */

        ,NOT_SUPPORT_VIDEOCODEC              /**< Video call is not supported because video codec is not supported. */

        ,BANDWIDTH_LIMITATION                /**< Notify network bandwidth  limitation status. */

        ,MEDIA_ADDRESS_UPDATED               /**< Notify media IP address updated. */

        ,AUTODISCOVERY_STATUS_CHANGED         /**< Notify http tunnel auto discovery status changed. */

        //MORE...
    }
}
