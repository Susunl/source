using System;
using System.Text;
using System.Windows.Forms;

#region 调用例子
//CheckQQQun QQ = new CheckQQQun("306473605");
//QQ.CheckResult += new CheckQQQun.CheckQun(QQ_CheckResult);
//void QQ_CheckResult(bool Result)
//{
//    if (Result)
//    {
//        //已授权
//    }
//    else
//    {

//        //未授权
//    }
//}
#endregion
/// <summary>
/// QQ群验证
/// </summary>
public partial class CheckQQQun
{

    // 创建一个委托，返回类型为void，两个参数
    public delegate void CheckQun(bool Result);
    // 将创建的委托和特定事件关联,在这里特定的事件为KeyDown
    public event CheckQun CheckResult;
    WebBrowser webBrowser1 = new WebBrowser();
    public bool GetQunList;
    string CurrQun = string.Empty;
    public CheckQQQun(string Number)
    {
        CurrQun = Number;
        webBrowser1.Navigate("http://xui.ptlogin2.qq.com/div/qlogin_div.html?flag2=3&u1=http%253A%252F%252Fqun.qzone.qq.com%252Fgroup");
        webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
    }

    void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        var loginbtn = webBrowser1.Document.GetElementById("loginbtn");
        if (loginbtn != null)
        {
            webBrowser1.Document.GetElementById("loginbtn").InvokeMember("Click");
        }
        else
        {
            if (webBrowser1.Url.ToString().IndexOf("http://qun.qzone.qq.com/cgi-bin/get_group_list") == -1)
            {
                HtmlElement qqscript = webBrowser1.Document.CreateElement("script");
                qqscript.SetAttribute("type", "text/javascript");
                qqscript.SetAttribute("text", "function GetQQ(){return g_iUin;}");
                webBrowser1.Document.Body.AppendChild(qqscript);

                HtmlElement script = webBrowser1.Document.CreateElement("script");
                script.SetAttribute("type", "text/javascript");
                script.SetAttribute("text", "function GetToken(){return QWT.getACSRFToken()}");
                webBrowser1.Document.Body.AppendChild(script);
                webBrowser1.Navigate("http://qun.qzone.qq.com/cgi-bin/get_group_list?uin=" + webBrowser1.Document.InvokeScript("GetQQ").ToString() + "&g_tk=" + Convert.ToInt32(webBrowser1.Document.InvokeScript("GetToken").ToString()));
            }
            else
            {
                if (webBrowser1.DocumentText.IndexOf(CurrQun) != -1)
                {
                    if (CheckResult != null)
                    {
                        CheckResult(true);
                    }
                }
                else
                {
                    if (CheckResult != null)
                    {
                        CheckResult(false);
                    }
                }
            }
        }
    }
}