//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace SuperSkill
//{
//    class @new
//    {
//        private void PrintDomBegin()
//        {
//            if (webBrowser1.Document != null)
//            {
//                HtmlElementCollection elemColl = null;
//                HtmlDocument doc = webBrowser1.Document;
//                if (doc != null)
//                {
//                    elemColl = doc.GetElementsByTagName("HTML");
//                    String str = PrintDom(elemColl, new System.Text.StringBuilder(), 0);
//                    webBrowser1.DocumentText = str;
//                }
//            }
//        }

//        private string PrintDom(HtmlElementCollection elemColl, System.Text.StringBuilder returnStr, Int32 depth)
//        {
//            System.Text.StringBuilder str = new System.Text.StringBuilder();

//            foreach (HtmlElement elem in elemColl)
//            {
//                string elemName;

//                elemName = elem.GetAttribute("ID");
//                if (elemName == null || elemName.Length == 0)
//                {
//                    elemName = elem.GetAttribute("name");
//                    if (elemName == null || elemName.Length == 0)
//                    {
//                        elemName = "<no name>";
//                    }
//                }

//                str.Append(' ', depth * 4);
//                str.Append(elemName + ": " + elem.TagName + "(Level " + depth + ")");
//                returnStr.AppendLine(str.ToString());

//                if (elem.CanHaveChildren)
//                {
//                    PrintDom(elem.Children, returnStr, depth + 1);
//                }

//                str.Remove(0, str.Length);
//            }

//            return (returnStr.ToString());
//        }
//    }
//}
