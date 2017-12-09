using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalculatorWebForm
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = this.Request.Browser.Browser;
            if(this.IsPostBack == false)
            {
                Random rnd = new Random();
                TextBox1.Text = rnd.Next().ToString();
                TextBox2.Text = rnd.Next().ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int number1 = int.Parse(TextBox1.Text);
            int number2 = int.Parse(TextBox2.Text);

            Label1.Text = (number1 + number2).ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int number1 = int.Parse(TextBox1.Text);
            int number2 = int.Parse(TextBox2.Text);

            Label1.Text = (number1 * number2).ToString();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Other.aspx?number=" + TextBox1.Text);
        }
    }
}