using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Hyper.EN;
using Hyper.CAD;

namespace Hyper.EN
{
    public class FileEN : DataEN 
    {
        private string extension;
        private int size;
        ArrayList ids;

        public FileEN() : base()
        {
            extension = "";
            size = -1;
        }
        //habria que poner en que dataEN (ruta) poner el fichero
        public FileEN(string nextension, int nsize)
        {
            extension = nextension;
            size = nsize;
        }

        /*
         * comprueba si el id del fichero existe en la bbdd
         */
        public bool Search(int s_id)
        {
            LoadID();
            foreach(int ids in ids)
            {
                if (ids == s_id)
                    return true;
            }
            return false;
        }
        /*
         * carga todos los ids en un vector
         */
        public void LoadID()
        {
            ids = FileCAD.LoadID();
        }
        /*
         * abre el archivo y devuelve true o false
         * si lo ha conseguido
         */
        public void Open()
        {
            DataCAD.Open();
        }

        public void Download()
        {
            FileCAD.Download();
        }

        public void Delete()
        {
            FileCAD.Delete();
        }

        public string Extension
        {
            get { return extension; }
            set { extension = value; }
        }
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

    }
}