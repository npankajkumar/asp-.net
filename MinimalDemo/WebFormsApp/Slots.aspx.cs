using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsApp
{
    public partial class Slots : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
         
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("<b>you clicked the button</b>");
            Response.Write("<button>Click me</button>");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("text changes");
            Response.Write("<button>Add</button>");
        }
    
       
    }
}