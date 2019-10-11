using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;

namespace WebAPI.Controllers
{
    public class ImageController : ApiController
    {
        #region Declarations
        public string CurrentImage = string.Empty;
        #endregion

        #region DataModel
        public class ImageData
        {
            public string PostImage { get; set; }
        }
        #endregion

        #region MemberFunction
        /// <summary>
        /// 查詢圖片
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult CommonSearch()
        {
            CheckXML();
            return Ok(new
            {
                status = "1",
                message = "Success",
                image = CurrentImage
            });
        }

        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]ImageData dt)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlElement user = doc.CreateElement("User");

                XmlElement imageXml = doc.CreateElement("Infomation");
                imageXml.SetAttribute("CurrentImage", dt.PostImage);
                user.AppendChild(imageXml);

                doc.AppendChild(user);
                doc.Save(@"D:\Setting.xml");
                //implement insert into database atcion
                return Request.CreateResponse(HttpStatusCode.OK, "Successful message");
            }
            catch (Exception ie)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, "Error Message");
            }
        }

        /// <summary>
        /// 檢查XML是否存在
        /// </summary>
        private void CheckXML()
        {
            //檢查目錄下有沒有設定檔xml
            if (System.IO.File.Exists(@"D:\Setting.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(@"D:\Setting.xml");
                XmlNode xn = xmlDoc.SelectSingleNode("User");
                XmlNodeList totalInfo = xn.ChildNodes;
                foreach (var item in totalInfo)
                {
                    XmlElement xeB = (XmlElement)item;

                    if (xeB.OuterXml.Contains("CurrentImage"))
                        CurrentImage = xeB.GetAttribute("CurrentImage");
                }
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                XmlElement user = doc.CreateElement("User");

                XmlElement imageXml = doc.CreateElement("Infomation");
                imageXml.SetAttribute("CurrentImage", "");
                user.AppendChild(imageXml);

                doc.AppendChild(user);
                doc.Save(@"D:\Setting.xml");
            }
        }
        #endregion
    }
}
