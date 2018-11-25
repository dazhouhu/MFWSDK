using Kyozy.MiniblinkNet;
using MFW.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MFWMain
{
    public partial class VPXWindow : Form
    {
        #region Fields
        private static CallManager callManager = CallManager.GetInstance();
        private static CallView callView = CallView.GetInstance();
        #endregion
        #region Constructors
        public VPXWindow()
        {
            InitializeComponent();
        }
        #endregion

        private void VPXWindow_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 45, 58, 66);
        }

        private void VPXWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            var msg = string.Empty;
            var callStateText =callManager.GetCallStateText(callManager.CurrentCall, true);
            if (!string.IsNullOrEmpty(callStateText))
            {
                msg +=  callStateText;
                msg += '\n' + "确定要挂断当前通话。";
                var okAction = new Action(()=> {
                    callManager.Hangup();
                    callManager.CurrentCall = null;
                    this.Hide();
                    e.Cancel = true;
                });
                callView.ShowMessage(true, msg, MessageBoxButtonsType.OKCancel, MessageBoxIcon.Question
                                                        , okAction);
            }
            else
            {
                this.Hide();
                callManager.CurrentCall = null;
                e.Cancel = true;
            }

        }

        private void VPXWindow_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
