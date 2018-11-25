namespace MFW.Tool.UX
{
    partial class ContentSelectPanel
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.rdoBFCP = new System.Windows.Forms.RadioButton();
            this.rdMonitor = new System.Windows.Forms.RadioButton();
            this.cbxFormat = new System.Windows.Forms.ComboBox();
            this.cbxMonitor = new System.Windows.Forms.ComboBox();
            this.cbxApp = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Image = global::MFW.Tool.Properties.Resources.cancel24;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(186, 146);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 40);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消  ";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rdoBFCP
            // 
            this.rdoBFCP.AutoSize = true;
            this.rdoBFCP.Location = new System.Drawing.Point(23, 26);
            this.rdoBFCP.Name = "rdoBFCP";
            this.rdoBFCP.Size = new System.Drawing.Size(95, 16);
            this.rdoBFCP.TabIndex = 8;
            this.rdoBFCP.TabStop = true;
            this.rdoBFCP.Text = "BFCP内容共享";
            this.rdoBFCP.UseVisualStyleBackColor = true;
            this.rdoBFCP.CheckedChanged += new System.EventHandler(this.rdoBFCP_CheckedChanged);
            // 
            // rdMonitor
            // 
            this.rdMonitor.AutoSize = true;
            this.rdMonitor.Checked = true;
            this.rdMonitor.Location = new System.Drawing.Point(23, 56);
            this.rdMonitor.Name = "rdMonitor";
            this.rdMonitor.Size = new System.Drawing.Size(107, 16);
            this.rdMonitor.TabIndex = 8;
            this.rdMonitor.TabStop = true;
            this.rdMonitor.Text = "监视器内容共享";
            this.rdMonitor.UseVisualStyleBackColor = true;
            this.rdMonitor.CheckedChanged += new System.EventHandler(this.rdMonitor_CheckedChanged);
            // 
            // cbxFormat
            // 
            this.cbxFormat.Enabled = false;
            this.cbxFormat.FormattingEnabled = true;
            this.cbxFormat.Items.AddRange(new object[] {
            "YUV",
            "RGBA"});
            this.cbxFormat.Location = new System.Drawing.Point(138, 25);
            this.cbxFormat.Name = "cbxFormat";
            this.cbxFormat.Size = new System.Drawing.Size(163, 20);
            this.cbxFormat.TabIndex = 9;
            // 
            // cbxMonitor
            // 
            this.cbxMonitor.DisplayMember = "DeviceName";
            this.cbxMonitor.FormattingEnabled = true;
            this.cbxMonitor.Items.AddRange(new object[] {
            "YUV",
            "RGBA"});
            this.cbxMonitor.Location = new System.Drawing.Point(138, 78);
            this.cbxMonitor.Name = "cbxMonitor";
            this.cbxMonitor.Size = new System.Drawing.Size(163, 20);
            this.cbxMonitor.TabIndex = 9;
            this.cbxMonitor.ValueMember = "DeviceHandle";
            // 
            // cbxApp
            // 
            this.cbxApp.DisplayMember = "DeviceName";
            this.cbxApp.FormattingEnabled = true;
            this.cbxApp.Items.AddRange(new object[] {
            "YUV",
            "RGBA"});
            this.cbxApp.Location = new System.Drawing.Point(138, 104);
            this.cbxApp.Name = "cbxApp";
            this.cbxApp.Size = new System.Drawing.Size(163, 20);
            this.cbxApp.TabIndex = 9;
            this.cbxApp.ValueMember = "AppDeviceHandle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "显示器监视器：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "应用程序：";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOK.Image = global::MFW.Tool.Properties.Resources.ok24;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(56, 146);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 40);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "确定  ";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ContentSelectPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxApp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxMonitor);
            this.Controls.Add(this.cbxFormat);
            this.Controls.Add(this.rdMonitor);
            this.Controls.Add(this.rdoBFCP);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "ContentSelectPanel";
            this.Size = new System.Drawing.Size(320, 204);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton rdoBFCP;
        private System.Windows.Forms.RadioButton rdMonitor;
        private System.Windows.Forms.ComboBox cbxFormat;
        private System.Windows.Forms.ComboBox cbxMonitor;
        private System.Windows.Forms.ComboBox cbxApp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}