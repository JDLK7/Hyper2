using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Hyper2
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["sesionIniciada"] != null) && ((bool)(Session["sesionIniciada"]) == true))
            {
                ButtonIniciarSesion.Visible = false;
                ButtonRegistrarse.Visible = false;
                dropDownSession.Visible = true;
            }
            else
            {
                ButtonIniciarSesion.Visible = true;
                ButtonRegistrarse.Visible = true;
                dropDownSession.Visible = false;
            }
        }

        protected void redirectIniciarSesion(object sender, EventArgs e)
        {
            Response.Redirect("~/iniciarSesion.aspx");
        }

        protected void redirectRegistrarse(object sender, EventArgs e)
        {
            Response.Redirect("~/registro.aspx");
        }

        protected void dropDownSession_IndexChanged(object sender, EventArgs e)
        {
            switch (dropDownSession.SelectedIndex)
            {
                case 0:
                    Response.Redirect("explorador.aspx");
                    break;
                case 1:
                    Response.Redirect("profile.aspx");
                    break;
                case 2:
                    Response.Redirect("messages.aspx");
                    break;
                case 3:
                    Response.Redirect("manageaccount.aspx");
                    break;
                case 4:
                    Session["sesionIniciada"] = false;
                    Session["username"] = "";
                    Response.Redirect("index.aspx");
                    break;
            }
        }
    }
}