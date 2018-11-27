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
            this.ParticipantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VideoProtocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemoteSystemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PacketsLost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PacketLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VideoRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VideoRateUsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VideoFrameRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VideoPacketsLost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VideoJitter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VideoFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorConcealment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioProtocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioPacketsLost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioJitter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioEncrypt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VideoEncrypt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeccEncrypt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioReceivedPacket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oundTripTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullIntraFrameRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntraFrameSent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PacketsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overallCPULoad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdMediaStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // grdMediaStatistics
            // 
            this.grdMediaStatistics.AllowUserToAddRows = false;
            this.grdMediaStatistics.AllowUserToDeleteRows = false;
            this.grdMediaStatistics.BackgroundColor = System.Drawing.Color.Azure;
            this.grdMediaStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMediaStatistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParticipantName,
            this.ChannelName,
            this.VideoProtocol,
            this.ChannelNum,
            this.RemoteSystemId,
            this.CallRate,
            this.PacketsLost,
            this.PacketLoss,
            this.VideoRate,
            this.VideoRateUsed,
            this.VideoFrameRate,
            this.VideoPacketsLost,
            this.VideoJitter,
            this.VideoFormat,
            this.ErrorConcealment,
            this.AudioProtocol,
            this.AudioRate,
            this.AudioPacketsLost,
            this.AudioJitter,
            this.AudioEncrypt,
            this.VideoEncrypt,
            this.FeccEncrypt,
            this.AudioReceivedPacket,
            this.oundTripTime,
            this.FullIntraFrameRequest,
            this.IntraFrameSent,
            this.PacketsCount,
            this.overallCPULoad});
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
            // ParticipantName
            // 
            this.ParticipantName.DataPropertyName = "ParticipantName";
            this.ParticipantName.HeaderText = "与会者";
            this.ParticipantName.Name = "ParticipantName";
            this.ParticipantName.ReadOnly = true;
            // 
            // ChannelName
            // 
            this.ChannelName.DataPropertyName = "ChannelName";
            this.ChannelName.HeaderText = "通道名称";
            this.ChannelName.Name = "ChannelName";
            this.ChannelName.ReadOnly = true;
            // 
            // VideoProtocol
            // 
            this.VideoProtocol.DataPropertyName = "VideoProtocol";
            this.VideoProtocol.HeaderText = "视频协议";
            this.VideoProtocol.Name = "VideoProtocol";
            this.VideoProtocol.ReadOnly = true;
            // 
            // ChannelNum
            // 
            this.ChannelNum.DataPropertyName = "ChannelNum";
            this.ChannelNum.HeaderText = "ssrc";
            this.ChannelNum.Name = "ChannelNum";
            this.ChannelNum.ReadOnly = true;
            // 
            // RemoteSystemId
            // 
            this.RemoteSystemId.DataPropertyName = "RemoteSystemId";
            this.RemoteSystemId.HeaderText = "远端系统Id";
            this.RemoteSystemId.Name = "RemoteSystemId";
            this.RemoteSystemId.ReadOnly = true;
            // 
            // CallRate
            // 
            this.CallRate.DataPropertyName = "CallRate";
            this.CallRate.HeaderText = "呼叫速率";
            this.CallRate.Name = "CallRate";
            this.CallRate.ReadOnly = true;
            // 
            // PacketsLost
            // 
            this.PacketsLost.DataPropertyName = "PacketsLost";
            this.PacketsLost.HeaderText = "已丢失的数据包";
            this.PacketsLost.Name = "PacketsLost";
            this.PacketsLost.ReadOnly = true;
            // 
            // PacketLoss
            // 
            this.PacketLoss.DataPropertyName = "PacketLoss";
            this.PacketLoss.HeaderText = "数据包丢失量";
            this.PacketLoss.Name = "PacketLoss";
            this.PacketLoss.ReadOnly = true;
            // 
            // VideoRate
            // 
            this.VideoRate.DataPropertyName = "VideoRate";
            this.VideoRate.HeaderText = "视频速率";
            this.VideoRate.Name = "VideoRate";
            this.VideoRate.ReadOnly = true;
            // 
            // VideoRateUsed
            // 
            this.VideoRateUsed.DataPropertyName = "VideoRateUsed";
            this.VideoRateUsed.HeaderText = "视频使用的速率";
            this.VideoRateUsed.Name = "VideoRateUsed";
            this.VideoRateUsed.ReadOnly = true;
            // 
            // VideoFrameRate
            // 
            this.VideoFrameRate.DataPropertyName = "VideoFrameRate";
            this.VideoFrameRate.HeaderText = "视频帧速率";
            this.VideoFrameRate.Name = "VideoFrameRate";
            this.VideoFrameRate.ReadOnly = true;
            // 
            // VideoPacketsLost
            // 
            this.VideoPacketsLost.DataPropertyName = "VideoPacketsLost";
            this.VideoPacketsLost.HeaderText = "已丢失的视频数据包";
            this.VideoPacketsLost.Name = "VideoPacketsLost";
            this.VideoPacketsLost.ReadOnly = true;
            // 
            // VideoJitter
            // 
            this.VideoJitter.DataPropertyName = "VideoJitter";
            this.VideoJitter.HeaderText = "视频抖动";
            this.VideoJitter.Name = "VideoJitter";
            this.VideoJitter.ReadOnly = true;
            // 
            // VideoFormat
            // 
            this.VideoFormat.DataPropertyName = "VideoFormat";
            this.VideoFormat.HeaderText = "视频格式";
            this.VideoFormat.Name = "VideoFormat";
            this.VideoFormat.ReadOnly = true;
            // 
            // ErrorConcealment
            // 
            this.ErrorConcealment.DataPropertyName = "ErrorConcealment";
            this.ErrorConcealment.HeaderText = "错误隐藏";
            this.ErrorConcealment.Name = "ErrorConcealment";
            this.ErrorConcealment.ReadOnly = true;
            // 
            // AudioProtocol
            // 
            this.AudioProtocol.DataPropertyName = "AudioProtocol";
            this.AudioProtocol.HeaderText = "视频协议";
            this.AudioProtocol.Name = "AudioProtocol";
            this.AudioProtocol.ReadOnly = true;
            // 
            // AudioRate
            // 
            this.AudioRate.DataPropertyName = "AudioRate";
            this.AudioRate.HeaderText = "音频速率";
            this.AudioRate.Name = "AudioRate";
            this.AudioRate.ReadOnly = true;
            // 
            // AudioPacketsLost
            // 
            this.AudioPacketsLost.DataPropertyName = "AudioPacketsLost";
            this.AudioPacketsLost.HeaderText = "已丢失的音频数据包";
            this.AudioPacketsLost.Name = "AudioPacketsLost";
            this.AudioPacketsLost.ReadOnly = true;
            // 
            // AudioJitter
            // 
            this.AudioJitter.DataPropertyName = "AudioJitter";
            this.AudioJitter.HeaderText = "音频抖动";
            this.AudioJitter.Name = "AudioJitter";
            this.AudioJitter.ReadOnly = true;
            // 
            // AudioEncrypt
            // 
            this.AudioEncrypt.DataPropertyName = "AudioEncrypt";
            this.AudioEncrypt.HeaderText = "音频已加密";
            this.AudioEncrypt.Name = "AudioEncrypt";
            this.AudioEncrypt.ReadOnly = true;
            // 
            // VideoEncrypt
            // 
            this.VideoEncrypt.DataPropertyName = "VideoEncrypt";
            this.VideoEncrypt.HeaderText = "视频已加密";
            this.VideoEncrypt.Name = "VideoEncrypt";
            this.VideoEncrypt.ReadOnly = true;
            // 
            // FeccEncrypt
            // 
            this.FeccEncrypt.DataPropertyName = "FeccEncrypt";
            this.FeccEncrypt.HeaderText = "运程控制已加密";
            this.FeccEncrypt.Name = "FeccEncrypt";
            this.FeccEncrypt.ReadOnly = true;
            // 
            // AudioReceivedPacket
            // 
            this.AudioReceivedPacket.DataPropertyName = "AudioReceivedPacket";
            this.AudioReceivedPacket.HeaderText = "已接收到的音频包";
            this.AudioReceivedPacket.Name = "AudioReceivedPacket";
            this.AudioReceivedPacket.ReadOnly = true;
            // 
            // oundTripTime
            // 
            this.oundTripTime.DataPropertyName = "RoundTripTime";
            this.oundTripTime.HeaderText = "往返时间R";
            this.oundTripTime.Name = "oundTripTime";
            this.oundTripTime.ReadOnly = true;
            // 
            // FullIntraFrameRequest
            // 
            this.FullIntraFrameRequest.DataPropertyName = "FullIntraFrameRequest";
            this.FullIntraFrameRequest.HeaderText = "全帧请求";
            this.FullIntraFrameRequest.Name = "FullIntraFrameRequest";
            this.FullIntraFrameRequest.ReadOnly = true;
            // 
            // IntraFrameSent
            // 
            this.IntraFrameSent.DataPropertyName = "IntraFrameSent";
            this.IntraFrameSent.HeaderText = "帧内发送";
            this.IntraFrameSent.Name = "IntraFrameSent";
            this.IntraFrameSent.ReadOnly = true;
            // 
            // PacketsCount
            // 
            this.PacketsCount.DataPropertyName = "PacketsCount";
            this.PacketsCount.HeaderText = "包总量";
            this.PacketsCount.Name = "PacketsCount";
            this.PacketsCount.ReadOnly = true;
            // 
            // overallCPULoad
            // 
            this.overallCPULoad.DataPropertyName = "OverallCPULoad";
            this.overallCPULoad.HeaderText = "CPU负载";
            this.overallCPULoad.Name = "overallCPULoad";
            this.overallCPULoad.ReadOnly = true;
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
            this.Load += new System.EventHandler(this.SignalPanel_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ParticipantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoProtocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemoteSystemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PacketsLost;
        private System.Windows.Forms.DataGridViewTextBoxColumn PacketLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoRateUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoFrameRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoPacketsLost;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoJitter;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorConcealment;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioProtocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioPacketsLost;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioJitter;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioEncrypt;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoEncrypt;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeccEncrypt;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioReceivedPacket;
        private System.Windows.Forms.DataGridViewTextBoxColumn oundTripTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullIntraFrameRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntraFrameSent;
        private System.Windows.Forms.DataGridViewTextBoxColumn PacketsCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn overallCPULoad;
    }
}
