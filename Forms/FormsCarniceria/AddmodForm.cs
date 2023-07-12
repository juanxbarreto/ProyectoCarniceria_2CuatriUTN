using LibreriaCarniceria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsCarniceria
{
    public partial class AddmodForm : Form
    {
        private Producto? productoExistente;
        private Carniceria carniceria;
        private ProductoDB productoDB = new ProductoDB();

        public AddmodForm(Carniceria carniceria)
        {
            InitializeComponent();
            this.carniceria = carniceria;
        }

        public AddmodForm(Carniceria carniceria, Producto producto) : this(carniceria)
        {
            productoExistente = producto;
            CargarDatosProductoExistente();
        }

        private void AddmodForm_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text;
            int cantidad = (int)numericUpDownCantidad.Value;
            decimal precio = numericUpDownPrecio.Value;
            string detalle = textBoxDetalle.Text;

            if (productoExistente is not null)
            {
                //Modificar producto
                if(carniceria.ModificarProd(nombre, cantidad, precio, detalle, productoExistente))
                {
                    try
                    {
                        productoDB.Modify(productoExistente);
                    }
                    catch (ExceptionDatabase ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al modificar el producto", "Error");
                }
            }
            else
            {
                //Agregar producto
                if (carniceria.AgregarProd(nombre, cantidad, precio, detalle))
                {
                    Producto nuevoProducto = new Producto(nombre, precio, cantidad, detalle);
                    try
                    {
                        productoDB.Save(nuevoProducto);
                    }
                    catch (ExceptionDatabase ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al agregar el producto", "Error");
                }
            }
            this.Close();

        }

        private void CargarDatosProductoExistente()
        {
            if (productoExistente is not null)
            {
                // Cargar los datos del producto existente en los controles del formulario
                textBoxNombre.Text = productoExistente.Nombre;
                numericUpDownPrecio.Value = Math.Round(productoExistente.PrecioPorKilo, 2);
                numericUpDownCantidad.Value = productoExistente.KilosEnStock;
                textBoxDetalle.Text = productoExistente.Detalle;
            }
        }
    }
}
