﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadWrite;
using SslnEngine;

namespace SuperSkill
{
    class call
    {
        public static void 释放call(uint 人物基质,int X坐标,int Y坐标,int Z坐标,int 代码,int 伤害)
        {
            int 释放地址 = (int)基址.释放CALL;
            int 人物数据 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, 人物基质);
            Asm asm = new Asm();
            asm.Push(Z坐标);
            asm.Push(Y坐标);
            asm.Push(X坐标);
            asm.Push(伤害);
            asm.Push(代码);
            asm.Push(人物数据);
            asm.Mov_EDI(释放地址);
            asm.Mov_EAX_EDI();
            asm.Call_EAX();
            asm.Add_ESP(24);
            asm.RunAsm(全局变量.进程ID);
        }

        public static void 物品CALL(int 物品代码)
        {
            //int 触发基址;
            //int 物品call;
            Asm asm = new Asm();
            asm.Mov_ECX(物品代码);
            asm.Mov_EAX(ReadWriteCtr.ReadMemInt(基址.人物基址));
            asm.Mov_EDX_DWORD_Ptr_EAX_Add(0);
            asm.Mov_EDX_DWORD_Ptr_EDX_Add((int)基址.物品CALL);
            asm.Push_ECX();
            asm.Mov_ECX_EAX();
            asm.Call_EDX();
            asm.RunAsm(全局变量.进程ID);
        }
        public static void 技能CALL(uint 人物基质, int X坐标, int Y坐标, int Z坐标, int 代码, int 伤害, float 大小)
        {
            ReadWriteCtr.WriteMemInt(0x400f00, 0);
            ReadWriteCtr.WriteMemInt(0x400f00 + 8, 代码);
            ReadWriteCtr.WriteMemInt(0x400f00 + 12, 伤害);
            ReadWriteCtr.WriteMemInt(0x400f00 + 24, X坐标);
            ReadWriteCtr.WriteMemInt(0x400f00 + 28, Y坐标);
            ReadWriteCtr.WriteMemInt(0x400f00 + 32, Z坐标);
            ReadWriteCtr.WriteMemInt(0x400f00 + 96, 大小);
            ReadWriteCtr.WriteMemInt(0x400f00 + 100, 65535);
            ReadWriteCtr.WriteMemInt(0x400f00 + 104, 65535);
            Asm asm = new Asm();
            asm.Mov_EBX(0);
            asm.Mov_ESI(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 人物基质));
            asm.Mov_EDI(38004);
            asm.Mov_ECX(0x400f00);
            asm.Mov_EDX((int)基址.技能CALL);
            asm.Call_EDX();
            asm.RunAsm(全局变量.进程ID);
        }
        public static void 无敌call()
        {
            Asm asm = new Asm();
            asm.Mov_ECX(ReadWriteCtr.ReadMemInt(全局变量.进程ID, 基址.人物基址));
            asm.Mov_ESI_ECX();
            asm.Push(-1);
            asm.Push(1);
            asm.Push(1);
            asm.Push(1);
            asm.Mov_EDX((int)基址.无敌CALL);
            asm.Call_EDX();
            asm.RunAsm(全局变量.进程ID);
        }
        public static void miss扣血call(int 扣血指针,int 控制血量 = 0)
        {
            Asm asm = new Asm();
            asm.Mov_ESI(扣血指针);
            asm.Mov_EDX_DWORD_Ptr_ESI();
            asm.Mov_EDX_DWORD_Ptr_EDX_Add(1168);// 0x490
            asm.Push(0);
            asm.Push(0);
            asm.Push(0);
            asm.Push(控制血量);
            asm.Mov_ECX_ESI();
            asm.Call_EDX();
            asm.RunAsm(全局变量.进程ID);
        }
    }
}
