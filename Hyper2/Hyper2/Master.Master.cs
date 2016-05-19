using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Hyper.CAD;
using System.Collections;
using Hyper.EN;

namespace Hyper2
{
    public partial class Master : System.Web.UI.MasterPage
    {
        /// <summary>
        /// Comprueba el estado de la sesión para mostrar unos botones diferentes en caso de que la
        /// sesión esté iniciada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["sesionIniciada"] != null) && ((bool)(Session["sesionIniciada"]) == true))
            {
                ButtonIniciarSesion.Visible = false;
                ButtonRegistrarse.Visible = false;
                dropDownSession.Visible = true;
                linkUpload.Attributes["href"] = "subir.aspx";
            }
            else
            {
                ButtonIniciarSesion.Visible = true;
                ButtonRegistrarse.Visible = true;
                dropDownSession.Visible = false;
                linkUpload.Attributes["href"] = "subir.aspx";
            }
        }

        /// <summary>
        /// Redirige a la página de inicio de sesión.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void redirectIniciarSesion(object sender, EventArgs e)
        {
            Response.Redirect("~/iniciarSesion.aspx");
        }

        /// <summary>
        /// Redirige a la página de registro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void redirectRegistrarse(object sender, EventArgs e)
        {
            Response.Redirect("~/registro.aspx");
        }

        /// <summary>
        /// Redirige a la página correspondiente según la opción que se haya escogido
        /// de la dropDownList que aparece al iniciar sesión.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dropDownSession_IndexChanged(object sender, EventArgs e)
        {
            switch (dropDownSession.SelectedIndex)
            {
                case 0:
                    Response.Redirect("explorador.aspx"); //Cambiar para que entre.
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

        protected void Buscar(object sender, EventArgs e)
        {

            string termino = textBox_search.Text;
            int campoSeleccionado = DropDownList2.SelectedIndex;
            ArrayList prueba = new ArrayList();

            switch (campoSeleccionado){

                case 1:

                    prueba = BuscarCAD.buscar(termino, "Música");
                    break;

                case 2:

                    prueba = BuscarCAD.buscar(termino, "Vídeos");
                    break;

                case 3:

                    prueba = BuscarCAD.buscar(termino, "Fotos");
                    break;

                case 4:

                    prueba = BuscarCAD.buscar(termino, "Archivos");
                    break;

                case 5:

                    prueba = BuscarCAD.buscar(termino, "Usuarios");
                    break;

                default:

                    prueba = BuscarCAD.buscar(termino, "Todos");
                    break;

            }

            // BuscarCAD.buscar(termino, campo);
            foreach (BuscarEN b in prueba)
            {
                System.Diagnostics.Debug.WriteLine("\n\n\n\n" + "La excepcion es:" + b.Name + "\n\n\n\n");
            }
            

        }
    }
}