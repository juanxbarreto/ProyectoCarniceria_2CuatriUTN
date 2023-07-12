using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibreriaCarniceria
{
    public static class ArchivosCarniceria
    {
        static XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Producto>));

        static string jsonStr;
        static string fileFacturas = "Facturas.txt";
        static string xlmFile = "Productos.xml";
        static string jsonFile = "Productos.json";

        static StreamWriter writter;
        static StreamReader reader;


        /*********************************************** SERELIZACION JSON *********************************************************************/

        /// <summary>
        /// Guarada en un archivo JSON los productos de la lista pasada por parametro
        /// </summary>
        /// <param name="productos"></param>
        /// <exception cref="Exception"></exception>
        public static void ProductosJsonSerializar(List<Producto> productos)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            try
            {
                jsonStr = JsonSerializer.Serialize(productos, options);

                using (writter = new StreamWriter(jsonFile))
                {
                    writter.Write(jsonStr);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al serializar los productos." + ex.Message);
            }
        }

        /// <summary>
        /// Convierte el archivo JSON en una lista de productos.
        /// </summary>
        /// <returns></returns>
        public static string ProductosJsonDeserializar()
        {
            List<Producto> productos = new List<Producto>();
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("Productos deserializados en JSON\n");

            try
            {
                using (reader = new StreamReader(jsonFile))
                {
                    productos = JsonSerializer.Deserialize<List<Producto>>(jsonStr);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al deserializar los productos." + ex.Message);
            }

            foreach (Producto producto in productos)
            {
                strBuilder.AppendLine($"ID: {producto.ID}, Nombre: {producto.Nombre}, Kilos en stock: {producto.KilosEnStock}, Precio por kg: {producto.PrecioPorKilo}, Detalle: {producto.Detalle}");
            }

            return strBuilder.ToString();
        }


        /*********************************************** SERELIZACION XLM *********************************************************************/

        /// <summary>
        /// Serializamos los productos de la lista pasados por parametro
        /// </summary>
        /// <param name="productos"></param>
        /// <exception cref="Exception"></exception>
        public static void ProductosXmlSerializar(List<Producto> productos)
        {
            using (writter = new StreamWriter(xlmFile))
            {
                try
                {
                    xmlSerializer.Serialize(writter, productos);
                }
                catch (Exception ex)
                {
                    List<Exception> exceptionsList = new List<Exception>();
                    if (ex is InvalidOperationException ||
                        ex is PathTooLongException ||
                        ex is UnauthorizedAccessException ||
                        ex is SecurityException ||
                        ex is IOException ||
                        ex is SerializationException ||
                        ex is FormatException)
                    {
                        exceptionsList.Add(ex);
                    }
                    if (exceptionsList.Count > 0)
                    {
                        throw new ExceptionArchivos("Ocurrio un problema al serializar los productos.", exceptionsList);
                    }
                }

            }
        }

        /// <summary>
        /// Deserealizamos los productos desde un archivo xml
        /// </summary>
        /// <param name="productos"></param>
        /// <exception cref="Exception"></exception>
        public static string ProductosXmlDeserializar()
        {
            List<Producto> productos = new List<Producto>();
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("Productos deserializados en XML\n");

            try
            {
                using (reader = new StreamReader(xlmFile))
                {
                    productos = xmlSerializer.Deserialize(reader) as List<Producto>;
                }
            }
            catch (Exception ex)
            {
                List<Exception> exceptionsList = new List<Exception>();
                if (ex is InvalidOperationException ||
                    ex is PathTooLongException ||
                    ex is UnauthorizedAccessException ||
                    ex is SecurityException ||
                    ex is IOException ||
                    ex is SerializationException ||
                    ex is FormatException)
                {
                    exceptionsList.Add(ex);
                }
                if (exceptionsList.Count > 0)
                {
                    throw new ExceptionArchivos("Ocurrio un problema al deserializar los productos.", exceptionsList);
                }
            }

            foreach (Producto producto in productos)
            {
                strBuilder.AppendLine($"ID: {producto.ID}, Nombre: {producto.Nombre}, Kilos en stock: {producto.KilosEnStock}, Precio por kg: {producto.PrecioPorKilo}, Detalle: {producto.Detalle}");
            }

            return strBuilder.ToString();
        }


        /*********************************************** FACTURA TXT *********************************************************************/

        /// <summary>
        /// Guardamos en un archivo txt el string con formato de factura
        /// </summary>
        /// <param name="facturaStr"></param>
        /// <exception cref="ExceptionArchivos"></exception>
        public static void GuardarFacturaTxt(string facturaStr)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(fileFacturas, !File.Exists(fileFacturas)))
                {
                    streamWriter.Write(facturaStr);
                }
            }
            catch (Exception ex)
            {
                List<Exception> listaExceptions = new List<Exception>();
                if (ex is InvalidOperationException ||
                    ex is PathTooLongException ||
                    ex is SecurityException ||
                    ex is IOException)
                {
                    listaExceptions.Add(ex);
                }

                if (listaExceptions.Count > 0)
                {
                    throw new ExceptionArchivos("Se produjo un error al guardar la factura.", listaExceptions);
                }
            }
        }

        public static string AbrirFacturaTxt()
        {
            string facturasStr = string.Empty;

            try
            {
                if (File.Exists(fileFacturas))
                {
                    facturasStr = File.ReadAllText(fileFacturas);
                }
            }
            catch (Exception ex)
            {
                List<Exception> listaExceptions = new List<Exception>();
                if (ex is InvalidOperationException ||
                    ex is PathTooLongException ||
                    ex is SecurityException ||
                    ex is IOException)
                {
                    listaExceptions.Add(ex);
                }

                if (listaExceptions.Count > 0)
                {
                    throw new ExceptionArchivos("Se produjo un error al cargar las facturas.", listaExceptions);
                }
            }
            finally
            {
                if (facturasStr == string.Empty)
                {
                    facturasStr = "No hay registro de facturas anteriores.";
                }
            }

            return facturasStr;
        }
    }
}
