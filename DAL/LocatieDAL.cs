using Contracts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    
    public class LocatieDAL
    {
        private readonly string connectionString;
        public LocatieDAL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString == null)
            {
                throw new InvalidOperationException("No connection string found");
            }
        }

        public int VoegLocatieToeMetID(LocatieDTO dto)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlString = "INSERT INTO LOCATIE(Naam, Adres) Values (@Naam, @Adres); " +
                                   "SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(sqlString, connection);
                cmd.Parameters.AddWithValue("@Naam", dto.Naam);
                cmd.Parameters.AddWithValue("@Adres", dto.Adres);
                connection.Open();
                int locationID = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
                return locationID;
            }
        }

        public LocatieDTO OntvangLocatie(int ID)
        {
            LocatieDTO locatieDTO = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlString = @"SELECT Naam, Adres FROM LOCATIE WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand( sqlString, connection);
                cmd.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        locatieDTO = new LocatieDTO()
                        {
                            Naam = reader["Naam"].ToString(),
                            Adres = reader["Adres"].ToString()
                        };
                    }
                }
            }
            return locatieDTO;
        }
    }
}
