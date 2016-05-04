using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hyper.EN;
using Hyper.CAD;

namespace Hyper.EN
{
    public class MessageEN
    {
        private int id;
        private String src; //Origen
        private String dst; //Destinatario
        private String text; //Texto

        private static int GetNextID() //Devuelve el proximo id disponible
        {
            
            return MessageCAD.GetNextID();
        }

        /**
         * Constructor de mensaje que recibe el origen, el destinatario y el mensaje
         */
        public MessageEN(String src, String dst, String text) 
        {
            this.src = src;
            this.dst = dst;
            this.text = text;
            this.id = MessageEN.GetNextID();

        }

        public string Src
        {
            get { return src; }
        }

        public string Dst
        {
            get { return dst; }
        }

        public string Text
        {
            get { return text; }
        }

        public int getID
        {
            get { return id; }
        }
    }
}