using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Hyper.EN
{
    public class NFolderEN
    {
        public static string defaultPath = @"c:\HyperDataFiles\";
        private string defaultFolder = "default";

        private string path;
        

        public NFolderEN()
        {
            this.path = defaultFolder;
            if (!Directory.Exists(defaultPath + path))
            {
                Directory.CreateDirectory(defaultPath + path);
            }
        }

        public NFolderEN(string path)
        {
            this.path = path;
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

        public void delete()
        {
            

            DirectoryInfo di = new DirectoryInfo(defaultPath + path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete();
            }

            Directory.Delete(defaultPath + path);
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
         * Recibe el nombre de una carpeta y abre la carpeta que haya en su interior
         */ 
        public NFolderEN open(string name)
        {
            NFolderEN aux = new NFolderEN(path + "/" + name);

            return aux;
        }
    }
}
