using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ViewImage
{
    public partial class _default : System.Web.UI.Page
    {
        #region MemberFunction
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            JObject jo = JObject.Parse(APIConnector.Get(tbUrl.Text));
            lbImg.Text = "<img src='data: image / png; base64,  " + jo.GetValue("image") + "' />";
        }
        public static class APIConnector
        {
            public static string Get(string url, Dictionary<string, string> headers = null, Func<HttpWebRequest, HttpWebResponse, string> hook = null)
            {
                string result = "ErrorCode:404";
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = "application/json";
                    request.ContentType = "application/json";
                    if (headers != null)
                    {
                        foreach (string key in headers.Keys)
                        {
                            request.Headers[key] = headers[key];
                        }
                    }
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            if (hook == null)
                            {
                                using (Stream sm = response.GetResponseStream())
                                using (StreamReader reader = new StreamReader(sm))
                                {
                                    result = reader.ReadToEnd();
                                }
                            }
                            else
                                result = hook(request, response);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return result;
            }
        }
        #endregion
    }
}