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
        /// <summary>
        /// Comprueba que los campos estén completados. Si no lo están
        /// colorea su borde de rojo para captar la atención del usuario.
        /// </summary>
        /// <returns></returns> Booleano que indica si se han rellenado los campos.
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

        /// <summary>
        /// Comprueba los datos introducidos por el usuario.
        /// Si estan bien inicia una nueva sesión.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void button_logIn_Click(object sender, EventArgs e)
        {
            if (check_textBoxes())
            {
                if(UserCAD.userLogin(textBox_username.Text, textBox_password.Text))
                {
                    label_error.Text = "";
                    Session["sesionIniciada"] = true;
                    Session["username"] = textBox_username.Text;

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