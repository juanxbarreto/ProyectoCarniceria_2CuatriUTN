using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCarniceria
{
    public class Cliente : Usuario
    {
        private string nombre;
        private decimal montoMaximo;

        public string Nombre
        {
            get { return this.nombre; }
        }

        public decimal MontoMaximo
        {
            get { return this.montoMaximo; }
            set { this.montoMaximo = value; }
        }

        public Cliente()
        {

        }

        public Cliente(int id, string email, string contraseña, string nombre, decimal dineroDisponible)
            : base(id, email, contraseña)
        {
            this.nombre = nombre;
            this.montoMaximo = dineroDisponible;
        }

        public Cliente? ValidarCredenciales(string correo, string contraseña, List<Cliente> listaClientes)
        {
            foreach (Cliente cliente in listaClientes)
            {
                if (cliente.Mail == correo && cliente.Contraseña == contraseña)
                {
                    return cliente;
                }
            }
            return null;
        }

        /// <summary>
        /// Genera un string con los datos del cliente.
        /// </summary>
        /// <returns>Retorna un string con los datos.</returns>
        public override string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"{base.Mostrar()}");
            str.AppendLine($"Nombre: {this.Nombre}");
            str.AppendLine($"Dinero disponible: ${this.MontoMaximo.ToString("N2")}");

            return str.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}
