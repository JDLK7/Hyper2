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
        private string src; //Origen
        private string dst; //Destinatario
        private string text; //Texto
        private DateTime date;

        //private MessageCAD cad;

        /**
         * Constructor de mensaje que recibe el origen, el destinatario y el mensaje
         */
        public MessageEN(String src, String dst, String text) 
        {
            this.src = src;
            this.dst = dst;
            this.text = text;
        }

        public MessageEN(int id, string user1, string user2, DateTime date, string text)
        {
            this.src = user1;
            this.dst = user2;
            this.text = text;
            this.date = date;
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

        public DateTime Date
        {
            get { return date; }
        }

    }
}