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
    public partial class HeladeraForm : Form
    {
        private Carniceria carniceria;
        private ProductoDB productosDB;
        private VendedorDB vendedorDB;
        private Vendedor vendedor;
        private DateTime hora;

        private CancellationTokenSource tokenCancelacionHora;
        private CancellationTokenSource tokenCancelacionOferta;

        public HeladeraForm(Vendedor vendedorSeleccionado, VendedorDB vendedoresDB)
        {
            InitializeComponent();
            this.vendedor = vendedorSeleccionado;
            carniceria = new Carniceria();
            this.vendedorDB = vendedoresDB;
            productosDB = new ProductoDB();
            tokenCancelacionHora = new CancellationTokenSource();
            tokenCancelacionOferta = new CancellationTokenSource();
        }

        private void HeladeraForm_Load(object sender, EventArgs e)
        {
            carniceria.ObtenerProdDB();
            carniceria.ObtenerClientesDB();
            carniceria.StockEnCero += ReponerStock;

            ActualizarProductos();
            ActualizarClientes();

            TareaOferta();
            TareaReloj();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (vendedor.Condicion == "Habilitado")
            {
                int cantidad = (int)numericUpDownCantidad.Value;

                DataGridViewRow filaProducto = dgvProductos.CurrentRow;
                DataGridViewRow filaCliente = dgvClientes.CurrentRow;

                Producto? productoElegido = filaProducto?.DataBoundItem as Producto;
                Cliente? clienteElegido = filaCliente?.DataBoundItem as Cliente;

                string medioDePago = ObtenerMedioDePago();

                if (carniceria.ValidarVenta(clienteElegido, productoElegido, cantidad, medioDePago))
                {
                    string mensaje = carniceria.MensajeModal(productoElegido, cantidad, medioDePago);
                    DialogResult resultado = MessageBox.Show(mensaje, "Confirmación de transacción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == resultado &&
                        carniceria.RealizarVenta(clienteElegido, productoElegido, cantidad, medioDePago))
                    {
                        MessageBox.Show("Venta realizada con exito!.");
                        try
                        {
                            carniceria.RellenarStock();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                        // Actualiza los campos necesarios
                        ActualizarClientes();
                        ActualizarProductos();
                        // Genera factura
                        carniceria.SubirFactura(productoElegido, cantidad, medioDePago);
                    }
                    else
                    {
                        MessageBox.Show("Venta cancelada.");
                    }
                }
                else
                {
                    MessageBox.Show("Operacion invalidada. Porfavor verifique ingresar una cantidad valida y que el cliente cuente con el saldo necesario.");
                }
            }
            else
            {
                MessageBox.Show("El vendedor se encuentra inhabilitado.");
            }
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            string nombreProducto = textBoxBuscar.Text.ToLower();

            List<Producto> listaProductos = new List<Producto>();

            if (nombreProducto != string.Empty)
            {
                listaProductos.Add(carniceria.Productos.Find(c => c.Nombre.ToLower() == nombreProducto));
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = listaProductos;
            }
            else
            {
                ActualizarProductos();
            }
        }

        /****************************************************** ACTUALIZAR ********************************************************/

        public void ReponerStock(object carniceria, EventoInfoProducto info)
        {
            MessageBox.Show($"Se ha rellenado el stock del producto {info.Nombre}.");
        }

        /// <summary>
        /// Actualiza los productos en el DGV
        /// </summary>
        private void ActualizarProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = carniceria.Productos;
        }

        private void ActualizarClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = carniceria.Clientes;
            dgvClientes.Columns["Contraseña"].Visible = false;
        }

        /// <summary>
        /// Actualiza el timepo del reloj
        /// </summary>
        private void ActualizarReloj()
        {
            try
            {
                while (!tokenCancelacionHora.IsCancellationRequested)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        labelReloj.Text = hora.FormatearFecha();
                    });
                    Thread.Sleep(1000);
                }
            }
            catch (ObjectDisposedException)
            {
                MessageBox.Show("Ocurrio un problema con el reloj.");
            }
        }

        /**************************************************************************************************************************/

        /**************************************************** TAREAS **************************************************************/

        /// <summary>
        /// Ejecuta la tarea reloj que nos da la hora actual
        /// </summary>
        private void TareaReloj()
        {
            try
            {
                Task.Run(() => ActualizarReloj());
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un problema con la tarea reloj.");
            }
        }

        /// <summary>
        /// Ejecuta la tarea ofertas que aplica un descuento del 50 a un producto al azar
        /// </summary>
        private async void TareaOferta()
        {
            try
            {
                while (!tokenCancelacionOferta.IsCancellationRequested)
                {
                    await Task.Delay(carniceria.ObtenerIntervaloDeDescuento());

                    if (!tokenCancelacionOferta.IsCancellationRequested)
                    {
                        int indice = carniceria.AplicarDescuentoAleatorio();
                        if (indice != -1)
                        {
                            MessageBox.Show($"¡El producto {carniceria.Productos[indice].Nombre} recibio un descuento del 50%!");
                            ActualizarProductos();
                            await Task.Delay(TimeSpan.FromSeconds(20));
                            carniceria.CancelarDescuento(indice);
                            ActualizarProductos();
                        }
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                MessageBox.Show("Ocurrio un problmea aplicando el descuento.");
            }
        }

        /**************************************************************************************************************************/

        /************************************************* OBTENER ****************************************************************/

        private string ObtenerMedioDePago()
        {
            string str = "Efectivo/Debito";
            if (checkBoxCredito.Checked)
            {
                str = "Credito";
            }
            return str;
        }

        /**************************************************************************************************************************/

        /************************************************* CERRAR FORM ************************************************************/

        private void HeladeraForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            tokenCancelacionOferta.Cancel();
            tokenCancelacionOferta.Dispose();
            tokenCancelacionHora.Cancel();
            tokenCancelacionHora.Dispose();
        }

        private void HeladeraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataGridViewRow filaProducto = dgvProductos.CurrentRow;
            DataGridViewRow filaCliente = dgvClientes.CurrentRow;

            Producto? productoElegido = filaProducto?.DataBoundItem as Producto;
            Cliente? clienteElegido = filaCliente?.DataBoundItem as Cliente;

            if (productoElegido is not null &&
                clienteElegido is not null)
            {
                try
                {
                    productosDB.Modify(productoElegido);

                }
                catch (ExceptionDatabase ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        /**************************************************************************************************************************/

        /**************************************************** SERIALIZAR **********************************************************/




        /**************************************************************************************************************************/

        /**************************************************** REPOSICION **********************************************************/

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddmodForm formNuevoProducto = new AddmodForm(carniceria);
            formNuevoProducto.ShowDialog();

            try
            {
                productosDB.GetData();
            }
            catch (ExceptionDatabase ex)
            {
                MessageBox.Show(ex.Message);
            }

            ActualizarProductos();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaProducto = dgvProductos.CurrentRow;
            Producto? productoElegido = filaProducto?.DataBoundItem as Producto;
            if (productoElegido is not null)
            {
                AddmodForm formModificarProducto = new AddmodForm(carniceria, productoElegido);
                formModificarProducto.ShowDialog();

                try
                {
                    productosDB.GetData();
                }
                catch (ExceptionDatabase ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ActualizarProductos();
            }
            else
            {
                MessageBox.Show("No se selecciono un producto para modificar.");
            }

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaProducto = dgvProductos.CurrentRow;
            Producto? productoElegido = filaProducto?.DataBoundItem as Producto;
            DialogResult resultado = MessageBox.Show($"¿Desea eliminar el producto {productoElegido.Nombre}?", "Eliminar corte", MessageBoxButtons.OKCancel);

            if (resultado == DialogResult.OK)
            {
                if (carniceria - productoElegido)
                {
                    try
                    {
                        productosDB.Delete(productoElegido);
                        productosDB.GetData();
                        ActualizarProductos();

                    }
                    catch (ExceptionDatabase ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show($"Ocurrio un problema, no se pudo eliminar el producto de la lista.");
                }
            }
        }

        /**************************************************************************************************************************/
    }
}
