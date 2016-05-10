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
    class NFolderCAD
    {

        private string path;
        private string owner;
        private string name;

        public NFolderCAD()
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
        public NFolderCAD(string path)
        {

        }

        public NFolderCAD(NFolderEN en)
        {
            this.path = en.Path;
            this.owner = en.Owner;
            this.name = en.getName();
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);

            try
            {
                db.Open();
                string sql = "insert into Files values('" + path + "','" + name + "','" + owner +"','0'," + 
                    "NULL, '" + DateTime.Now + "')";

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
           
            /*
             * insert into table...
             */ 

        }

        public void Delete()
        {
            /*
             * delete from table where path = this.path
             */ 
        }
    }
}
