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
    public partial class Registro : System.Web.UI.Page
    {
        /// <summary>
        /// Comprueba que todos los campos se hayan rellenado.
        /// En caso contrario cambia el color de su borde por rojo 
        /// para captar la atención del usuario.
        /// </summary>
        /// <returns>Booleano con el resultado de la comprobación.</returns>
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

        /// <summary>
        /// Comprueba que el email introducido sea válido.
        /// </summary>
        /// <returns>Booleano con el resultado de la comprobación.</returns>
        private bool check_email()
        {
            //Buscar en lista de email validos.
            string email = textBox_email.Text;
            if (!(email.Contains("@gmail.com") || email.Contains("@hotmail.com") || email.Contains("@hotmail.es")))
            {
                label_email.Text = "El email no es válido";
                return false;
            }
            else
            {
                if(UserCAD.SearchEmail(email))
                {
                    label_email.Text = "El email ya está en uso";
                    return false;
                }
                else
                {
                    label_email.Text = "";
                    return true;
                }
            }
        }

        /// <summary>
        /// Comprueba si el nombre de usuario está disponible.
        /// En caso negativo se avisa con un mensaje de error contenido en un label.
        /// </summary>
        /// <returns>Booleano con el resultado de la comprobación.</returns>
        private bool check_username()
        {
            string user = textBox_username.Text;

            if(user.Length > 16)
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

        /// <summary>
        /// Comprueba si la contraseña y la confirmación de la contraseña coinciden y si el
        /// tamaño de la contraseña es el adecuado. Cuando no se cumple se indica el error en un
        /// label.
        /// </summary>
        /// <returns>Booleano con el resultado de la operación</returns>
        private bool check_password()
        {
            if(textBox_password.Text.Length > 20 || textBox_passwordConf.Text.Length > 20)
            {
                label_password.Text = "No puede superar los 20 caracteres";
                return false;
            }
            else
            {
                if (textBox_password.Text == textBox_passwordConf.Text)
                {
                    label_password.Text = "";
                    return true;
                }
                else
                {
                    label_password.Text = "Las contraseñas no coinciden";
                    return false;
                }
            }
        }

        /// <summary>
        /// Envía un email de bienvenida al usuario que se acaba de registrar.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        private void confirmation_email(string email, string firstName)
        {
            //Contraseña mail "molamasquemega"
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            MailMessage message = new MailMessage();
            
            try
            {
                MailAddress fromAddress = new MailAddress("noreply.hyperCloud@gmail.com");
                MailAddress toAddress = new MailAddress(email);
                message.Subject = "¡Bienvenido a Hyper!";
                message.Body =
                    "Hola " + firstName + ", te damos la bienvenida a Hyper, el mejor y más social sistema de almacenamiento en la nube. " +
                    "Recuerda que si quieres puedes suscribirte a una de nuestras tarifas para tener aun más espacio.";
                message.From = fromAddress;
                message.To.Add(toAddress);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("noreply.hyperCloud@gmail.com", "molamasquemega");
                smtpClient.Send(message);
            }
            catch(Exception)
            {
                //Error al enviar el mensaje.
                //¿Pop up de error?
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Manejador del botón de registro que llama a todas las comprobaciones
        /// y si todo está correcto registra al usuario en la bas de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void button_signIn_Click(object sender, EventArgs e)
        {
            bool t = check_textBoxes(),
                    u = check_username(),
                    m = check_email(),
                    p = check_password();

            if (t && u && m && p)
            {
                string  firstName = textBox_firstName.Text,
                        lastName = textBox_lastName.Text,
                        username = textBox_username.Text,
                        email = textBox_email.Text,
                        password = textBox_password.Text;

                UserEN user = new UserEN(username,firstName,lastName,email,password);
                user.Save();
                confirmation_email(email, firstName);

                Response.Redirect("iniciarSesion.aspx");
            }
        }
    }
}