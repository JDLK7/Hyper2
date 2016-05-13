using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Hyper.EN;
using Hyper.CAD;

//QUE puede hacer el usuario sobre SI MISMO
//como mostrar usuario
namespace Hyper.EN
{
    public class UserEN
    {
        //Datos personales del usuario
        private string username;
        private string firstName;
        private string lastName;
        private string email;
        //private Folder folder;
        private string password;
        private SuscripcionEN suscripcion;        //Tipo de suscripcion
        private string directory;   //Directorio personal
        private bool enabled;       //Cuenta activa o inactiva.
        private MessageBuilderEN msgBuilder;

        private NFolderEN folder;

        public UserEN()
        {
            username = "";
            firstName = "";
            lastName = "";
            email = "";
            folder = new NFolderEN();
            password = "";
            suscripcion = new SuscripcionEN(); 
            directory = "";
            enabled = false;
        }

        public UserEN(string username, string firstName, string lastName, string email, string password)
        {
            this.folder = new NFolderEN(username, username);
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            enabled = true;
            //plan = ... basico

            msgBuilder = new MessageBuilderEN(username);

           
        }

        /*
         * Método que devuelve un array de los usuarios que coinciden
         * con el nombre de usuario que se pasa por parámetro.
         */
        public static ArrayList Search(string username)
        {
            return UserCAD.Search(username);
        }

        public void getUser(int s_id)
        {

        }

        /*
         * Método que envia un mensaje privado a un destinatario.
         */
        public void SendMessage(UserEN dst, string message)
        {
            msgBuilder.SendMessage(dst.Username, message);
        }

        public void CommentFile()
        {

        }

        /*
         * Recibe una cantidad de meses, una cuenta bancaria y una tarifa y crea una suscripcion
         */
         
        public void Suscribe()
        {
            string cuenta = ""; //pillar de textbox
            int meses = 0; //pillar de textbox
            TarifaEN tarifa = new TarifaEN(); //mostrar lista con tarifas y elegir una
            TarifaEN.getTarifas(); //Mostrar estas tarifas

            Suscripcion = SuscripcionEN.suscribirse(meses, tarifa, cuenta);
        } 

        /*
         * Recibe un nombre de usuario para cargar los datos desde
         * la base de datos en el objeto UserEn que lo llama.
         * Si el nombre no fuese exacto se recibira una excepcion del CAD.
         */
        public void Load(string username)
        {
            UserEN user = UserCAD.Load(username);
            this.username = username;
            firstName = user.FirstName;
            lastName = user.LastName;
            email = user.Email;
            password = user.Password;
            suscripcion = user.suscripcion;
            enabled = user.Enabled;
        }

        /*
         * Carga los datos del usuaro que lo llama en la base de datos.
         */
        public void Save()
        {
            UserCAD.Save(this);
        }

        /*
         * Getters y setters de los atributos de clase.
         */
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Directory
        {
            get { return directory; }
            set { directory = value; }
        }

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public SuscripcionEN Suscripcion
        {
            get {return suscripcion; }
            set { suscripcion = value; }
        }

        public NFolderEN Folder
        {
            get { return folder; }
            set { folder = value; }
        }
    }
}