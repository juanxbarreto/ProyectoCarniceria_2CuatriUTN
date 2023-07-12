using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LibreriaCarniceria
{
    public class Carniceria
    {
        private List<Cliente> clientes;
        private List<Producto> productos;
        private List<Vendedor> vendedores;

        public delegate void DelegadoStock(object carniceria, EventoInfoProducto infoProd);
        public event DelegadoStock StockEnCero;

        public List<Cliente> Clientes
        {
            get { return this.clientes; }
            set { this.clientes = value; }
        }

        public List<Producto> Productos
        {
            get { return this.productos; }
            set { this.productos = value; }
        }

        public List<Vendedor> Vendedores
        {
            get { return this.vendedores; }
            set { this.vendedores = value; }
        }

        public Carniceria()
        {
            this.clientes = new List<Cliente>();
            this.productos = new List<Producto>();
            this.vendedores = new List<Vendedor>();
        }

        
        /// <summary>
        /// Agrega un nuevo producto a la carniceria (si cumple los requisitos).
        /// </summary>
        /// <param name="corte"></param>
        /// <param name="cantidad"></param>
        /// <param name="precio"></param>
        /// <returns>Retorna true si el producto fue agregado a la lista, de lo contrario false.</returns>
        public bool AgregarProd(string nombre, int cantidad, decimal precio, string detalle)
        {
            if (nombre.ValidarTexto() && cantidad > 0 && precio > 0 && detalle.ValidarTexto())
            {
                try
                {
                    Producto nuevoProducto = new Producto(nombre, precio, cantidad, detalle);

                    if (this + nuevoProducto)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    Console.WriteLine($"Error al agregar el producto: {ex.Message}");
                }
            }

            return false;
        }

        /// <summary>
        /// Modifica los valores de un producto existente. 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="cantidad"></param>
        /// <param name="precio"></param>
        /// <param name="producto"></param>
        /// <returns></returns>
        public bool ModificarProd(string nombre, int cantidad, decimal precio, string detalle, Producto producto)
        {
            if (nombre.ValidarTexto() && cantidad > 0 && precio > 0 && detalle.ValidarTexto())
            {
                producto.Nombre = nombre;
                producto.PrecioPorKilo = precio;
                producto.KilosEnStock = cantidad;
                producto.Detalle = detalle;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Calcula el precio final de una compra/venta.
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="cantidad"></param>
        /// <param name="medioDePago"></param>
        /// <returns> Devuelve el precio en un dato tipo 'decimal' </returns>
        public decimal ObtenerPrecioFinal(Producto producto, int cantidad, string medioDePago)
        {
            decimal precioFinal = cantidad * producto.PrecioPorKilo;
            if (medioDePago == "Credito")
            {
                precioFinal += precioFinal * 0.05m;
            }
            return precioFinal;
        }

        /// <summary>
        /// Obtiene la lista de Productos y la carga en el amito local.
        /// </summary>
        public void ObtenerProdDB()
        {
            ProductoDB productoDB = new ProductoDB();
            this.productos = productoDB.GetData();
        }

        /// <summary>
        /// Obtiene la lista de Clientes y la carga en el amito local.
        /// </summary>
        public void ObtenerClientesDB()
        {
            ClientesDB clientesDB = new ClientesDB();
            this.clientes = clientesDB.GetData();
        }

        /// <summary>
        /// Repone el stock de un producto sin unidades en 15.
        /// </summary>
        public void RellenarStock()
        {
            foreach (Producto producto in this.productos)
            {
                if (producto.KilosEnStock == 0)
                {
                    EventoInfoProducto infoCarne = new EventoInfoProducto(producto);

                    if (StockEnCero is not null)
                    {
                        try
                        {
                            producto.KilosEnStock += 15;
                            StockEnCero.Invoke(this, infoCarne);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Hubo un error para rellenar el stock.", ex);
                        }
                    }
                }
            }
        }

        /********************************************** COMPRA/VENTA ************************************************************/

        /// <summary>
        /// Genera un mensaje modal para la confirmacion/cancelacion de la transaccion.
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="cantidad"></param>
        /// <param name="medioDePago"></param>
        /// <returns> El mensaje en un dato de tipo string </returns>
        public string MensajeModal(Producto producto, int cantidad, string medioDePago)
        {
            decimal precioFinal = ObtenerPrecioFinal(producto, cantidad, medioDePago);
            StringBuilder mensajeBuilder = new StringBuilder();
            mensajeBuilder.AppendLine("Confirmar operacion:");
            mensajeBuilder.AppendLine();
            mensajeBuilder.AppendLine($"Producto: {producto.Nombre}");
            mensajeBuilder.AppendLine($"Cantidad: {cantidad} Kg");
            mensajeBuilder.AppendLine($"Medio de pago: {medioDePago}");
            mensajeBuilder.AppendLine();
            mensajeBuilder.AppendLine($"Precio Final: {precioFinal.ToString("N2")}");
            mensajeBuilder.AppendLine("¿Desea confirmar la operacion?");

            return mensajeBuilder.ToString();
        }

        /// <summary>
        /// Realiza los cambios pertinentes a una compra/venta segun parametros.
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="producto"></param>
        /// <param name="cantidad"></param>
        /// <param name="medioDePago"></param>
        /// <returns>Si la transaccion pudo realizarse devuelve true, de lo contrario false</returns>
        public bool RealizarVenta(Cliente cliente, Producto producto, int cantidad, string medioDePago)
        {
            if (ValidarVenta(cliente, producto, cantidad, medioDePago))
            {
                decimal precioFinal = ObtenerPrecioFinal(producto, cantidad, medioDePago);
                //Actualizar saldo cliente
                cliente.MontoMaximo -= precioFinal;
                //Actualizamos el stock del producto
                producto.KilosEnStock -= cantidad;

                return true;
            }
            return false;
        }

        /// <summary>
        /// Realiza las validaciones pertinentes para completar la venta/compra.
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="producto"></param>
        /// <param name="cantidad"></param>
        /// <param name="medioDePago"></param>
        /// <returns> Devuelve true de ser factible la transaccion, de lo contrario false </returns>
        public bool ValidarVenta(Cliente cliente, Producto producto, int cantidad, string medioDePago)
        {
            if (cliente is not null && producto is not null)
            {
                decimal precioFinal = ObtenerPrecioFinal(producto, cantidad, medioDePago);
                if (cliente.MontoMaximo > precioFinal && producto.KilosEnStock >= cantidad && cantidad > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /************************************************************************************************************************/

        /*********************************************** FACTURAS ***************************************************************/

        /// <summary>
        /// Generamos una 'factura' con los datos de la compra/venta.
        /// </summary>
        /// <returns> Devolvemos el string de la factura </returns>
        public string GenerarFactura(Producto producto, int cantidad, string medioDePago)
        {
            StringBuilder facturaBuilder = new StringBuilder();
            decimal precioFinal = ObtenerPrecioFinal(producto, cantidad, medioDePago);
            DateTime hora = DateTime.Now;

            facturaBuilder.AppendLine("==================================");
            facturaBuilder.AppendLine("         FACTURA DE COMPRA");
            facturaBuilder.AppendLine("==================================");
            facturaBuilder.AppendLine();
            facturaBuilder.AppendLine($"CARNICERIA DON JULIO");
            facturaBuilder.AppendLine($"{DateTime.Today.ToString("dd/M/yy")} {hora.FormatearFecha()}");
            facturaBuilder.AppendLine();
            facturaBuilder.AppendLine($"Producto: {producto.Nombre}");
            facturaBuilder.AppendLine($"Cantidad a comprar: Kg{cantidad}");
            facturaBuilder.AppendLine($"Precio por kilo: ${producto.PrecioPorKilo}");
            facturaBuilder.AppendLine($"Medio de pago: {medioDePago}");
            facturaBuilder.AppendLine();
            facturaBuilder.AppendLine($"Precio final: ${precioFinal.ToString("N2")}");
            facturaBuilder.AppendLine("==================================");

            return facturaBuilder.ToString();
        }

        public void SubirFactura(Producto producto, int cantidad, string medioDePago)
        {
            try
            {
                ArchivosCarniceria.GuardarFacturaTxt(GenerarFactura(producto, cantidad, medioDePago));
            }
            catch (ExceptionArchivos ex)
            {
                throw new Exception("Ocurrio un problema al guardar la factura." + ex.Message);
            }
        }

        /************************************************************************************************************************/

        /******************************************** LOGICA DESCUENTOS *********************************************************/

        /// <summary>
        /// Aplica un descuento del 50% a un producto al azar de la lista.
        /// </summary>
        /// <returns>Devuelve el indice del producto, de no existir ninguno: -1</returns>
        public int AplicarDescuentoAleatorio()
        {
            int indice = -1;

            if (this.productos is not null && this.productos.Count > 0)
            {
                Random rnd = new Random();
                indice = rnd.Next(0, this.productos.Count);
                Producto producto = this.productos[indice];
                producto.PrecioPorKilo -= producto.PrecioPorKilo / 2;
            }

            return indice;
        }

        /// <summary>
        /// Busca el producto referenciando su indice y devuelve su valor original.
        /// </summary>
        /// <param name="indice"></param>
        public void CancelarDescuento(int indice)
        {
            this.productos[indice].PrecioPorKilo += this.productos[indice].PrecioPorKilo;
        }

        /// <summary>
        /// Genera un numero aleatorio que significara el intervalo en milisegundos que durara el descuento;
        /// </summary>
        /// <returns></returns>
        public int ObtenerIntervaloDeDescuento()
        {
            Random intervalo = new Random();
            return intervalo.Next(1000, 60001);
        }

        /************************************************************************************************************************/

        /***************************************** SOBRECARGA DE OPERADORES *****************************************************/

        /// <summary>
        /// Verifica si un producto pertenece a la carnicería.
        /// </summary>
        /// <param name="carniceria"></param>
        /// <param name="producto"></param>
        /// <returns>Retorna true si el producto ingresado ya pertenece a la carnicería, de lo contrario false.</returns>
        public static bool operator ==(Carniceria carniceria, Producto producto)
        {
            foreach (Producto item in carniceria.productos)
            {
                if (item == producto)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Carniceria carniceria, Producto producto)
        {
            return !(carniceria == producto);
        }

        /// <summary>
        /// Agrega un producto a la carnicería, utilizando el operador == para verificar no se encuentre ya en la misma.
        /// </summary>
        /// <param name="carniceria"></param>
        /// <param name="corte"></param>
        /// <returns>Retorna true si consigue agregar el corte a la carnicería, de lo contrario false.</returns>
        public static bool operator +(Carniceria carniceria, Producto producto)
        {
            if (carniceria is not null && carniceria != producto)
            {
                carniceria.productos.Add(producto);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Elimina un producto de la carnicería.
        /// </summary>
        /// <param name="carniceria"></param>
        /// <param name="corte"></param>
        /// <returns></returns>
        public static bool operator -(Carniceria carniceria, Producto producto)
        {
            if (carniceria is not null && carniceria == producto)
            {
                carniceria.productos.Remove(producto);
                return true;
            }

            return false;
        }

        /************************************************************************************************************************/

    }
}
