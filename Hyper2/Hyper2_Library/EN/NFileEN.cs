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

        public string path;
        private string owner;
        private string name;
        private string extension;
        private long size;
        private bool visibility;
        private DateTime date;
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

        public string Name
        {
            get { return name; }
        }

        public DateTime Date
        {
            get { return date; }
        }

        public string Extension
        {
            get { return extension; }
        }

        public string Size
        {
            get
            {
                if (size >= 1073741824)
                {
                    return (size / (1024 * 1024 * 1024)).ToString() + "GB";
                }
                else if (size >= 1048576)
                {
                    return (size / (1024 * 1024)).ToString() + "MB";
                }
                else if(size >= 1024)
                {
                    return (size / 1024).ToString() + "KB";
                }
                else
                {
                    return size.ToString() + "B";
                }
            }
        }

        public bool Visibility
        {
            get { return visibility; }
            set { visibility = value; }
        }

        /*
         * Constructor para nuevos archivos
         */
        public NFileEN(string path, string name)
        {
            this.path = defaultPath;
            this.name = getName();
            this.extension = getExtension();
            this.cad = new NFileCAD(this);
        }

        public NFileEN(FileInfo fi)
        {
            path = fi.ToString();
            name = fi.Name;
            extension = fi.Extension;
            size = fi.Length;
            date = DateTime.Now;
            visibility = false;
        }

        /*
         * Constructor para archivos existentes
         */ 
        public NFileEN(string path)
        {
            this.cad = new NFileCAD(path);
            this.owner = cad.Owner;
            //this.path = cad.Path;
            this.path = path;
            this.extension = getExtension();
            this.name = getName();

        }

        public void Save()
        {
            NFileCAD.Save(this);
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

            if (index > 0)
            {
                return path.Substring(index+1);
            }
            else
            {
                return "";
            }
        }

        public static void DeleteFile(string path)
        {
            NFileCAD.DeleteFile(path);
        }
    }
}
