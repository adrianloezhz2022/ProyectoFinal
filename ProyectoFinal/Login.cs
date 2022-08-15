using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class Home : ConnectionHandler
    {
        public void Login()
        {
            
            using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario", sqlconnection))
                {

                }
            }
        }
    }
}