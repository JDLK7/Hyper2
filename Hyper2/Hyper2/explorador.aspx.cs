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
        protected string selectedFile;
        protected string actualPath;
        
        /*
         * Método que se utiliza para crear un evento que se lanzará cada vez que 
         * se presione el botón contenido en cada elemento de la ListView del explorador.
         * Dicha señal está conectada a un método que captura el nombre del archivo seleccionado.
         */
        protected void Page_Init(object sender, EventArgs e)
        {
            explorerListView.ItemCommand += new EventHandler<ListViewCommandEventArgs>(onClickedMore);
        }

        /*
         * Método que con el ListViewCommandEventArgs que recibe revisa si el comando que lo ha enviado
         * ha sido el del botón more de los elementos de la lista. En caso afirmativo recoge el índice de dicho elemento
         * y guarda el nombre del archivo en una variable de clase.
         */
        protected void onClickedMore(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "more")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                ListViewItem item = explorerListView.Items[index];
                Label c = (Label)item.FindControl("labelName");

                selectedFile = c.Text;

                ModalPopupExtender1.Show();

                buttonDownload_Click(sender, e);
            }
        }

        //Solucion provisional. Lo mejor es cargarlo de la base de datos para evitar problemas.
        protected void onClickedNode(object sender, EventArgs e)
        {
            actualPath += TreeView1.SelectedNode.Text + "\\";

            populateListView(actualPath);
            updatePanelListView.Update();
        }

        private void populateListView(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            explorerListView.DataSource = FullDirList(di);
            explorerListView.DataBind();
        }

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (actualPath == null)
            {
                actualPath = NFolderEN.defaultPath + Session["username"].ToString();
            }
            
            if (!this.IsPostBack)
            {
                DirectoryInfo rootInfo = new DirectoryInfo(NFolderEN.defaultPath);
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

        protected void buttonNewFolder_Click(object sender, EventArgs e)
        {
            newFolderName.Visible = true;
        }

        protected void buttonOk_Click(object sender, EventArgs e)
        {
            string name = newFolderName.Text;
            //Se crea la carpeta con el nombre recogido.
            newFolderName.Visible = false;

            NFolderEN aux = new NFolderEN(Session["username"].ToString());
            aux.createFolder(name);

            populateListView(actualPath);
            updatePanelListView.Update();
        }

        protected void buttonUpload_Click(object sender, EventArgs e)
        {

        }

        protected void buttonDownload_Click(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo(actualPath + selectedFile);

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