using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace LibreriaCarniceria
{
    public class ProductoDB : IDatabase<Producto>
    {
        private string connectionString;
        private SqlCommand command;
        private SqlConnection connection;
        private SqlDataReader dataReader;

        public ProductoDB()
        {
            connectionString = (@"Data Source = LOCALHOST;
                                Database = ParcialProgramacion;
                                Trusted_Connection = True;
                                TrustServerCertificate = true; ");
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = CommandType.Text;
            command.Connection = connection;
        }

        public List<Producto> GetData()
        {
            List<Producto> listaProductos = new List<Producto>();

            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "SELECT * FROM PRODUCTS";

                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        listaProductos.Add(new Producto(Convert.ToInt32(dataReader["IDProducto"]),
                                    dataReader["Nombre"].ToString(),
                                    Convert.ToDecimal(dataReader["PrecioPorKilo"]),
                                    Convert.ToInt32(dataReader["KilosEnStock"]),
                                    dataReader["Detalle"].ToString()
                                    ));
                    }
                }
            }
            catch (Exception ex)
            {
                List<Exception> innerExceptions = new List<Exception>();
                if (ex is SqlException ||
                    ex is InvalidOperationException ||
                    ex is SqlNullValueException)
                {
                    innerExceptions.Add(ex);
                }

                if (innerExceptions.Count > 0)
                {
                    throw new ExceptionDatabase("Ocurrio un error al leer la tabla de productos.", innerExceptions);
                }
            }
            finally
            {
                connection.Close();
            }

            return listaProductos;
        }

        public void Save(Producto producto)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "INSERT INTO PRODUCTS VALUES (@Nombre, @PrecioPorKilo, @KilosEnStock, @Detalle)";
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@PrecioPorKilo", producto.PrecioPorKilo);
                command.Parameters.AddWithValue("@KilosEnStock", producto.KilosEnStock);
                command.Parameters.AddWithValue("@Detalle", producto.Detalle);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (Exception ex)
            {
                List<Exception> innerExceptions = new List<Exception>();
                if (ex is SqlException ||
                    ex is InvalidOperationException ||
                    ex is SqlNullValueException)
                {
                    innerExceptions.Add(ex);
                }

                if (innerExceptions.Count > 0)
                {
                    throw new ExceptionDatabase("Ocurrio un problema al guardar la tabla de productos.", innerExceptions);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public void Modify(Producto producto)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"UPDATE PRODUCTS SET Nombre = @Nombre, PrecioPorKilo = @PrecioPorKilo, KilosEnStock = @KilosEnStock, Detalle = @Detalle WHERE PRODUCTS.IDProducto = {producto.ID}";
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@PrecioPorKilo", producto.PrecioPorKilo);
                command.Parameters.AddWithValue("@KilosEnStock", producto.KilosEnStock);
                command.Parameters.AddWithValue("@Detalle", producto.Detalle);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                List<Exception> innerExceptions = new List<Exception>();
                if (ex is SqlException ||
                    ex is InvalidOperationException ||
                    ex is SqlNullValueException)
                {
                    innerExceptions.Add(ex);
                }

                if (innerExceptions.Count > 0)
                {
                    throw new ExceptionDatabase("Ocurrio un problema al modificar la tabla de productos.", innerExceptions);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public void Delete(Producto producto)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"DELETE FROM PRODUCTS WHERE PRODUCTS.IDProducto = {producto.ID}";
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                List<Exception> innerExceptions = new List<Exception>();
                if (ex is SqlException ||
                    ex is InvalidOperationException ||
                    ex is SqlNullValueException)
                {
                    innerExceptions.Add(ex);
                }

                if (innerExceptions.Count > 0)
                {
                    throw new ExceptionDatabase("Ocurrio un problema al eliminar un producto de la tabla.", innerExceptions);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
