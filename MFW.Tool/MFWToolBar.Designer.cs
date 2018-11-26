namespace MFW.Tool
{
    partial class MFWToolBar
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
            this.components = new System.ComponentModel.Container();
            this.tbSpeakerVolume = new System.Windows.Forms.TrackBar();
            this.tbMicVolume = new System.Windows.Forms.TrackBar();
            this.moreMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemDTMF = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFECC = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemP = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVAS = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCP = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSignal = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.Button();
            this.btnAttender = new System.Windows.Forms.Button();
            this.btnShare = new System.Windows.Forms.Button();
            this.btnCamera = new System.Windows.Forms.Button();
            this.btnSpeaker = new System.Windows.Forms.Button();
            this.btnMic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeakerVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMicVolume)).BeginInit();
            this.moreMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSpeakerVolume
            // 
            this.tbSpeakerVolume.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbSpeakerVolume.Location = new System.Drawing.Point(261, -109);
            this.tbSpeakerVolume.Maximum = 128;
            this.tbSpeakerVolume.Name = "tbSpeakerVolume";
            this.tbSpeakerVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbSpeakerVolume.Size = new System.Drawing.Size(45, 128);
            this.tbSpeakerVolume.TabIndex = 8;
            this.tbSpeakerVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbSpeakerVolume.Visible = false;
            this.tbSpeakerVolume.ValueChanged += new System.EventHandler(this.tbSpeakerVolume_ValueChanged);
            // 
            // tbMicVolume
            // 
            this.tbMicVolume.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbMicVolume.Location = new System.Drawing.Point(181, -109);
            this.tbMicVolume.Maximum = 128;
            this.tbMicVolume.Name = "tbMicVolume";
            this.tbMicVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbMicVolume.Size = new System.Drawing.Size(45, 128);
            this.tbMicVolume.TabIndex = 9;
            this.tbMicVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbMicVolume.Visible = false;
            this.tbMicVolume.ValueChanged += new System.EventHandler(this.tbMicVolume_ValueChanged);
            // 
            // moreMenu
            // 
            this.moreMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDTMF,
            this.menuItemFECC,
            this.menuItemLayout});
            this.moreMenu.Name = "moreMenu";
            this.moreMenu.Size = new System.Drawing.Size(154, 70);
            // 
            // menuItemDTMF
            // 
            this.menuItemDTMF.Name = "menuItemDTMF";
            this.menuItemDTMF.Size = new System.Drawing.Size(153, 22);
            this.menuItemDTMF.Text = "DTMF报号盘";
            this.menuItemDTMF.Click += new System.EventHandler(this.menuItemDTMF_Click);
            // 
            // menuItemFECC
            // 
            this.menuItemFECC.Name = "menuItemFECC";
            this.menuItemFECC.Size = new System.Drawing.Size(153, 22);
            this.menuItemFECC.Text = "FECC远程控制";
            this.menuItemFECC.Click += new System.EventHandler(this.menuItemFECC_Click);
            // 
            // menuItemLayout
            // 
            this.menuItemLayout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemP,
            this.menuItemVAS,
            this.menuItemCP});
            this.menuItemLayout.Name = "menuItemLayout";
            this.menuItemLayout.Size = new System.Drawing.Size(153, 22);
            this.menuItemLayout.Text = "布局";
            // 
            // menuItemP
            // 
            this.menuItemP.Name = "menuItemP";
            this.menuItemP.Size = new System.Drawing.Size(225, 22);
            this.menuItemP.Text = "Presentation 布局";
            this.menuItemP.Click += new System.EventHandler(this.menuItemP_Click);
            // 
            // menuItemVAS
            // 
            this.menuItemVAS.Name = "menuItemVAS";
            this.menuItemVAS.Size = new System.Drawing.Size(225, 22);
            this.menuItemVAS.Text = "VAS 布局";
            this.menuItemVAS.Click += new System.EventHandler(this.menuItemVAS_Click);
            // 
            // menuItemCP
            // 
            this.menuItemCP.Name = "menuItemCP";
            this.menuItemCP.Size = new System.Drawing.Size(225, 22);
            this.menuItemCP.Text = "Continuous Presence 布局";
            this.menuItemCP.Click += new System.EventHandler(this.menuItemCP_Click);
            // 
            // btnSignal
            // 
            this.btnSignal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSignal.FlatAppearance.BorderSize = 0;
            this.btnSignal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignal.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSignal.ForeColor = System.Drawing.Color.White;
            this.btnSignal.Image = global::MFW.Tool.Properties.Resources.signal0;
            this.btnSignal.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSignal.Location = new System.Drawing.Point(20, 10);
            this.btnSignal.Name = "btnSignal";
            this.btnSignal.Size = new System.Drawing.Size(70, 60);
            this.btnSignal.TabIndex = 1;
            this.btnSignal.Text = "信号量";
            this.btnSignal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSignal.UseVisualStyleBackColor = true;
            this.btnSignal.Click += new System.EventHandler(this.btnSignal_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExit.Image = global::MFW.Tool.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(710, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 60);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "退出";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMore
            // 
            this.btnMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnMore.FlatAppearance.BorderSize = 0;
            this.btnMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMore.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMore.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMore.Image = global::MFW.Tool.Properties.Resources.more;
            this.btnMore.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMore.Location = new System.Drawing.Point(578, 10);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(70, 60);
            this.btnMore.TabIndex = 2;
            this.btnMore.Text = "更多";
            this.btnMore.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // btnAttender
            // 
            this.btnAttender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnAttender.FlatAppearance.BorderSize = 0;
            this.btnAttender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttender.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAttender.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAttender.Image = global::MFW.Tool.Properties.Resources.attender;
            this.btnAttender.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAttender.Location = new System.Drawing.Point(498, 10);
            this.btnAttender.Name = "btnAttender";
            this.btnAttender.Size = new System.Drawing.Size(70, 60);
            this.btnAttender.TabIndex = 3;
            this.btnAttender.Text = "参会人";
            this.btnAttender.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAttender.UseVisualStyleBackColor = true;
            this.btnAttender.Click += new System.EventHandler(this.btnAttender_Click);
            // 
            // btnShare
            // 
            this.btnShare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnShare.Enabled = false;
            this.btnShare.FlatAppearance.BorderSize = 0;
            this.btnShare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShare.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShare.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnShare.Image = global::MFW.Tool.Properties.Resources.share_mute;
            this.btnShare.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShare.Location = new System.Drawing.Point(408, 10);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(80, 60);
            this.btnShare.TabIndex = 4;
            this.btnShare.Text = "发起共享";
            this.btnShare.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnShare.UseVisualStyleBackColor = true;
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
            // 
            // btnCamera
            // 
            this.btnCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCamera.Enabled = false;
            this.btnCamera.FlatAppearance.BorderSize = 0;
            this.btnCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCamera.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCamera.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCamera.Image = global::MFW.Tool.Properties.Resources.camera_mute;
            this.btnCamera.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCamera.Location = new System.Drawing.Point(328, 10);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(70, 60);
            this.btnCamera.TabIndex = 5;
            this.btnCamera.Text = "摄像头";
            this.btnCamera.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCamera.UseVisualStyleBackColor = true;
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            // 
            // btnSpeaker
            // 
            this.btnSpeaker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnSpeaker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSpeaker.Enabled = false;
            this.btnSpeaker.FlatAppearance.BorderSize = 0;
            this.btnSpeaker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpeaker.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSpeaker.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSpeaker.Image = global::MFW.Tool.Properties.Resources.speaker_mute;
            this.btnSpeaker.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSpeaker.Location = new System.Drawing.Point(248, 10);
            this.btnSpeaker.Name = "btnSpeaker";
            this.btnSpeaker.Size = new System.Drawing.Size(70, 60);
            this.btnSpeaker.TabIndex = 6;
            this.btnSpeaker.Text = "扬声器";
            this.btnSpeaker.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSpeaker.UseVisualStyleBackColor = true;
            this.btnSpeaker.Click += new System.EventHandler(this.btnSpeaker_Click);
            // 
            // btnMic
            // 
            this.btnMic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnMic.Enabled = false;
            this.btnMic.FlatAppearance.BorderSize = 0;
            this.btnMic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMic.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMic.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMic.Image = global::MFW.Tool.Properties.Resources.mic_mute;
            this.btnMic.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMic.Location = new System.Drawing.Point(168, 10);
            this.btnMic.Name = "btnMic";
            this.btnMic.Size = new System.Drawing.Size(70, 60);
            this.btnMic.TabIndex = 7;
            this.btnMic.Text = "麦克风";
            this.btnMic.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMic.UseVisualStyleBackColor = true;
            this.btnMic.Click += new System.EventHandler(this.btnMic_Click);
            // 
            // MFWToolBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.btnSignal);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMore);
            this.Controls.Add(this.btnAttender);
            this.Controls.Add(this.btnShare);
            this.Controls.Add(this.btnCamera);
            this.Controls.Add(this.btnSpeaker);
            this.Controls.Add(this.btnMic);
            this.Controls.Add(this.tbSpeakerVolume);
            this.Controls.Add(this.tbMicVolume);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "MFWToolBar";
            this.Size = new System.Drawing.Size(800, 80);
            this.Load += new System.EventHandler(this.MFWToolBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeakerVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMicVolume)).EndInit();
            this.moreMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Button btnAttender;
        private System.Windows.Forms.Button btnShare;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.Button btnSpeaker;
        private System.Windows.Forms.Button btnMic;
        private System.Windows.Forms.TrackBar tbSpeakerVolume;
        private System.Windows.Forms.TrackBar tbMicVolume;
        private System.Windows.Forms.Button btnSignal;
        private System.Windows.Forms.ContextMenuStrip moreMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemDTMF;
        private System.Windows.Forms.ToolStripMenuItem menuItemFECC;
        private System.Windows.Forms.ToolStripMenuItem menuItemLayout;
        private System.Windows.Forms.ToolStripMenuItem menuItemP;
        private System.Windows.Forms.ToolStripMenuItem menuItemVAS;
        private System.Windows.Forms.ToolStripMenuItem menuItemCP;
    }
}
