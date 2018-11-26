namespace MFW.Tool.UX
{
    partial class SignalPanel
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
            this.grdMediaStatistics = new System.Windows.Forms.DataGridView();
            this.txtCallRate = new System.Windows.Forms.Label();
            this.lblCallRate = new System.Windows.Forms.Label();
            this.callCallType = new System.Windows.Forms.Label();
            this.lblCallType = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdMediaStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // grdMediaStatistics
            // 
            this.grdMediaStatistics.AllowUserToAddRows = false;
            this.grdMediaStatistics.AllowUserToDeleteRows = false;
            this.grdMediaStatistics.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.grdMediaStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMediaStatistics.Location = new System.Drawing.Point(0, 36);
            this.grdMediaStatistics.Margin = new System.Windows.Forms.Padding(0);
            this.grdMediaStatistics.Name = "grdMediaStatistics";
            this.grdMediaStatistics.ReadOnly = true;
            this.grdMediaStatistics.RowTemplate.Height = 23;
            this.grdMediaStatistics.Size = new System.Drawing.Size(700, 406);
            this.grdMediaStatistics.TabIndex = 13;
            // 
            // txtCallRate
            // 
            this.txtCallRate.AutoSize = true;
            this.txtCallRate.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCallRate.Location = new System.Drawing.Point(320, 13);
            this.txtCallRate.Name = "txtCallRate";
            this.txtCallRate.Size = new System.Drawing.Size(85, 19);
            this.txtCallRate.TabIndex = 9;
            this.txtCallRate.Text = "呼叫类型";
            // 
            // lblCallRate
            // 
            this.lblCallRate.AutoSize = true;
            this.lblCallRate.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCallRate.Location = new System.Drawing.Point(224, 13);
            this.lblCallRate.Name = "lblCallRate";
            this.lblCallRate.Size = new System.Drawing.Size(104, 19);
            this.lblCallRate.TabIndex = 10;
            this.lblCallRate.Text = "呼叫速率：";
            // 
            // callCallType
            // 
            this.callCallType.AutoSize = true;
            this.callCallType.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.callCallType.Location = new System.Drawing.Point(114, 13);
            this.callCallType.Name = "callCallType";
            this.callCallType.Size = new System.Drawing.Size(85, 19);
            this.callCallType.TabIndex = 11;
            this.callCallType.Text = "呼叫类型";
            // 
            // lblCallType
            // 
            this.lblCallType.AutoSize = true;
            this.lblCallType.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCallType.Location = new System.Drawing.Point(13, 13);
            this.lblCallType.Name = "lblCallType";
            this.lblCallType.Size = new System.Drawing.Size(104, 19);
            this.lblCallType.TabIndex = 12;
            this.lblCallType.Text = "呼叫类型：";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOK.Image = global::MFW.Tool.Properties.Resources.ok24;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(305, 448);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 40);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "关闭  ";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SignalPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grdMediaStatistics);
            this.Controls.Add(this.txtCallRate);
            this.Controls.Add(this.lblCallRate);
            this.Controls.Add(this.callCallType);
            this.Controls.Add(this.lblCallType);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "SignalPanel";
            this.Size = new System.Drawing.Size(700, 500);
            ((System.ComponentModel.ISupportInitialize)(this.grdMediaStatistics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView grdMediaStatistics;
        private System.Windows.Forms.Label txtCallRate;
        private System.Windows.Forms.Label lblCallRate;
        private System.Windows.Forms.Label callCallType;
        private System.Windows.Forms.Label lblCallType;
    }
}
