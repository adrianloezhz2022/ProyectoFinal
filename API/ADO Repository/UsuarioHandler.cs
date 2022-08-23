using API.Model;
using System.Data;
using System.Data.SqlClient;

namespace API.ADO_Repository
{
    public static class UsuarioHandler
    {
        public static string ConnectionString = "Server=DESKTOP-L2KI5RL/MSSQLSERVER01;Database=SistemaGestion;Trusted_Connection=True";
        public static List<Usuario> GetUsarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario", sqlconnection))
                {
                    sqlconnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();

                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                                usuario.Mail = dataReader["Mail"].ToString();
                                usuarios.Add(usuario);
                            }
                        }
                    sqlconnection.Close();
                    }
                }
            }
        return usuarios;
        }
        public static bool EliminarUsuario(int id)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM Usuario WHERE Id = @id";

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
        public static bool CrearUsuario(Usuario usuario)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Usuario] (Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES (@nombreparameter, @apellidoParameter, @nombreUsuarioParameter, @contraseñaParameter, @mailParameter);";
                {
                    SqlParameter nombreParameter = new SqlParameter("@nombreparameter", SqlDbType.VarChar) { Value = usuario.Nombre };
                    SqlParameter apellidoParameter = new SqlParameter("@apellidoParameter", SqlDbType.VarChar) { Value = usuario.Apellido };
                    SqlParameter nombreUsuarioParameter = new SqlParameter("nombreUsuarioParameter", SqlDbType.VarChar) { Value = usuario.NombreUsuario };
                    SqlParameter contraseñaParameter = new SqlParameter("@contraseñaParameter", SqlDbType.VarChar) { Value = usuario.Contraseña };
                    SqlParameter mailParameter = new SqlParameter("@mailParameter", SqlDbType.VarChar) { Value = usuario.Mail };

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(nombreParameter);
                        sqlCommand.Parameters.Add(apellidoParameter);
                        sqlCommand.Parameters.Add(nombreUsuarioParameter);
                        sqlCommand.Parameters.Add(contraseñaParameter);
                        sqlCommand.Parameters.Add(mailParameter);

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
        public static bool ModificarUsuario(Usuario usuario)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "UPDATE [SistemaGestion].[dbo].[Usuario] SET Nombre = @nombre, Apellido = @apellido, NombreUsuario = @nombreUsuario, Contraseña = @nombreContraseña, Mail = @mail WHERE Id = @id";

                SqlParameter nombreParameter = new SqlParameter("nombre", SqlDbType.VarChar) { Value = usuario.Nombre };
                SqlParameter apellidoParameter = new SqlParameter("apellido", SqlDbType.VarChar) {Value = usuario.Apellido };
                SqlParameter nombreUsuarioParameter = new SqlParameter("nombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario };
                SqlParameter contraseñaParameter = new SqlParameter("contraseña", SqlDbType.VarChar) { Value = usuario.Contraseña };
                SqlParameter mailParameter = new SqlParameter("email", SqlDbType.VarChar) { Value = usuario.Mail};

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(nombreParameter);
                    sqlCommand.Parameters.Add(apellidoParameter);
                    sqlCommand.Parameters.Add(nombreUsuarioParameter);
                    sqlCommand.Parameters.Add(contraseñaParameter);
                    sqlCommand.Parameters.Add(mailParameter);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }
                }
            return resultado;
            }
        }
    }
}