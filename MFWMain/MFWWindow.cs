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
    public partial class MFWWindow : Form
    {
        public MFWWindow()
        {
            InitializeComponent();
            MFWCore.MFWEvent += onWFWEventHandle;
        }

        private void MFWWindow_Load(object sender, EventArgs e)
        {
            MFWCore.Register("58.218.201.171", "polycomtest4@ch", "123456789", this.mfwContainer);
        }

        public void onWFWEventHandle(Event evt)
        {
            this.Invoke(new Action(()=>{ 
            switch(evt.EventType)
            {
                case EventType.SIP_REGISTER_SUCCESS:
                    {
                        MFWCore.Dial("2164334", CallMode.AUDIOVIDEO_CALL);
                    }
                    break;
                    case EventType.SIP_REGISTER_FAILURE:
                        {
                            throw new Exception("Failure");
                        }break;
                    case EventType.SIP_REGISTER_UNREGISTERED:
                        {

                            throw new Exception("SIP_REGISTER_UNREGISTERED");
                        }
                        break;
            }
            }));
        }
    }
}
