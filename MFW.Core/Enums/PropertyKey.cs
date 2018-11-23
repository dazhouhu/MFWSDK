namespace MFW.Core
{
    public enum PropertyKey
    {
        PLCM_MFW_KVLIST_KEY_MINSYS = 0
        ,PLCM_MFW_KVLIST_KEY_SIP_ProxyServer                        		    /**< DNS name or IP address of the SIP Proxy Server. */
        ,PLCM_MFW_KVLIST_KEY_SIP_Transport                                     /**< Protocol the user application uses for SIP signaling. The value can be "UDP","TCP" or "TLS". */
        ,PLCM_MFW_KVLIST_KEY_SIP_ServerType									    /**< Determines if you need to register the user application with a SIP Server. The value can be "ibm","standard" or "off".  */
        ,PLCM_MFW_KVLIST_KEY_SIP_Register_Expires_Interval                     /**< The expiration interval for SIP register. */
        ,PLCM_MFW_KVLIST_KEY_SIP_UserName										/**< User name for authentication to a Registrar Server. */
        ,PLCM_MFW_KVLIST_KEY_SIP_Domain										    /**< Domain name for authentication to a Registrar Server. If user application uses Polycom DMA server as the SIP server,the value can be left empty. */
        ,PLCM_MFW_KVLIST_KEY_SIP_AuthorizationName  							/**< Authentication name when registering to a SIP Registrar Server. If the value is empty,the User Name is used for authentication.  */
        ,PLCM_MFW_KVLIST_KEY_SIP_Password										/**< Password for authentication to a Registrar Server. */
        ,PLCM_MFW_KVLIST_KEY_SIP_CookieHead									    /**< Cookie head. */
        ,PLCM_MFW_KVLIST_KEY_SIP_Base_Cred                                     /**< Base credential head. */
        ,PLCM_MFW_KVLIST_KEY_SIP_AnonymousToken_Cred                           /**< Anonymous-Token cred. */
        ,PLCM_MFW_KVLIST_KEY_SIP_Anonymous_Cred                                /**< Anonymous cred. */

        ,PLCM_MFW_KVLIST_KEY_CallSettings_MaxCallNum							/**< Maximum number of SIP calls. */
        ,PLCM_MFW_KVLIST_KEY_CallSettings_NetworkCallRate						/**< Negotiated speed (bandwidth) for the call; usually combined video and audio speeds in the call. */
        ,PLCM_MFW_KVLIST_KEY_CallSettings_AesEcription							/**< Determines if a user application uses AES encryption. The value can be "on","off","auto". */
        ,PLCM_MFW_KVLIST_KEY_CallSettings_DefaultAudioStartPort				    /**< Sets the start port of audio port range. This range of ports needs to be opened in the firewall. */
        ,PLCM_MFW_KVLIST_KEY_CallSettings_DefaultAudioEndPort					/**< Sets the end port of audio port range. This range of ports needs to be opened in the firewall. */
        ,PLCM_MFW_KVLIST_KEY_CallSettings_DefaultVideoStartPort				    /**< Sets the start port of video port range. This range of ports needs to be opened in the firewall. */
        ,PLCM_MFW_KVLIST_KEY_CallSettings_DefaultVideoEndPort                  /**< Sets the end port of video port range. This range of ports needs to be opened in the firewall. */

        ,PLCM_MFW_KVLIST_KEY_CallSettings_SIPClientListeningPort               /**< Local listen port for SIP. Default value is 5060. */
        ,PLCM_MFW_KVLIST_KEY_CallSettings_SIPClientListeningTLSPort            /**< Local listen port for SIP TLS. Default value is 5061. */

        ,PLCM_MFW_KVLIST_KEY_EnableSVC								        	/**< Enable/Disable the SVC feature. The value can be "true" or "false". */
        ,PLCM_MFW_KVLIST_KEY_LogLevel                        					/**< Log information level. Log levels defined in Macros can be set. */
        ,PLCM_MFW_KVLIST_KEY_User_Agent                                      	/**< Customer names for SIP user-agent. */

        ,PLCM_MFW_KVLIST_ICE_UserName                                        	/**< ICE username. */
        ,PLCM_MFW_KVLIST_ICE_Password                                        	/**< ICE password. */
        ,PLCM_MFW_KVLIST_ICE_TCPServer                                       	/**< ICE TCP server.*/
        ,PLCM_MFW_KVLIST_ICE_UDPServer                                       	/**< ICE UDP server. */
        ,PLCM_MFW_KVLIST_ICE_TLSServer                                         /**< ICE TLS server. */
        ,PLCM_MFW_KVLIST_ICE_Enable                                            /**< Enable/ Disable ICE. The value can be "true" or "false". */
        ,PLCM_MFW_KVLIST_ICE_AUTHTOKEN_Enable                                  /**< Enable/Disable ICE token. The value can be "true" or "false". */
        ,PLCM_MFW_KVLIST_ICE_INIT_AUTHTOKEN                                    /**< Authentication token for initial Binding request. */
        ,PLCM_MFW_KVLIST_ICE_RTO                                               /**< Represents the starting interval between retransmissions which doubles after each retransmission. Unit is millisecond. Default value is 100. */
        ,PLCM_MFW_KVLIST_ICE_RC                                                /**< Number of maximum retransmissions for single request sent to the TURN server. Default value is 7. */
        ,PLCM_MFW_KVLIST_ICE_RM												    /**< Represents duration equal to rm times the rto has passed since the last request was sent and no response received when client will consider the transaction (connection to the TURN server) timed out and failed. The default value is 16. */

        ,PLCM_MFW_KVLIST_QOS_ServiceType                                       /**< Qos service type. The value can be "IP_PRECEDENCE","DIFFSERV". Not supported on Windows. */
        ,PLCM_MFW_KVLIST_QOS_Audio                                             /**< Qos audio value. The value can be 0~255. Not supported on Windows. */
        ,PLCM_MFW_KVLIST_QOS_Video                                             /**< Qos video value. The value can be 0~255. Not supported on Windows. */
        ,PLCM_MFW_KVLIST_QOS_Fecc                                              /**< Qos FECC value. The value can be 0~255. Not supported on Windows. */
        ,PLCM_MFW_KVLIST_QOS_Enable                                            /**< Enable/Disable Qos. The value can be "true" or "false". */

        ,PLCM_MFW_KVLIST_DBM_Enable                                            /**< Enable/Disable DBM. The value can be "true" or "false". */

        ,PLCM_MFW_KVLIST_KEY_REG_ID                                            /**< Register id,the unique index of Registrar server. This value can only be added or removed,but it can not be updated. */

        ,PLCM_MFW_KVLIST_LPR_Enable                                            /**< Enable/ Disable LPR. The value can be "true" or "false". */

        ,PLCM_MFW_KVLIST_CERT_PATH                                           	/**< Sets the path of certificates. */
        ,PLCM_MFW_KVLIST_CERT_CHECKFQDN                                     	/**< Whether check the FQDN of certificate. */

        ,PLCM_MFW_KVLIST_HttpConnect_Enable                                	    /**< Enable/Disable Http connect. The value can be "true" or "false".  */
        ,PLCM_MFW_KVLIST_SIP_HttpProxyServer                                	/**< SIP http proxy server. */
        ,PLCM_MFW_KVLIST_SIP_HttpProxyPort                                  	/**< SIP http proxy port.  */
        ,PLCM_MFW_KVLIST_SIP_HttpProxyUserName                             	    /**< SIP http proxy user name.  */
        ,PLCM_MFW_KVLIST_SIP_HttpPassword                                   	/**< SIP http proxy password.  */
        ,PLCM_MFW_KVLIST_ICE_HttpProxyServer                                	/**< ICE http proxy server. */
        ,PLCM_MFW_KVLIST_ICE_HttpProxyPort                                  	/**< ICE http proxy port.  */
        ,PLCM_MFW_KVLIST_ICE_HttpProxyUserName                             	    /**< ICE http proxy user name.  */
        ,PLCM_MFW_KVLIST_ICE_HttpPassword                                   	/**< ICE http proxy password.  */
        ,PLCM_MFW_KVLIST_MEDIA_HttpProxyServer                                 /**< Media http proxy server.  */
        ,PLCM_MFW_KVLIST_MEDIA_HttpProxyPort                                   /**< Media http proxy port.  */
        ,PLCM_MFW_KVLIST_MEDIA_HttpProxyUserName                             	/**< Media http proxy user name.  */
        ,PLCM_MFW_KVLIST_MEDIA_HttpPassword                                    /**< Media http proxy password.  */
        ,PLCM_MFW_KVLIST_PRODUCT												/**< Product name.  */
        ,PLCM_MFW_KVLIST_AutoZoom_Enable                                       /**< Enable/ Disable auto zoom for video render. The value can be "true" or "false". */
        ,PLCM_MFW_KVLIST_TLSOffLoad_Enable                                     /**< Enable/ Disable TLS OffLoad. The value can be "true" or "false". */
        ,PLCM_MFW_KVLIST_TLSOffLoad_Host                                       /**< TLS OffLoad host name. */
        ,PLCM_MFW_KVLIST_TLSOffLoad_Port										/**< TLS OffLoad port. */

        ,PLCM_MFW_KVLIST_HttpTunnel_Enable                                     /**< Enable/ Disable http tunnel. The value can be "true" or "false". */
        ,PLCM_MFW_KVLIST_SIP_HttpTunnelProxyServer                             /**< SIP http tunnel proxy server. */
        ,PLCM_MFW_KVLIST_SIP_HttpTunnelProxyPort                               /**< SIP http tunnel proxy port. */
        ,PLCM_MFW_KVLIST_MEDIA_HttpTunnelProxyServer                           /**< Media http tunnel proxy server.  */
        ,PLCM_MFW_KVLIST_MEDIA_HttpTunnelProxyPort                             /**< Media http tunnel proxy port.  */
        ,PLCM_MFW_KVLIST_RTPMode                                               /**< RTP mode. The value can be TCP/RTP/AVP or RTP/AVP or All.  */
        ,PLCM_MFW_KVLIST_TCPBFCPForced                                         /**< Enable/ Disable TCP/BFCP forced. The value can be "true" or "false".  */
        ,PLCM_MFW_KVLIST_G729B_Enable                                          /**< Enable/Disable G729B codec. The value can be "true" or "false".  */
        ,PLCM_MFW_KVLIST_SAML_Enable											/**< Enable/Disable SAML. The value can be "true" or "false". */
        ,PLCM_MFW_KVLIST_iLBCFrame                                             /**< Microsecond Frame for iLBC codec. The value can be "20" or "30".  Default value is 30. */
        ,PLCM_MFW_KVLIST_BFCP_CONTENT_Enable                                  /**< Enable/Disable BFCP content. The value can be "true" or "false".  */
        ,PLCM_MFW_KVLIST_SUPPORT_PORTRAIT_MODE                                /**< Enable/Disable support portrait mode.  */
        ,PLCM_MFW_KVLIST_KEY_DisplayName									   /**< Display name for sip call. */
        ,PLCM_MFW_KVLIST_FECC_Enable                                           /**<  Enable/Disable FECC function. */
        ,PLCM_MFW_KVLIST_Comfortable_Noise_Enable                            /**< Enable/Disable comfortable noise function. */
        ,PLCM_MFW_KVLIST_SIP_Header_Compact_Enable                           /**< Enable/Disable SIP header compact function. */

        ,PLCM_MFW_KVLIST_KEY_MAXSYS,

        LocalAddr,
        CalleeAddr,
        AUDIO_INPUT_DEVICE,
        AUDIO_OUTPUT_DEVICE,
        AUDIO_OUTPUT_DEVICE_FOR_RINGTONE,
        VIDEO_INPUT_DEVICE,
        MONITOR_DEVICE,

        /*Sound Effects*/
        SOUND_INCOMING,
        SOUND_CLOSED,
        SOUND_RINGING,
        SOUND_HOLD,

        //ICE token
        ICE_AUTH_TOKEN,

        LayoutType
    }
}
