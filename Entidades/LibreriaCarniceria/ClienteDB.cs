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
    public class ClientesDB : IDatabase<Cliente>
    {
        private string connectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public ClientesDB()
        {
            connectionString = (@"Data Source = LOCALHOST;
                                Database = ParcialProgramacion;
                                Trusted_Connection = True;
                                TrustServerCertificate = true; ");
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;
        }

        public List<Cliente> GetData()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // Abre la conexión antes de asignarla al comando
                    command.Parameters.Clear();
                    command.Connection = connection; // Asigna la conexión al comando
                    command.CommandText = "SELECT u.IDUsuario, c.Nombre, u.Correo, u.Contraseña, c.MontoMaximoCompra " +
                        "FROM Clientes AS c " +
                        "JOIN Usuarios AS u ON c.IDCliente = u.IDCliente WHERE u.TipoUsuario = 'Cliente'";

                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["IDUsuario"]);
                            string correo = reader["Correo"].ToString();
                            string contraseña = reader["Contraseña"].ToString();
                            string nombre = reader["Nombre"].ToString();
                            decimal montoMaximoCompra = Convert.ToDecimal(reader["MontoMaximoCompra"]);

                            clientes.Add(new Cliente(id, correo, contraseña, nombre, montoMaximoCompra));
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
                        throw new ExceptionDatabase("Ocurrio un error al leer la tabla de cliente.", innerExceptions);
                    }
                }
            }

            return clientes;
        }


        public void Modify(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.Parameters.Clear();
                        connection.Open();
                        command.CommandText = $"UPDATE Clientes SET MontoMaximoCompra = @MontoMaximoCompra WHERE Clientes.IDCliente = {cliente.ID}";
                        command.Parameters.AddWithValue("@MontoMaximoCompra", cliente.MontoMaximo);
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
                            throw new ExceptionDatabase("Ocurrio un error al modificar la tabla de clientes.", innerExceptions);
                        }
                    }
                }
            }
        }

        public Cliente? ClienteExist(string correoIngresado, string contraseñaIngresada)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    command.Parameters.Clear();
                    connection.Open();
                    command.CommandText = $"SELECT * FROM USUARIOS WHERE Correo = '{correoIngresado}' AND CONTRASEÑA = '{contraseñaIngresada}'";

                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["IDUsuario"]);
                            string correo = reader["Correo"].ToString();
                            string contraseña = reader["Contraseña"].ToString();
                            string nombre = reader["Nombre"].ToString();
                            decimal montoMaximoCompra = Convert.ToDecimal(reader["MontoMaximoCompra"]);

                            return new Cliente(id, correo, contraseña, nombre, montoMaximoCompra);
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
                        throw new ExceptionDatabase("Ocurrio un error al leer la tabla de clientes.", innerExceptions);
                    }
                }
            }
            return null;
        }

        public string UserType(string correo, string contraseña)
        {
            string strTipoUser = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    command.Parameters.Clear();
                    connection.Open();
                    command.CommandText = $"SELECT TipoUsuario FROM USUARIOS WHERE Correo = '{correo}' AND CONTRASEÑA = '{contraseña}'";

                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            strTipoUser = reader.GetString(reader.GetOrdinal("TipoUsuario"));
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
                        throw new ExceptionDatabase("Ocurrio un error al leer la tabla de clientes.", innerExceptions);
                    }
                }
            }
            return strTipoUser;
        }
    }
}
