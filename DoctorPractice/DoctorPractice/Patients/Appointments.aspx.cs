using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorPractice.Patients
{
    public partial class Appointments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDataSource1.XPath = "/Appointments/Appointment[@Patient=\""+User.Identity.Name+"\"]";
        }
    }
}