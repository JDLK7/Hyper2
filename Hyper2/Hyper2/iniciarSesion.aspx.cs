using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hyper.EN;
using Hyper.CAD;
using System.Net.Mail;

namespace Hyper2
{
    public partial class iniciarSesion : System.Web.UI.Page
    {

        private bool check_textBoxes()
        {
            bool r = true;


            if (textBox_username.Text == "")
            {
                textBox_username.BorderColor = System.Drawing.Color.Red;
                r = false;
            }

            if (textBox_password.Text == "")
            {
                textBox_password.BorderColor = System.Drawing.Color.Red;
                r = false;
            }

            return r;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button_logIn_Click(object sender, EventArgs e)
        {
            if (check_textBoxes())
            {
                if(UserCAD.userLogin(textBox_username.Text, textBox_password.Text))
                {
                    label_error.Text = "";
                    Session["sesionIniciada"] = true;
                    Response.Redirect("explorador.aspx");
                }

                else
                {
                    label_error.Text = "Credenciales inválidas";
                }
            }
        }
    }
}