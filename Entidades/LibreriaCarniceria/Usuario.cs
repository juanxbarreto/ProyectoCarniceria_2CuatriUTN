using System.Text;

namespace LibreriaCarniceria
{
    public class Usuario
    {
        private int id;
        private string mail;
        private string contraseña;
        private string tipo;

        public int ID
        {
            get { return id; }
        }

        public string Mail
        {
            get { return this.mail; }
        }
        public string Contraseña
        {
            get { return this.contraseña; }
        }

        public Usuario()
        {

        }

        public Usuario(int id, string email, string contraseña)
        {
            this.id = id;
            this.mail = email;
            this.contraseña = contraseña;
        }

        public Usuario(int id, string email, string contraseña, string tipo)
            : this(id, email, contraseña)
        {
            this.tipo = tipo;
        }


        /// <summary>
        /// Genera un string con los datos del usuario.
        /// </summary>
        /// <returns>Retorna un string con todos los datos.</returns>
        public virtual string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"ID: {this.ID}");
            str.Append($"Email: {this.Mail}");

            return str.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

    }
}