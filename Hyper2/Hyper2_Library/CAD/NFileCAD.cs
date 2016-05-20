using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyper.CAD;
using Hyper.EN;
using System.Configuration;
using System.Data.SqlClient;

namespace Hyper.CAD
{
    class NFileCAD
    {

        private string path;
        private string owner;
        private string name;
        private string extension;
        private string date;
        private bool visibility;

        public NFileCAD()
        {
            this.path = "";
            this.path = "";
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }


        /*
         * select where path = this.path
         */
        public NFileCAD(string path)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);

            try
            {
                db.Open();
                string sql = "select * from Files where path='" + path + "'";

                SqlCommand command = new SqlCommand(sql, db);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    this.path = reader.GetValue(0).ToString();
                    this.name = reader.GetValue(1).ToString();
                    this.owner = reader.GetValue(2).ToString();
                    this.visibility = Convert.ToBoolean(Convert.ToInt16(reader.GetValue(3).ToString()));
                    this.extension = reader.GetValue(4).ToString();
                    this.date = reader.GetValue(5).ToString();
                    
                }

            }
            catch (Exception)
            {
                UserEN error = new UserEN("error", "error", "error", "error", "error");
            }
            finally
            {
                db.Close();
            }

        }

        public NFileCAD(NFileEN en)
        {
            this.path = en.Path;
            this.owner = en.Owner;
            this.name = en.getName();
            this.extension = en.getExtension();
            int visibilityAux = 0;

            if (visibility)
            {
                visibilityAux = 1;
            }

            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);

            try
            {
                db.Open();
                string sql = "insert into Files values('" + path + "','" + name + "','" + owner + "','"+ visibilityAux + "'," +
                    extension + ", '" + DateTime.Now + "')";

                SqlCommand command = new SqlCommand(sql, db);
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                UserEN error = new UserEN("error", "error", "error", "error", "error");
            }
            finally
            {
                db.Close();
            }

        }

        public static void Save(NFileEN fi)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);

            string query = "INSERT INTO [Files] (Path,Name,Visibility,Extension,UploadTime) " +
            "values (@pa,@na,@vi,@ext,@up)";

            db.Open();

            SqlCommand insert = new SqlCommand(query, db);
            insert.Parameters.AddWithValue("@pa", fi.Path);
            insert.Parameters.AddWithValue("@na", fi.Name);
            insert.Parameters.AddWithValue("@vi", 0);
            insert.Parameters.AddWithValue("@ext", fi.Extension);
            insert.Parameters.AddWithValue("@up", fi.Date);

            try
            {
                int columnas = insert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //UserEN error = new UserEN("error", "error", "error", "error", "error");
            }
            finally
            {
                db.Close();
            }
        }

        public static void DeleteFile(string path)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);
            SqlCommand delete = new SqlCommand();
            delete.CommandType = System.Data.CommandType.Text;
            delete.CommandText = "DELETE FROM Files WHERE Path = '" + path + "'";
            delete.Connection = db;

            db.Open();
            try
            {
                delete.ExecuteNonQuery();
            }
            catch(Exception)
            {

            }
            finally
            {
                db.Close();
            }
        }

        public static void DeleteDirectory(string path)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);
            SqlCommand delete = new SqlCommand();
            delete.CommandType = System.Data.CommandType.Text;
            delete.CommandText = "DELETE FROM Files WHERE Path LIKE '" + path + "'";
            delete.Connection = db;

            db.Open();
            try
            {
                delete.ExecuteNonQuery();
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
