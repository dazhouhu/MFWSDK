namespace MFW.Core
{
    public enum PropertyKey
    {
        MINSYS = 0
        ,SIP_ProxyServer		                            /**< DNS name or IP address of the SIP Proxy Server. */
        ,SIP_Transport                                     /**< Protocol the user application uses for SIP signaling. The value can be "UDP","TCP" or "TLS". */
        ,SIP_ServerType									    /**< Determines if you need to register the user application with a SIP Server. The value can be "ibm","standard" or "off".  */
        ,SIP_Register_Expires_Interval                     /**< The expiration interval for SIP register. */
        ,SIP_UserName										/**< User name for authentication to a Registrar Server. */
        ,SIP_Domain										    /**< Domain name for authentication to a Registrar Server. If user application uses Polycom DMA server as the SIP server,the value can be left empty. */
        ,SIP_AuthorizationName  							/**< Authentication name when registering to a SIP Registrar Server. If the value is empty,the User Name is used for authentication.  */
        ,SIP_Password										/**< Password for authentication to a Registrar Server. */
        ,SIP_CookieHead									    /**< Cookie head. */
        ,SIP_Base_Cred                                     /**< Base credential head. */
        ,SIP_AnonymousToken_Cred                           /**< Anonymous-Token cred. */
        ,SIP_Anonymous_Cred                                /**< Anonymous cred. */

        ,CallSettings_MaxCallNum							/**< Maximum number of SIP calls. */
        ,CallSettings_NetworkCallRate						/**< Negotiated speed (bandwidth) for the call; usually combined video and audio speeds in the call. */
        ,CallSettings_AesEcription							/**< Determines if a user application uses AES encryption. The value can be "on","off","auto". */
        ,CallSettings_DefaultAudioStartPort				    /**< Sets the start port of audio port range. This range of ports needs to be opened in the firewall. */
        ,CallSettings_DefaultAudioEndPort					/**< Sets the end port of audio port range. This range of ports needs to be opened in the firewall. */
        ,CallSettings_DefaultVideoStartPort				    /**< Sets the start port of video port range. This range of ports needs to be opened in the firewall. */
        ,CallSettings_DefaultVideoEndPort                  /**< Sets the end port of video port range. This range of ports needs to be opened in the firewall. */

        ,CallSettings_SIPClientListeningPort               /**< Local listen port for SIP. Default value is 5060. */
        ,CallSettings_SIPClientListeningTLSPort            /**< Local listen port for SIP TLS. Default value is 5061. */

        ,EnableSVC								        	/**< Enable/Disable the SVC feature. The value can be "true" or "false". */
        ,LogLevel                        					/**< Log information level. Log levels defined in Macros can be set. */
        ,User_Agent                                      	/**< Customer names for SIP user-agent. */

        ,ICE_UserName                                        	/**< ICE username. */
        ,ICE_Password                                        	/**< ICE password. */
        ,ICE_TCPServer                                       	/**< ICE TCP server.*/
        ,ICE_UDPServer                                       	/**< ICE UDP server. */
        ,ICE_TLSServer                                         /**< ICE TLS server. */
        ,ICE_Enable                                            /**< Enable/ Disable ICE. The value can be "true" or "false". */
        ,ICE_AUTHTOKEN_Enable                                  /**< Enable/Disable ICE token. The value can be "true" or "false". */
        ,ICE_INIT_AUTHTOKEN                                    /**< Authentication token for initial Binding request. */
        ,ICE_RTO                                               /**< Represents the starting interval between retransmissions which doubles after each retransmission. Unit is millisecond. Default value is 100. */
        ,ICE_RC                                                /**< Number of maximum retransmissions for single request sent to the TURN server. Default value is 7. */
        ,ICE_RM												/**< Represents duration equal to rm times the rto has passed since the last request was sent and no response received when client will consider the transaction (connection to the TURN server) timed out and failed. The default value is 16. */

        ,QOS_ServiceType                                       /**< Qos service type. The value can be "IP_PRECEDENCE","DIFFSERV". Not supported on Windows. */
        ,QOS_Audio                                             /**< Qos audio value. The value can be 0~255. Not supported on Windows. */
        ,QOS_Video                                             /**< Qos video value. The value can be 0~255. Not supported on Windows. */
        ,QOS_Fecc                                              /**< Qos FECC value. The value can be 0~255. Not supported on Windows. */
        ,QOS_Enable                                            /**< Enable/Disable Qos. The value can be "true" or "false". */

        ,DBM_Enable                                            /**< Enable/Disable DBM. The value can be "true" or "false". */

        ,REG_ID                                                                /**< Register id,the unique index of Registrar server. This value can only be added or removed,but it can not be updated. */

        ,LPR_Enable                                            /**< Enable/ Disable LPR. The value can be "true" or "false". */

        ,CERT_PATH                                           	/**< Sets the path of certificates. */
        ,CERT_CHECKFQDN                                     	/**< Whether check the FQDN of certificate. */

        ,HttpConnect_Enable                                	/**< Enable/Disable Http connect. The value can be "true" or "false".  */
        ,SIP_HttpProxyServer                                	/**< SIP http proxy server. */
        ,SIP_HttpProxyPort                                  	/**< SIP http proxy port.  */
        ,SIP_HttpProxyUserName                             	/**< SIP http proxy user name.  */
        ,SIP_HttpPassword                                   	/**< SIP http proxy password.  */
        ,ICE_HttpProxyServer                                	/**< ICE http proxy server. */
        ,ICE_HttpProxyPort                                  	/**< ICE http proxy port.  */
        ,ICE_HttpProxyUserName                             	/**< ICE http proxy user name.  */
        ,ICE_HttpPassword                                   	/**< ICE http proxy password.  */
        ,MEDIA_HttpProxyServer                                 /**< Media http proxy server.  */
        ,MEDIA_HttpProxyPort                                   /**< Media http proxy port.  */
        ,MEDIA_HttpProxyUserName                             	/**< Media http proxy user name.  */
        ,MEDIA_HttpPassword                                    /**< Media http proxy password.  */
        ,PRODUCT												/**< Product name.  */
        ,AutoZoom_Enable                                       /**< Enable/ Disable auto zoom for video render. The value can be "true" or "false". */
        ,TLSOffLoad_Enable                                     /**< Enable/ Disable TLS OffLoad. The value can be "true" or "false". */
        ,TLSOffLoad_Host                                       /**< TLS OffLoad host name. */
        ,TLSOffLoad_Port										/**< TLS OffLoad port. */

        ,HttpTunnel_Enable                                     /**< Enable/ Disable http tunnel. The value can be "true" or "false". */
        ,SIP_HttpTunnelProxyServer                             /**< SIP http tunnel proxy server. */
        ,SIP_HttpTunnelProxyPort                               /**< SIP http tunnel proxy port. */
        ,MEDIA_HttpTunnelProxyServer                           /**< Media http tunnel proxy server.  */
        ,MEDIA_HttpTunnelProxyPort                             /**< Media http tunnel proxy port.  */
        ,RTPMode                                               /**< RTP mode. The value can be TCP/RTP/AVP or RTP/AVP or All.  */
        ,TCPBFCPForced                                         /**< Enable/ Disable TCP/BFCP forced. The value can be "true" or "false".  */
        ,G729B_Enable                                          /**< Enable/Disable G729B codec. The value can be "true" or "false".  */
        ,SAML_Enable											/**< Enable/Disable SAML. The value can be "true" or "false". */
        ,iLBCFrame                                             /**< Microsecond Frame for iLBC codec. The value can be "20" or "30".  Default value is 30. */
        ,BFCP_CONTENT_Enable                                  /**< Enable/Disable BFCP content. The value can be "true" or "false".  */
        ,SUPPORT_PORTRAIT_MODE                                /**< Enable/Disable support portrait mode.  */
        ,DisplayName									                        /**< Display name for sip call. */
        ,FECC_Enable                                           /**<  Enable/Disable FECC function. */
        ,Comfortable_Noise_Enable                            /**< Enable/Disable comfortable noise function. */
        ,SIP_Header_Compact_Enable                           /**< Enable/Disable SIP header compact function. */

        ,MAXSYS
        //MORE...
    }
}
