using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReadWrite;
using SslnEngine;

namespace SuperSkill
{
    class 检测
    {
        [DllImport("kernel32.dll")]
        public static extern int GetModuleHandleA(string lpModuleName);
        [DllImport("kernel32.dll")]
        public static extern int GetModuleHandleExA(long dwFlags , string lpModuleName,int phModule);
        [DllImport("kernel32.dll")]
        public static extern bool IsBadReadPtr(int 参_内存地址,int 参_内存长度);
        [DllImport("kernel32.dll")]
        public static unsafe extern bool VirtualProtectEx(int handle, int address, int size, int flNewProtect, [Out] int* lpflOldProtect);
        [DllImport("Dll1.dll")]
        public static unsafe extern uint ListProcessModules(int handle, string name);
        public unsafe static int ASM_置可读写(int 进程句柄, int 内存地址, int 内存长度)
        {
            int 旧的保护 = 0;
            VirtualProtectEx(进程句柄, 内存地址, 内存长度, 64, &旧的保护);
            return 旧的保护;
        }
        public static unsafe void ASM_写字节集(int 参_内存地址, byte[] 参_写入数据)
        {
            if (IsBadReadPtr(参_内存地址, 1))
                return;
            ReadWriteCtr.WriteMemByteArray(0x400900, 参_写入数据);
            ASM_置可读写( -1, 参_内存地址, 参_写入数据.Length);
            ASM_字符传输(参_内存地址, 0x400900, 参_写入数据.Length);
        }
        public static unsafe void ASM_字符传输(int 内存地址, int 数值地址, int 写入长度)
        {
            Asm asm = new Asm();
            asm.Push_ESI();
            asm.Push_EDI();
            asm.Pushfd();
            asm.Cld();
            asm.Mov_EAX(写入长度);
            asm.Mov_ESI(数值地址);
            asm.Mov_EDI(内存地址);
            asm.Rep_Movsb();
            asm.Popfd();
            asm.Pop_EDI();
            asm.Pop_ESI();
            asm.RunAsm(全局变量.进程ID);
        }
        public static void 处理检测()
        {
            byte[] i1 = { 144, 144 };
            byte[] i2 = { 144, 144, 144, 144, 144 };
            byte[] i3 = { 0x31, 0xD2, 0x90 };
            byte[] i4 = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            byte[] i5 = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            byte[] i6 = { 0x90, 0x90, 0xE9, 0xEE, 0xFC, 0x83, 0x19, 0x90 };
            ReadWriteCtr.WriteMemByteArray(基址.伤害检测1, i1);
            ReadWriteCtr.WriteMemByteArray(基址.伤害检测2, i2);
            //uint i = ListProcessModules(全局变量.进程ID, "GDPImpl.dll");
            //uint j = ListProcessModules(全局变量.进程ID, "GameRpcs.dll");
            //ReadWriteCtr.WriteMemByteArray(j + 0x16595D, i3);
            //ReadWriteCtr.WriteMemByteArray(j + 0x4292B7, i3);
            //ReadWriteCtr.WriteMemByteArray(j + 0x1229F6, i3);
            //ReadWriteCtr.WriteMemByteArray(j + 0x1A72CD, i3);
            //ReadWriteCtr.WriteMemByteArray(j + 0x1BF2D7, i4);
            //ReadWriteCtr.WriteMemByteArray(j + 0x1B01EA, i5);
            //byte[] i7 = { 0x31, 0xD2 };
            //byte[] i8 = { 0xC3, 0x90, 0x90, 0x90, 0x90 };
            //byte[] i9 = { 0xC3 };
            //byte[] i10 = { 0x31, 0xD2, 0x90, 0x90, 0x90, 0x90 };
            //byte[] i11 = { 0x31, 0xC9, 0x90, 0x90, 0x90, 0x90 };
            //byte[] i12 = { 0X90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            //byte[] i13 = { 0x31, 0xC0, 0x90, 0x90, 0x90, 0x90 };
            //ReadWriteCtr.WriteMemByteArray(ListProcessModules(全局变量.进程ID, "GDPImpl.dll") + 0x19BEE7, i7);
            //ReadWriteCtr.WriteMemByteArray(ListProcessModules(全局变量.进程ID, "GDPImpl.dll") + 0x190D00, i8);
            //ReadWriteCtr.WriteMemByteArray(ListProcessModules(全局变量.进程ID, "GDPImpl.dll") + 0x1A6F90, i9);
            //ReadWriteCtr.WriteMemByteArray(ListProcessModules(全局变量.进程ID, "GDPImpl.dll") + 0x1AFE30, i8);
            //ReadWriteCtr.WriteMemByteArray(ListProcessModules(全局变量.进程ID, "GDPImpl.dll") + 0x19E440, i9);
            //ReadWriteCtr.WriteMemByteArray(ListProcessModules(全局变量.进程ID, "GDPImpl.dll") + 0x198AE0, i9);
            //ReadWriteCtr.WriteMemByteArray(ListProcessModules(全局变量.进程ID, "GDPImpl.dll") + 0x1B0690, i9);
            //ReadWriteCtr.WriteMemByteArray(ListProcessModules(全局变量.进程ID, "GDPImpl.dll") + 0x1A1C00, i8);
            //ReadWriteCtr.WriteMemByteArray(ListProcessModules(全局变量.进程ID, "GDPImpl.dll") + 0x11FDB0, i8);
            //ReadWriteCtr.WriteMemByteArray(ListProcessModules(全局变量.进程ID, "GDPImpl.dll") + 0x135510, i8);
            //ReadWriteCtr.WriteMemByteArray(ListProcessModules(全局变量.进程ID, "GDPImpl.dll") + 0x1B07B0, i8);
            //ReadWriteCtr.WriteMemByteArray(ListProcessModules(全局变量.进程ID, "GDPImpl.dll") + 0x1B0724, i10);
            //ReadWriteCtr.WriteMemByteArray(ListProcessModules(全局变量.进程ID, "GDPImpl.dll") + 0x1986A8, i11);
            //ReadWriteCtr.WriteMemByteArray(ListProcessModules(全局变量.进程ID, "GDPImpl.dll") + 0x1986B1, i10);
            //ReadWriteCtr.WriteMemByteArray(ListProcessModules(全局变量.进程ID, "GDPImpl.dll") + 0x198660, i12);
            //ReadWriteCtr.WriteMemByteArray(ListProcessModules(全局变量.进程ID, "GDPImpl.dll") + 0x198719, i13);

            //ReadWriteCtr.WriteMemByteArray(0x4ACDB86, i2);
            //ReadWriteCtr.WriteMemByteArray(0x5E420FD, i2);
            //ReadWriteCtr.WriteMemByteArray(0x5E3B5CB, i1);
            //ReadWriteCtr.WriteMemByteArray(0x54DE3E6, i2);
            //ReadWriteCtr.WriteMemByteArray(0x54DE3CF, i1);
            //ReadWriteCtr.WriteMemByteArray(0x55562F5, i2);
            //ReadWriteCtr.WriteMemByteArray(0x5E31954, i2);
            //ReadWriteCtr.WriteMemByteArray(0x5E3D309, i2);
            //ReadWriteCtr.WriteMemByteArray(0x5E35412, i2);
            //ReadWriteCtr.WriteMemByteArray(0x5E35B95, i2);
            //ReadWriteCtr.WriteMemByteArray(0x5E36D02, i2);
            //ReadWriteCtr.WriteMemByteArray(0x5500C2C, i2);
            //ReadWriteCtr.WriteMemByteArray(0x54FD884, i2);
            //ReadWriteCtr.WriteMemByteArray(0x5E407F5, i2);
            //ReadWriteCtr.WriteMemByteArray(0x5E34996, i2);
            //ReadWriteCtr.WriteMemByteArray(0x5E30517, i2);
            //ReadWriteCtr.WriteMemByteArray(0x5E38AE0, i2);
            //ReadWriteCtr.WriteMemByteArray(0x5E43B4F, i2);
            //ReadWriteCtr.WriteMemByteArray(0x5E38379, i2);
            //ReadWriteCtr.WriteMemByteArray(0x5E4350C, i2);
            //ReadWriteCtr.WriteMemByteArray(0x5E3675B, i2);
            //ReadWriteCtr.WriteMemByteArray(0x5E3D733, i2);
            //ReadWriteCtr.WriteMemByteArray(0x5E359D8, i2);

            //ReadWriteCtr.WriteMemByteArray(0x538322E, i3);
            //ReadWriteCtr.WriteMemByteArray(0x55D5E8C, i3);
            //ReadWriteCtr.WriteMemByteArray(0x55D5EA6, i3);
            //ReadWriteCtr.WriteMemByteArray(0x55D5EBE, i3);

            //MessageBox.Show(Convert.ToString(ReadWriteCtr.ReadMemInt(0x400400)), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //ReadWriteCtr.WriteMemByteArray(0x55D5ED6, i3);
            //ReadWriteCtr.WriteMemByteArray(0x55D5EEE, i3);
            //ReadWriteCtr.WriteMemByteArray(0x55D5F08, i3);
            //ReadWriteCtr.WriteMemByteArray(0x55D5F20, i3);
            //ReadWriteCtr.WriteMemByteArray(0x55D5F38, i3);
            //ReadWriteCtr.WriteMemByteArray(0x55D5F50, i3);
            //ReadWriteCtr.WriteMemByteArray(0x55D5F68, i3);
            //ReadWriteCtr.WriteMemByteArray(0x55D5F81, i3);
            //ReadWriteCtr.WriteMemByteArray(0x55D5F9A, i3);
            //ReadWriteCtr.WriteMemByteArray(0x55D5FB3, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C48229, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C4842D, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C498E9, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C49AAA, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C4BB13, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C4E74C, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C4EA56, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C4F2D3, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C4F750, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C50CD2, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C51357, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C51A49, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C51C61, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C524BE, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C52957, i3);


            //ReadWriteCtr.WriteMemByteArray(0x5C52A9B, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C52C92, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C53540, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C536CF, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C5474E, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C54F09, i3);
            //ReadWriteCtr.WriteMemByteArray(0x5C5555A, i3);

            //MessageBox.Show("检测处理完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            功能.公告("欢迎使用大佬赞助版本");
            功能.公告("大佬牛逼!!!!谢谢大佬");
            功能.公告("伤害检测处理完毕");

        }

    }
}
