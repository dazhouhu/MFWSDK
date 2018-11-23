namespace MFWMain
{
    partial class MFWWindow
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
            this.mfwContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // mfwContainer
            // 
            this.mfwContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mfwContainer.Location = new System.Drawing.Point(0, 0);
            this.mfwContainer.Name = "mfwContainer";
            this.mfwContainer.Size = new System.Drawing.Size(784, 562);
            this.mfwContainer.TabIndex = 0;
            // 
            // MFWWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.mfwContainer);
            this.Name = "MFWWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MFWWindow";
            this.Load += new System.EventHandler(this.MFWWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mfwContainer;
    }
}