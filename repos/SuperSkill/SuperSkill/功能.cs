using EncryptionDecrypt;
using ReadWrite;
using SslnEngine;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Transform;

namespace SuperSkill
{
    public class 功能
    {
        [DllImport("Dll1.dll")]
        public static extern int SearchMemory(int 进程ID, byte[] buffer, int buffer_size);
        [DllImport("Dll1.dll")]
        public static unsafe extern int SearchMemory2(int 进程ID, int* buffer, int buffer_size);
        public static bool BytesCompare_Base64(byte[] b1, byte[] b2)
        {
            //if (b1 == null || b2 == null) return false;
            //if (b1.Length != b2.Length) return false;
            return string.Compare(Convert.ToBase64String(b1), Convert.ToBase64String(b2), false) == 0 ? true : false;
        }
        public static void 超级三速(int 移动速度)
        {
            int i;
            i = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, 基址.人物基址) + 基址.上衣偏移);
            EncDec.超级加密(i + (int)基址.攻击速度, 1500);
            EncDec.超级加密(i + (int)基址.释放速度, 1500);
            if (移动速度 == 0)
                EncDec.超级加密(i + (int)基址.移动速度, 1500);
            else
                EncDec.超级加密(i + (int)基址.移动速度, 移动速度);
            内存按键(319);
            call.Delay(50);
            内存按键(319);
            公告("超级三速和评分开启成功");
            //MessageBox.Show(Convert.ToString(i), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void 超音速加速()
        {
            byte[] i1 = { 216, 5, 0, 11, 64, 0 };
            byte[] i2 = { 0, 0, 48, 65, 209, 158, 30, 109, 208, 99, 58, 121, 26, 255, 204, 81, 226, 108, 174, 95, 101, 107, 0, 95, 47, 84, 16, 98, 159, 82, 26, 34, 13, 0, 10, 0, 200, 143, 64, 119, 96, 79, 109, 81, 178, 78, 13, 78, 164, 139, 132, 118, 101, 107, 16, 79, 119, 141, 222, 152, 39, 84, 26, 34, 0, 0, 204, 204, 204, 204 };
            ReadWriteCtr.WriteMemByteArray(基址.超音速加速A, i1);
            ReadWriteCtr.WriteMemByteArray(0x400b00, i2);
            公告("城镇加速开启成功");
        }
        public static void 超音速加速DisAble()
        {
            byte[] i1 = { 216, 5, 44, 71, 45, 5 };
            byte[] i2 = { 0, 0, 48, 65, 209, 158, 30, 109, 208, 99, 58, 121, 26, 255, 204, 81, 226, 108, 174, 95, 101, 107, 0, 95, 47, 84, 16, 98, 159, 82, 26, 34, 13, 0, 10, 0, 200, 143, 64, 119, 96, 79, 109, 81, 178, 78, 13, 78, 164, 139, 132, 118, 101, 107, 16, 79, 119, 141, 222, 152, 39, 84, 26, 34, 0, 0, 204, 204, 204, 204 };
            byte[] RAsm = new byte[i2.Length];
            ReadWriteCtr.WriteMemByteArray(基址.超音速加速A, i1);
            ReadWriteCtr.WriteMemByteArray(0x400b00, RAsm);
            公告("城镇加速关闭成功");
        }
        public static void 超级三速DisAble()
        {
            int i;
            i = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, 基址.人物基址) + 基址.上衣偏移);
            EncDec.超级加密(i + (int)基址.攻击速度, 0);
            EncDec.超级加密(i + (int)基址.释放速度, 0);
            EncDec.超级加密(i + (int)基址.移动速度, 0);
            内存按键(319);
            call.Delay(50);
            内存按键(319);
            公告("超级三速和评分关闭成功");
            //MessageBox.Show(Convert.ToString(i), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void 技能无CD()
        {
            uint i = 0x4300, 技能地址;
            string 技能名称 = "";
            int 技能等级;
            string 总技能 = "";
            while (i <= 0x5000)
            {
                技能地址 = (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, 基址.人物基址) + i);
                技能等级 = (int)EncDec.Decrypt(全局变量.进程ID, 技能地址 + 基址.技能等级, 基址.解密基址);
                if (技能等级 >= 0 && 技能等级 < 100)
                {
                    int 技能CD = (int)EncDec.Decrypt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却7) + 8 * (uint)(技能等级 - 1), 基址.解密基址);
                    技能名称 = TransCtr.UnicodeToAnsi(ReadWriteCtr.ReadMemByteArray(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能名称), 50));
                    if (技能名称.Length > 1 && 技能名称.IndexOf("?") == -1 && 技能名称.IndexOf("不使用") == -1 && 总技能.IndexOf(技能名称) == -1 && 技能等级 > 0 && 技能CD > 2000)
                    {
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却1) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却2) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却3) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却4) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却5) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却6) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却7) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却8) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却9) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却10) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却11) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却12) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        //EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址 + 基址.技能冷却13) + 8 * (uint)(技能等级 - 1)), 技能CD * 10);
                        //EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址 + 基址.技能冷却14) + 8 * (uint)(技能等级 - 1)), 技能CD * 10);
                    }
                }
                i += 4;
            }
            公告("技能CD修改完毕");
        }
        public static void 技能无CDDisAble()
        {
            uint i = 0x4300, 技能地址;
            string 技能名称 = "";
            int 技能等级;
            string 总技能 = "";
            while (i <= 0x5000)
            {
                技能地址 = (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, 基址.人物基址) + i);
                技能等级 = (int)EncDec.Decrypt(全局变量.进程ID, 技能地址 + 基址.技能等级, 基址.解密基址);
                if (技能等级 >= 0 && 技能等级 < 100)
                {
                    int 技能CD = (int)EncDec.Decrypt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却7) + 8 * (uint)(技能等级 - 1), 基址.解密基址);
                    技能名称 = TransCtr.UnicodeToAnsi(ReadWriteCtr.ReadMemByteArray(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能名称), 50));
                    if (技能名称.Length > 1 && 技能名称.IndexOf("?") == -1 && 技能名称.IndexOf("不使用") == -1 && 总技能.IndexOf(技能名称) == -1 && 技能等级 > 0)
                    {
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却1) + 8 * (uint)(技能等级 - 1)), 技能CD * 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却2) + 8 * (uint)(技能等级 - 1)), 技能CD * 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却3) + 8 * (uint)(技能等级 - 1)), 技能CD * 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却4) + 8 * (uint)(技能等级 - 1)), 技能CD * 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却5) + 8 * (uint)(技能等级 - 1)), 技能CD * 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却6) + 8 * (uint)(技能等级 - 1)), 技能CD * 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却7) + 8 * (uint)(技能等级 - 1)), 技能CD * 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却8) + 8 * (uint)(技能等级 - 1)), 技能CD * 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却9) + 8 * (uint)(技能等级 - 1)), 技能CD * 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却10) + 8 * (uint)(技能等级 - 1)), 技能CD * 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却11) + 8 * (uint)(技能等级 - 1)), 技能CD * 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却12) + 8 * (uint)(技能等级 - 1)), 技能CD * 10);
                        //EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址 + 基址.技能冷却13) + 8 * (uint)(技能等级 - 1)), 技能CD * 10);
                        //EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址 + 基址.技能冷却14) + 8 * (uint)(技能等级 - 1)), 技能CD * 10);
                    }
                }
                i += 4;
            }
        }
        public static void 一键评分()
        {
            int 地址;
            地址 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, 基址.评分基址);
            ReadWriteCtr.WriteMemInt(全局变量.进程ID, (uint)(地址 + 基址.C_E_评分), 123456);
        }
        public static void 全屏吸物()
        {
            int 人物地址;
            int 地图地址;
            int 对象数量;
            int Time = 0;
            int OBJ数据;
            int OBJ类型;
            int x;
            int y;
            if (判断_游戏状态() == 3)
            {
                ReadWriteCtr.WriteMemInt(全局变量.进程ID, 基址.自动捡物, 1300955444);
                人物地址 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, 基址.人物基址);
                地图地址 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(人物地址) + 基址.地图偏移);
                对象数量 = (ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(地图地址 + 基址.尾地址)) - ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(地图地址 + 基址.首地址))) / 4;
                for (int i = 1; i <= 对象数量; i++)
                {
                    OBJ数据 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(地图地址 + 基址.首地址)) + (uint)Time);
                    Time = Time + 4;
                    OBJ类型 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(OBJ数据 + 基址.类型偏移));
                    if (OBJ类型 == 289)// || OBJ类型 == 529 || OBJ类型 == 545 || OBJ类型 == 273
                    {
                        x = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(人物地址 + 基址.X坐标)) + 0);
                        y = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(人物地址 + 基址.X坐标)) + 4);
                        ReadWriteCtr.WriteMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(OBJ数据 + 基址.对象坐标)) + 16, x);
                        ReadWriteCtr.WriteMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(OBJ数据 + 基址.对象坐标)) + 20, y);
                    }
                }

            }
            else
                return;
            //ReadWriteCtr.WriteMemInt(全局变量.进程ID, 基址.自动捡物, 1300959860);

        }
        public static void 全局吸怪()
        {
            int 人物地址;
            int 地图地址;
            int 对象数量;
            int Time = 0;
            int OBJ数据;
            int OBJ类型;
            int x;
            int y;
            if (判断_游戏状态() == 3)
            {
                人物地址 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, 基址.人物基址);
                地图地址 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(人物地址) + 基址.地图偏移);
                对象数量 = (ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(地图地址 + 基址.尾地址)) - ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(地图地址 + 基址.首地址))) / 4;
                for (int i = 1; i <= 对象数量; i++)
                {
                    OBJ数据 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(地图地址 + 基址.首地址)) + (uint)Time);
                    Time = Time + 4;
                    OBJ类型 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(OBJ数据 + 基址.类型偏移));
                    if (OBJ类型 == 529 || OBJ类型 == 545 || OBJ类型 == 273)// || OBJ类型 == 529 || OBJ类型 == 545 || OBJ类型 == 273
                    {
                        x = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(人物地址 + 基址.X坐标)) + 0);
                        y = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(人物地址 + 基址.X坐标)) + 4);
                        ReadWriteCtr.WriteMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(OBJ数据 + 基址.对象坐标)) + 16, x);
                        ReadWriteCtr.WriteMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(OBJ数据 + 基址.对象坐标)) + 20, y);
                    }
                }

            }
            else
                return;
            //ReadWriteCtr.WriteMemInt(全局变量.进程ID, 基址.自动捡物, 1300959860);

        }
        public static void 定怪()
        {
            if (判断_游戏状态() == 3)
            {
                int Time = 0;
                int 人物地址 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, 基址.人物基址);
                int 地图地址 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(人物地址) + 基址.地图偏移);
                int 对象数量 = (ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(地图地址 + 基址.尾地址)) - ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(地图地址 + 基址.首地址))) / 4;
                for (int i = 1; i <= 对象数量; i++)
                {
                    int OBJ数据 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(地图地址 + 基址.首地址)) + (uint)Time);
                    Time = Time + 4;
                    int OBJ类型 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(OBJ数据 + 基址.类型偏移));
                    if (OBJ类型 == 529 || OBJ类型 == 545 || OBJ类型 == 273)
                    {
                        //ReadWriteCtr.WriteMemInt((uint)(OBJ数据 + 基址.不死偏移),12);
                        EncDec.Encryption(全局变量.进程ID, (uint)(OBJ数据 + 基址.不死偏移), 12, 基址.解密基址);

                    }


                }
            }





        }
        public static void 全屏吸物DisAble()
        {
            ReadWriteCtr.WriteMemInt(全局变量.进程ID, 基址.自动捡物, 1300959860);
        }
        public static int 判断_游戏状态()
        {
            int i;
            i = ReadWriteCtr.ReadMemInt(全局变量.进程ID, 基址.游戏状态);
            return i;
        }
        public static void 独家变怪(int 怪物代码 = 64024)
        {
            Asm asm = new Asm();
            byte[] 附加字节 = { 0x90, 0x90, 0x90, 0x90 };
            byte[] array = asm.JMP(0x400d00, 基址.独家变怪, 附加字节);
            ReadWriteCtr.WriteMemByteArray(基址.独家变怪, array);
            asm.Mov_EAX(怪物代码);
            asm.Push_EAX();
            asm.Mov_ECX((int)基址.怪物目录);
            ReadWriteCtr.WriteMemByteArray(0x400d00, 转换.数组加法(asm.取汇编代码(), asm.JMP(基址.独家变怪 + 9, 0x400d0B)));
            asm.清空汇编代码();
            公告("真.独家变怪开启成功");
        }
        public static void 独家变怪DisAble()
        {
            Asm asm = new Asm();
            asm.Mov_EDX_DWORD_Ptr_EBP_Add(8);
            asm.Push_EDX();
            asm.Mov_ECX((int)基址.怪物目录);
            ReadWriteCtr.WriteMemByteArray(基址.独家变怪, asm.取汇编代码());
            asm.清空汇编代码();
            byte[] i = new byte[50];
            ReadWriteCtr.WriteMemByteArray(0x400D00, i);
            公告("真.独家变怪关闭成功");
        }
        public static void 内存药剂()
        {
            byte[] i = { 0xF0, 05, 00, 00, 0xE8, 03, 00, 00, 00, 00, 00, 00, 01, 00, 00, 00 };
            int j = SearchMemory(全局变量.进程ID, i, i.Length);
            if (ReadWriteCtr.ReadMemInt((uint)j) == 1520)
            {
                ReadWriteCtr.WriteMemInt((uint)(j), 0);
                ReadWriteCtr.WriteMemInt((uint)(j + 0x8), 1);
                ReadWriteCtr.WriteMemInt((uint)(j + 0x58), 5);
                ReadWriteCtr.WriteMemInt((uint)(j + 0x58 + 0x4), 999999999);
                ReadWriteCtr.WriteMemInt((uint)(j + 0x58 + 0x4 + 0x4), 99999999);
                ReadWriteCtr.WriteMemInt((uint)(j + 0x58 + 0x4 + 0x8), 1);
                ReadWriteCtr.WriteMemInt((uint)(j + 0x58 + 0x4 + 0x8 + 0x4), 1);
                ReadWriteCtr.WriteMemInt((uint)(j + 0x58 + 0x4 + 0x8 + 0x4 + 0x4), 2147483640);
                公告("成功开始奔放进图波浪完事 " + j.ToString());
                //MessageBox.Show("成功 开始奔放 + " + Convert.ToString(j) + "   提示 进图波浪开始奔放", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //MessageBox.Show("失败 请重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //公告("成功 开始奔放 进图波浪完事  " + j.ToString() );
                公告("失败请下游戏重试或者购买达人hp药剂放到背包");
            }
            //byte[] k = { 0x38, 04, 00, 00, 0xE8, 03, 00, 00, 00, 00, 00, 00, 01, 00, 00, 00 };
            //int l = SearchMemory(全局变量.进程ID, k, k.Length);
            //公告("成功开始奔放进图波浪完事 " + l.ToString());
            //if (ReadWriteCtr.ReadMemInt((uint)l) == 1080)
            //{
            //    ReadWriteCtr.WriteMemInt((uint)(l), 0);
            //    ReadWriteCtr.WriteMemInt((uint)(l + 0x8), 1);
            //    ReadWriteCtr.WriteMemInt((uint)(l + 0x58), 1);
            //    ReadWriteCtr.WriteMemInt((uint)(l + 0x58 + 0x4), 999999999);
            //    ReadWriteCtr.WriteMemInt((uint)(l + 0x58 + 0x4 + 0x4), 99999999);
            //    ReadWriteCtr.WriteMemInt((uint)(l + 0x58 + 0x4 + 0x8), 1);
            //    ReadWriteCtr.WriteMemInt((uint)(l + 0x58 + 0x4 + 0x8 + 0x4), 1);
            //    ReadWriteCtr.WriteMemInt((uint)(l + 0x58 + 0x4 + 0x8 + 0x4 + 0x4), 2147483640);
            //    公告("成功开始奔放进图波浪完事 " + l.ToString());
            //    //MessageBox.Show("成功 开始奔放 + " + Convert.ToString(l) + "   提示 进图波浪开始奔放", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    公告("失败请下游戏重试或者购买专家hp药剂放到背包");
            //    //MessageBox.Show("失败 请重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
        }
        public unsafe static void 内存药剂斗神()
        {
            uint[] i = { 基址.物品栏, 基址.物品栏偏移, 基址.物品栏6, 0x28, 0 };
            int j = ReadWriteCtr.读偏移型(基址.人物基址, i);
            公告(j.ToString());
            j = SearchMemory2(全局变量.进程ID, &j, 4);
            ReadWriteCtr.WriteMemInt((uint)(j - 0x70), 10000);
            byte[] i1 = { 0, 6, 64, 0, 32, 6, 64, 0, 32, 6, 64, 126 };
            公告(j.ToString());
            ReadWriteCtr.WriteMemByteArray((uint)(j - 0x70 + 0x7C0), i1);
            ReadWriteCtr.WriteMemInt((uint)(j - 0x70 + 0x7C0 + 0x10), 1200000);
            ReadWriteCtr.WriteMemInt((uint)(j - 0x70 + 0x7C0 + 0x10 + 4), 1);
            ReadWriteCtr.WriteMemInt(0x400600, 106);
            ReadWriteCtr.WriteMemInt(0x400604, 0);
            ReadWriteCtr.WriteMemInt(0x400608, 1);
            ReadWriteCtr.WriteMemInt(0x400610, 73);
            ReadWriteCtr.WriteMemInt(0x400614, 200);
            ReadWriteCtr.WriteMemInt(0x400618, 1);
            //SearchMemory2(全局变量.进程ID,j,4);
            MessageBox.Show("成功 开始奔放 + " + Convert.ToString(j) + "   提示 进图波浪开始奔放", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            公告("本功能在开启前 需要在物品栏6放置一个斗神药剂");
        }
        public static void 全屏遍历秒杀()
        {
            int 人物地址;
            int 地图地址;
            int 对象数量;
            int OBJ数据;
            int OBJ类型;
            if (判断_游戏状态() == 3)
            {
                call.物品CALL(7955);
                Thread.Sleep(300);
                //ReadWriteCtr.WriteMemInt(全局变量.进程ID, 基址.自动捡物, 1300955444);
                人物地址 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, 基址.人物基址);
                地图地址 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(人物地址) + 基址.地图偏移);
                对象数量 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(地图地址 + 基址.尾地址)) - ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(地图地址 + 基址.首地址));
                //while(true)
                //{ 
                for (int i = 0; i < 对象数量; i = i + 4)
                {
                    OBJ数据 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(地图地址 + 基址.首地址)) + (uint)i);

                    OBJ类型 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(OBJ数据 + 基址.类型偏移));
                    //OBJ阵营 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(OBJ数据 + 基址.阵营偏移));
                    if (OBJ类型 == 273)
                    {

                        if (EncDec.Decrypt((uint)(OBJ数据 + 基址.人物等级), 基址.解密基址) == 60)
                        {
                            //公告(OBJ数据.ToString());
                            ReadWriteCtr.WriteMemInt(0x400500, OBJ数据);
                            uint[] i1 = { 19736, 3220, 4, 8, 20, 0 };
                            int j = ReadWriteCtr.读偏移型(0x400500, i1);
                            EncDec.超级加密(j, TransCtr.IntToFloat(200000.ToString()));
                            ReadWriteCtr.WriteMemInt(0x400500, 0);
                            //判断 = true;
                            break;

                        }
                    }
                }
                //Thread.Sleep(30);
                //if (判断)
                //break;
                // }

            }
            else
                return;
            //ReadWriteCtr.WriteMemInt(全局变量.进程ID, 基址.自动捡物, 1300959860);

        }
        public static void miss设计图附伤()
        {
            int 设计图地址, 人物地址;
            uint[] j = { 基址.物品栏, 基址.物品栏偏移, 基址.物品栏1, 0 };
            设计图地址 = ReadWriteCtr.读偏移型(基址.人物基址, j);
            人物地址 = ReadWriteCtr.ReadMemInt(基址.人物基址);
            uint[] i = { 基址.物品栏, 基址.物品栏偏移, 基址.物品栏1, 1564 };
            uint[] i2 = { 基址.物品栏, 基址.物品栏偏移, 基址.物品栏1, 1564, 4 };
            uint[] i3 = { 基址.物品栏, 基址.物品栏偏移, 基址.物品栏1, 1564, 8 };
            uint[] i4 = { 基址.物品栏, 基址.物品栏偏移, 基址.物品栏1, 1564, 14 };
            uint[] i5 = { 基址.物品栏, 基址.物品栏偏移, 基址.物品栏1, 1564, 18 };
            ReadWriteCtr.WriteMemInt((uint)ReadWriteCtr.读偏移型(基址.人物基址, i), 0x400700);
            ReadWriteCtr.WriteMemInt((uint)ReadWriteCtr.读偏移型(基址.人物基址, i2), 0x400800);
            ReadWriteCtr.WriteMemInt((uint)ReadWriteCtr.读偏移型(基址.人物基址, i3), 0x400880);
            ReadWriteCtr.WriteMemInt((uint)ReadWriteCtr.读偏移型(基址.人物基址, i4), 6666666);
            ReadWriteCtr.WriteMemInt((uint)ReadWriteCtr.读偏移型(基址.人物基址, i5), 1);
            BUFF属性();
            Asm asm = new Asm();
            asm.Mov_EAX(人物地址);
            asm.Mov_ESI(设计图地址);
            asm.Mov_EDX_DWORD_Ptr_ESI();
            asm.Push(-1);
            asm.Push(2);
            asm.Push_EAX();
            asm.Mov_EAX_DWORD_Ptr_EDX_Add(376);
            asm.Mov_ECX_ESI();
            asm.Call_EAX();
            asm.RunAsm(全局变量.进程ID);
            ReadWriteCtr.WriteMemInt((uint)ReadWriteCtr.读偏移型(基址.人物基址, i), 0);
            ReadWriteCtr.WriteMemInt((uint)ReadWriteCtr.读偏移型(基址.人物基址, i2), 0);
            ReadWriteCtr.WriteMemInt((uint)ReadWriteCtr.读偏移型(基址.人物基址, i3), 0);
            ReadWriteCtr.WriteMemInt((uint)ReadWriteCtr.读偏移型(基址.人物基址, i4), 0);
            ReadWriteCtr.WriteMemInt((uint)ReadWriteCtr.读偏移型(基址.人物基址, i5), 0);
            BUFF属性DisAble();
        }
        public static void BUFF属性()
        {
            ReadWriteCtr.WriteMemInt(0x400800, 103);
            ReadWriteCtr.WriteMemInt(0x400804, -100);
            ReadWriteCtr.WriteMemInt(0x400810, 4);
            ReadWriteCtr.WriteMemInt(0x400814, 66666);
            ReadWriteCtr.WriteMemInt(0x400820, 15);
            ReadWriteCtr.WriteMemInt(0x400824, 100);
            ReadWriteCtr.WriteMemInt(0x400830, 16);
            ReadWriteCtr.WriteMemInt(0x400834, 100);
            ReadWriteCtr.WriteMemInt(0x400840, 48);
            ReadWriteCtr.WriteMemInt(0x400844, 66666);
            ReadWriteCtr.WriteMemInt(0x400850, 48);
            ReadWriteCtr.WriteMemInt(0x400854, 100);
            ReadWriteCtr.WriteMemInt(0x400860, 63);
            ReadWriteCtr.WriteMemInt(0x400864, 350);
            ReadWriteCtr.WriteMemInt(0x400870, 70);
            ReadWriteCtr.WriteMemInt(0x400874, 5500);
        }
        public static void BUFF属性DisAble()
        {
            ReadWriteCtr.WriteMemInt(0x400800, 0);
            ReadWriteCtr.WriteMemInt(0x400804, 0);
            ReadWriteCtr.WriteMemInt(0x400810, 0);
            ReadWriteCtr.WriteMemInt(0x400814, 0);
            ReadWriteCtr.WriteMemInt(0x400820, 0);
            ReadWriteCtr.WriteMemInt(0x400824, 0);
            ReadWriteCtr.WriteMemInt(0x400830, 0);
            ReadWriteCtr.WriteMemInt(0x400834, 0);
            ReadWriteCtr.WriteMemInt(0x400840, 0);
            ReadWriteCtr.WriteMemInt(0x400844, 0);
            ReadWriteCtr.WriteMemInt(0x400850, 0);
            ReadWriteCtr.WriteMemInt(0x400854, 0);
            ReadWriteCtr.WriteMemInt(0x400860, 0);
            ReadWriteCtr.WriteMemInt(0x400864, 0);
            ReadWriteCtr.WriteMemInt(0x400870, 0);
            ReadWriteCtr.WriteMemInt(0x400874, 0);
        }

        public static void 公告(string 内容)
        {

            byte[] 公告字节集 = TransCtr.AnsiToUnicode("Su超级技能: " + 内容); //{ 0x85, 0x8D, 0xA7, 0x7E, 0x80, 0x62, 0xFD, 0x80, 0x31, 00, 0x31, 00, 0x34, 00, 0x39, 00, 0x32, 00, 0x30, 0x00, 0x36, 00, 0x35, 00, 0x32, 00, 0x38 };
            ReadWriteCtr.WriteMemByteArray(0x400400, 公告字节集);
            Asm asm = new Asm();
            asm.Mov_ECX_DWORD_Ptr((int)基址.商店基址);
            asm.Mov_ECX_DWORD_Ptr_ECX_Add((int)基址.公告偏移);
            asm.Mov_EBX((int)基址.喇叭公告);
            asm.Push(0);
            asm.Push(0);
            asm.Push(0);
            asm.Push(0);
            asm.Push(0);
            asm.Push(37);
            asm.Push(-0x10);
            asm.Push(0x400400);
            asm.Call_EBX();
            asm.RunAsm(全局变量.进程ID);
            byte[] RAsm = new byte[公告字节集.Length];
            ReadWriteCtr.WriteMemByteArray(0x400400, RAsm);

        }
        public static void 内存按键(int 按键参数)
        {
            byte[] i1 = { 1 };
            byte[] i2 = { 0 };
            ReadWriteCtr.WriteMemByteArray((uint)(ReadWriteCtr.ReadMemInt(基址.按键基址) + 按键参数), i1);
            call.Delay(50);
            ReadWriteCtr.WriteMemByteArray((uint)(ReadWriteCtr.ReadMemInt(基址.按键基址) + 按键参数), i2);

        }

        public static void 独家弱怪()
        {
            Asm asm = new Asm();
            byte[] array1 = { 0xC7, 0x45, 0x0C, 01, 00, 00, 00, 0x53, 0x56, 0x57 };
            asm.Mov_EAX_DWORD_Ptr((int)基址.变怪基址_B);
            byte[] array2 = asm.JMP(基址.变怪基址_A + 8, 0x400D5F);
            ReadWriteCtr.WriteMemByteArray(0x400d50, 转换.数组加法(array1, asm.取汇编代码(), array2));
            asm.清空汇编代码();
            byte[] array = asm.JMP(0x400d50, 基址.变怪基址_A);
            ReadWriteCtr.WriteMemByteArray(基址.变怪基址_A, array);
            功能.公告("真.独家弱怪开启成功");
        }
        public static void 独家弱怪DisAble()
        {
            Asm asm = new Asm();
            asm.Push_EBX();
            asm.Push_ESI();
            asm.Push_EDI();
            asm.Mov_EAX_DWORD_Ptr((int)基址.变怪基址_B);
            ReadWriteCtr.WriteMemByteArray(基址.变怪基址_A, asm.取汇编代码());
            asm.清空汇编代码();
            byte[] array = new byte[0x20];
            ReadWriteCtr.WriteMemByteArray(0x400d50, array);
            功能.公告("真.独家弱怪关闭成功");
        }

    }

}
