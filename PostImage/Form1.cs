using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostImage
{
    public partial class Form1 : Form
    {
        #region Declarations
        public string _PostUrl = @"http://localhost:2622/";
        public string _ImagePath = string.Empty;
        #endregion

        #region Property
        public string ImagePath { get; set; }
        public string Image { get; set; }
        public string PostUrl
        {
            get { return _PostUrl; }
            set { _PostUrl = value; }
        }
        #endregion

        #region DataModel
        public class ImageData
        {
            public string PostImage { get; set; }
        }
        #endregion

        #region MemberFunction
        public Form1()
        {
            InitializeComponent();
            PostUrl = @"http://localhost:2622/Api/Image/Post";
            tbUrl.Text = PostUrl;
        }

        private void btChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select File";
            dialog.InitialDirectory = ".\\";
            if (dialog.ShowDialog() == DialogResult.OK)
                ImagePath = dialog.FileName;
            tbImage.Text = ImagePath;
            Image = ImageToBase64String();
        }

        private void btPost_Click(object sender, EventArgs e)
        {
            PostAction();
            APIConnector.Get(tbWeb.Text);
        }

        public string ImageToBase64String()
        {

            using (Image image = System.Drawing.Image.FromFile(ImagePath))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
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

        public void PostAction()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    ImageData data = new ImageData { PostImage = Image };
                    client.BaseAddress = new Uri(PostUrl);
                    var response = client.PostAsJsonAsync("", data).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        tbConsole.Text += DateTime.Now.ToLongTimeString() + " Success\r\n";
                    }
                    else
                        tbConsole.Text += DateTime.Now.ToLongTimeString() + " Error\r\n";
                }
            }
            catch (Exception ie)
            {
                MessageBox.Show(ie.Message + "\r\n" + ie.StackTrace);
            }

        }
        #endregion
    }
}
