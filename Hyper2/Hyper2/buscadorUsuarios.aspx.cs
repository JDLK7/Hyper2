using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hyper.EN;
using Hyper.CAD;
using System.Collections;
using System.IO;
using System.IO.Compression;

namespace Hyper2
{
    public partial class buscadorUsuarios : System.Web.UI.Page
    {

        /// <summary>
        /// Actualiza la lista de archivos para que aparezcan los de la 
        /// carpeta actual.
        /// </summary>
        private void updateListView()
        {
            populateListView();
            updatePanelListView.Update();
        }

        /// <summary>
        /// Método que se utiliza para crear un evento que se lanzará cada vez que 
        /// se presione el botón contenido en cada elemento de la ListView del explorador.
        /// Dicha señal está conectada a un método que captura el nombre del archivo seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
            explorerListView.ItemCommand += new EventHandler<ListViewCommandEventArgs>(onClickedMore);
        }

        /// <summary>
        /// Detecta el clic del elemento de la lista del cual se ha pulsado su botón. Recoge el índice
        /// de dicho elemento y guarda el nombre en una variable de clase para que pueda ser descargado,
        /// compartido, etc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        protected void onClickedMore(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "more")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                ListViewItem item = explorerListView.Items[index];
                Label c = (Label)item.FindControl("labelName");

                Session["selectedFile"] = c.Text;

                //ModalPopupExtender1.Show();
            }
        }

        /// <summary>
        /// Enlaza los datos que van a ser mostrados en la listView que sirve de explorador.
        /// </summary>
        /// <param name="path"></param> Ruta absoluta de la carpeta cuyos archivos se van a enlazar.
        private void populateListView()
        {
            //DirectoryInfo di = new DirectoryInfo(path);

            //explorerListView.DataSource = FullDirList(di);


            explorerListView.DataSource = BuscarCAD.buscar(Request.QueryString["termino"], Request.QueryString["campo"], false);
            explorerListView.DataBind();
        }

        /// <summary>
        /// Método al que se llama cada vez que se recarga la página.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            updateListView();
        }

        /// <summary>
        /// Realiza un listado de todos los elementos contenidos en un directorio.
        /// </summary>
        /// <param name="dir1"></param> Directorio a listar.
        /// <returns></returns> ArrayList que contiene objetos DirectoryInfo y/o FileInfo.
        public ArrayList FullDirList(DirectoryInfo dir1)
        {
            ArrayList files = new ArrayList();

            foreach (DirectoryInfo f in dir1.GetDirectories())
            {
                files.Add(f);
            }

            foreach (FileInfo f in dir1.GetFiles())
            {
                files.Add(f);
            }

            return files;
        }


        /// <summary>
        /// Descarga el archivo escogido en el explorador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonDownload_Click(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo((string)Session["actualPath"] + @"\" + Session["selectedFile"].ToString());

            if (fileInfo.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=\"" + fileInfo.Name + "\"");
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.Flush();
                Response.TransmitFile(fileInfo.FullName);
                Response.End();
            }
            else
            {
                //Posiblemente sea porque es una carpeta (descargar como zip?)
            }
        }

        /// <summary>
        /// Manejador del botón de eliminar. Borra el archivo del directorio físico
        /// y de la base de datos. Si es una carpeta se borra el directorio y todos
        /// los archivos que contiene.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonRemove_Click(object sender, EventArgs e)
        {
            string file = (string)Session["actualPath"] + @"\" + Session["selectedFile"].ToString();

            if (File.GetAttributes(file) == FileAttributes.Directory)
            {
                //BORRA EL DIRECTORIO Y SUS ARCHIVOS.
            }
            else
            {
                File.Delete(file);
                updateListView();
            }
        }

        protected void iniciarChat(object sender, EventArgs e)
        {

            LinkButton boton = (LinkButton)sender;
            string usuarioAChatear = boton.CssClass;
            string yo = Session["username"].ToString();

            MessageCAD.chat(yo, usuarioAChatear);
            MessageCAD.chat(usuarioAChatear, yo);

            Response.Redirect("~/messages.aspx");

        }


    }
}