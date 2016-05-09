using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hyper2
{
    public partial class Registro : System.Web.UI.Page
    {
        /*
         * Método que comprueba si todos los textBox se han rellenado.
         * En caso contrario cambia el color de su borde por rojo para
         * distinguirlos de los completados. Devuelve un booleano. 
         */
        private bool check_textBoxes()
        {
            bool r = true;

            if (textBox_firstName.Text == "")
            {
                textBox_firstName.BorderColor = System.Drawing.Color.Red;
                r = false;
            }
            if (textBox_lastName.Text == "")
            {
                textBox_lastName.BorderColor = System.Drawing.Color.Red;
                r = false;
            }
            if (textBox_username.Text == "")
            {
                textBox_username.BorderColor = System.Drawing.Color.Red;
                r = false;
            }
            if (textBox_email.Text == "")
            {
                textBox_email.BorderColor = System.Drawing.Color.Red;
                r = false;
            }
            if (textBox_password.Text == "")
            {
                textBox_password.BorderColor = System.Drawing.Color.Red;
                r = false;
            }
            if (textBox_passwordConf.Text == "")
            {
                textBox_passwordConf.BorderColor = System.Drawing.Color.Red;
                r = false;
            }

            return r;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void button_signIn_Click(object sender, EventArgs e)
        {
            //Devuelve bool.
            check_textBoxes();

            //Buscar en lista de email validos.
            string email = textBox_email.Text;
            if (!(email.Contains("@gmail.com") || email.Contains("@hotmail.com") || email.Contains("@hotmail.es")))
            {
                label_email.Text = "El email no es válido";
            }

        }
    }
}