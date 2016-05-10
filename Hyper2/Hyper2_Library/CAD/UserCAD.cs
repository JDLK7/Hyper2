using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Hyper.EN;
using System.Configuration;
using System.Data.SqlClient;

namespace Hyper.CAD
{
    public class UserCAD
    {
        private UserEN user;
        public static ArrayList Search(string username)
        {

            ArrayList nulo = new ArrayList();
            return nulo;
        }
        public static UserEN Load(string username)
        {

            UserEN nulo = new UserEN();
            return nulo;
        }
        public static void Save(UserEN user)
        {

        }
        public UserEN GetUser(int id)
        {
            string orden = "SELECT user FROM users WHERE users.id = ";
            orden += id.ToString();
            //mandar la instruccion a la base de datos y obtener datos
            //guardar los datos en user
            return user;
        }

        public void UpdateUser(UserEN cust)
        {
            string orden = "set firstName = '" + cust.FirstName +
                "', lastName = '" + cust.LastName + "', email = '" + cust.Email +
                "', password = '" + cust.Password + "', suscripcion = '" + cust.Suscripcion.ToString() +
                "', directory = '" + cust.Directory + "', enable = " + cust.Enabled + ";";
        }

        public static bool SearchEmail(string email)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);

<<<<<<< HEAD
            try
            {
                db.Open();
                string query = "SELECT email FROM User WHERE email = " + email + ";";
                SqlCommand command = new SqlCommand(query, db);
                SqlDataReader dr = command.ExecuteReader();

                dr.Read();
                return dr.HasRows;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                db.Close();
            }

=======
            return false;
>>>>>>> origin/master
        }

        public static bool SearchUsername(string username)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);

            try
            {
                db.Open();
                string query = "SELECT username FROM User WHERE username = " + username + ";";
                SqlCommand command = new SqlCommand(query, db);
                SqlDataReader dr = command.ExecuteReader();

<<<<<<< HEAD
                dr.Read();
                return dr.HasRows;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                db.Close();
            }
=======
            return false;
>>>>>>> origin/master
        }
    }
}