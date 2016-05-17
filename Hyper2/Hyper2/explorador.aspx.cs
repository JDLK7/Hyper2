using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Hyper.EN;
using System.Collections;

namespace Hyper2
{
    public partial class explorador : System.Web.UI.Page
    {
        protected string actualPath;
        
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

                ModalPopupExtender1.Show();
            }
        }

        /// <summary>
        /// Detecta el clic en un nodo del arbol de carpetas y se cambia la carpeta mostrada a ésta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void onClickedNode(object sender, EventArgs e)
        {
            actualPath += TreeView1.SelectedNode.Text + "\\";

            populateListView(actualPath);
            updatePanelListView.Update();
        }

        /// <summary>
        /// Enlaza los datos que van a ser mostrados en la listView que sirve de explorador.
        /// </summary>
        /// <param name="path"></param> Ruta absoluta de la carpeta cuyos archivos se van a enlazar.
        private void populateListView(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            explorerListView.DataSource = FullDirList(di);
            explorerListView.DataBind();
        }

        /// <summary>
        /// Enlaza los datos que van a ser mostrados en el treeView que sirve como árbol de carpetas.
        /// </summary>
        /// <param name="dirInfo"></param> Directorio a enlazar.
        /// <param name="treeNode"></param> Arbol al que enlazar los datos.
        private void PopulateTreeView(DirectoryInfo dirInfo, TreeNode treeNode)
        {
            foreach (DirectoryInfo directory in dirInfo.GetDirectories())
            {
                TreeNode directoryNode = new TreeNode
                {
                    Text = directory.Name,
                    Value = directory.FullName
                };

                if (treeNode == null)
                {
                    //If Root Node, add to TreeView.
                    TreeView1.Nodes.Add(directoryNode);
                }
                else
                {
                    //If Child Node, add to Parent Node.
                    treeNode.ChildNodes.Add(directoryNode);
                }

                /*
                //Get all files in the Directory.
                foreach (FileInfo file in directory.GetFiles())
                {
                    //Add each file as Child Node.
                    TreeNode fileNode = new TreeNode
                    {
                        Text = file.Name,
                        Value = file.FullName,
                        Target = "_blank",
                        NavigateUrl = (new Uri(Server.MapPath("~/"))).MakeRelativeUri(new Uri(file.FullName)).ToString()
                    };
                    directoryNode.ChildNodes.Add(fileNode);
                }*/

                PopulateTreeView(directory, directoryNode);
            }
        }

        /// <summary>
        /// Método al que se llama cada vez que se recarga la página.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (actualPath == null)
            {
                actualPath = NFolderEN.defaultPath + Session["username"].ToString() + "\\";
            }
            
            if (!this.IsPostBack)
            {
                //Aqui tiene que ir directamente el path asignado al usuario.
                DirectoryInfo rootInfo = new DirectoryInfo(NFolderEN.defaultPath + (string)Session["username"] + "\\");
                this.PopulateTreeView(rootInfo, null);
            }
            
            populateListView(actualPath);
        }

        /*
        public void ListFiles(string path)
        {
            NFolderEN aux = new NFolderEN(path);
            files = aux.getFiles();

            foreach (NFolderEN f in aux.getFolders())
            {
                files.Add(f);
            }
        }
        */
        
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
        /// Hace aparecer un recuadro en el que se introduce el nombre de la 
        /// nueva carpeta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonNewFolder_Click(object sender, EventArgs e)
        {
            newFolderName.Visible = true;
        }

        /// <summary>
        /// Manejador de un botón oculto que sirve para poder detectar la pulsación
        /// de la tecla Enter. Recoge el nombre de la carpeta nueva y la crea en el
        /// directorio actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonOk_Click(object sender, EventArgs e)
        {
            string name = newFolderName.Text + "\\";
            newFolderName.Visible = false;

            if(name != "")
            {
                //NFolderEN aux = new NFolderEN(Session["username"].ToString());
                //aux.createFolder(name);

                Directory.CreateDirectory(actualPath + name);

                TreeView1.Nodes.Clear();
                DirectoryInfo rootInfo = new DirectoryInfo(actualPath);
                PopulateTreeView(rootInfo, null);
                populateListView(actualPath);

                updatePanelListView.Update();
                updatePanelTreeView.Update();
            }
        }

        /// <summary>
        /// Sube un nuevo archivo a la carpeta actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonUpload_Click(object sender, EventArgs e)
        {
            
        }

        /*
         * POR ALGUNA RAZON SI EL NOMBRE TIENE ESPACIOS NO LO COGE ENTERO.
         */
        /// <summary>
        /// Descarga el archivo escogido en el explorador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonDownload_Click(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo(actualPath + @"\" + Session["selectedFile"].ToString());

            if (fileInfo.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.Flush();
                Response.TransmitFile(fileInfo.FullName);
                Response.End();
            }
        }
    }
}