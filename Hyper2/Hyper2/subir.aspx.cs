using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hyper.EN;
using System.IO;
using System.IO.Compression;

namespace Hyper2
{
    public partial class subir : System.Web.UI.Page
    {
        private string path = @"C:\HyperDataFiles\Temporary\";

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void clickSubir(object sender, EventArgs e)
        {

           

        }

        private void Download()
        {
            UserEN user = new UserEN("Paquito", "Paco", "Garcia", "paco@gmail.com", "1234");
            NFileEN file = new NFileEN("bien.txt", user.Username);

            FileInfo fileInfo = new FileInfo(file.path);

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

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    string name = getNextName();
                    Directory.CreateDirectory(path + name);
                    string filename = FileUpload1.FileName;
                    //filename = "jose.zip";
                    FileUpload1.SaveAs(path + name + "\\"+ filename);
                    StatusLabel.Text = "Upload status: File uploaded!";

                    File.WriteAllText(path + name + "\\description.txt", description.Text);

                    ZipFile.CreateFromDirectory(path + name, path + name + ".zip");

                    DirectoryInfo di = new DirectoryInfo(path + name);

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                    Directory.Delete(path + name);

                    string url = HttpContext.Current.Request.Url.Authority;
                    StatusLabel.Text = "Copy your link: " + url + "/download.aspx?file=" + name + ".zip";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }



        public string getNextName()
        {
            

            int i = 1;

            string name = i.ToString();
            
            while (Directory.Exists(path + name) || File.Exists(path + name + ".zip"))
            {
                i++;
                name = i.ToString();
            }

            return name;
        }



    }
}