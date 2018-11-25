using Kyozy.MiniblinkNet;
using MFW.Core;
using MFW.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MFWMain
{
    public partial class MainWindow : Form
    {
        #region Fields
        private WebView webView = null;
        private VPXWindow vpxWindow = null;
        private MFWToolBar toolbar = null;
        private DeviceManager deviceManager = DeviceManager.GetInstance();
        private static readonly string ServerUri = ConfigurationManager.AppSettings["ServerUri"];
        private static readonly string SipServer = ConfigurationManager.AppSettings["SipServer"];
        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
            webView = new WebView(this);
        }
        #endregion

        #region Properties
        public string UserName { get; set; }
        #endregion

        private void MainWindow_Load(object sender, EventArgs e)
        {
            webView.SetCspCheckEnable(false);
            webView.CookieEnabled = true;
            webView.NavigationToNewWindowEnable = false;

            webView.OnTitleChange += new EventHandler<TitleChangeEventArgs>(OnWebViewTitleChange);
            //webView.OnURLChange += new EventHandler<UrlChangeEventArgs>(OnWebViewURLChange);
            //webView.OnLoadingFinish += new EventHandler<LoadingFinishEventArgs>(OnWebViewLoadingFinish);
            //webView.OnLoadUrlBegin += new EventHandler<LoadUrlBeginEventArgs>(OnWebViewLoadUrlBegin);
            //webView.OnDocumentReady += new EventHandler<DocumentReadyEventArgs>(OnWebViewDocumentReady);
            //webView.OnDownload += new EventHandler<DownloadEventArgs>(OnWebViewDownload);

            #region BindFunction
            JsValue.BindFunction("OnLogin", new wkeJsNativeFunction(OnLogin), 2);
            JsValue.BindFunction("OnLogout", new wkeJsNativeFunction(OnLogout),0);
            JsValue.BindGetter("ServerUri", new wkeJsNativeFunction(GetServerUri));
            JsValue.BindGetter("Token", new wkeJsNativeFunction(GetToken));
            JsValue.BindSetter("Token", new wkeJsNativeFunction(SetToken));
            JsValue.BindFunction("Dial", new wkeJsNativeFunction(OnDial), 3);
            #endregion

            //var devToolPath ="file:///" + (Application.StartupPath + @"\front_end\inspector.html").Replace("\\","/");
            var devToolPath = "file:///D:/test/miniblinknet/Demo/bin/Debug/front_end/inspector.html";
            webView.SetDebugConfig("showDevTools", devToolPath);
            webView.ShowDevtools(devToolPath, null, IntPtr.Zero);
            //webView.LoadFile(@"Assets\pages\login.html");
            webView.LoadFile(@"Assets\pages\meeting.html");

            vpxWindow = new VPXWindow();
            toolbar = new MFWToolBar();
            toolbar.BindPanel(vpxWindow.pnlContainer);
            MFWCore.MFWEvent += MFWEventHandle;

            deviceManager.PropertyChanged += OnPropertyChangedEventHandler;

            var userName = "polycomtest4@ch";
            var pwd = "123456789";
            MFWCore.Register(SipServer, userName, pwd, vpxWindow.pnlContainer);

        }
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            MFWCore.Unregister();
            vpxWindow.Dispose();
            webView.Dispose();
        }

        private void MFWEventHandle(Event evt)
        {
            switch (evt.EventType)
            {
                #region Register
                case EventType.UNKNOWN: break;
                case EventType.SIP_REGISTER_SUCCESS: {
                        Console.WriteLine("SIP_REGISTER_SUCCESS");
                    } break;
                case EventType.SIP_REGISTER_FAILURE:
                    {
                        Console.WriteLine("SIP_REGISTER_FAILURE");
                    }
                    break;
                case EventType.SIP_REGISTER_UNREGISTERED:
                    {
                        Console.WriteLine("SIP_REGISTER_UNREGISTERED");
                    }
                    break;
                #endregion
                #region Call
                case EventType.SIP_CALL_INCOMING:
                    {
                        vpxWindow.Show();
                        vpxWindow.BringToFront();
                        vpxWindow.Focus();
                    }
                    break;
                case EventType.SIP_CALL_TRYING:
                    {
                        vpxWindow.Show();
                        vpxWindow.BringToFront();
                        vpxWindow.Focus();
                    }
                    break;
                case EventType.SIP_CALL_RINGING:
                    {
                        vpxWindow.Show();
                        vpxWindow.BringToFront();
                        vpxWindow.Focus();
                    }
                    break;
                case EventType.SIP_CALL_FAILURE:break;
                case EventType.SIP_CALL_CLOSED:break;
                case EventType.SIP_CALL_HOLD:break;
                case EventType.SIP_CALL_HELD:break;
                case EventType.SIP_CALL_DOUBLE_HOLD:break;
                case EventType.SIP_CALL_UAS_CONNECTED:
                    {
                        vpxWindow.Show();
                        vpxWindow.BringToFront();
                        vpxWindow.Focus();
                    }
                    break;
                case EventType.SIP_CALL_UAC_CONNECTED:
                    {
                        vpxWindow.Show();
                        vpxWindow.BringToFront();
                        vpxWindow.Focus();
                    }
                    break;
                #endregion
                #region Content
                case EventType.SIP_CONTENT_INCOMING:break;
                case EventType.SIP_CONTENT_CLOSED: break;
                case EventType.SIP_CONTENT_SENDING:break;
                case EventType.SIP_CONTENT_IDLE:break;
                case EventType.SIP_CONTENT_UNSUPPORTED:break;
                #endregion

                #region Stream
                case EventType.STREAM_VIDEO_LOCAL_RESOLUTIONCHANGED:break;
                case EventType.STREAM_VIDEO_REMOTE_RESOLUTIONCHANGED:break;
                #endregion

                case EventType.NETWORK_CHANGED: break;
                case EventType.MFW_INTERNAL_TIME_OUT: break;


                case EventType.REFRESH_ACTIVE_SPEAKER:break;
                case EventType.REMOTE_VIDEO_REFRESH:break;
                case EventType.REMOTE_VIDEO_CHANNELSTATUS_CHANGED: break;
                case EventType.REMOTE_VIDEO_DISPLAYNAME_UPDATE:break;
                case EventType.SIP_CALL_MODE_CHANGED: break;

                case EventType.SIP_CALL_MODE_UPGRADE_REQ: break;
                case EventType.IS_TALKING_STATUS_CHANGED: break;
                case EventType.CERTIFICATE_VERIFY: break;
                case EventType.TRANSCODER_FINISH: break;
                case EventType.ICE_STATUS_CHANGED: break;
                case EventType.SUTLITE_INCOMING_CALL: break;
                case EventType.SUTLITE_TERMINATE_CALL: break;
                case EventType.NOT_SUPPORT_VIDEOCODEC: break;

                case EventType.BANDWIDTH_LIMITATION: break;
                case EventType.MEDIA_ADDRESS_UPDATED: break;
                case EventType.AUTODISCOVERY_STATUS_CHANGED: break;
            }
        }

        private void OnPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "CurrentVideoInputDevice":
                    {
                        var js = string.Empty;
                        if (null== deviceManager.CurrentVideoInputDevice)
                        {
                            js = "if(enableVideo){ enableVideo(true)}";
                        }
                        else
                        {
                            js="if(enableVideo){ enableVideo(false)}";
                        }
                        webView.RunJsByFrame(webView.MainFrame, js);
                    }
                    break;
            }
        }
        #region Web View Handle
        void OnWebViewDownload(object sender, DownloadEventArgs e)
        {
            e.Cancel = true;
        }

        void OnWebViewDocumentReady(object sender, DocumentReadyEventArgs e)
        {
            
        }

        void OnWebViewLoadUrlBegin(object sender, LoadUrlBeginEventArgs e)
        {
        }

        void OnWebViewLoadingFinish(object sender, LoadingFinishEventArgs e)
        {
        }
                
        void OnWebViewURLChange(object sender, UrlChangeEventArgs e)
        {
        }

        void OnWebViewTitleChange(object sender, TitleChangeEventArgs e)
        {
            this.Text = e.Title;
        }

        #region Js CallBack
        private long GetServerUri(IntPtr es, IntPtr param)
        {
            return JsValue.StringValue(es, ServerUri);
        }
        private string _token = string.Empty;
        private long GetToken(IntPtr es, IntPtr param)
        {
            return JsValue.StringValue(es, _token);
        }
        private long SetToken(IntPtr es, IntPtr param)
        {
            var token = JsValue.Arg(es, 0).ToString(es);
            _token = token;
            return JsValue.UndefinedValue();
        }
        private long OnLogin(IntPtr es, IntPtr param)
        {
            var userName = JsValue.Arg(es, 0).ToString(es);
            var pwd = JsValue.Arg(es, 1).ToString(es);
            UserName = userName;
            userName = "polycomtest4@ch";
            pwd = "123456789";
            try
            {
                MFWCore.Register(SipServer, userName, pwd, vpxWindow.pnlContainer);
                return JsValue.UndefinedValue();
            }
            catch (Exception ex)
            {
                return JsValue.ThrowException(es, "注册终端失败，ex:" + ex.Message);
            }
        }
        private long OnLogout(IntPtr es,IntPtr param)
        {
            MFWCore.Unregister();
            return JsValue.UndefinedValue();
        }
        private long OnDial(IntPtr es,IntPtr param)
        {
            var caller = JsValue.Arg(es, 0).ToString(es);
            var isVideo = JsValue.Arg(es, 1).ToBoolean(es);
            var dispName = JsValue.Arg(es, 2).ToString(es);
            if(string.IsNullOrWhiteSpace(dispName))
            {
                dispName = UserName;
            }
            try
            {                
                MFWCore.SetProperty(PropertyKey.PLCM_MFW_KVLIST_KEY_DisplayName, dispName);
                MFWCore.Dial(caller, isVideo ? CallMode.AUDIOVIDEO_CALL : CallMode.AUDIO_CALL);
                vpxWindow.Show();
                vpxWindow.BringToFront();
                vpxWindow.Focus();
                return JsValue.UndefinedValue();
            }
            catch (Exception ex)
            {
                return JsValue.ThrowException(es, "呼叫失败，ex:" + ex.Message);
            }
        }
        #endregion
        #endregion

    }
}
