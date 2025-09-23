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
    }
}
