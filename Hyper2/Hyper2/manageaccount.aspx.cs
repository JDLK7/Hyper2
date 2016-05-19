using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hyper.CAD;
using System.IO;

namespace Hyper2
{
    public partial class manageaccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            profilePic.ImageUrl =  "IMG/" + Session["username"].ToString() +".jpg";
            

        }
   
        //private static string path = @"C:\HyperDataFiles\ProfilePics\";
        private static string path = "IMG/";

        protected void buttonUpload_Click(object sender, EventArgs e)
        {
            if (uploadPic.HasFile)
            {
                try
                {
                    string name = Session["username"].ToString() + ".jpg";

                    if (File.Exists(path + name))
                    {
                        FileInfo f = new FileInfo(path + name);
                        f.Delete();
                    }

                    uploadPic.SaveAs(Server.MapPath(path + name));
                    profilePic.ImageUrl = "IMG/" + Session["username"].ToString() + ".jpg";
                    
                }
                catch (Exception ex)
                {
                   
                }
            }
        }

        protected void buttonCambiar(object sender, EventArgs e)
        {
            if(TextBoxName.Text != "")
            {
                UserCAD.changeField(Session["username"].ToString(), "firstName", TextBoxName.Text);
            }

            if (TextBoxSurname.Text != "")
            {
                UserCAD.changeField(Session["username"].ToString(), "lastName", TextBoxSurname.Text);
            }

            /* Dada su dificil implementacion, es imposible cambiar el nombre
            if (TextBoxUsername.Text != "")
            {
                if (UserCAD.changeField(Session["username"].ToString(), "username", TextBoxUsername.Text))
                {
                    Directory.Move(@"c:\HyperDataFiles\" + Session["username"].ToString(), @"c:\HyperDataFiles\" + TextBoxUsername.Text);
                    NFolderCAD.Rename(@"c:\HyperDataFiles\" + Session["username"].ToString(), @"c:\HyperDataFiles\" + TextBoxUsername.Text, TextBoxUsername.Text);
                    Session["username"] = TextBoxUsername.Text;
                    UserCAD.changeField(TextBoxUsername.Text, "folder", "c:\\HyperDataFiles\\" + TextBoxUsername.Text + "\\");
                }

            }
            */

            if(TextBoxEmail.Text != "")
            {
                UserCAD.changeField(Session["username"].ToString(), "email", TextBoxEmail.Text);
            }

            if(TextBoxPassword.Text != "" && TextBoxPassword.Text == TextBoxPassword2.Text)
            {
                UserCAD.changeField(Session["username"].ToString(), "password", TextBoxPassword.Text);
            }

        }
    }
}