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
            this.lblChannelName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnVideo = new System.Windows.Forms.Button();
            this.btnAudio = new System.Windows.Forms.Button();
            this.pnlVideo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlVideo
            // 
            this.pnlVideo.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnlVideo.Controls.Add(this.btnVideo);
            this.pnlVideo.Controls.Add(this.btnAudio);
            this.pnlVideo.Controls.Add(this.lblChannelName);
            this.pnlVideo.Controls.Add(this.lblName);
            this.pnlVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVideo.Location = new System.Drawing.Point(0, 0);
            this.pnlVideo.Margin = new System.Windows.Forms.Padding(0);
            this.pnlVideo.Name = "pnlVideo";
            this.pnlVideo.Size = new System.Drawing.Size(324, 244);
            this.pnlVideo.TabIndex = 0;
            // 
            // lblChannelName
            // 
            this.lblChannelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblChannelName.AutoSize = true;
            this.lblChannelName.BackColor = System.Drawing.Color.Transparent;
            this.lblChannelName.ForeColor = System.Drawing.Color.Red;
            this.lblChannelName.Location = new System.Drawing.Point(16, 215);
            this.lblChannelName.Name = "lblChannelName";
            this.lblChannelName.Size = new System.Drawing.Size(77, 12);
            this.lblChannelName.TabIndex = 0;
            this.lblChannelName.Text = "Channel Name";
            this.lblChannelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(16, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(33, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // btnVideo
            // 
            this.btnVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVideo.BackColor = System.Drawing.Color.Transparent;
            this.btnVideo.Enabled = false;
            this.btnVideo.FlatAppearance.BorderSize = 0;
            this.btnVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVideo.Image = global::MFW.Core.Assets.MFWResource.camera;
            this.btnVideo.Location = new System.Drawing.Point(275, 201);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(40, 40);
            this.btnVideo.TabIndex = 1;
            this.btnVideo.UseVisualStyleBackColor = false;
            // 
            // btnAudio
            // 
            this.btnAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAudio.BackColor = System.Drawing.Color.Transparent;
            this.btnAudio.Enabled = false;
            this.btnAudio.FlatAppearance.BorderSize = 0;
            this.btnAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAudio.Image = global::MFW.Core.Assets.MFWResource.speaker;
            this.btnAudio.Location = new System.Drawing.Point(229, 201);
            this.btnAudio.Name = "btnAudio";
            this.btnAudio.Size = new System.Drawing.Size(40, 40);
            this.btnAudio.TabIndex = 0;
            this.btnAudio.UseVisualStyleBackColor = false;
            // 
            // ChannelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.pnlVideo);
            this.Name = "ChannelView";
            this.Size = new System.Drawing.Size(324, 244);
            this.Load += new System.EventHandler(this.ChannelView_Load);
            this.SizeChanged += new System.EventHandler(this.ChannelView_SizeChanged);
            this.pnlVideo.ResumeLayout(false);
            this.pnlVideo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlVideo;
        private System.Windows.Forms.Label lblChannelName;
        private System.Windows.Forms.Button btnAudio;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.Label lblName;
    }
}
