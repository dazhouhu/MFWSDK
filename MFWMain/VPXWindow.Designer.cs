namespace MFWMain
{
    partial class VPXWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(784, 562);
            this.pnlContainer.TabIndex = 0;
            // 
            // VPXWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.pnlContainer);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "VPXWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VPXWindow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VPXWindow_FormClosing);
            this.Load += new System.EventHandler(this.VPXWindow_Load);
            this.Shown += new System.EventHandler(this.VPXWindow_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlContainer;
    }
}