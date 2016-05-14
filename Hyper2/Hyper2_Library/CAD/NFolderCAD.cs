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
        private string name;
        private int visibility;
        private string extension;
        private DateTime date;

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

        /*
         * select where path = this.path
         */
        public NFolderCAD(string path)
        {

        }

        public NFolderCAD(NFolderEN en)
        {
            this.path = en.Path;
            this.name = en.Name;
            this.visibility = Convert.ToInt32(en.Visibility);
            this.extension = en.Extension;
            this.date = en.Date;
            

            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);

            
            string query = "INSERT INTO [Files] (Path,Name,Visibility,Extension,UploadTime) " +
            "values (@pa,@na,@vi,@ext,@up)";

            db.Open();

            SqlCommand insert = new SqlCommand(query, db);
            insert.Parameters.AddWithValue("@pa", path);
            insert.Parameters.AddWithValue("@na", name);
            insert.Parameters.AddWithValue("@vi", 0);
            insert.Parameters.AddWithValue("@ext", extension);
            insert.Parameters.AddWithValue("@up", date);

            try
            {
                int columnas = insert.ExecuteNonQuery();
            }
            catch (Exception ex)
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
