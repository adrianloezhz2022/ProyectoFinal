using API.Model;
using System.Data;
using System.Data.SqlClient;

namespace API.ADO_Repository
{
    public static class ProductoHandler
    {
        public static string ConnectionString = "Server=DESKTOP-L2KI5RL/MSSQLSERVER01;Database=SistemaGestion;Trusted_Connection=True";
        public static List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();
            using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto", sqlconnection))
                {
                    sqlconnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                       
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Producto producto = new Producto();

                                producto.Id = Convert.ToInt32(dataReader["Id"]);
                                producto.Descripciones = dataReader["Descripciones"].ToString();
                                producto.PrecioVenta = Convert.ToInt32(dataReader["PrecioVenta"]);
                                producto.Costo = Convert.ToInt32(dataReader["Costo"]);
                                producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                                productos.Add(producto);
                            }
                        }
                    }
                    sqlconnection.Close();
                }
            }
        return productos;
        }
        public static bool EliminarProducto(int id)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM Producto WHERE Id = @id";

                SqlParameter sqlParameter = new SqlParameter("id", System.Data.SqlDbType.BigInt);
                sqlParameter.Value = id;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(sqlParameter);
                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }
                }

                sqlConnection.Close();

                return resultado;
            }
        }
        public static bool CrearProducto(Producto producto)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Producto] (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES (@descripcionesparameter, @costoParameter, @precioVentaParameter, @stockParameter, @IdUsuarioParameter);";
                {
                    SqlParameter descripcionesParameter = new SqlParameter("@descripciones", SqlDbType.VarChar) { Value = producto.Descripciones };
                    SqlParameter costoParameter = new SqlParameter("@costo", SqlDbType.Int) { Value = producto.Costo };
                    SqlParameter precioVentaParameter = new SqlParameter("@precioVenta", SqlDbType.Int) { Value = producto.PrecioVenta };
                    SqlParameter stockParameter = new SqlParameter("@stock", SqlDbType.Int) { Value = producto.Stock };
                    SqlParameter IdUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int) { Value = producto.IdUsuario };

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(descripcionesParameter);
                        sqlCommand.Parameters.Add(costoParameter);
                        sqlCommand.Parameters.Add(precioVentaParameter);
                        sqlCommand.Parameters.Add(stockParameter);
                        sqlCommand.Parameters.Add(IdUsuarioParameter);

                        int numberOfRows = sqlCommand.ExecuteNonQuery();

                        if (numberOfRows > 0)
                        {
                            resultado = true;
                        }
                    }
                    sqlConnection.Close();
                }
                return resultado;
            }
        }
        public static bool ModificarProducto(Producto producto)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "UPDATE [SistemaGestion].[dbo].[Producto] SET Descripciones = @descripciones, Costo = @costo, PrecioVenta = @precio, Stock = @stock, IdUsuario = @IdUsuario WHERE Id = @id";

                SqlParameter descripcionesParameter = new SqlParameter("producto", SqlDbType.VarChar) { Value = producto.Descripciones };
                SqlParameter costoParameter = new SqlParameter("costo", SqlDbType.VarChar) { Value = producto.Costo };
                SqlParameter precioVentaParameter = new SqlParameter("precio", SqlDbType.VarChar) { Value = producto.Precio };
                SqlParameter stockParameter = new SqlParameter("stock", SqlDbType.VarChar) { Value = producto.Stock };
                SqlParameter IdUsuarioParameter = new SqlParameter("IdUsuario", SqlDbType.VarChar) { Value = producto.IdUsuario };

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(descripcionesParameter);
                    sqlCommand.Parameters.Add(costoParameter);
                    sqlCommand.Parameters.Add(precioVentaParameter);
                    sqlCommand.Parameters.Add(stockParameter);
                    sqlCommand.Parameters.Add(IdUsuarioParameter);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }
                }
            }
            return resultado;
        }
    }
}