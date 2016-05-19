using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Hyper.EN;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

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

        /*
         * Metodo que guarda un objeto UserEN en la base de datos,
         * de forma que queda registrado en la página.
         */
        public static void Save(UserEN user)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);

            string query = "INSERT INTO [User] (username,email,password,firstName,lastName,profilePic,admin,folder) " +
                "values (@us,@em,@pass,@first,@last,@pic,@adm,@fol)";

            db.Open();

            SqlCommand insert = new SqlCommand(query, db);

            insert.Parameters.AddWithValue("@us", user.Username);
            insert.Parameters.AddWithValue("@em", user.Email);
            insert.Parameters.AddWithValue("@pass", user.Password);
            insert.Parameters.AddWithValue("@first", user.FirstName);
            insert.Parameters.AddWithValue("@last", user.LastName);
            insert.Parameters.Add("@pic", SqlDbType.Image).Value = DBNull.Value;
            insert.Parameters.AddWithValue("@adm", 0);
            insert.Parameters.AddWithValue("@fol", user.FolderPath);

            try
            {
                int columnas = insert.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                db.Close();
            }
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

            try
            {
                db.Open();
                string query = "SELECT [email] FROM [User] WHERE [email] = '" + email + "'";
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
        }

        public static bool SearchUsername(string username)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);

            try
            {
                db.Open();
                string query = "SELECT [username] FROM [User] WHERE [username] = '" + username + "'";
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
        }

        public static bool userLogin(string username, string password)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);

            try
            {
                db.Open();
                string query = "SELECT [username], [password] FROM [User] WHERE [username] = '" + username + "'";
                SqlCommand command = new SqlCommand(query, db);
                SqlDataReader dr = command.ExecuteReader();

                dr.Read();
                if (dr.HasRows)
                {
                    string pss = dr.GetSqlValue(1).ToString();
                    if(pss == password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                db.Close();
            }
        }
        

        public static bool changeField(string username, string field, string newName)
        {

            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);

            try
            {
                db.Open();
                string query = "update [User] set [" + field + "] ='" + newName + "' WHERE [username] = '" + username + "'";
                SqlCommand command = new SqlCommand(query, db);
                command.ExecuteNonQuery();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                db.Close();
            }
        }
    }
}