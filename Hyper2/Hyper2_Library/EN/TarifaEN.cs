using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Hyper.CAD;

namespace Hyper.EN
{
    public class TarifaEN
    {

        private string tipoTarifa;
        private string descripcion;
        private int velocidadMaxima;
        private int espacioGB;
        private int precio; 

        public TarifaEN()
        {
            tipoTarifa = "";
            descripcion = "";
            velocidadMaxima = 0;
            espacioGB = 0;
            precio = 0;

        }

        public TarifaEN(string tipoTarifa)
        {
         
            TarifaCAD.Load(tipoTarifa);

        }

        public TarifaEN(string tipoTarifa, string descripcion, int velocidadMaxima, int espacioGB, int precio)
        {

            this.tipoTarifa = tipoTarifa;
            this.descripcion = descripcion;
            this.velocidadMaxima = velocidadMaxima;
            this.espacioGB = espacioGB;
            this.precio = precio;

        }

        public void Save()
        {

            TarifaCAD.Save(this);

        }

        public static ArrayList getTarifas()
        {
            ArrayList tarifas = TarifaCAD.getTarifas();

            return tarifas;
        }

        public string TipoTarifa { get; set; }
        public string Descripcion { get; set; }
        public int VelocidadMaxima { get; set; }
        public int EspacioGB { get; set; }
        public int Precio { get; set; }

    }
}