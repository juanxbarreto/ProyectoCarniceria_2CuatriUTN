using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCarniceria
{
    public class EventoInfoProducto : EventArgs
    {
        private string nombre;

        public string Nombre
        {
            get { return this.nombre; }
        }

        public EventoInfoProducto(Producto producto)
        {
            this.nombre = producto.Nombre;
        }
    }
}
