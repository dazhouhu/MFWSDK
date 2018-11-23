using Kyozy.MiniblinkNet;
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
        private static readonly string ServerUri = ConfigurationManager.AppSettings["ServerUri"];
        #endregion
        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
            webView = new WebView(this);
        }
        #endregion

        private void MainWindow_Load(object sender, EventArgs e)
        {
            webView.OnTitleChange += new EventHandler<TitleChangeEventArgs>(OnWebViewTitleChange);
            webView.OnURLChange += new EventHandler<UrlChangeEventArgs>(OnWebViewURLChange);
            webView.OnLoadingFinish += new EventHandler<LoadingFinishEventArgs>(OnWebViewLoadingFinish);
            webView.OnLoadUrlBegin += new EventHandler<LoadUrlBeginEventArgs>(OnWebViewLoadUrlBegin);
            webView.OnDocumentReady += new EventHandler<DocumentReadyEventArgs>(OnWebViewDocumentReady);
            webView.OnDownload += new EventHandler<DownloadEventArgs>(OnWebViewDownload);

            webView.LoadFile(@"Assets\pages\login.html");
            //webView.ShowDevtools(@"front_end\inspector.html", null, IntPtr.Zero);
        }

        #region Web View Handle
        void OnWebViewDownload(object sender, DownloadEventArgs e)
        {
        }

        void OnWebViewDocumentReady(object sender, DocumentReadyEventArgs e)
        {
            /*
            var js = string.Format("G.baseUri='{0}'", ServerUri);
            webView.RunJsByFrame(e.Frame, js);
            */
        }

        void OnWebViewLoadUrlBegin(object sender, LoadUrlBeginEventArgs e)
        {
        }

        void OnWebViewLoadingFinish(object sender, LoadingFinishEventArgs e)
        {
        }

        //js中的 OnBtnClick() 会调用到此处
        long OnBtnClick(IntPtr es, IntPtr param)
        {
            JsValue v = webView.RunJS("return document.getElementsByTagName('html')[0].outerHTML;");
            System.Diagnostics.Debug.WriteLine(v.ToString(es)); // 带参数的 ToString 方法来取文本
            return JsValue.UndefinedValue();
        }


        void OnWebViewURLChange(object sender, UrlChangeEventArgs e)
        {
        }

        void OnWebViewTitleChange(object sender, TitleChangeEventArgs e)
        {
            this.Text = e.Title;
        }
        #endregion
        
    }
}
