using System;
using System.Diagnostics;

namespace MessageServer
{
    /// <summary>
    /// 执行CMD命令，或以进程的形式打开应用程序（d:\*.exe）
    /// </summary>
    public class Cmd
    {
        /// <summary>
        /// 以后台进程的形式执行应用程序（d:\*.exe）
        /// </summary>
        public static Process newProcess(String exe)
        {
            Process P = new Process();
            P.StartInfo.CreateNoWindow = true;
            P.StartInfo.FileName = exe;
            P.StartInfo.UseShellExecute = false;
            P.StartInfo.RedirectStandardError = true;
            P.StartInfo.RedirectStandardInput = true;
            P.StartInfo.RedirectStandardOutput = true;
            //P.StartInfo.WorkingDirectory = @"C:\windows\system32";
            P.Start();
            return P;
        }

        /// <summary>
        /// 执行CMD命令
        /// </summary>
        public static string Run(string cmd)
        {
            Process P = newProcess("cmd.exe");
            P.StandardInput.WriteLine(cmd);
            P.StandardInput.WriteLine("exit");
            string outStr = P.StandardOutput.ReadToEnd();
            P.Close();
            return outStr;
        }

        /// <summary>
        /// 定义委托接口处理函数，用于实时处理cmd输出信息
        /// </summary>
        public delegate void Callback(String line);

        ///// <summary>
        ///// 此函数用于实时显示cmd输出信息, Callback示例
        ///// </summary>
        //private void Callback1(String line)
        //{
        //    textBox1.AppendText(line);
        //    textBox1.AppendText(Environment.NewLine);
        //    textBox1.ScrollToCaret();

        //    richTextBox1.SelectionColor = Color.Green;
        //    richTextBox1.AppendText(line);
        //    richTextBox1.AppendText(Environment.NewLine);
        //    richTextBox1.ScrollToCaret();
        //}


        /// <summary>
        /// 执行CMD语句,实时获取cmd输出结果，输出到call函数中
        /// </summary>
        /// <param name="cmd">要执行的CMD命令</param>
        public static string Run(string cmd, Server.Print call)
        {
            String CMD_FILE = "cmd.exe"; // 执行cmd命令

            Process P = newProcess(CMD_FILE);
            P.StandardInput.WriteLine(cmd);
            P.StandardInput.WriteLine("exit");

            string outStr = "";
            string line = "";
            string baseDir = System.AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');

            try
            {
                for (int i = 0; i < 3; i++) P.StandardOutput.ReadLine();

                while ((line = P.StandardOutput.ReadLine()) != null || ((line = P.StandardError.ReadToEnd()) != null && !line.Trim().Equals("")))
                {
                    // cmd运行输出信息
                    if (!line.EndsWith(">exit") && !line.Equals(""))
                    {
                        if (line.StartsWith(baseDir + ">")) line = line.Replace(baseDir + ">", "cmd>\r\n"); // 识别的cmd命令行信息
                        line = ((line.Contains("[Fatal Error]") || line.Contains("ERROR:") || line.Contains("Exception")) ? "【E】 " : "") + line;
                        if (call != null) call(line);
                        outStr += line + "\r\n";
                    }
                }
            }
            catch (Exception ex)
            {
                if (call != null) call(ex.Message);
                //MessageBox.Show(ex.Message);
            }

            P.WaitForExit();
            P.Close();

            return outStr;
        }


        /// <summary>
        /// 以进程的形式打开应用程序（d:\*.exe）,并执行命令
        /// </summary>
        public static void RunProgram(string programName, string cmd)
        {
            Process P = newProcess(programName);
            if (cmd.Length != 0)
            {
                P.StandardInput.WriteLine(cmd);
            }
            P.Close();
        }


        /// <summary>
        /// 正常启动window应用程序（d:\*.exe）
        /// </summary>
        public static void Open(String exe)
        {
            System.Diagnostics.Process.Start(exe);
        }

        /// <summary>
        /// 正常启动window应用程序（d:\*.exe）,并传递初始命令参数
        /// </summary>
        public static void Open(String exe, String args)
        {
            System.Diagnostics.Process.Start(exe, args);
        }
    }
}
