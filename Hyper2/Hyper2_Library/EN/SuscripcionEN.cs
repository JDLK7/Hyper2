using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Hyper.EN;
using Hyper.CAD;
using System.Globalization;


namespace Hyper.EN
{
    
    public class SuscripcionEN
    {
        //private UserEN usuario;//Para usarlo como clave ajena
        private string cuentaBancaria;
        private TarifaEN tarifa;
        private int precio; //El precio en euros a pagar por dicha suscripcion
        private int meses; //Meses suscritos a dicha tarifa
        private DateTime fechaInicio;
        private DateTime fechaFinal;

        public SuscripcionEN()
        {

            //usuario = null;
            cuentaBancaria = "";
            fechaInicio = DateTime.MinValue;
            fechaFinal = DateTime.MinValue;
            tarifa = new TarifaEN();

        }

        public SuscripcionEN(UserEN usuario)
        {

            SuscripcionCAD.Load(usuario);

        }

        public SuscripcionEN(/*UserEN usuario, */string cuentaBancaria, TarifaEN tarifa, DateTime fechaInicio, DateTime fechaFinal)
        {

            //this.usuario = usuario;
            this.cuentaBancaria = cuentaBancaria;
            this.tarifa = tarifa;
            this.fechaInicio = fechaInicio;
            this.fechaFinal = fechaFinal;

        }

        public void Save()
        {

            SuscripcionCAD.Save(this);

        }

        /*
        public UserEN Usuario
        {

            get { return usuario; }
            set { usuario = value; }

        }
        */

        public string CuentaBancaria
        {

            get { return cuentaBancaria; }
            set { cuentaBancaria = value; }

        }

        public TarifaEN Tarifa
        {

            get { return tarifa; }
            set { tarifa = value; }

        }


        public DateTime FechaInicio
        {

            get { return fechaInicio; }
            set { fechaInicio = value; }

        }

        public DateTime FechaFinal
        {

            get { return fechaFinal; }
            set { fechaFinal = value; }

        }

        public int Meses
        {

            get { return meses; }
            set { meses = value; }

        }

        /*
         * Recibe una duración en meses, una cuenta bancaria, el tipo de tarifa y te crea la suscricpcion
         */

        public static SuscripcionEN suscribirse(int meses, TarifaEN tarifa, string CuentaBancaria)
        {

            SuscripcionEN sus = new SuscripcionEN();

            DateTime inicio = DateTime.Now;
            DateTime final = inicio;
            final.AddMonths(meses);

            sus.FechaInicio = inicio;
            sus.FechaFinal = final;

            sus.Meses = meses;
            sus.precio = tarifa.Precio * meses;

            sus.CuentaBancaria = CuentaBancaria;

            sus.Tarifa = tarifa;

            sus.Save();

            return sus;
        }
    }

}