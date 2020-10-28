using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 稍后_Click(object sender, EventArgs e)
        {
            this.Hide();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Show();
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
