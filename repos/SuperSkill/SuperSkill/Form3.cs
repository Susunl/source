using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static void Write(string i)
        {
            FileStream fs = new FileStream("C:\\ak.txt", FileMode.Create);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(i);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }
        public static bool check(HtmlElement htmlElement)
        {

            //if (htmlElement.OuterText.IndexOf("{\"gc\":835290838,\"gn\":\"SuperSkills\",\"owner\":1253013130}") > 0)
            //{
            //    //MessageBox.Show("yes");
            //    return true;
            //}
            //MessageBox.Show("no");
            try
            {
                string i = htmlElement.OuterText;
                if (i == "{\"ec\":0,\"errcode\":0,\"em\":\"\"}")
                {
                    MessageBox.Show("你并没有加入任何群臭弟弟");
                    return false;
                }
                RootObject r = JsonConvert.DeserializeObject<RootObject>(i);
                foreach (Join ep in r.join)
                {
                    if (ep.gc == "876555510" && ep.gn == "SuperSkills赞助群" && ep.owner == "1253013130")
                    {
                        //MessageBox.Show("yes");
                        return true;
                    }
                }
                foreach (Create ep in r.create)
                {
                    if (ep.gc == "876555510" && ep.gn == "SuperSkills赞助群" && ep.owner == "1253013130")
                    {
                        //MessageBox.Show("yes");
                        return true;
                    }
                }
                foreach (Manage ep in r.manage)
                {
                    if (ep.gc == "876555510" && ep.gn == "SuperSkills赞助群" && ep.owner == "1253013130")
                    {
                        //MessageBox.Show("yes");
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        public class Join
        {
            public string gc { get; set; }
            public string gn { get; set; }
            public string owner { get; set; }
        }

        public class Manage
        {
            public string gc { get; set; }
            public string gn { get; set; }
            public string owner { get; set; }
        }

        public class Create
        {
            public string gc { get; set; }
            public string gn { get; set; }
            public string owner { get; set; }
        }

        public class RootObject
        {
            public string ec { get; set; }
            public string errcode { get; set; }
            public string em { get; set; }
            public List<Join> join { get; set; }
            public List<Manage> manage { get; set; }
            public List<Create> create { get; set; }
        }

        private void doFunctionInPage()
        {
            webBrowser1.Document.InvokeScript("CreateSusunl");
        }

        static bool check_AddFunctionStatus = false;
        public void addFunctionToPage()
        {
            if (!check_AddFunctionStatus)
            {
                //
                HtmlElement script = webBrowser1.Document.CreateElement("script");
                script.SetAttribute("type", "text/javascript");
                script.SetAttribute("text", "function CreateSusunl(){ $.post('https://qun.qq.com/cgi-bin/qun_mgr/get_group_list','bkn='+$.getCSRFToken(),function(data,status){CreateDom(data,status);} );}");
                HtmlElement head = webBrowser1.Document.Body.AppendChild(script);

                //
                HtmlElement script2 = webBrowser1.Document.CreateElement("script");
                script2.SetAttribute("type", "text/javascript");
                script2.SetAttribute("text", "function CreateDom(data,status){ if ( data != '' ) {var json = '';if ( data instanceof Object ) {json = JSON.stringify(data);}else{json = data;}$('body').append('<div id=\"susunl_grouplist\">'+json+'</div>' ); }else{ CreateSusunl(); } } ");
                HtmlElement head1 = webBrowser1.Document.Body.AppendChild(script2);
                //MessageBox.Show(head1.OuterText);

                //
                //webBrowser1.Document.InvokeScript("CreateSusunl");

                //webBrowser1.Document.InvokeScript("CreateDom");
                check_AddFunctionStatus = true;
                doFunctionInPage();
            }
        }

        private void WebBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {

            if (webBrowser1.Url.ToString().StartsWith("https://qun.qq.com/member.html"))
            {

                addFunctionToPage();
                HtmlElement htmlElement = webBrowser1.Document.GetElementById("susunl_grouplist");
                if (htmlElement == null)
                    return;
                if (check(htmlElement))
                {
                    CloseChrome();
                    Form1 form2 = new Form1();
                    form2.Show();
                    Dispose(false);
                }
                else
                {
                    CloseChrome();
                    Environment.Exit(0);
                }
                //string groupListText = webBrowser1.DocumentText;
                //string groupid = "835290838";
                //if (Regex.IsMatch(groupListText, $"data-groupid=\"{groupid}\""))
                //{
                //    //MessageBox.Show("验证成功");
                //    CloseChrome();
                //    Form1 form2 = new Form1();
                //    form2.Show();
                //    Dispose(false);

                //}
                //else
                //{
                //    //MessageBox.Show("请加指定交流群:835290838");
                //    CloseChrome();
                //    Application.Exit();
                //}
                //HtmlElementCollection i = webBrowser1.Document.GetElementsByTagName("LI");
                //if (i == null)
                //{
                //    return;
                //}
                //String output = "";
                //foreach (HtmlElement item in i)
                //{
                //    //output = output + " \n\r" +"title:" + item.GetAttribute("title") + "data-id:"+item.GetAttribute("data-id");
                //    output = output + item.OuterHtml;
                //}
                //if (output.IndexOf("SuperSkills") < 0)
                //{
                //    return;
                //}
                ////HtmlElementCollection hec = webBrowser1.Document.GetElementsByTagName("div");//< div class="my-all-group">
                ////string str = PrintDom(hec, new System.Text.StringBuilder(), 0);
                ////Write(str);
                ////foreach (HtmlElement he in hec)
                ////{
                ////    string cat_name = he.GetAttribute("className");
                ////    MessageBox.Show(cat_name);
                ////}
                ////MessageBox.Show("判断成功");
                ////Thread.Sleep(2000);
                //webBrowser1.ProgressChanged -= WebBrowser1_ProgressChanged;
                //if (output.IndexOf("SuperSkills") > 0 && output.IndexOf("835290838") > 0)
                //{
                //    MessageBox.Show("验证成功");
                //    CloseChrome();
                //    Form1 form2 = new Form1();
                //    form2.Show();
                //    Dispose(false);
                //}
                //else
                //{
                //    MessageBox.Show("请加指定交流群:835290838");
                //    CloseChrome();
                //    Application.Exit();
                //}
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
