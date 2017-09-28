namespace UDPClient
{
    partial class frmUdp
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocalIp = new System.Windows.Forms.TextBox();
            this.txtLocalPort = new System.Windows.Forms.TextBox();
            this.txtRemoteIp = new System.Windows.Forms.TextBox();
            this.txtRemotePort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnReceive = new System.Windows.Forms.Button();
            this.listBoxView = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "本地IP：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "远程IP：";
            // 
            // txtLocalIp
            // 
            this.txtLocalIp.Location = new System.Drawing.Point(93, 31);
            this.txtLocalIp.Name = "txtLocalIp";
            this.txtLocalIp.Size = new System.Drawing.Size(132, 21);
            this.txtLocalIp.TabIndex = 2;
            // 
            // txtLocalPort
            // 
            this.txtLocalPort.Location = new System.Drawing.Point(266, 31);
            this.txtLocalPort.Name = "txtLocalPort";
            this.txtLocalPort.Size = new System.Drawing.Size(50, 21);
            this.txtLocalPort.TabIndex = 3;
            // 
            // txtRemoteIp
            // 
            this.txtRemoteIp.Location = new System.Drawing.Point(93, 68);
            this.txtRemoteIp.Name = "txtRemoteIp";
            this.txtRemoteIp.Size = new System.Drawing.Size(132, 21);
            this.txtRemoteIp.TabIndex = 4;
            // 
            // txtRemotePort
            // 
            this.txtRemotePort.Location = new System.Drawing.Point(266, 68);
            this.txtRemotePort.Name = "txtRemotePort";
            this.txtRemotePort.Size = new System.Drawing.Size(50, 21);
            this.txtRemotePort.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "：";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(34, 119);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "匿名";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(90, 114);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(165, 21);
            this.txtMessage.TabIndex = 9;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(261, 112);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(32, 155);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(145, 155);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnReceive
            // 
            this.btnReceive.Location = new System.Drawing.Point(261, 155);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(75, 23);
            this.btnReceive.TabIndex = 13;
            this.btnReceive.Text = "接收";
            this.btnReceive.UseVisualStyleBackColor = true;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // listBoxView
            // 
            this.listBoxView.FormattingEnabled = true;
            this.listBoxView.ItemHeight = 12;
            this.listBoxView.Location = new System.Drawing.Point(32, 194);
            this.listBoxView.Name = "listBoxView";
            this.listBoxView.Size = new System.Drawing.Size(302, 112);
            this.listBoxView.TabIndex = 14;
            // 
            // frmUdp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 322);
            this.Controls.Add(this.listBoxView);
            this.Controls.Add(this.btnReceive);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRemotePort);
            this.Controls.Add(this.txtRemoteIp);
            this.Controls.Add(this.txtLocalPort);
            this.Controls.Add(this.txtLocalIp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmUdp";
            this.Text = "UDP测试";
            this.Load += new System.EventHandler(this.frmUdp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocalIp;
        private System.Windows.Forms.TextBox txtLocalPort;
        private System.Windows.Forms.TextBox txtRemoteIp;
        private System.Windows.Forms.TextBox txtRemotePort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.ListBox listBoxView;
    }
}

