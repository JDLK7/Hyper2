using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hyper.EN
{
    public class BuscarEN
    {
        string name;
        string tipo;
        string path;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }


        public BuscarEN(string name, string tipo)
        {
            this.name = name;
            this.tipo = tipo;
            this.path = "";
        }

        public BuscarEN(string name, string tipo, string path)
        {
            this.name = name;
            this.tipo = tipo;
            this.path = path;
        }
    }
}
