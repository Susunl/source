namespace MessageServer
{
    partial class MessageServer
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
            this.components = new System.ComponentModel.Container();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_Ip = new System.Windows.Forms.TextBox();
            this.button_start = new System.Windows.Forms.Button();
            this.textBox_send = new System.Windows.Forms.TextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.comboBox_clients = new System.Windows.Forms.ComboBox();
            this.label_clientIp = new System.Windows.Forms.Label();
            this.textBox_showing = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // textBox_Port
            // 
            this.textBox_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Port.Location = new System.Drawing.Point(407, 3);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(49, 21);
            this.textBox_Port.TabIndex = 19;
            this.textBox_Port.Text = "8080";
            // 
            // textBox_Ip
            // 
            this.textBox_Ip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Ip.Location = new System.Drawing.Point(84, 3);
            this.textBox_Ip.Name = "textBox_Ip";
            this.textBox_Ip.Size = new System.Drawing.Size(317, 21);
            this.textBox_Ip.TabIndex = 18;
            this.textBox_Ip.Text = "192.168.199.154";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(3, 3);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 17;
            this.button_start.Text = "启动服务";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // textBox_send
            // 
            this.textBox_send.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_send.Location = new System.Drawing.Point(3, 357);
            this.textBox_send.Multiline = true;
            this.textBox_send.Name = "textBox_send";
            this.textBox_send.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_send.Size = new System.Drawing.Size(453, 37);
            this.textBox_send.TabIndex = 16;
            // 
            // button_send
            // 
            this.button_send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_send.Location = new System.Drawing.Point(381, 396);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(75, 23);
            this.button_send.TabIndex = 15;
            this.button_send.Text = "发送信息";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // comboBox_clients
            // 
            this.comboBox_clients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_clients.FormattingEnabled = true;
            this.comboBox_clients.Location = new System.Drawing.Point(73, 396);
            this.comboBox_clients.Name = "comboBox_clients";
            this.comboBox_clients.Size = new System.Drawing.Size(302, 20);
            this.comboBox_clients.TabIndex = 20;
            this.comboBox_clients.DropDown += new System.EventHandler(this.comboBox_clients_DropDown);
            // 
            // label_clientIp
            // 
            this.label_clientIp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_clientIp.AutoSize = true;
            this.label_clientIp.Location = new System.Drawing.Point(1, 399);
            this.label_clientIp.Name = "label_clientIp";
            this.label_clientIp.Size = new System.Drawing.Size(65, 12);
            this.label_clientIp.TabIndex = 21;
            this.label_clientIp.Text = "选择客户端";
            // 
            // textBox_showing
            // 
            this.textBox_showing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_showing.Location = new System.Drawing.Point(12, 30);
            this.textBox_showing.Name = "textBox_showing";
            this.textBox_showing.Size = new System.Drawing.Size(372, 327);
            this.textBox_showing.TabIndex = 22;
            this.textBox_showing.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 600000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MessageServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 420);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_showing);
            this.Controls.Add(this.label_clientIp);
            this.Controls.Add(this.comboBox_clients);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_Ip);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.textBox_send);
            this.Controls.Add(this.button_send);
            this.Name = "MessageServer";
            this.ShowInTaskbar = false;
            this.Text = "服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessageServer_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MessageServer_FormClosed);
            this.Load += new System.EventHandler(this.MessageServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_Ip;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.TextBox textBox_send;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.ComboBox comboBox_clients;
        private System.Windows.Forms.Label label_clientIp;
        private System.Windows.Forms.RichTextBox textBox_showing;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
    }
}

