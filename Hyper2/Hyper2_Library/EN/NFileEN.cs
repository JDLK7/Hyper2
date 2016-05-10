using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using Hyper.CAD;

namespace Hyper.EN
{
    public class NFileEN
    {
        public static string defaultPath = @"c:\HyperDataFiles\";
        private string defaultFolder = "default";
        private string defaultOwner = "default";

        public string path;
        private string owner;
        private string name;
        private string extension;
        private NFileCAD cad;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        /*
         * Constructor para nuevos archivos
         */
        public NFileEN(string path, string owner)
        {
            this.owner = owner;
            this.path = defaultPath + path;
            this.name = getName();
            this.extension = getExtension();
            this.cad = new NFileCAD(this);
        }

        /*
         * Constructor para archivos existentes
         */ 
        public NFileEN(string path)
        {
            this.cad = new NFileCAD(path);
            this.owner = cad.Owner;
            this.path = cad.Path;
            this.extension = getExtension();
            this.name = getName();

        }

        public string getName()
        {
            int index = path.LastIndexOf('/');
            int index2 = path.LastIndexOf('.');

            if (index2 > 0)
            {

                return path.Substring(index + 1, index2);
            }
            else
            {
                return path;
            }
        }

        public string getExtension()
        {
            int index = path.LastIndexOf('.');

            if(index > 0)
            {
                return path.Substring(index);
            }
            else
            {
                return "";
            }
        }
    }
}
