using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Collections;
using Hyper.CAD;

namespace Hyper.EN
{
    public class NFolderEN
    {
        public static string defaultPath = @"c:\HyperDataFiles\";
        private static string compressedPath = @"c:\HyperDataFiles\Compressed\";
        private string defaultFolder = "default";
        private string defaultOwner = "default";

        private string path;
        private string owner;
        private NFolderCAD cad;

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

        public NFolderEN()
        {
            this.path = defaultFolder;
            this.Owner = defaultOwner;

            if (!Directory.Exists(defaultPath + path))
            {
                Directory.CreateDirectory(defaultPath + path);
                cad = new NFolderCAD();
            }
        }

        public NFolderEN(string path, string owner)
        {
            this.path = path;
            this.owner = owner;

            if (!Directory.Exists(defaultPath + path))
            {
                Directory.CreateDirectory(defaultPath + path);
            }


        }

        public string getName()
        {
            int index = path.LastIndexOf('/');

            if (index > 0)
            {

                return path.Substring(index+1);
            }
            else
            {
                return path;
            }
        }

        public void Delete()
        {
            

            DirectoryInfo di = new DirectoryInfo(defaultPath + path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                //dir.Delete();
                NFolderEN aux = new NFolderEN(this.path + "/" + dir.Name, owner);
                aux.Delete();
            }

     
            Directory.Delete(defaultPath + path);
            cad.Delete();
        }

        public ArrayList getContent()
        {
            DirectoryInfo di = new DirectoryInfo(defaultPath + path);

            ArrayList content = new ArrayList();

            foreach (FileInfo file in di.GetFiles())
            {
                content.Add(file.Name);
            }

            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                content.Add(dir.Name);
            }

            return content;
        }

        /*
         * Devuelve un arraylist conteniendo los folders del interior
         */ 
        public ArrayList getFolders()
        {

            DirectoryInfo di = new DirectoryInfo(defaultPath + path);

            ArrayList content = new ArrayList();

            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                content.Add(new NFolderEN(this.path + "/" + dir.Name, owner));
            }

            return content;
        }

        /*
         * Recibe el nombre de una carpeta y abre la carpeta que haya en su interior
         */ 
        public NFolderEN open(string name)
        {
            NFolderEN aux = new NFolderEN(path + "/" + name, owner);

            return aux;
        }

        public string CompressFolder()
        {
            string name;

            int i = 1;


            {
                i++;
            }


            return name;
        }
    }
}
