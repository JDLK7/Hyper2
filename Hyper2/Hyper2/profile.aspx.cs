using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hyper.CAD;

namespace Hyper2
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            profilePic.ImageUrl = "IMG/" + Session["username"].ToString() + ".jpg";
            LabelNombre.Text = "<b>Nombre de usuario:</b> xd";
            LabelEmail.Text = "<b>Email: </b>" + UserCAD.getField(Session["username"].ToString(), "email");
            LabelPlan.Text = "<b>Plan: </b>" + UserCAD.getField(Session["username"].ToString(), "plan");
        }
    }
}