using API.Model;
using Microsoft.AspNetCore.Connections;
using System.Data.SqlClient;

namespace API.ADO_Repository
{
    public static class ProductoVendidoHandler
    {
        public static string ConnectionString = "Server=DESKTOP-L2KI5RL/MSSQLSERVER01;Database=SistemaGestion;Trusted_Connection=True";
        public static List<ProductoVendido> GetProductosVendidos()
        {
            List<ProductoVendido> productosvendidos = new List<ProductoVendido>();
            using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ProductoVendido", sqlconnection))
                {
                    sqlconnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();

                                productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);
                                productosvendidos.Add(productoVendido);
                            }
                        }
                    }
                    sqlconnection.Close();
                }
            }
            return productosvendidos;
        }
    }
}
