using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Hyper.CAD;
using Hyper.EN;
using System.Configuration;
using System.Data.SqlClient;

namespace Hyper.CAD
{
    public class MessageCAD
    {

        /**
         * Devuelve un array con los mensajes(tanto enviados como recibidos) del usuario)
         */ 
        public static ArrayList GetMessages(String user)
        {
            ArrayList messages = new ArrayList();



            ArrayList nulo = new ArrayList();
            return nulo;
        }

        /**
         * Devuelve el proximo id disponible para los mensajes
         * select max(id) +1
         */
        public static int GetNextID()
        {
            int id = 0;
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);

            try
            {
                db.Open();
                string query = "select max(id) from Message";

                SqlCommand command = new SqlCommand(query, db);
                SqlDataReader dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    id = dr.GetInt32(0);
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                db.Close();
            }
            return id + 1;
        }

        /**
         * Almacena un mensaje en la base de datos
         */ 
        public static void Save(MessageEN m)
        {
            int id = m.getID;
            string user1 = m.Src;
            string user2 = m.Dst;
            DateTime date = DateTime.Now;
            string text = m.Text;

            ArrayList converUser1 = MessageCAD.getConversations(user1);
            ArrayList converUser2 = MessageCAD.getConversations(user2);

            if (!converUser1.Contains(user2))
            {
                chat(user1, user2);
            }
            if (!converUser2.Contains(user1))
            {
                chat(user2, user1);
            }


            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);

            try
            {
                db.Open();
                string query = "insert into Message values('" + id + "','" + user1 + "','" + user2 + "','" + date + "','" + text + "')";

                SqlCommand command = new SqlCommand(query, db);
                command.ExecuteNonQuery();

               

            }
            catch (Exception)
            {

            }
            finally
            {
                db.Close();
            }

        }

        /*
         * Devuelve una lista con los usuarios que se está chateando
         */ 
        public static ArrayList getConversations(String user)
        {
            ArrayList usuarios = new ArrayList();

            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);

            try
            {
                db.Open();
                string query = "SELECT user2 FROM Chat WHERE user1 = " + user + ";";
                SqlCommand command = new SqlCommand(query, db);
                SqlDataReader dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string aux = dr.GetString(0);
                        usuarios.Add(aux);
                    }
                }
              
            }
            catch (Exception)
            {
                
            }
            finally
            {
                db.Close();
            }

            return usuarios;
        }


        /*
         * Inicializa una conversacion entre ambos usuarios
         */ 
        private static void chat(string user1, string user2)
        {

            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);

            try
            {
                db.Open();
                string query = "insert into Chat values('" + user1 + "','" + user2 + "')";

                SqlCommand command = new SqlCommand(query, db);
                command.ExecuteNonQuery();



            }
            catch (Exception)
            {

            }
            finally
            {
                db.Close();
            }
        }
    }
}