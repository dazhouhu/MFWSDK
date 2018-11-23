using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MFW.Core
{
    public partial class UXMessageMask : Panel
    {
        private UXMessageMask()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Color drawColor = Color.FromArgb(127, this.BackColor);
            //// 定义画笔
            Pen labelBorderPen = new Pen(drawColor, 0);
            SolidBrush labelBackColorBrush = new SolidBrush(drawColor);
            //// 绘制背景色
            pe.Graphics.DrawRectangle(labelBorderPen, 0, 0, Size.Width, Size.Height);
            pe.Graphics.FillRectangle(labelBackColorBrush, 0, 0, Size.Width, Size.Height);


            base.OnPaint(pe);
        }

        public static void ShowMessage(Panel ownerPnl, bool isModal, string msg, MessageBoxButtonsType btnType, MessageBoxIcon boxIcon
            , Action okAction = null, Action cancelAction = null, Action noAction = null)
        {
            HideMessage(ownerPnl);

            var msgPnl = new UXMessageMask()
            {
                Name = "msgPnl"
            };
            msgPnl.Left = 0;
            msgPnl.Top = 0;
            msgPnl.Width = ownerPnl.Width;
            msgPnl.Height = ownerPnl.Height;
            msgPnl.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            ownerPnl.Controls.Add(msgPnl);
            msgPnl.BringToFront();

            if (isModal)
            {
                var win = new UXMessageWindow()
                {
                    Message = msg,
                    MessageBoxButtonsType = btnType,
                    MessageBoxIcon = boxIcon,
                    OKAction = okAction,
                    CancelAction = cancelAction,
                    NoAction = noAction,
                    Owner = ownerPnl.FindForm()
                };
                win.FormClosed += (sender, args) => { HideMessage(ownerPnl); };
                win.ShowDialog();
            }
            else
            {
                var msgBox = new UXMessagePanel()
                {
                    Message = msg,
                    MessageBoxButtonsType = btnType,
                    MessageBoxIcon = boxIcon,
                    OKAction = okAction,
                    CancelAction = cancelAction,
                    NoAction = noAction
                };
                var x = (ownerPnl.Width - msgBox.Width) / 2;
                var y = (ownerPnl.Height - msgBox.Height) / 2;
                msgBox.Location = new Point(x, y);
                msgBox.Disposed += (obj, args) => { HideMessage(ownerPnl); };
                msgPnl.Controls.Add(msgBox);
            }
        }

        public static void HideMessage(Panel ownerPnl)
        {
            if (null == ownerPnl)
            {
                return;
            }
            if (ownerPnl.Controls.ContainsKey("msgPnl"))
            {
                ownerPnl.Controls.RemoveByKey("msgPnl");
            }
        }

        public static void ShowForm(Panel ownerPnl, Control pnl)
        {
            HideMessage(ownerPnl);

            var msgPnl = new UXMessageMask()
            {
                Name = "msgPnl"
            };
            msgPnl.Left = 0;
            msgPnl.Top = 0;
            msgPnl.Width = ownerPnl.Width;
            msgPnl.Height = ownerPnl.Height;
            msgPnl.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            ownerPnl.Controls.Add(msgPnl);
            msgPnl.BringToFront();

            var x = (ownerPnl.Width - pnl.Width) / 2;
            var y = (ownerPnl.Height - pnl.Height) / 2;
            pnl.Location = new Point(x, y);
            msgPnl.Controls.Add(pnl);
            pnl.Disposed += (obj, args) => {
                HideMessage(ownerPnl);
            };
        }
    }

    public enum MessageBoxButtonsType
    {
        None = 0,
        OK,
        OKCancel,
        YesNo,
        YesNoCancel,
        Answer,
        Hangup,
        AnswerHangup
    }
}
