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
            UserEN paco = new UserEN("Piki", "firstName", "lastName", "email", "password");

            ArrayList content = paco.Folder.getContent();

            foreach (string name in content)
            {
                System.Console.WriteLine(name);
            }

            NFolderEN carpetica = paco.Folder.open("carpetica");

            content = carpetica.getContent();

            foreach (string name in content)
            {
                System.Console.WriteLine(name);
            }

            // NFolderEN prueba = new NFolderEN("prueba");


            //System.Console.Write(prueba.getName());

            System.Console.ReadLine();
        }
    }
}
