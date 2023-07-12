using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCarniceria
{
    public class Producto
    {
        private string nombre;
        private decimal precioPorKilo;
        private int kilosEnStock;
        private string detalle;
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public decimal PrecioPorKilo
        {
            get { return this.precioPorKilo; }
            set { this.precioPorKilo = value; }
        }

        public int KilosEnStock
        {
            get { return this.kilosEnStock; }
            set { this.kilosEnStock = value; }
        }
        public string Detalle
        {
            get { return this.detalle; }
            set { this.detalle = value; }
        }

        public Producto()
        {

        }

        public Producto(string nombre, decimal precioPorKilo, int kilosEnStock, string detalle)
        {
            this.nombre = nombre;
            this.precioPorKilo = precioPorKilo;
            this.kilosEnStock = kilosEnStock;
            this.detalle = detalle;
        }

        public Producto(int id, string nombre, decimal precioPorKilo, int kilosEnStock, string detalle)
                : this(nombre, precioPorKilo, kilosEnStock, detalle)
        {
            this.id = id;
        }


        /// <summary>
        /// Verifica si dos productos son iguales segun su nombre
        /// </summary>
        /// <param name="prod1"></param>
        /// <param name="prod2"></param>
        /// <returns> Retorna true o false </returns>
        public static bool operator ==(Producto prod1, Producto prod2)
        {
            return prod1.nombre == prod2.nombre;
        }

        public static bool operator !=(Producto prod1, Producto prod2)
        {
            return !(prod1 == prod2);
        }

    }
}
