﻿using EncryptionDecrypt;
using ReadWrite;
using System;
using System.Windows.Forms;
using Transform;

namespace SuperSkill
{
    public class 功能
    {
        public static void 超级三速()
        {
            int i;
            i = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, 基址.人物基址) + 基址.上衣偏移);
            EncDec.超级加密(i + (int)基址.攻击速度, 1500);
            EncDec.超级加密(i + (int)基址.释放速度, 1500);
            EncDec.超级加密(i + (int)基址.移动速度, 3000);
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
                技能等级 = EncDec.Decrypt(全局变量.进程ID, 技能地址 + 基址.技能等级, 基址.解密基址);
                if (技能等级 >= 0 && 技能等级 < 100)
                {
                    int 技能CD = EncDec.Decrypt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能冷却1) + 8 * (uint)(技能等级 - 1), 基址.解密基址);
                    技能名称 = TransCtr.UnicodeToAnsi(ReadWriteCtr.ReadMemByteArray(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能名称), 50));
                    if (技能名称.Length > 1 && 技能名称.IndexOf("?") == -1 && 技能名称.IndexOf("不使用") == -1 && 总技能.IndexOf(技能名称) == -1 && 技能等级 > 0)
                    {
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址 + 基址.技能冷却1) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址 + 基址.技能冷却2) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址 + 基址.技能冷却3) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址 + 基址.技能冷却4) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址 + 基址.技能冷却5) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址 + 基址.技能冷却6) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址 + 基址.技能冷却7) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址 + 基址.技能冷却8) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址 + 基址.技能冷却9) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址 + 基址.技能冷却10) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址 + 基址.技能冷却11) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                        EncDec.超级加密((int)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址 + 基址.技能冷却12) + 8 * (uint)(技能等级 - 1)), 技能CD / 10);
                    }
                }
                i += 4;
            }
        }
        public static void 一键评分()
        {
            int 地址;
            地址 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, 基址.评分基址);
            EncDec.超级加密(地址 + (int)基址.加密评分, 5201314);
        }
        /// <summary>
        /// Timer2：全屏吸物
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            int z;
            if (判断_游戏状态() == 3)
            {
                ReadWriteCtr.WriteMemInt(全局变量.进程ID, 基址.自动捡物, 1300955444);
                人物地址 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, 基址.人物基址);
                地图地址 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(人物地址) + 基址.地图偏移);
                对象数量 = (ReadWriteCtr.ReadMemInt(全局变量.进程ID,(uint)(地图地址 + 基址.尾地址)) - ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(地图地址 + 基址.首地址))) / 4;
                for (int i = 1; i <= 对象数量; i++)
                {
                    OBJ数据 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID,(uint)(地图地址 + 基址.首地址)) + (uint)Time);
                    Time = Time + 4;
                    OBJ类型 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(OBJ数据 + 基址.类型偏移));
                    if (OBJ类型 == 289)
                    {
                        x = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(人物地址 + 基址.X坐标)) + 0);
                        y = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(人物地址 + 基址.X坐标)) + 4);
                        ReadWriteCtr.WriteMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(OBJ数据 + 基址.对象坐标)) + 16, x);
                        ReadWriteCtr.WriteMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(OBJ数据 + 基址.对象坐标)) + 20, y);
                    }
                }
                
            }
            else
                return ;
            //ReadWriteCtr.WriteMemInt(全局变量.进程ID, 基址.自动捡物, 1300959860);

        }
        private static int 判断_游戏状态()
        {
            int i;
            i = ReadWriteCtr.ReadMemInt(全局变量.进程ID, 基址.游戏状态);
            return i;
        }



    }

}
