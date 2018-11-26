using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
