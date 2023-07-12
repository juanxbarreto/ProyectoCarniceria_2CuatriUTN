using LibreriaCarniceria;

namespace FormsCarniceria
{
    public partial class LoginForm : Form
    {
        private Carniceria carniceria;
        private ClientesDB clientesDB;
        private VendedorDB vendedoresDB;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            carniceria = new Carniceria();
            clientesDB = new ClientesDB();
            vendedoresDB = new VendedorDB();
            comboBoxTipo.Items.Add("Vendedor");
            comboBoxTipo.Items.Add("Cliente");
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string correoElectronico = textBoxMail.Text;
            string contraseña = textBoxPass.Text;
            

            if (comboBoxTipo.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de usuario.");
            }
            else
            {
                string? rol = comboBoxTipo.SelectedItem.ToString();
                if (rol == "Vendedor")
                {
                    //codigo vendedor
                    List<Vendedor> ListaVendedores = vendedoresDB.GetData();
                    Vendedor? vendedorSeleccionado = new Vendedor();
                    vendedorSeleccionado = vendedorSeleccionado.ValidarCredenciales(correoElectronico, contraseña, ListaVendedores);

                    if (vendedorSeleccionado is not null)
                    {
                        MessageBox.Show("Inicio de sesion correcto. Bienvenido Vendedor!.");
                        // Redirigir al formulario "Heladera"
                        HeladeraForm formHeladera = new HeladeraForm(vendedorSeleccionado, vendedoresDB);
                        formHeladera.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Las credenciales no son validas o no coinciden con el tipo de usuario Vendedor.");
                    }
                }
                else if (rol == "Cliente")
                {
                    // codigo cliente
                    List<Cliente> ListaClientes = clientesDB.GetData();
                    Cliente? clienteSeleccionado = new Cliente();
                    clienteSeleccionado = clienteSeleccionado.ValidarCredenciales(correoElectronico, contraseña, ListaClientes);

                    if (clienteSeleccionado is not null)
                    {
                        MessageBox.Show("Inicio de sesion correcto. Bienvenido Cliente!.");
                        // Redirigir al formulario "Ventas"
                        
                        VentasForm formVenta = new VentasForm(clienteSeleccionado, clientesDB);
                        formVenta.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Las credenciales no son validas o no coinciden con el tipo de usuario Cliente.");
                    }
                }
            }

        }


        private void btnAutocompletar_Click(object sender, EventArgs e)
        {
            if (comboBoxTipo.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de usuario.");
            }
            else
            {
                string tipoUsuario = comboBoxTipo.SelectedItem.ToString();
                // Autocompletar los campos de correo electrónico y contraseña según el tipo de usuario seleccionado
                if (tipoUsuario == "Vendedor")
                {
                    textBoxMail.Text = "usuario3@gmail.com";
                    textBoxPass.Text = "qwerty";
                }
                else if (tipoUsuario == "Cliente")
                {
                    textBoxMail.Text = "usuario1@gmail.com";
                    textBoxPass.Text = "123456";
                }
            }
        }
    }
}