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

        public NFolderCAD()
        {
            this.path = "";
            this.path = "";
        }

        public NFolderCAD(NFolderEN en)
        {
            this.path = en.Path;
            this.owner = en.Owner;
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                db.Open();
            }
            catch (Exception)
            {
                UserEN error = new UserEN("error", "error", "error", "error", "error");
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
