namespace MessageServer
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using ZhenziSms;

    public class Server
    {
        public string ipString = "127.0.0.1";   // 服务器端ip
        public int port = 37280;                // 服务器端口

        public Socket socket;
        public Print print;                     // 运行时的信息输出方法

        public Dictionary<string, Socket> clients = new Dictionary<string, Socket>();   // 存储连接到服务器的客户端信息
        public bool started = false;            // 标识当前是否启动了服务

        public Server(Print print = null, string ipString = null, int port = -1)
        {
            this.print = print;
            if (ipString != null) this.ipString = ipString;
            if (port >= 0) this.port = port;
        }

        public Server(Print print = null, string ipString = null, string port = "-1")
        {
            this.print = print;
            if (ipString != null) this.ipString = ipString;

            int port_int = Int32.Parse(port);
            if (port_int >= 0) this.port = port_int;
        }

        /// <summary>
        /// Print用于输出Server的输出信息
        /// </summary>
        public delegate void Print(string info);

        /// <summary>
        /// 启动服务
        /// </summary>
        public void start()
        {
            try
            {
                IPAddress address = IPAddress.Parse(ipString);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(new IPEndPoint(address, port));
                socket.Listen(10000);

                if (print != null)
                {
                    try { print("启动服务【" + socket.LocalEndPoint.ToString() + "】成功"); }
                    catch { print = null; }
                }
                started = true;

                new Thread(listenClientConnect).Start(socket);  // 在新的线程中监听客户端连接
            }
            catch (Exception exception)
            {
                if (print != null)
                {
                    print("启动服务失败 " + exception.ToString());
                }
                started = false;
            }
        }

        /// <summary>
        /// 监听客户端的连接
        /// </summary>
        private void listenClientConnect(object obj)
        {
            Socket socket = (Socket)obj;
            while (true)
            {
                Socket clientScoket = socket.Accept();
                print?.Invoke("客户端" + clientScoket.RemoteEndPoint.ToString() + "已连接");
                new Thread(receiveData).Start(clientScoket);   // 在新的线程中接收客户端信息

                Thread.Sleep(1000);                            // 延时1秒后，接收连接请求
                if (!started) return;
            }
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        public void Send(string info, string id)
        {
            if (clients.ContainsKey(id))
            {
                Socket socket = clients[id];

                try
                {
                    Send(socket, info);
                }
                catch (Exception ex)
                {
                    clients.Remove(id);
                    if (print != null) print("客户端已断开，【" + id + "】");
                }
            }
        }

        /// <summary>
        /// 通过socket发送数据data
        /// </summary>
        private void Send(Socket socket, string data)
        {
            if (socket != null && data != null && !data.Equals(""))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(data);   // 将data转化为byte数组
                socket.Send(bytes);                            // 
            }
        }

        private string clientIp = "";
        /// <summary>
        /// 输出Server的输出信息到客户端
        /// </summary>
        public void PrintOnClient(string info)
        {
            Send(info, clientIp);
        }

        /// <summary>
        /// 接收通过socket发送过来的数据
        /// </summary>
        private void receiveData(object obj)
        {
            Socket socket = (Socket)obj;
            string clientIp = socket.RemoteEndPoint.ToString();                 // 获取客户端标识 ip和端口
            if (!clients.ContainsKey(clientIp)) clients.Add(clientIp, socket);  // 将连接的客户端socket添加到clients中保存
            else clients[clientIp] = socket;

            while (true)
            {
                try
                {
                    string str = Receive(socket);
                    //byte[] byteArray = Encoding.Default.GetBytes(str);
                    //string str1 = Encoding.ASCII.GetString(byteArray);
                    if (!str.Equals(""))
                    {
                        if (str.Equals("[.Echo]"))
                        {
                            this.clientIp = clientIp;
                            print = new Print(PrintOnClient);     // 在客户端显示服务器输出信息
                        }
                        print?.Invoke("【" + clientIp + "】" + str);

                        try
                        {
                            string[] str_arr = str.Split(new string[6] { "\r\n湿度为", " ％RH ，温度为 ", "℃ \r\nCO浓度值为 ", " \r\n甲醛浓度值为", "\r\nPM2.5浓度值为", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                            Dictionary<string, Dictionary<string, string>> dic = new Dictionary<string, Dictionary<string, string>>()
                            {
                                { "TAHS",new Dictionary<string, string>()
                                    {
                                        { "H",str_arr[0]},
                                        { "T",str_arr[1]},
                                    }
                                },
                                { "CO",new Dictionary<string, string>()
                                    {
                                        { "CON",str_arr[2]},
                                    }
                                },
                                { "HCHO",new Dictionary<string, string>()
                                    {
                                        { "CON",str_arr[3]},
                                    }
                                },
                                { "PM10",new Dictionary<string, string>()
                                    {
                                        { "CON",str_arr[4]},
                                    }
                                },
                            };
                            string Jsondata = JsonConvert.SerializeObject(dic);
                            print?.Invoke(Jsondata);
                            string i = json.Post("data=" + Jsondata);
                            //json.Post("http://127.0.0.1/xb/api.php?action=update", Jsondata);
                            print?.Invoke(i);
                            if (Convert.ToSingle(str_arr[2]) > 200&&全局变量.可燃气体 == true)
                            {
                                string tmp = "尊敬的刘星宇先生，检测到您的智能家居环境空气质量出现问题，可燃气体浓度超标,当前浓度为:" + str_arr[2] + "PPM,请及时开门开窗，进行通风处理";
                                sendMessage("13709002740", tmp);
                                全局变量.可燃气体 = false;
                            }
                            if (Convert.ToSingle(str_arr[3]) > 200 && 全局变量.甲醛 == true)
                            {
                                string tmp = "尊敬的刘星宇先生，检测到您的智能家居环境空气质量出现问题，甲醛浓度超标,当前浓度为:" + str_arr[3] + "PPM,请及时开门开窗，进行通风处理";
                                sendMessage("13709002740", tmp);
                                全局变量.甲醛 = false;
                            }
                            if (Convert.ToSingle(str_arr[4]) > 200 && 全局变量.PM2_5 == true)
                            {
                                string tmp = "尊敬的刘星宇先生，检测到您的智能家居环境空气质量出现问题，PM2.5浓度超标,当前浓度为:" + str_arr[4] + "ug/m3,请及时开门开窗，进行通风处理";
                                sendMessage("13709002740", tmp);
                                全局变量.PM2_5 = false;
                            }
                        }
                        catch
                        {
                        }

                        if (str.Equals("[.Shutdown]")) Environment.Exit(0); // 服务器退出
                        else if (str.StartsWith("[.RunCmd]")) runCMD(str);  // 执行cmd命令
                    }
                }
                catch (Exception exception)
                {
                    if (print != null) print("连接已自动断开，【" + clientIp + "】" + exception.Message);

                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();

                    if (clients.ContainsKey(clientIp)) clients.Remove(clientIp);
                    return;
                }

                if (!started) return;
                Thread.Sleep(200);      // 延时0.2秒后再接收客户端发送的消息
            }
        }

        /// <summary>
        /// 执行cmd命令
        /// </summary>
        private void runCMD(string cmd)
        {
            new Thread(runCMD_0).Start(cmd);
        }

        /// <summary>
        /// 执行cmd命令
        /// </summary>
        private void runCMD_0(object obj)
        {
            string cmd = (string)obj;
            string START = "[.RunCmd]";
            if (cmd.StartsWith(START))
            {
                cmd = cmd.Substring(START.Length);  // 获取cmd信息
                Cmd.Run(cmd, print);                // 执行cmd，输出执行结果到print
            }
        }

        /// <summary>
        /// 从socket接收数据
        /// </summary>
        private string Receive(Socket socket)
        {
            string data = "";

            byte[] bytes = null;
            int len = socket.Available;
            if (len > 0)
            {
                bytes = new byte[len];
                int receiveNumber = socket.Receive(bytes);
                data = Encoding.Default.GetString(bytes, 0, receiveNumber);
            }

            return data;
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        public void stop()
        {
            started = false;
        }
        public static string sendMessage(string number, string message)
        {
            var client = new ZhenziSmsClient("https://sms_developer.zhenzikj.com", "105728", "8c406a59-e02e-45e2-a6d6-256b8b17e5be");
            var parameters = new Dictionary<string, string>();
            parameters.Add("message", message);
            parameters.Add("number", number);
            //parameters.Add("clientIp", "792.168.2.222");
            //parameters.Add("messageId", "");
            var result = client.Send(parameters);
            return result;
        }
    }
}
