using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Hyper.EN;
using Hyper.CAD;

namespace Hyper.EN
{
    public class FolderEN : DataEN
    {
        private int num_files;
        ArrayList files;

        public FolderEN() : base()
        {
            num_files = 0;
        }

        public FolderEN(ArrayList nfiles) : base()
        {
            foreach(DataEN f in nfiles)
            {
                files.Add(f);
            }

            FolderCAD.AddFiles(nfiles);
            num_files = files.Count;
        }

        /*
         * devuelve la ruta en la que se encuentra
         */
        public string GetRoute()
        {
            return DataCAD.GetRoute(id);
        }

        public ArrayList GetIdFiles()
        {
            return FolderCAD.GetIdFiles(id);
        }

        public ArrayList GetNameFiles()
        {
            return FolderCAD.GetNameFiles(id);
        }
        
        public int Size
        {
            get { return num_files; }
            set { num_files = value; }
        }
    }
}