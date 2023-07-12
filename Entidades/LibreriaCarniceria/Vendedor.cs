using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCarniceria
{
    public class Vendedor : Usuario
    {
        private string condicion;

        public string Condicion
        {
            get { return this.condicion; }
            set { this.condicion = value; }
        }
        
        public Vendedor()
        {

        }

        public Vendedor(int id, string email, string contraseña, string condicion)
            : base(id, email, contraseña)
        {
            this.condicion = condicion;
        }

        public Vendedor? ValidarCredenciales(string correo, string contraseña, List<Vendedor> listaVendedores)
        {
            foreach (Vendedor vendedor in listaVendedores)
            {
                if (vendedor.Mail == correo && vendedor.Contraseña == contraseña)
                {
                    return vendedor;
                }
            }
            return null;
        }

        /// <summary>
        /// Genera un string con los datos del vendedor. 
        /// </summary>
        /// <returns>Retorna un string con los datos.</returns>
        public override string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"{base.Mostrar()}");
            str.AppendLine($"Condicion: {this.Condicion}");

            return str.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}
