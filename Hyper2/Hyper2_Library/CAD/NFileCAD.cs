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
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);

            try
            {
                db.Open();
                string sql = "insert into Files values('" + path + "','" + name + "','" + owner + "','0'," +
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

        public void Delete()
        {
            /*
             * delete from table where path = this.path
             */
        }
    }
}
