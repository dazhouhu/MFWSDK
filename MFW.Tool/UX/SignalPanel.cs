using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MFW.Core;

namespace MFW.Tool.UX
{
    public partial class SignalPanel : UserControl
    {
        #region Fields
        private MFW.Core.PropertyManager propertyManager = MFW.Core.PropertyManager.GetInstance();
        #endregion
        #region Constructors
        private static SignalPanel instance = null;
        public SignalPanel()
        {
            InitializeComponent();
        }
        private  static SignalPanel GetInstamce()
        {
            if(null == instance)
            {
                instance = new SignalPanel();
            }
            return instance;
        }
        #endregion

        public Action OnOk { get; set; }
        private void btnOK_Click(object sender, EventArgs e)
        {
            OnOk?.Invoke();
            this.Dispose();
        }

        public void BindSignals(IEnumerable<MediaStatistics> statistics)
        {
            //var ds = statistics.ToList();
            var ds = new List<MediaStatistics>()
            {
                new MediaStatistics(){ChannelName="1"},
                new MediaStatistics(){ChannelName="2"},
                new MediaStatistics(){ChannelName="3"},
                new MediaStatistics(){ChannelName="4"},
            };
            this.grdMediaStatistics.DataSource = ds;
        }

        private void SignalPanel_Load(object sender, EventArgs e)
        {
            grdMediaStatistics.AutoGenerateColumns = false;

            MFWCore.GetMediaStatistics(BindSignals);

            this.txtCallRate.Text = "SIP";
            this.txtCallRate.Text = propertyManager.GetProperty(PropertyKey.PLCM_MFW_KVLIST_KEY_CallSettings_NetworkCallRate);
        }
    }
}
