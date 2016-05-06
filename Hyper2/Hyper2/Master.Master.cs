using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Hyper2
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Console.WriteLine("xddd");
            Directory.CreateDirectory(@"c:\juan");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Console.WriteLine("xddd");
            Directory.CreateDirectory(@"c:\paco");
        }
    }
}