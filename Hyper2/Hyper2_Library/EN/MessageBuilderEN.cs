using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Hyper.EN;
using Hyper.CAD;

namespace Hyper.EN
{
    public class MessageBuilderEN
    {

        String user;
        ArrayList messages; //Array que almacena los mensajes recibidos y enviados por el usuario

        /**
         * Crea un controlador para enviar y recibir mensajes
         */
        public MessageBuilderEN(String user)
        {
            this.user = user;
            messages = MessageCAD.GetMessages(user);
        }


        /**
         * Recibe un destinatario y un texto y envia el mensaje
         */
        public void SendMessage(String dst, String text)
        {
            MessageEN m = new MessageEN(user, dst, text);

            MessageCAD.Save(m);
        }


        /**
         * Recibe un usuario de destino y devuelve un array list con todos los mensajes que tienen en comun
         */
        public ArrayList ShowMessages(String dst)
        {
            GetMessages();
            ArrayList aux = new ArrayList();

            foreach(MessageEN m in messages)
            {
                if(m.Dst == dst || m.Src == dst) //si coinciden el origen o el destino con el usuario proporcionado lo devuelve
                {
                    aux.Add(m);
                }
            }

            return aux;
        }

        /**
         * Actualiza el array de mensajes que contiene todos los mensajes del usuario, tanto enviados como recibidos
         */
        public ArrayList GetMessages()
        {
            messages = MessageCAD.GetMessages(user);

            return messages;
        }

        public string User
        {
            get { return user; }
        }
    }
}