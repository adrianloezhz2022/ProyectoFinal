﻿using API.Model;
using System.Data.SqlClient;

namespace API.ADO_Repository
{
    public static class VentaHandler
    {
        public static string ConnectionString = "DESKTOP-L2KI5RL/MSSQLSERVER01;Database=SistemaGestion;Trusted_Connection=True";
        public static List<Venta> GetVentas()
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Venta", sqlconnection))
                {
                    sqlconnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();

                                venta.Id = Convert.ToInt32(dataReader["IdProducto"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();
                                ventas.Add(venta);
                            }
                        }
                    }
                    sqlconnection.Close();
                }
            }
            return ventas;
        }
    }
}