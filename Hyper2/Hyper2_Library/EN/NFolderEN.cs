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
        //private DateTime date;
        private NFolderCAD cad;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public string Name
        {
            get { return getName(); }
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public string Extension
        {
            get { return "Carpeta"; }
        }

        public string Size
        {
            get { return "-"; }
        }

        public string Date
        {
            get { return "1/1/1970"; }
        }


        /*
         * Constructor de carpetas vacias para pruebas
         */
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


        /*
         * Constructor de carpeta que crea una carpeta nueva
         */ 
        public NFolderEN(string path, string owner)
        {
            this.path = path;
            this.owner = owner;

            if (!Directory.Exists(defaultPath + path))
            {
                Directory.CreateDirectory(defaultPath + path);
                cad = new NFolderCAD(this);
            }

            
        }

        /*
         * Constructor de una carpeta ya existente
         */
        public NFolderEN(string path)
        {
            this.cad = new NFolderCAD(path);
            this.Owner = cad.Owner;
            this.Path = path;
        }


        /*
         * Devuelve el nombre de la carpeta
         */ 
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

        /*
         * Borra la carpeta actual y todo su contenido
         */ 
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

        /*
         * Devuelve un array de strings con el contenido de la carpeta
         */ 
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
                content.Add(new NFolderEN(this.path + "/" + dir.Name));
            }

            return content;
        }

        public ArrayList getFiles()
        {

            DirectoryInfo di = new DirectoryInfo(defaultPath + path);

            ArrayList content = new ArrayList();

            foreach (FileInfo file in di.GetFiles())
            {
                content.Add(new NFileEN(this.path + "/" + file.Name));
            }

            return content;
        }

        /*
         * Recibe el nombre de una carpeta y abre la carpeta que haya en su interior
         */
        public NFolderEN open(string name)
        {
            NFolderEN aux = new NFolderEN(path + "/" + name);

            return aux;
        }

        /*
         * Crea una carpeta comprimida para posteriormente descargarla, devuelve su nombre auxiliar
         */ 
        public string CompressFolder()
        {
            string name;

            int i = 1;

            name = i + " "+ this.getName() + ".zip";

            while (File.Exists(compressedPath + name))
            {
                i++;
                name = i + " " + this.getName() + ".zip";
            }

            ZipFile.CreateFromDirectory(defaultPath + this.Path, compressedPath + name);

            return name;
        }

        /*
         * Crea una carpeta dentro de la carpeta que ha llamadado al metodo
         */ 
        public void createFolder(string name)
        {

            NFolderEN folder = new NFolderEN(path + "/" + name, owner);
            

            
        }
    }
}
