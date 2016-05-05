using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Hyper.EN;

namespace Hyper.CAD
{
    public class FileCAD : DataCAD
    {
        public static ArrayList LoadID()
        {
    
            ArrayList nulo = new ArrayList();
            return nulo;
        }
        public static bool Download()
        {

            return true;
        }
        /*
        public static bool Open()
        {

            return true;
        }
        */
        public static bool Delete()
        {

            return true;
        }

        public static void Buscar(String buscador, String extension) {
            String SQL = "select name,extension from file,data WHERE File.id = Data.name LIKE name = \'buscador%\' AND File.extension = \'extension\'";
        }

        public static void Buscar(String buscador)
        {
            String SQL = "select name,extension from file,data WHERE File.id = Data.name LIKE name = 'buscador%'";
        }


    }
}