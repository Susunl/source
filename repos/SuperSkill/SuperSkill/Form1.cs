using EncryptionDecrypt;
using ProcessCtr;
using ReadWrite;
using System;
using System.Threading;
using System.Windows.Forms;
using Transform;
using KoalaStudio.BookshopManager;
using System.Runtime.InteropServices;
using SslnEngine;
using System.IO;

namespace SuperSkill
{
    public partial class Form1 : Form
    {
        public Form1()                                                                          //固定不用修改
        {                                                                                       //固定不用修改
            //AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            InitializeComponent();                                                          //固定不用修改
        }
        //System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        //{
        //    string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
        //    dllName = dllName.Replace(".", "_");
        //    if (dllName.EndsWith("_resources"))
        //    {
        //        return null;
        //    }

        //    System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
        //    byte[] bytes = (byte[])rm.GetObject(dllName);
        //    return System.Reflection.Assembly.Load(bytes);
        //}
        //固定不用修改
        /// 时钟时间
        private void timer1_Tick(object sender, EventArgs e)
        {
            SysTime.Text
                    = "当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (全局变量.评分开关 == true)
            {
                功能.一键评分();
            }
            if (全局变量.全局吸怪 == true)
            {
                功能.全局吸怪();
            }
        }
        /// 窗口1创建完毕过后干的事情
        private void Form1_Load(object sender, EventArgs e)
        {
            SysTimeTimer.Start();       ///启动时钟时间
            //comboBox1.Text = "远程卖修";
            //全局变量.进程ID = ProCtr.GetProcessID("DNF");
            //string message = string.Format("进程id是：{0}", 全局变量.进程ID);
            //MessageBox.Show(message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //初始化被单击
        private void button1_Click(object sender, EventArgs e)                                  //初始化被单击
        {
            //string i;
            //int j;
            //var strToBytes1 = System.Text.Encoding.UTF8.GetBytes(str1);
            //if (验证.取机器码() != "2EF598542E177FF2C77126D579AAA129")
            //    Environment.Exit(0);

            全局变量.进程ID = ProCtr.GetProcessID("DNF");
            if (全局变量.进程ID == -1)
            {
                MessageBox.Show("未获取到游戏ID\n请进入游戏到仓库重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            检测.处理检测();
        }
        //读取职业技能被单击
        private void button3_Click(object sender, EventArgs e)
        {
            uint i = 0x4300,技能地址;
            string 技能名称 = "";
            int 技能等级;
            string 总技能="";
            ListView_Skill.Items.Clear();
            while (i <= 0x6000)
            {
                技能地址 = (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID,(uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID,基址.人物基址)+i);
                技能等级 = (int)EncDec.Decrypt(全局变量.进程ID,技能地址+基址.技能等级,基址.解密基址);
                if (技能等级 >= 0 && 技能等级 < 100)
                {
                    技能名称 = TransCtr.UnicodeToAnsi(ReadWriteCtr.ReadMemByteArray(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, 技能地址 + 基址.技能名称), 50));
                    if (技能名称.Length > 1 && 技能名称.IndexOf("?") == -1&&技能名称.IndexOf("不使用") == -1&&总技能.IndexOf(技能名称)==-1&&技能等级>0)
                    {
                        this.ListView_Skill.Update();
                        ListViewItem lvi = this.ListView_Skill.Items.Add(Convert.ToString(i));
                        lvi.SubItems.Add(技能名称);
                        lvi.SubItems.Add(Convert.ToString(技能等级));
                        this.ListView_Skill.EndUpdate();
                        总技能 += 技能名称;
                    }
                }
                i +=4;
            }
        }
        //listview_skill事件被双击
        private void ListView_Skill_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int 技能地址1,技能等级,技能CD, 技能地址2;
            uint i1, i2, i3, i4, i5, 技能数据;
            string 总技能公式 = "",技能数据2 ="";
            //int 技能等级代码;
            全局变量.技能名 = this.ListView_Skill.SelectedItems[0].SubItems[1].Text;
            技能地址1 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, 基址.人物基址) + Convert.ToUInt32(this.ListView_Skill.SelectedItems[0].Text));
            技能等级 = (int)EncDec.Decrypt(全局变量.进程ID, (uint)技能地址1 + 基址.技能等级, 基址.解密基址);
            this.ListView_SkillProperties.Items.Clear(); //清空ListView_SkillProperties内容
            技能CD = (int)EncDec.Decrypt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址1 + 基址.技能冷却7) + 8*(uint)(技能等级-1), 基址.解密基址) / 1000;
            label1.Text = "当前技能cd为:" + 技能CD + "秒";
            //第一层遍历
            i1 = 0;
            while (i1 < 13)
            {
                技能地址2 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址1 + 基址.超级技能)) + i1)) + 20);
                if (技能地址2 == -1 || 技能地址2 == 0 || Math.Abs(技能地址2) < 0x400000)
                {
                    i1 += 4;
                    continue;
                }
                if (总技能公式.IndexOf(Convert.ToString(技能地址2)) == -1)
                {
                    技能数据 = EncDec.Decrypt(全局变量.进程ID, (uint)(技能地址2 + 8 * (技能等级 - 1)), 基址.解密基址);
                    if (技能数据 > 1)
                    {
                        技能数据2 = TransCtr.FloatToInt(技能数据);
                        this.ListView_SkillProperties.Update();
                        ListViewItem lvi = this.ListView_SkillProperties.Items.Add(技能数据2);       //liseview添加项
                        lvi.SubItems.Add(this.ListView_Skill.SelectedItems[0].SubItems[0].Text + "+" + Convert.ToString(基址.超级技能) + "+" + Convert.ToString(i1) + "+20");      //添加次级项
                        lvi.SubItems.Add(Convert.ToString(技能地址2));
                        this.ListView_SkillProperties.EndUpdate();
                        总技能公式 = 总技能公式 + " " + Convert.ToString(技能地址2);

                    }
                } 

                i1 += 4;
            }
            //第二层遍历
            i1 = 0;
            while (i1 < 13)
            {
                i2 = 0;
                while (i2 < 13)
                {
                    技能地址2 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址1 + 基址.超级技能)) + i1)) + i2)) + 20);
                    if (技能地址2 == -1 || 技能地址2 == 0 || Math.Abs(技能地址2) < 0x400000)
                    {
                        i2 += 4;
                        continue;
                    }
                    if (总技能公式.IndexOf(Convert.ToString(技能地址2)) == -1 )
                    {
                        技能数据 = EncDec.Decrypt(全局变量.进程ID, (uint)(技能地址2 + 8 * (技能等级 - 1)), 基址.解密基址);
                        if (技能数据 > 1)
                        {
                            技能数据2 = TransCtr.FloatToInt(技能数据);
                            this.ListView_SkillProperties.Update();
                            ListViewItem lvi = this.ListView_SkillProperties.Items.Add(技能数据2);       //liseview添加项
                            lvi.SubItems.Add(this.ListView_Skill.SelectedItems[0].SubItems[0].Text + "+" + Convert.ToString(基址.超级技能) + "+" + Convert.ToString(i1) + "+" + Convert.ToString(i2) + "+20");      //添加次级项
                            lvi.SubItems.Add(Convert.ToString(技能地址2));
                            this.ListView_SkillProperties.EndUpdate();
                            总技能公式 = 总技能公式 + " " + Convert.ToString(技能地址2);
                        }
                    }
                    i2 += 4;
                }
                i1 += 4;
            }
            //第三层遍历
            i1 = 0;
            while (i1 < 13)
            {
                i2 = 0;
                while (i2 < 13)
                {
                    i3 = 0;
                    while (i3 < 13)
                    {
                        技能地址2 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址1 + 基址.超级技能)) + i1)) + i2)) + i3)) + 20);
                        if (技能地址2 == -1 || 技能地址2 == 0 || Math.Abs(技能地址2) < 0x400000)
                        {
                            i3 += 4;
                            continue;
                        }
                        if (总技能公式.IndexOf(Convert.ToString(技能地址2)) == -1)
                        {
                            技能数据 = EncDec.Decrypt(全局变量.进程ID, (uint)(技能地址2 + 8 * (技能等级 - 1)), 基址.解密基址);
                            if (技能数据 > 1)
                            {
                                技能数据2 = TransCtr.FloatToInt(技能数据);
                                this.ListView_SkillProperties.Update();
                                ListViewItem lvi = this.ListView_SkillProperties.Items.Add(技能数据2);       //liseview添加项
                                lvi.SubItems.Add(this.ListView_Skill.SelectedItems[0].SubItems[0].Text + "+" + Convert.ToString(基址.超级技能) + "+" + Convert.ToString(i1) + "+" + Convert.ToString(i2) + "+" + Convert.ToString(i3) + "+20");      //添加次级项
                                lvi.SubItems.Add(Convert.ToString(技能地址2));
                                this.ListView_SkillProperties.EndUpdate();
                                总技能公式 = 总技能公式 + " " + Convert.ToString(技能地址2);
                            }
                        }
                        i3 += 4;
                    }
                    i2 += 4;
                }
                i1 += 4;
            }
            //第四层遍历
            i1 = 0;
            while (i1 < 13)
            {
                i2 = 0;
                while (i2 < 13)
                {
                    i3 = 0;
                    while (i3 < 13)
                    {
                        i4 = 0;
                        while (i4 < 13)
                        {
                            技能地址2 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址1 + 基址.超级技能)) + i1)) + i2)) + i3)) + i4)) + 20);
                            if (技能地址2 == -1 || 技能地址2 == 0 || Math.Abs(技能地址2) < 0x400000)
                            {
                                i4 += 4;
                                continue;
                            }
                            if (总技能公式.IndexOf(Convert.ToString(技能地址2)) == -1)
                            {
                                技能数据 = EncDec.Decrypt(全局变量.进程ID, (uint)(技能地址2 + 8 * (技能等级 - 1)), 基址.解密基址);
                                if (技能数据 > 1)
                                {
                                    技能数据2 = TransCtr.FloatToInt(技能数据);
                                    this.ListView_SkillProperties.Update();
                                    ListViewItem lvi = this.ListView_SkillProperties.Items.Add(技能数据2);       //liseview添加项
                                    lvi.SubItems.Add(this.ListView_Skill.SelectedItems[0].SubItems[0].Text + "+" + Convert.ToString(基址.超级技能) + "+" + Convert.ToString(i1) + "+" + Convert.ToString(i2) + "+" + Convert.ToString(i3) + "+" + Convert.ToString(i4) + "+20");      //添加次级项
                                    lvi.SubItems.Add(Convert.ToString(技能地址2));
                                    this.ListView_SkillProperties.EndUpdate();
                                    总技能公式 = 总技能公式 + " " + Convert.ToString(技能地址2);
                                }
                            }
                            i4 += 4;
                        }
                        i3 += 4;
                    }
                    i2 += 4;
                }
                i1 += 4;
            }
            //第五层遍历
            i1 = 0;
            while (i1 < 13)
            {
                i2 = 0;
                while (i2 < 13)
                {
                    i3 = 0;
                    while (i3 < 13)
                    {
                        i4 = 0;
                        while (i4 < 13)
                        {
                            i5 = 0;
                            while (i5 < 13)
                            {
                                技能地址2 = ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)(ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)技能地址1 + 基址.超级技能)) + i1)) + i2)) + i3)) + i4)) + i5)) + 20);
                                if (技能地址2 == -1 || 技能地址2 == 0 || Math.Abs(技能地址2) < 0x400000)
                                {
                                    i5 += 4;
                                    continue;
                                }
                                if (总技能公式.IndexOf(Convert.ToString(技能地址2)) == -1)
                                {
                                    技能数据 = EncDec.Decrypt(全局变量.进程ID, (uint)(技能地址2 + 8 * (技能等级 - 1)), 基址.解密基址);
                                    if (技能数据 > 1)
                                    {
                                        技能数据2 = TransCtr.FloatToInt(技能数据);
                                        this.ListView_SkillProperties.Update();
                                        ListViewItem lvi = this.ListView_SkillProperties.Items.Add(技能数据2);       //liseview添加项
                                        lvi.SubItems.Add(this.ListView_Skill.SelectedItems[0].SubItems[0].Text + "+" + Convert.ToString(基址.超级技能) + "+" + Convert.ToString(i1) + "+" + Convert.ToString(i2) + "+" + Convert.ToString(i3) + "+" + Convert.ToString(i4) + "+" + Convert.ToString(i5) + "+20");      //添加次级项
                                        lvi.SubItems.Add(Convert.ToString(技能地址2));
                                        this.ListView_SkillProperties.EndUpdate();
                                        总技能公式 = 总技能公式 + " " + Convert.ToString(技能地址2);
                                    }
                                }
                                i5 += 4;
                            }
                            i4 += 4;
                        }
                        i3 += 4;
                    }
                    i2 += 4;
                }
                i1 += 4;
            }
        }
    
    private void 鸣谢_Click(object sender, EventArgs e)
        {

            //功能.超级三速();
            //功能call.释放call((int)基址.人物基址, 800, 255, 0, 54106, 999999);
            //MessageBox.Show("释放成功", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //ListView_SkillProperties双击事件 添加属性到ListView_SkillProperties_Edit
        private void ListView_SkillProperties_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ListView_SkillProperties_Edit.Update();
            ListViewItem lvi = this.ListView_SkillProperties_Edit.Items.Add(this.ListView_SkillProperties.SelectedItems[0].SubItems[1].Text);
            lvi.SubItems.Add(this.ListView_SkillProperties.SelectedItems[0].SubItems[0].Text);
            lvi.SubItems.Add(全局变量.技能名);
            lvi.SubItems.Add(ListView_SkillProperties.SelectedItems[0].SubItems[0].Text);
            this.ListView_SkillProperties_Edit.EndUpdate();
        }
        // ListView_SkillProperties_Edit双击事件 修改属性或备注
        private void ListView_SkillProperties_Edit_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = this.ListView_SkillProperties_Edit.GetItemAt(e.X, e.Y);
            int 列 = item.SubItems.IndexOf(item.GetSubItemAt(e.X, e.Y));   //列索引
            if (列 == 1 || 列 == 2)
            {
                Form2 form2 = new Form2(this);
                全局变量.要修改的数据 = this.ListView_SkillProperties_Edit.SelectedItems[0].SubItems[列].Text;
                全局变量.要修改的列 = 列 ;
                form2.ShowDialog();
                this.ListView_SkillProperties_Edit.SelectedItems[0].SubItems[全局变量.要修改的列].Text = 全局变量.要修改的数据;
            }


        }
        private void 修改属性()
        {
            //声明变量
            int index = -1, index2, t_level, i = 0;
            uint t_add, t_pet, t_skilladd = 0;

            //ListView_SkillProperties_Edit中有项目才进行修改
            if (this.ListView_SkillProperties_Edit.Items.Count > 0)
            {
                //循环项目数次
                for (i = 0; i < this.ListView_SkillProperties_Edit.Items.Count; i++)
                {
                    index = -1;
                    index2 = 0;
                    index2 = this.ListView_SkillProperties_Edit.Items[i].SubItems[0].Text.IndexOf("+", index + 1);   //公式第一个+号位置
                    t_pet = Convert.ToUInt32(this.ListView_SkillProperties_Edit.Items[i].SubItems[0].Text.Substring(index + 1, index2 - index - 1));  //技能偏移
                    t_skilladd = (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, (uint)ReadWriteCtr.ReadMemInt(全局变量.进程ID, 基址.人物基址) + t_pet);   //技能地址
                    t_level = (int)EncDec.Decrypt(全局变量.进程ID, (uint)t_skilladd + 基址.技能等级, 基址.解密基址);   //技能等级
                    Thread.Sleep(30);   //延迟30毫秒
                    t_add = (uint)ReadWriteCtr.ReadMemCode(全局变量.进程ID, Convert.ToString(基址.人物基址) + "+" + this.ListView_SkillProperties_Edit.Items[i].SubItems[0].Text);
                    //加密
                    EncDec.Encryption(全局变量.进程ID, (uint)(t_add + 8 * (t_level - 1)), TransCtr.IntToFloat(this.ListView_SkillProperties_Edit.Items[i].SubItems[1].Text), 基址.解密基址);
                    Thread.Sleep(30);   //延迟30毫秒进入下一循环
                }
                功能.公告("数据修改成功");
            }
            else
            {
                功能.公告("没有数据在list中");
            }
        }
        //搜索技能 然后焦点于指定技能
        private void Button_SearchSkill_Click(object sender, EventArgs e)
        {
            SearchSkill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            修改属性();
        }

        private void TextBox_SearchSkill_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0xD)   //如果按下的是Enter
            {
                SearchSkill();
            }
        }
        private void SearchSkill()
        {
            int t_index = 0;
            if (this.ListView_Skill.SelectedItems.Count > 0)
                t_index = this.ListView_Skill.SelectedItems[0].Index + 1;
            for (int i = t_index; i < this.ListView_Skill.Items.Count; i++) //第一次循环，从选中位置开始
            {
                if (this.ListView_Skill.Items[i].SubItems[1].Text.IndexOf(this.TextBox_SearchSkill.Text) != -1)
                {
                    this.ListView_Skill.Items[i].Selected = true;       //选中行
                    this.ListView_Skill.EnsureVisible(i);               //滚动到指定的行位置
                    this.ListView_Skill.Focus();                        //ListView_Skill获得焦点
                    return;
                }
            }
            for (int j = 0; j < this.ListView_Skill.Items.Count; j++)   //第二次循环，从头开始，以搜索选中项之前的内容
            {
                if (this.ListView_Skill.Items[j].SubItems[1].Text.IndexOf(this.TextBox_SearchSkill.Text) != -1)
                {
                    this.ListView_Skill.Items[j].Selected = true;   //选中行
                    this.ListView_Skill.EnsureVisible(j);           //滚动到指定的行位置
                    this.ListView_Skill.Focus();                    //ListView_Skill获得焦点
                    return;
                }
            }
        }

        private void 删除选中项toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.ListView_SkillProperties_Edit.SelectedItems.Count > 0)
                this.ListView_SkillProperties_Edit.SelectedItems[0].Remove();
        }

        private void 清空所有项toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.ListView_SkillProperties_Edit.Items.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                //功能.技能无CD();
                int.TryParse(textBox1.Text, out int c);
                功能.超级三速(c);
                全局变量.评分开关 = true;
            }
            else
            {
                //功能.技能无CDDisAble();
                功能.超级三速DisAble();
                全局变量.评分开关 = false;
            }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
                功能.全屏吸物();
            else
                功能.全屏吸物DisAble();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            HotKey.RegisterHotKey(Handle, 100, 0, Keys.F3);
            HotKey.RegisterHotKey(Handle, 101, 0, Keys.V);
            HotKey.RegisterHotKey(Handle, 102, 0, Keys.Oemtilde);
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            HotKey.UnregisterHotKey(Handle, 100);
            HotKey.UnregisterHotKey(Handle, 101);
            HotKey.UnregisterHotKey(Handle, 102);
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;//如果m.Msg的值为0x0312那么表示用户按下了热键
                                         //按快捷键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 100:    //按下的是Shift+S
                            修改属性();        //此处填写快捷键响应代码         
                            break;
                        case 101:    //按下的是Ctrl+B
                            if(checkBox4.Enabled == true)
                            功能.全屏吸物();                 //此处填写快捷键响应代码
                            break;
                        case 102:    //按下的是Alt+D
                                     //call.物品CALL(1111);         //此处填写快捷键响应代码
                                     // call.物品CALL(2600027);
                            
                            int.TryParse(textBox1.Text, out int c);
                            if(c == 0)
                                ReadWriteCtr.WriteMemInt(0x400604, 0);
                            else
                                ReadWriteCtr.WriteMemInt(0x400604, c);
                            //MessageBox.Show(Convert.ToString(c), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            call.物品CALL(2600656);
                            call.物品CALL(2600027);
                            //功能.miss设计图附伤();
                            //call.技能CALL(基址.人物基址,800,255,0,70059,0,200);
                            //int.TryParse(textBox1.Text, out int a);
                            //功能.超级三速(a);
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }
        [DllImport("Dll1.dll")]
        public static extern int SearchMemory(int 进程ID,byte[] buffer,int buffer_size);
        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();
        private unsafe void 测试_Click(object sender, EventArgs e)
        {
            //配置.打开配置();
            //MessageBox.Show(this.ListView_SkillProperties_Edit.Items[0].SubItems[0].Text);







            //call.释放call(基址.人物基址, 800, 255, 0, 54106, 0);
            //byte[] i1 = { 233 };
            //byte[] i2 = { 233 };
            //byte[] i3 = { 233 };
            //byte[] i4 = { 233 };
            //byte[] i5 = { 233 };
            //ReadWriteCtr.WriteMemByteArray(全局变量.进程ID, 0x400400, 转换.数组加法(i1, i2, i3, i4, i5), 0);
            //string str = System.Text.Encoding.Default.GetString(转换.数组加法(i1, i2, i3, i4, i5));
            //byte[] i = { 0xF0, 05, 00, 00, 0xE8, 03, 00, 00, 00, 00, 00, 00, 01, 00, 00, 00 };
            //SearchMemory(全局变量.进程ID, i, i.Length);
            //int c = -1;
            //int.TryParse(textBox1.Text, out c);
            //MessageBox.Show(Convert.ToString(c), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //功能.独家变怪();
            //call.物品CALL(1111);
            //uint tmp = 功能.内存药剂();
            //MessageBox.Show(Convert.ToString(tmp), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //byte[] i = { 1, 1, 1, 2, 1, 1 };
            //byte[] k = { 1, 1, 2 };
            //功能.定怪();
            //int j = Algorithm.Sunday(i, k);
            //MessageBox.Show(Convert.ToString(j), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //检测.处理检测();
            //功能.全屏遍历秒杀();
            //功能.公告("1123");
            //start();
            //EncDec.Decrypt(2220812064,基址.解密基址);
            // MessageBox.Show(TransCtr.FloatToInt(1140981760), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //int old = 0;
            //IntPtr handle = ProcessAPI.OpenProcess(ReadWriteAPI.PROCESS_ALL_ACCESS, false, 全局变量.进程ID); //获取句柄
            //ReadWriteCtr.VirtualProtectEx(handle, 0x55556E4, 1000, 64, &old);
            //MessageBox.Show(Convert.ToString(ReadWriteCtr.VirtualProtectEx(handle, 0x55556E4, 1000, 64, &old)), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //if (ReadWriteCtr.VirtualProtectEx(handle, 0x55556E4, 1000, 64, old) == false)
            //{

            //MessageBox.Show(Convert.ToString(GetLastError()), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
            //Asm asm = new Asm();
            //asm.CreateThread(全局变量.进程ID);
            //call.无敌call();
            //功能.miss设计图附伤();
            //call.卡经验();
            //功能.miss设计图附伤();
            //uint[] i = { 基址.物品栏, 基址.物品栏偏移, 基址.物品栏6, 0x28,0};
            //ReadWriteCtr.读偏移型(基址.人物基址,i);
            //MessageBox.Show(Convert.ToString(ReadWriteCtr.读偏移型(基址.人物基址, i)), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //EncDec.Encryption(全局变量.进程ID, (uint)(ReadWriteCtr.读偏移型(基址.人物基址, i) + 8),1,基址.解密基址);
            //功能.遍历城镇();
            //功能.超音速加速();

        }

        private void 独家变怪_CheckedChanged(object sender, EventArgs e)
        {
            if (独家变怪.Checked == true)
                功能.独家变怪();
            else
                功能.独家变怪DisAble();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            功能.内存药剂斗神();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
           
            功能.技能无CD();
            //功能.超级三速();
            //全局变量.评分开关 = true;
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {


            //只允许输入数字
            if (e.KeyChar == 0x20)
                e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0))
                return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out int c);
            if(c == 0)
            textBox1.Text = "";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
                功能.超音速加速();
            else
                功能.超音速加速DisAble();
        }

        private void 打开配置_Click(object sender, EventArgs e)
        {
            
            //Form1 form1 = new Form1();
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.InitialDirectory = "./";//注意这里写路径时要用c:\\而不是c:\
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "配置文件(*.ini)|*.ini";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                全局变量.配置文件路径 = file;
            }
            //MessageBox.Show(form1.ListView_SkillProperties_Edit.Items[0].SubItems[0].Text);
            ListView_SkillProperties_Edit.Items.Clear();
            IniFile ini = new IniFile(全局变量.配置文件路径);
            for (int i = 0; i < 100; i++)
            {
                string i1 = "operatorinformation" + i.ToString();
                if (ini.IniReadValue(i1, "技能公式") == "")
                    break;
                ListView_SkillProperties_Edit.Update();
                ListViewItem lvi = this.ListView_SkillProperties_Edit.Items.Add(ini.IniReadValue(i1, "技能公式"));
                lvi.SubItems.Add(ini.IniReadValue(i1, "技能数值"));
                lvi.SubItems.Add(ini.IniReadValue(i1, "技能描述"));
                lvi.SubItems.Add(ini.IniReadValue(i1, "原值"));
                ListView_SkillProperties_Edit.EndUpdate();
            }
        }
        public void 保存配置文件()
        {
            int i = 0;

            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "配置文件(*.ini)|*.ini";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                FileStream fs1 = new FileStream(saveDlg.FileName, FileMode.Create, FileAccess.Write);
                fs1.Close();
            }
            全局变量.保存配置文件路径 = saveDlg.FileName;
            //ListView_SkillProperties_Edit中有项目才进行修改
            if (ListView_SkillProperties_Edit.Items.Count > 0)
            {
                //循环项目数次
                for (i = 0; i < ListView_SkillProperties_Edit.Items.Count; i++)
                {
                    IniFile ini = new IniFile(全局变量.保存配置文件路径);
                    string i1 = "operatorinformation" + i.ToString();
                    ini.IniWriteValue(i1, "技能公式", ListView_SkillProperties_Edit.Items[i].SubItems[0].Text);
                    ini.IniWriteValue(i1, "技能数值", ListView_SkillProperties_Edit.Items[i].SubItems[1].Text);
                    ini.IniWriteValue(i1, "技能描述", ListView_SkillProperties_Edit.Items[i].SubItems[2].Text);
                    ini.IniWriteValue(i1, "原值", ListView_SkillProperties_Edit.Items[i].SubItems[3].Text);

                }
            }
            else
            {
                功能.公告("没有数据在list中");
            }
        }

        private void 保存配置_Click(object sender, EventArgs e)
        {
            保存配置文件();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                功能.公告("Combobox没有选中任何项。");
            }

            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                功能.公告("Combobox输入的文本为空。");
            }
            
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.ToString() == "远程卖物")
                    ReadWriteCtr.WriteMemInt(基址.卖修基址, 5);
                if (comboBox1.SelectedItem.ToString() == "远程修理")
                    ReadWriteCtr.WriteMemInt(基址.卖修基址, 6);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //只允许输入数字
            if (e.KeyChar == 0x20)
                e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0))
                return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox2.Text, out int c);
            if (c == 0)
                textBox2.Text = "";
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
                功能.独家弱怪();
            else
                功能.独家弱怪DisAble();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
                全局变量.全局吸怪 = true;
            else
                全局变量.全局吸怪 = false;
        }
    }
}
