using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
namespace ZhenziSms
{
    public class ZhenziSmsClient
    {
        private static readonly string DEFAULT_CHARSET = "UTF-8";
        private static readonly int CONNECTION_TIMEOUT = 20 * 1000;
        private static readonly int READ_TIMEOUT = 20 * 1000;
        private String apiUrl = "";
        private string appId;
        private string appSecret;

        public ZhenziSmsClient(string apiUrl, string appId, string appSecret)
        {
            this.apiUrl = apiUrl;
            this.appId = appId;
            this.appSecret = appSecret;
        }
        public String Send(Dictionary<string, string> parameters)
        {
            parameters.Add("appId", appId);
            parameters.Add("appSecret", appSecret);
            var result = DoPost(apiUrl + "/sms/send.do", parameters, DEFAULT_CHARSET, CONNECTION_TIMEOUT,
                    READ_TIMEOUT);
            return result;
        }

        public String Balance()
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("appId", appId);
            parameters.Add("appSecret", appSecret);

            var result = DoPost(apiUrl + "/account/balance.do",
                parameters,
                DEFAULT_CHARSET,
                CONNECTION_TIMEOUT,
                READ_TIMEOUT);
            return result;
        }
        public String FindSmsByMessageId(string messageId)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("appId", appId);
            parameters.Add("appSecret", appSecret);
            parameters.Add("messageId", messageId);
            var result = DoPost(apiUrl + "/smslog/findSmsByMessageId.do",
                parameters,
                DEFAULT_CHARSET,
                CONNECTION_TIMEOUT,
                READ_TIMEOUT);
            return result;
        }
        private string DoPost(string url, Dictionary<string, string> parameters, string charset, int connectionTimeout, int readTimeout)
        {
            var ret = string.Empty;
            var contentType = "application/x-www-form-urlencoded;charset=" + charset;
            var encoding = BuildEncoding(charset);
            var query = BuildQuery(parameters, encoding);
            var queryBytes = encoding.GetBytes(query);
            var httpRequest = BuildRequest(url, contentType, queryBytes);

            var requestStream = httpRequest.GetRequestStream();
            requestStream.Write(queryBytes, 0, queryBytes.Length);

            using (var rsp = httpRequest.GetResponse())
            {
                using (var rspStream = rsp.GetResponseStream())
                {
                    using (var streamReader = new StreamReader(rspStream))
                    {
                        ret = streamReader.ReadToEnd();
                    }
                }
            }

            return ret;

        }
        private Encoding BuildEncoding(string charset)
        {
            var encoding = Encoding.UTF8;
            if (!string.IsNullOrEmpty(charset))
            {
                encoding = Encoding.GetEncoding(charset);
            }

            return encoding;
        }

        private HttpWebRequest BuildRequest(string url, string contentType, byte[] queryBytes)
        {
            HttpWebRequest httpRequest = null;
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                //ServicePointManager.SecurityProtocol = spt; //不指定,使之自动协商/适应, 避免指定的版本与服务器不一样反而连不上
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                httpRequest = WebRequest.Create(url) as HttpWebRequest;
                httpRequest.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                httpRequest = WebRequest.Create(url) as HttpWebRequest;
            }
            httpRequest.Method = "POST";
            httpRequest.ContentType = contentType;
            httpRequest.Accept = "text/xml,text/javascript,text/html";
            httpRequest.ContentLength = queryBytes.Length;
            return httpRequest;
        }

        /// <summary>
        /// 默认charset为UTF-8
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public String BuildQuery(Dictionary<string, string> parameters, Encoding encoding)
        {
            if ((parameters == null) || (parameters.Count == 0))
            {
                return string.Empty;
            }

            var query = new StringBuilder();
            var hasParam = false;

            foreach (var kvp in parameters)
            {
                String name = kvp.Key;
                String value = kvp.Value;
                if (!string.IsNullOrEmpty(name))
                {
                    if (hasParam)
                    {
                        query.Append("&");
                    }
                    else
                    {
                        hasParam = true;
                    }
                    query.Append(name).Append("=").Append(HttpUtility.UrlEncode(value, encoding));
                }
            }
            return query.ToString();
        }
        private bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受
        }
    }
}
