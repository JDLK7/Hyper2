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
            Session["sesionIniciada"] = false;

            if ((bool)(Session["sesionIniciada"]) == false)
            {

                ButtonIniciarSesion.Visible = true;
                ButtonRegistrarse.Visible = true;
                dropDownSesionIniciada.Visible = false;

            }
            else
            {

                ButtonIniciarSesion.Visible = false;
                ButtonRegistrarse.Visible = false;
                dropDownSesionIniciada.Visible = true;

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

    }
}