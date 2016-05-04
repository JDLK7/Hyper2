using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Hyper.CAD;
using Hyper.EN;

namespace Hyper.CAD
{
    public class MessageCAD
    {

        /**
         * Devuelve un array con los mensajes(tanto enviados como recibidos) del usuario)
         */ 
        public static ArrayList GetMessages(String user)
        {

            ArrayList nulo = new ArrayList();
            return nulo;
        }

        /**
         * Devuelve el proximo id disponible para los mensajes
         * select max(id) +1
         */
        public static int GetNextID()
        {

            return -1;
        }

        /**
         * Almacena un mensaje en la base de datos
         */ 
        public static void Save(MessageEN m)
        {

        }
    }
}