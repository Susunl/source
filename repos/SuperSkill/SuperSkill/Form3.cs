using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SuperSkill
{
    public partial class 群验证 : Form
    {
        public 群验证()
        {
            InitializeComponent();
        }

        private void 群验证_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("本程序完全开源，仅供编程爱好者交流研究 请于下载后24小时内自行删除 由本程序引起的一切后果自负\n 点击确定即代表你同意此声明");
            webBrowser1.Navigate("http://xui.ptlogin2.qq.com/cgi-bin/xlogin?appid=549000912&daid=5&style=40&s_url=http://qun.qzone.qq.com/group");
            webBrowser1.ProgressChanged += WebBrowser1_ProgressChanged;
            webBrowser1.Navigated += WebBrowser1_Navigated;
        }
        private void WebBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (webBrowser1.Url.ToString().StartsWith("http://qun.qzone.qq.com"))
            {
                this.Hide();
            }
        }

        private void WebBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {

            if (webBrowser1.Url.ToString().StartsWith("http://qun.qzone.qq.com"))
            {
                HtmlElement groupList = webBrowser1.Document.GetElementById("my_group_list_container");
                if (groupList == null)
                {
                    return;
                }
                webBrowser1.ProgressChanged -= WebBrowser1_ProgressChanged;
                string groupListText = webBrowser1.DocumentText;
                string groupid = "1072040879";
                if (Regex.IsMatch(groupListText, $"data-groupid=\"{groupid}\""))
                {
                    //MessageBox.Show("验证成功");
                    CloseChrome();
                    Form1 form2 = new Form1();
                    form2.Show();
                    this.Dispose(false);

                }
                else
                {
                    //MessageBox.Show("请加指定交流群:835290838");
                    CloseChrome();
                    Application.Exit();
                }
            }
        }
        public void CloseChrome()
        {
            if (webBrowser1 != null)
            {
                webBrowser1.Dispose();
            }
        }
    }
}
