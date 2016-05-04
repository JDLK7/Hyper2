using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Hyper.EN;

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
    }
}