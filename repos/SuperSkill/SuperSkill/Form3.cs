using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
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
            webBrowser1.Navigate("https://xui.ptlogin2.qq.com/cgi-bin/xlogin?pt_disable_pwd=1&appid=715030901&daid=73&hide_close_icon=1&pt_no_auth=1&s_url=https%3A%2F%2Fqun.qq.com%2Fmember.html%23");
            webBrowser1.ProgressChanged += WebBrowser1_ProgressChanged;
            webBrowser1.Navigated += WebBrowser1_Navigated;
        }
        private void WebBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (webBrowser1.Url.ToString().StartsWith("https://qun.qq.com/member.html"))
            {
                this.Hide();
            }
        }
        private string PrintDom(HtmlElementCollection elemColl, System.Text.StringBuilder returnStr, Int32 depth)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();

            foreach (HtmlElement elem in elemColl)
            {
                string elemName;

                elemName = elem.GetAttribute("ID");
                if (elemName == null || elemName.Length == 0)
                {
                    elemName = elem.GetAttribute("name");
                    if (elemName == null || elemName.Length == 0)
                    {
                        elemName = "<no name>";
                    }
                }

                str.Append(' ', depth * 4);
                str.Append(elemName + ": " + elem.TagName + "(Level " + depth + ")");
                returnStr.AppendLine(str.ToString());

                if (elem.CanHaveChildren)
                {
                    PrintDom(elem.Children, returnStr, depth + 1);
                }

                str.Remove(0, str.Length);
            }

            return (returnStr.ToString());
        }
        private bool checkUrlRedirect( String url = "" )
        {
            
            int result = url.IndexOf("qun.qq.com/member.html");
            if ( result > 0 )
            {
                MessageBox.Show(url);
                return true;

            }
            //MessageBox.Show(result.ToString());
            //Thread.Sleep(5000);
            return false;
        }
        public void FindKeyWord( WebBrowser wb , string keyWord)
        {
            foreach (HtmlElement item in wb.Document.All)
            {
                if (item.InnerText != null)
                {
                    if (ClearChar(item.InnerText) == keyWord)
                    {
                        MessageBox.Show("123");
                        break;
                    }
                }
            }

        }
        public void Write(string i)
        {
            FileStream fs = new FileStream("E:\\ak.txt", FileMode.Create);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(i);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }

        public string ClearChar(string str)
        {
            str = str.Replace("\n", null);
            str = str.Replace("\r", null);
            str = str.Replace("&nbsp;", null);
            str = str.Replace(" ", null);
            return str;
        }

        private Boolean check( WebBrowser webBrowser)
        {
            HtmlElementCollection i = webBrowser.Document.GetElementsByTagName("LI");
            String output="";
            foreach ( HtmlElement item in i )
            {
                //output = output + " \n\r" +"title:" + item.GetAttribute("title") + "data-id:"+item.GetAttribute("data-id");
                output = output + item.OuterHtml;
            }
            if(output.IndexOf("624核心骨干交流群") > 0)
                Write(output);
            return false;
        }

        private void WebBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            
            if (webBrowser1.Url.ToString().StartsWith("https://qun.qq.com/member.html"))
            {
                object[] o = new object[1];
                o[0] = "$.post('https://qun.qq.com/cgi-bin/qun_mgr/get_group_list','bkn='+$.getCSRFToken(),function(data,status){if ( data != '' ) {var json = '';if ( data instanceof Object ) {json = JSON.stringify(data);}else{json = datg;}$('body').append('<div id=\'susunl_grouplist\'>'+json+'</div>');}});";
                webBrowser1.Document.InvokeScript("message",o);
                HtmlElement htmlElement = webBrowser1.Document.GetElementById("susunl_grouplist");
                htmlElement.
                return;
                HtmlElementCollection i = webBrowser1.Document.GetElementsByTagName("LI");
                if (i == null)
                {
                    return;
                }
                String output = "";
                foreach (HtmlElement item in i)
                {
                    //output = output + " \n\r" +"title:" + item.GetAttribute("title") + "data-id:"+item.GetAttribute("data-id");
                    output = output + item.OuterHtml;
                }
                if (output.IndexOf("SuperSkills") < 0)
                {
                    return;
                }
                //HtmlElementCollection hec = webBrowser1.Document.GetElementsByTagName("div");//< div class="my-all-group">
                //string str = PrintDom(hec, new System.Text.StringBuilder(), 0);
                //Write(str);
                //foreach (HtmlElement he in hec)
                //{
                //    string cat_name = he.GetAttribute("className");
                //    MessageBox.Show(cat_name);
                //}
                //MessageBox.Show("判断成功");
                //Thread.Sleep(2000);
                webBrowser1.ProgressChanged -= WebBrowser1_ProgressChanged;
                if (output.IndexOf("SuperSkills") > 0 && output.IndexOf("835290838") > 0)
                {
                    MessageBox.Show("验证成功");
                    CloseChrome();
                    Form1 form2 = new Form1();
                    form2.Show();
                    this.Dispose(false);
                }
                else
                {
                    MessageBox.Show("请加指定交流群:835290838");
                    CloseChrome();
                    Application.Exit();
                }
                //string groupid = "1072040879";
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
