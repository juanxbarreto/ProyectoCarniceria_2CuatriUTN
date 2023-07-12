using LibreriaCarniceria;
using System.Text;

namespace PruebasUnitariasCarniceria
{
    [TestClass]
    public class UnitTestCarniceria
    {
        [TestMethod]
        public void TestObtenerClientes()
        {
            List<Cliente> clientes;
            ClientesDB clientesDB = new ClientesDB();

            clientes = clientesDB.GetData();

            Assert.AreNotEqual(clientes.Count, 0);
        }

        [TestMethod]
        public void TestUsuario_ToString()
        {
            Usuario usuario = new Usuario(99999, "prueba@test.com", "12345");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID: {usuario.ID}");
            sb.Append($"Email: {usuario.Mail}");


            string usuarioToString = usuario.ToString();

            Assert.AreEqual(sb.ToString(), usuarioToString);
        }

        [TestMethod]
        public void TestAplicarDescuento()
        {
            Carniceria carniceria = new Carniceria();
            carniceria.Productos.Add(new Producto("Prueba", 50, 1, "Detalle"));

            int indice = carniceria.AplicarDescuentoAleatorio();
            decimal precioDescontado = carniceria.Productos[indice].PrecioPorKilo;

            Assert.AreEqual(25, precioDescontado);
        }
    }
}