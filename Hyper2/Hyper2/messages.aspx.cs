using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Hyper.EN;
using Hyper.CAD;
using System.Collections;

namespace Hyper2
{
    public partial class messages : System.Web.UI.Page
    {
        ArrayList files = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {

            UserEN kalia = new UserEN("kalia", "Kalia", "Reina", "kalia@gmail.com", "1234");
            UserEN jose = new UserEN("jose", "jose", "leal", "josesguay@hotmail.com", "4321");
            UserEN jose2 = new UserEN("jose2", "jose", "leal", "josesguay2@hotmail.com", "4321");
            UserEN javi = new UserEN("Javi", "Javi", "Puto amo", "puticosamosysergio@gmail.com", "0101");
            javi.Save();
            jose2.Save();


            jose.SendMessage(jose2, "Xq siempre me cuento mi propia vida? Maldito doble cuenteo.");

            ArrayList converstions = MessageCAD.getConversations("jose");

            ListView1.DataSource = converstions;
            ListView1.DataBind();

            //Directory.CreateDirectory("c:\\" + aux);
            DirectoryInfo di = new DirectoryInfo(NFolderEN.defaultPath);

            FullDirList(di);
            ListView2.DataSource = files;
            ListView2.DataBind();
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