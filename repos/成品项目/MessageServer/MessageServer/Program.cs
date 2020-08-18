using System;
using System.Windows.Forms;

namespace MessageServer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            if (args.Length > 1)    // 通过命令行参数启动服务,如： call "%~dp0MessageServer.exe" 127.0.0.1 37280
            {
                new Server(null, args[0], args[1]).start();
            }
            else
            {   // 通过windows窗体启动服务
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MessageServer());
            }
        }
    }
}
