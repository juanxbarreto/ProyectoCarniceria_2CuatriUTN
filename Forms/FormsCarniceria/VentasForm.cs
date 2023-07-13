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
    public partial class VentasForm : Form
    {
        private Carniceria carniceria;
        private ClientesDB clientesDB;
        private Cliente cliente;

        private DateTime hora;
        private CancellationTokenSource tokenCancelacionHora;
        private CancellationTokenSource tokenCancelacionOferta;

        public VentasForm(Cliente clienteSeleccionado, ClientesDB clientesDB)
        {
            InitializeComponent();
            this.cliente = clienteSeleccionado;
            carniceria = new Carniceria();
            this.clientesDB = clientesDB;
            tokenCancelacionHora = new CancellationTokenSource();
            tokenCancelacionOferta = new CancellationTokenSource();
        }

        private void VentasForm_Load(object sender, EventArgs e)
        {
            carniceria.ObtenerProdDB();
            carniceria.StockEnCero += ReponerStock;

            TareaOferta();
            TareaReloj();
            ActualizarDatosCliente();
            ActualizarProductos();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            string medioDePago = ObtenerMedioDePago();
            int cantidad = (int)numericUpDownCantidad.Value;
            DataGridViewRow fila = dgvProductos.CurrentRow;
            Producto? productoElegido = fila?.DataBoundItem as Producto;

            if (carniceria.ValidarVenta(cliente, productoElegido, cantidad, medioDePago))
            {
                string mensaje = carniceria.MensajeModal(productoElegido, cantidad, medioDePago);
                DialogResult resultado = MessageBox.Show(mensaje, "Confirmación de transacción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes &&
                    carniceria.RealizarVenta(cliente, productoElegido, cantidad, medioDePago))
                {
                    MessageBox.Show("Compra realizada con exito!.\nYa puede encontrar las facturas en el archivo correspondiente.");
                    try
                    {
                        carniceria.RellenarStock();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                    // Actualiza los campos necesarios
                    ActualizarDatosCliente();
                    ActualizarProductos();
                    // Cargamos la factura en el txt
                    carniceria.SubirFactura(productoElegido, cantidad, medioDePago);
                }
                else
                {
                    MessageBox.Show("Compra cancelada.");
                }
            }
            else
            {
                MessageBox.Show("No se puede realizar la compra. Verifique su saldo e ingrese una cantidad valida del producto.");
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

        private void btnSaldo_Click(object sender, EventArgs e)
        {
            cliente.MontoMaximo = (decimal)numericUpDownSaldo.Value;
            ActualizarDatosCliente();
        }

        /*************************************************** CERRAR FORM *********************************************************/

        private void VentasForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            tokenCancelacionOferta.Cancel();
            tokenCancelacionOferta.Dispose();
            tokenCancelacionHora.Cancel();
            tokenCancelacionHora.Dispose();
        }
        private void VentasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                clientesDB.Modify(cliente);
            }
            catch (ExceptionDatabase ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /**************************************************************************************************************************/

        /****************************************************** ACTUALIZAR ********************************************************/

        public void ReponerStock(object carniceria, EventoInfoProducto info)
        {
            MessageBox.Show($"Se ha rellenado el stock del producto {info.Nombre}.");
        }

        /// <summary>
        /// Actualiza los datos del cliente en el label
        /// </summary>
        private void ActualizarDatosCliente()
        {
            labelCliente.Text = cliente.Mostrar();
        }

        /// <summary>
        /// Actualiza los productos en el DGV
        /// </summary>
        private void ActualizarProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = carniceria.Productos;
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

        /*************************************************** SERIALIZAR ***********************************************************/

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            try
            {
                ArchivosCarniceria.ProductosXmlSerializar(carniceria.Productos);
            }
            catch (ExceptionArchivos ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeserializar_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(ArchivosCarniceria.ProductosXmlDeserializar(), "Productos serializados en XML", MessageBoxButtons.OK);
            }
            catch (ExceptionArchivos ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /**************************************************************************************************************************/
    }
}
