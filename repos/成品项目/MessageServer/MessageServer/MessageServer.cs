using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZhenziSms;

namespace MessageServer
{
    public partial class MessageServer : Form
    {
        Server server;

        public MessageServer()
        {
            InitializeComponent();
        }

        // 启动服务
        private void button_start_Click(object sender, EventArgs e)
        {
            if (server == null) server = new Server(SeverPrint, textBox_Ip.Text, textBox_Port.Text);
            if (!server.started) server.start();
        }

        // 服务器端输出信息
        private void SeverPrint(string info)
        {
            if (textBox_showing.IsDisposed) server.print = null;
            else
            {
                if (textBox_showing.InvokeRequired)
                {
                    Server.Print F = new Server.Print(SeverPrint);
                    this.Invoke(F, new object[] { info });
                }
                else
                {
                    if (info != null)
                    {
                        textBox_showing.SelectionColor = Color.Green;
                        textBox_showing.AppendText(info);
                        textBox_showing.AppendText(Environment.NewLine);
                        textBox_showing.ScrollToCaret();
                    }
                }
            }
        }

        // 发送信息到客户端
        private void button_send_Click(object sender, EventArgs e)
        {
            if (server != null) server.Send(textBox_send.Text, comboBox_clients.Text);
        }

        private void MessageServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        // 选择客户端时，更新客户端列表信息
        private void comboBox_clients_DropDown(object sender, EventArgs e)
        {
            if (server != null)
            {
                List<string> clientList = server.clients.Keys.ToList<string>();
                comboBox_clients.DataSource = clientList;
            }
        }

        private void MessageServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new ZhenziSmsClient("https://sms_developer.zhenzikj.com", "105728", "8c406a59-e02e-45e2-a6d6-256b8b17e5be");
            string i = "尊敬的刘星宇先生，检测到您的智能家居环境空气质量出现问题，甲醛浓度超标，请及时开门开窗，进行通风处理";
            var parameters = new Dictionary<string, string>();
            parameters.Add("message", i);
            parameters.Add("number", "13709002740");
            //parameters.Add("clientIp", "792.168.2.222");
            //parameters.Add("messageId", "");
            var result = client.Send(parameters);
            MessageBox.Show(result);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            全局变量.PM2_5 = true;
            全局变量.可燃气体 = true;
            全局变量.甲醛 = true;
        }

        private void MessageServer_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
