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
        public SignalPanel()
        {
            InitializeComponent();
        }

        public Action OnOk { get; set; }
        private void btnOK_Click(object sender, EventArgs e)
        {
            OnOk?.Invoke();
            this.Dispose();
        }

        public void BindSignals(IEnumerable<MediaStatistics> statistics)
        {
            this.grdMediaStatistics.DataSource = statistics;
            this.grdMediaStatistics.Refresh();
        }
    }
}
