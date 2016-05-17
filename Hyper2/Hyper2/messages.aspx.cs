using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Hyper.EN;
using Hyper.CAD;
using System.Collections;

namespace Hyper2
{
    public partial class messages : System.Web.UI.Page
    {
        private static string userSesion = "Javi";
        private static string userConversacion = "jose2";

        public struct mensajesChat
        {
            public string text;
            public string src;
            public string dst;
            public string clase;
        }

        protected void Mostrar_Conversacion(string userSesion, string userConversacion)
        {

            ArrayList converstions = MessageCAD.getConversations(userSesion);

            ArrayList mensajesPorConversaciones = new ArrayList();

            foreach (UserEN user in converstions)
            {

                mensajesPorConversaciones.Add(new MessageBuilderEN(user.Username));

            }


            ArrayList arrayDeMensajes = new ArrayList();

            foreach (MessageBuilderEN mensajes in mensajesPorConversaciones)
            {

                if (mensajes.User == userConversacion)
                {

                    foreach (MessageEN msg in mensajes.GetMessages())
                    {

                        if (msg.Src == userSesion || msg.Dst == userSesion)
                        {

                            if(msg.Src == userSesion)
                            {

                                msg.Propietario = "mensajeEmisor";

                            }
                            else
                            {

                                msg.Propietario = "mensajeReceptor";

                            }

                            arrayDeMensajes.Add(msg);

                        }

                    }


                }

            }

            ListViewMessages.DataSource = arrayDeMensajes;
            ListViewMessages.DataBind();


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            UserEN kalia = new UserEN("kalia", "Kalia", "Reina", "kalia@gmail.com", "1234");
            UserEN jose = new UserEN("jose", "jose", "leal", "josesguay@hotmail.com", "4321");
            UserEN jose2 = new UserEN("jose2", "jose", "leal", "josesguay2@hotmail.com", "4321");
            UserEN javi = new UserEN("Javi", "Javi", "Puto amo", "puticosamosysergio@gmail.com", "0101");
            javi.Save();
            jose2.Save();*/
            
            ArrayList converstions = MessageCAD.getConversations(UserSesion);

            ListViewUsers.DataSource = converstions;
            ListViewUsers.DataBind();

            Mostrar_Conversacion(UserSesion, UserConversacion);

        }

        protected void mostrarMensajes(object sender, EventArgs e)
        {

            Button boton = (Button)sender;
            UserConversacion = boton.Text;

            Mostrar_Conversacion(UserSesion, UserConversacion);

        }

        protected void mandarMensajes(object sender, EventArgs e)
        {

            MessageBuilderEN creadorDeMensajes = new MessageBuilderEN(UserSesion);
            creadorDeMensajes.SendMessage(UserConversacion, chatBox.Text);
            chatBox.Text = "";
            Mostrar_Conversacion(UserSesion, UserConversacion);

        }

        public string UserSesion
        {

            get { return userSesion; }
            set { userSesion = value; }

        }

        public string UserConversacion
        {

            get { return userConversacion; }
            set { userConversacion = value; }
        }

    }
}