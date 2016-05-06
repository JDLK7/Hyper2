using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace Hyper.EN
{
    public class NFileEN
    {
        public static string defaultPath = @"c:\HyperDataFiles\";
        private string defaultFolder = "default";
        private string defaultOwner = "default";

        public string path;
        private string owner;
        //private NFolderCAD cad;

        public NFileEN(string path, string owner)
        {
            this.owner = owner;
            this.path = defaultPath + path;
        }

    }
}
