using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCarniceria
{
    public class VendedorDB : IDatabase<Vendedor>
    {
        private string connectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public VendedorDB()
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

        public List<Vendedor> GetData()
        {
            List<Vendedor> vendedores = new List<Vendedor>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    command.Parameters.Clear();
                    connection.Open();
                    command.Connection = connection; // Asigna la conexión al comando
                    command.CommandText = "SELECT u.IDUsuario, u.Correo, u.Contraseña, v.Condicion " +
                        "FROM Vendedores AS v " +
                        "JOIN Usuarios AS u ON v.IDVendedor = u.IDVendedor WHERE u.TipoUsuario = 'Vendedor'";

                    using (reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["IDUsuario"]);
                            string correo = reader["Correo"].ToString();
                            string contraseña = reader["Contraseña"].ToString();
                            string habilitado = reader["Condicion"].ToString();
                            vendedores.Add(new Vendedor(id, correo, contraseña, habilitado));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error al leer la tabla Vendedores. " + ex.Message);
                }
            }

            return vendedores;
        }

        public void Modify(Vendedor vendedor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    command.Parameters.Clear();
                    connection.Open();
                    command.CommandText = $"UPDATE VENDEDORES SET Condicion = @Condicion WHERE Vendedores.IDVendedor = {vendedor.ID}";
                    command.Parameters.AddWithValue("@Condicion", vendedor.Condicion);
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
                        throw new ExceptionDatabase("Ocurrio un error al leer la tabla de vendedores.", innerExceptions);
                    }
                }
            }
        }

        public bool CondicionVendedor(Vendedor vendedor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    command.Parameters.Clear();
                    connection.Open();
                    command.CommandText = $"SELECT Condicion FROM VENDEDORES WHERE IDVendedor = '{vendedor.ID}'";

                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string condicionVendedor = reader.GetString(reader.GetOrdinal("Condicion"));
                            if (condicionVendedor == "HABILITADO")
                            {
                                return true;
                            }
                            return false;
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
                        throw new ExceptionDatabase("Ocurrio un error al leer la tabla de vendedores.", innerExceptions);
                    }
                }
            }
            return false;
        }

    }
}
