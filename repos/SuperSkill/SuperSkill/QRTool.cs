using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRTool
{
    /// <summary>
    /// QRTool.DependentFiles.LoadResourceDll();       // 载入资源dll文件
    /// </summary>
    class DependentFiles
    {
        /// <summary>
        /// 载入资源文件中附带的所有dll文件
        /// </summary>
        public static void LoadResourceDll()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }

        private static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");
            if (dllName.EndsWith("_resources")) return null;
            string Namespace = Assembly.GetEntryAssembly().GetTypes()[0].Namespace;
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            byte[] bytes = (byte[])rm.GetObject(dllName);
            return System.Reflection.Assembly.Load(bytes);
        }

    }

}