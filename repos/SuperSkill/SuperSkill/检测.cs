using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReadWrite;

namespace SuperSkill
{
    class 检测
    {
        public static void 处理检测()
        {
            byte[] i1 = { 144, 144 };
            byte[] i2 = { 144, 144, 144, 144, 144 };
            //byte[] i3 = { 195};
            ReadWriteCtr.WriteMemByteArray(0x4ACDB82, i1);
            //MessageBox.Show(Convert.ToString(i), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReadWriteCtr.WriteMemByteArray(0x4ACDB86, i2);

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
            功能.公告("初始化成功!!");
            功能.公告("伤害检测处理完毕");

        }

    }
}
