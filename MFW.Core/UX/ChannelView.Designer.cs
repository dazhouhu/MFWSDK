namespace MFW.Core
{
   partial class ChannelView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlVideo = new System.Windows.Forms.Panel();
            this.nlBar = new System.Windows.Forms.Panel();
            this.pnlBtns = new System.Windows.Forms.Panel();
            this.btnVideo = new System.Windows.Forms.Button();
            this.btnAudio = new System.Windows.Forms.Button();
            this.lblChannelName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlVideo.SuspendLayout();
            this.nlBar.SuspendLayout();
            this.pnlBtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlVideo
            // 
            this.pnlVideo.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnlVideo.Controls.Add(this.nlBar);
            this.pnlVideo.Controls.Add(this.lblName);
            this.pnlVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVideo.Location = new System.Drawing.Point(0, 0);
            this.pnlVideo.Margin = new System.Windows.Forms.Padding(0);
            this.pnlVideo.Name = "pnlVideo";
            this.pnlVideo.Size = new System.Drawing.Size(316, 216);
            this.pnlVideo.TabIndex = 0;
            // 
            // nlBar
            // 
            this.nlBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nlBar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.nlBar.Controls.Add(this.pnlBtns);
            this.nlBar.Controls.Add(this.lblChannelName);
            this.nlBar.Location = new System.Drawing.Point(3, 176);
            this.nlBar.Margin = new System.Windows.Forms.Padding(0);
            this.nlBar.Name = "nlBar";
            this.nlBar.Size = new System.Drawing.Size(316, 40);
            this.nlBar.TabIndex = 1;
            // 
            // pnlBtns
            // 
            this.pnlBtns.Controls.Add(this.btnVideo);
            this.pnlBtns.Controls.Add(this.btnAudio);
            this.pnlBtns.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBtns.Location = new System.Drawing.Point(236, 0);
            this.pnlBtns.Name = "pnlBtns";
            this.pnlBtns.Size = new System.Drawing.Size(80, 40);
            this.pnlBtns.TabIndex = 1;
            // 
            // btnVideo
            // 
            this.btnVideo.Enabled = false;
            this.btnVideo.FlatAppearance.BorderSize = 0;
            this.btnVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVideo.Image =  MFW.Core.Assets.MFWResource.camera;
            this.btnVideo.Location = new System.Drawing.Point(40, 0);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(40, 40);
            this.btnVideo.TabIndex = 1;
            this.btnVideo.UseVisualStyleBackColor = true;
            // 
            // btnAudio
            // 
            this.btnAudio.Enabled = false;
            this.btnAudio.FlatAppearance.BorderSize = 0;
            this.btnAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAudio.Image = MFW.Core.Assets.MFWResource.speaker;
            this.btnAudio.Location = new System.Drawing.Point(0, 0);
            this.btnAudio.Name = "btnAudio";
            this.btnAudio.Size = new System.Drawing.Size(40, 40);
            this.btnAudio.TabIndex = 0;
            this.btnAudio.UseVisualStyleBackColor = true;
            // 
            // lblChannelName
            // 
            this.lblChannelName.AutoSize = true;
            this.lblChannelName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblChannelName.Location = new System.Drawing.Point(3, 15);
            this.lblChannelName.Name = "lblChannelName";
            this.lblChannelName.Size = new System.Drawing.Size(77, 12);
            this.lblChannelName.TabIndex = 0;
            this.lblChannelName.Text = "Channel Name";
            this.lblChannelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(16, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(33, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // ChannelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pnlVideo);
            this.Name = "ChannelView";
            this.Size = new System.Drawing.Size(316, 216);
            this.Load += new System.EventHandler(this.ChannelView_Load);
            this.SizeChanged += new System.EventHandler(this.ChannelView_SizeChanged);
            this.pnlVideo.ResumeLayout(false);
            this.pnlVideo.PerformLayout();
            this.nlBar.ResumeLayout(false);
            this.nlBar.PerformLayout();
            this.pnlBtns.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlVideo;
        private System.Windows.Forms.Panel nlBar;
        private System.Windows.Forms.Panel pnlBtns;
        private System.Windows.Forms.Label lblChannelName;
        private System.Windows.Forms.Button btnAudio;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.Label lblName;
    }
}
