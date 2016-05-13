﻿using System;
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
        protected void Page_Init(object sender, EventArgs e)
        {
            explorerListView.ItemCommand += new EventHandler<ListViewCommandEventArgs>(onClickedMore);
        }

        protected void onClickedMore(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "more")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                ListViewItem item = explorerListView.Items[index];
                Label c = (Label)item.FindControl("labelName");

                labelResultado.Text = c.Text;
            }
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
            if (!this.IsPostBack)
            {
                DirectoryInfo rootInfo = new DirectoryInfo(NFolderEN.defaultPath);
                this.PopulateTreeView(rootInfo, null);
            }

            DirectoryInfo di = new DirectoryInfo(NFolderEN.defaultPath);

            
            FullDirList(di);
            explorerListView.DataSource = files;
            explorerListView.DataBind();
            

            /*
            ListFiles("AyMiJose");
            listView1.DataSource = files;
            listView1.DataBind();
            */
        }

        ArrayList files = new ArrayList();

        public void ListFiles(string path)
        {
            NFolderEN aux = new NFolderEN(path);
            files = aux.getFiles();

            foreach (NFolderEN f in aux.getFolders())
            {
                files.Add(f);
            }
        }
        
        public void FullDirList(DirectoryInfo dir1)
        {
            foreach (DirectoryInfo f in dir1.GetDirectories())
            {
                files.Add(f);
            }

            foreach (FileInfo f in dir1.GetFiles())
            {
                files.Add(f);
            }
        }
        
    }
}