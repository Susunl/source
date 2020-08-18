namespace SuperSkill
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.读取职业技能 = new System.Windows.Forms.Button();
            this.SysTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.SysTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ListView_Skill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListView_SkillProperties = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListView_SkillProperties_Edit = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除选中项toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.清空所有项toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBox_SearchSkill = new System.Windows.Forms.TextBox();
            this.Button_SearchSkill = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.独家变怪 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.保存配置 = new System.Windows.Forms.Button();
            this.打开配置 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "初始化";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 读取职业技能
            // 
            this.读取职业技能.Location = new System.Drawing.Point(82, 1);
            this.读取职业技能.Name = "读取职业技能";
            this.读取职业技能.Size = new System.Drawing.Size(86, 23);
            this.读取职业技能.TabIndex = 4;
            this.读取职业技能.Text = "读取职业技能";
            this.读取职业技能.UseVisualStyleBackColor = true;
            this.读取职业技能.Click += new System.EventHandler(this.button3_Click);
            // 
            // SysTimeTimer
            // 
            this.SysTimeTimer.Interval = 500;
            this.SysTimeTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SysTime
            // 
            this.SysTime.AutoSize = true;
            this.SysTime.BackColor = System.Drawing.SystemColors.Highlight;
            this.SysTime.Location = new System.Drawing.Point(255, 6);
            this.SysTime.Name = "SysTime";
            this.SysTime.Size = new System.Drawing.Size(53, 12);
            this.SysTime.TabIndex = 5;
            this.SysTime.Text = "当前时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(255, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Made By Susunl";
            // 
            // ListView_Skill
            // 
            this.ListView_Skill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.ListView_Skill.FullRowSelect = true;
            this.ListView_Skill.GridLines = true;
            this.ListView_Skill.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListView_Skill.Location = new System.Drawing.Point(1, 57);
            this.ListView_Skill.Name = "ListView_Skill";
            this.ListView_Skill.Size = new System.Drawing.Size(256, 351);
            this.ListView_Skill.TabIndex = 7;
            this.ListView_Skill.TabStop = false;
            this.ListView_Skill.UseCompatibleStateImageBehavior = false;
            this.ListView_Skill.View = System.Windows.Forms.View.Details;
            this.ListView_Skill.SelectedIndexChanged += new System.EventHandler(this.ListView_Skill_SelectedIndexChanged);
            this.ListView_Skill.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView_Skill_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "公式";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "技能名称";
            this.columnHeader2.Width = 196;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "等级";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 37;
            // 
            // ListView_SkillProperties
            // 
            this.ListView_SkillProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.ListView_SkillProperties.FullRowSelect = true;
            this.ListView_SkillProperties.GridLines = true;
            this.ListView_SkillProperties.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListView_SkillProperties.Location = new System.Drawing.Point(290, 65);
            this.ListView_SkillProperties.Name = "ListView_SkillProperties";
            this.ListView_SkillProperties.Size = new System.Drawing.Size(275, 145);
            this.ListView_SkillProperties.TabIndex = 11;
            this.ListView_SkillProperties.TabStop = false;
            this.ListView_SkillProperties.UseCompatibleStateImageBehavior = false;
            this.ListView_SkillProperties.View = System.Windows.Forms.View.Details;
            this.ListView_SkillProperties.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView_SkillProperties_MouseDoubleClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "数值";
            this.columnHeader4.Width = 88;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "公式";
            this.columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "地址";
            this.columnHeader6.Width = 69;
            // 
            // ListView_SkillProperties_Edit
            // 
            this.ListView_SkillProperties_Edit.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.ListView_SkillProperties_Edit.ContextMenuStrip = this.contextMenuStrip1;
            this.ListView_SkillProperties_Edit.FullRowSelect = true;
            this.ListView_SkillProperties_Edit.GridLines = true;
            this.ListView_SkillProperties_Edit.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListView_SkillProperties_Edit.Location = new System.Drawing.Point(263, 237);
            this.ListView_SkillProperties_Edit.Name = "ListView_SkillProperties_Edit";
            this.ListView_SkillProperties_Edit.Size = new System.Drawing.Size(275, 170);
            this.ListView_SkillProperties_Edit.TabIndex = 13;
            this.ListView_SkillProperties_Edit.TabStop = false;
            this.ListView_SkillProperties_Edit.UseCompatibleStateImageBehavior = false;
            this.ListView_SkillProperties_Edit.View = System.Windows.Forms.View.Details;
            this.ListView_SkillProperties_Edit.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView_SkillProperties_Edit_MouseDoubleClick);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "公式";
            this.columnHeader7.Width = 0;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "属性数值";
            this.columnHeader8.Width = 84;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "备注";
            this.columnHeader9.Width = 110;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "原值";
            this.columnHeader10.Width = 58;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除选中项toolStripMenuItem1,
            this.清空所有项toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 48);
            // 
            // 删除选中项toolStripMenuItem1
            // 
            this.删除选中项toolStripMenuItem1.Name = "删除选中项toolStripMenuItem1";
            this.删除选中项toolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.删除选中项toolStripMenuItem1.Text = "删除选中项";
            this.删除选中项toolStripMenuItem1.Click += new System.EventHandler(this.删除选中项toolStripMenuItem1_Click);
            // 
            // 清空所有项toolStripMenuItem2
            // 
            this.清空所有项toolStripMenuItem2.Name = "清空所有项toolStripMenuItem2";
            this.清空所有项toolStripMenuItem2.Size = new System.Drawing.Size(136, 22);
            this.清空所有项toolStripMenuItem2.Text = "清空所有项";
            this.清空所有项toolStripMenuItem2.Click += new System.EventHandler(this.清空所有项toolStripMenuItem2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(-1, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 14;
            this.label2.Text = "搜索技能名";
            // 
            // TextBox_SearchSkill
            // 
            this.TextBox_SearchSkill.Location = new System.Drawing.Point(82, 30);
            this.TextBox_SearchSkill.Name = "TextBox_SearchSkill";
            this.TextBox_SearchSkill.Size = new System.Drawing.Size(107, 21);
            this.TextBox_SearchSkill.TabIndex = 15;
            this.TextBox_SearchSkill.TabStop = false;
            this.TextBox_SearchSkill.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_SearchSkill_KeyPress);
            // 
            // Button_SearchSkill
            // 
            this.Button_SearchSkill.Location = new System.Drawing.Point(195, 24);
            this.Button_SearchSkill.Name = "Button_SearchSkill";
            this.Button_SearchSkill.Size = new System.Drawing.Size(47, 27);
            this.Button_SearchSkill.TabIndex = 16;
            this.Button_SearchSkill.TabStop = false;
            this.Button_SearchSkill.Text = "搜索";
            this.Button_SearchSkill.UseVisualStyleBackColor = true;
            this.Button_SearchSkill.Click += new System.EventHandler(this.Button_SearchSkill_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(440, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "F3属性修改";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "修改属性(双击修改,右键删除)";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(542, 35);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "一键牛逼";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(542, 79);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(66, 16);
            this.checkBox4.TabIndex = 23;
            this.checkBox4.Text = "V键吸物";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // 独家变怪
            // 
            this.独家变怪.AutoSize = true;
            this.独家变怪.Enabled = false;
            this.独家变怪.Location = new System.Drawing.Point(633, 62);
            this.独家变怪.Name = "独家变怪";
            this.独家变怪.Size = new System.Drawing.Size(90, 16);
            this.独家变怪.TabIndex = 25;
            this.独家变怪.Text = "真.独家变怪";
            this.独家变怪.UseVisualStyleBackColor = true;
            this.独家变怪.CheckedChanged += new System.EventHandler(this.独家变怪_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(542, 123);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 26;
            this.checkBox2.Text = "团本功能";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(542, 101);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(72, 16);
            this.checkBox3.TabIndex = 27;
            this.checkBox3.Text = "技能无CD";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(542, 145);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 21);
            this.textBox1.TabIndex = 28;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "伤害修改";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(542, 172);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(72, 16);
            this.checkBox5.TabIndex = 29;
            this.checkBox5.Text = "城镇加速";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // 保存配置
            // 
            this.保存配置.Location = new System.Drawing.Point(542, 384);
            this.保存配置.Name = "保存配置";
            this.保存配置.Size = new System.Drawing.Size(75, 23);
            this.保存配置.TabIndex = 30;
            this.保存配置.Text = "保存配置";
            this.保存配置.UseVisualStyleBackColor = true;
            this.保存配置.Click += new System.EventHandler(this.保存配置_Click);
            // 
            // 打开配置
            // 
            this.打开配置.Location = new System.Drawing.Point(542, 355);
            this.打开配置.Name = "打开配置";
            this.打开配置.Size = new System.Drawing.Size(75, 23);
            this.打开配置.TabIndex = 31;
            this.打开配置.Text = "打开配置";
            this.打开配置.UseVisualStyleBackColor = true;
            this.打开配置.Click += new System.EventHandler(this.打开配置_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "远程卖物",
            "远程修理"});
            this.comboBox1.Location = new System.Drawing.Point(542, 194);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(77, 20);
            this.comboBox1.TabIndex = 32;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(633, 35);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(85, 21);
            this.textBox2.TabIndex = 33;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "移速修改.默认";
            this.textBox2.Click += new System.EventHandler(this.textBox2_Click);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(542, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 25);
            this.label5.TabIndex = 35;
            this.label5.Text = "以下为赞助12功能";
            // 
            // label4
            // 
            this.label4.Image = global::SuperSkill.Properties.Resources.安排也;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label4.Location = new System.Drawing.Point(540, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 86);
            this.label4.TabIndex = 34;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(633, 84);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(90, 16);
            this.checkBox6.TabIndex = 36;
            this.checkBox6.Text = "真.独家弱怪";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(542, 57);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(72, 16);
            this.checkBox7.TabIndex = 37;
            this.checkBox7.Text = "一键吸怪";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(542, 220);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 38;
            this.button3.Text = "真.团本功能";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(633, 106);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 39;
            this.button4.Text = "测试";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 410);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkBox7);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.打开配置);
            this.Controls.Add(this.保存配置);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.独家变怪);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Button_SearchSkill);
            this.Controls.Add(this.TextBox_SearchSkill);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ListView_SkillProperties_Edit);
            this.Controls.Add(this.ListView_SkillProperties);
            this.Controls.Add(this.ListView_Skill);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SysTime);
            this.Controls.Add(this.读取职业技能);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Su超级技能大佬赞助版本";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button 读取职业技能;
        private System.Windows.Forms.Timer SysTimeTimer;
        private System.Windows.Forms.Label SysTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView ListView_Skill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView ListView_SkillProperties;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBox_SearchSkill;
        private System.Windows.Forms.Button Button_SearchSkill;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除选中项toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 清空所有项toolStripMenuItem2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox 独家变怪;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.CheckBox checkBox5;
        public  System.Windows.Forms.ListView ListView_SkillProperties_Edit;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button 保存配置;
        private System.Windows.Forms.Button 打开配置;
        private System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

