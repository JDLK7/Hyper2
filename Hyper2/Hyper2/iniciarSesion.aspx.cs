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

        /*
         * Método que comprueba si el nombre de usuario introducido está disponible o ya esta en uso.
         * En caso contrario se indica en un bajo el textBox correspondiente.
         * Devuelve un booleano.
         */
        private bool check_username()
        {
            string user = textBox_username.Text;

            if (user.Length > 16)
            {
                label_username.Text = "No puede superar los 16 caracteres";
                return false;
            }
            else
            {
                if (UserCAD.SearchUsername(textBox_username.Text))
                {
                    label_username.Text = "El nombre de usuario ya está en uso";
                    return false;
                }
                else
                {
                    label_username.Text = "";
                    return true;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button_logIn_Click(object sender, EventArgs e)
        {

        }
    }
}