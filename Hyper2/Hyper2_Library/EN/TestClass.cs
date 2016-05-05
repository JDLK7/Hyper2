using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyper.EN;
using System.Collections;

namespace Hyper2_Library.EN
{
    class TestClass
    {
        static void Main(string[] args)
        {
            UserEN jose = new UserEN("Jose", "firstName", "lastName", "email", "password");

            ArrayList al = jose.Folder.getFolders();

            foreach (NFolderEN aux in al)
            {
                System.Console.WriteLine(aux.getName());
            }

            NFolderEN carpetica = (NFolderEN) al[0];

            System.Console.WriteLine(carpetica.getName());

            foreach (string name in carpetica.getContent())
            {
                System.Console.WriteLine(name);
            }

            System.Console.ReadLine();
        }
    }
}
