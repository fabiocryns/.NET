using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace DoctorPractice
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/Taglines.xml"));
            XmlNodeList nodes = doc.SelectNodes("/Taglines/Tagline");            Label1.Text = nodes.Item(new Random().Next(0, nodes.Count-1)).InnerText;
        }
    }
}