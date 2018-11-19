namespace MFW.Core
{
    public enum QoEType
    {
        UNKNOWN					= 0X00000000
        ,VIDEO_CAPTURE_RAWONLY	= 0X00000001   /**< QoE type is video input raw data. */
	    ,VIDEO_CAPTURE_SCALED	= 0X00000002   /**< QoE type is video input scaled data. */
        ,VIDEO_RENDER			= 0X00000004   /**< QoE type is video output. */
        ,AUDIO_RECORD			= 0X00000008   /**< QoE type is audio input. */
        ,AUDIO_PLAYING			= 0X00000010   /**< QoE type is audio output. */
        ,ENCODED_VIDEO			= 0X00000020   /**< QoE type is H264 video stream data input. */
        ,ENCODED_CONTENT		= 0X00000040   /**< QoE type is H264 content stream data input. */
        ,DECODED_VIDEO			= 0X00000080   /**< QoE type is H264 video stream data output. */
        ,DECODED_CONTENT		= 0X00000100   /**< QoE type is H264 content stream data output. */
        ,RTP_RECEIVED_VIDEO		= 0X00000200   /**< QoE type is RTP video data output. */
        ,RTP_RECEIVED_AUDIO		= 0X00000400   /**< QoE type is RTP audio data output. */
        ,RTP_RECEIVED_CONTENT	= 0X00000800   /**< QoE type is RTP content data output. */
        ,RTP_SENT_VIDEO			= 0X00001000   /**< QoE type is RTP video data input. */
        ,RTP_SENT_AUDIO			= 0X00002000   /**< QoE type is RTP audio data input. */
        ,RTP_SENT_CONTENT		= 0X00004000   /**< QoE type is RTP content data input. */
        ,ALL					= 0X00007FFF   /**< QoE type is all above. */
    }
}
