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

        private string owner;

        private string path;
        private string name;
        private bool visibility;
        private DateTime date;

        private NFolderCAD cad;

        /*
         * Constructor de carpetas vacias para pruebas
         */
        public NFolderEN()
        {
            path = defaultPath;
            name = defaultFolder;
            visibility = false;
        }

        /// <summary>
        /// Constructor utilizado para registrar la carpeta raiz de un nuevo usuario.
        /// </summary>
        /// <param name="username"></param>
        public NFolderEN(string username)
        {
            path = defaultPath + username + @"\";
            name = username;
            visibility = false;
            date = DateTime.Now;

            Directory.CreateDirectory(path);

            cad = new NFolderCAD(this);
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
                Directory.CreateDirectory(defaultPath + path + "\\");
                cad = new NFolderCAD(this);
            }
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool Visibility
        {
            get { return visibility; }
            set { visibility = value; }
        }

        public string Extension
        {
            get { return "Folder"; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
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

        /// <summary>
        /// Método que crea una carpeta físicamente.
        /// </summary>
        /// <param name="path">Ruta en donde se va a crear.</param>
        /// <param name="name">Nombre de la carpeta.</param>
        public static void createFolder(string path, string name)
        {
            Directory.CreateDirectory(path + name + "\\");

            //Objeto NFolderEN para guardar la nueva carpeta en la bbdd
            NFolderEN aux = new NFolderEN();
            aux.Path = path + name + "\\";
            aux.Name = name;
            aux.Date = DateTime.Now;
            aux.cad = new NFolderCAD(aux);
        }
    }
}
