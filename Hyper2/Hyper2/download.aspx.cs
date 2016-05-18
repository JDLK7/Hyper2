using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Hyper2
{
    public partial class download : System.Web.UI.Page
    {
        private string path = @"C:\HyperDataFiles\Temporary\";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["file"] != "")
            {
                FileInfo f = new FileInfo(path + Request.QueryString["file"]);
                if (f.Exists)
                {
                    Download(path + Request.QueryString["file"]);
                }
            
            }
        }

        private void Download(string path)
        {
            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.Flush();
                Response.TransmitFile(fileInfo.FullName);
                File.Delete(path);
                Response.End();
            }
        }
    }
}