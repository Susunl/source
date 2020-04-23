using System.Runtime.InteropServices;

namespace SuperSkill
{
    class ScanMemory1
    {
        public const int PROCESS_ALL_ACCESS = 2035711;
        [DllImport("kernel32.dll")]
        public static extern int OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("Psapi.dll")]
        public static unsafe extern bool EnumProcessModules(int hProcess, int*[] lphModule, int cb, int lpcbNeeded);
        //public static unsafe bool SearchMemory()
        //{
        //    int hProcess = OpenProcess(PROCESS_ALL_ACCESS, false, 全局变量.进程ID);
        //    if (hProcess == 0)
        //    {
        //        MessageBox.Show("请初始化", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    int*[] hModule = null;
        //    EnumProcessModules(全局变量.进程ID, hModule,hModule.Length,0);






        //}


    }
}
