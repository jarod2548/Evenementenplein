using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using EvenementenPleinMapper;
namespace DAL
{
    public class EvenementDAL
    {
        private readonly string connectionString;

        public EvenementDAL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString == null)
            {
                throw new InvalidOperationException("No connection string found");
            }
        }

        

        public void VoegEvenementToe(EvenementDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string sqlString = @"INSERT INTO EVENEMENT (Naam, Beschrijving) VALUES (@Naam, @Beschrijving)";
                SqlCommand cmd = new SqlCommand(sqlString, connection);
                cmd.Parameters.AddWithValue("@Naam", dto.Naam);
                cmd.Parameters.AddWithValue("@Beschrijving", dto.Beschrijving);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
