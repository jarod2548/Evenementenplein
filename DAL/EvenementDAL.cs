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
                string sqlString = @"INSERT INTO EVENEMENT (Naam, Beschrijving, Capaciteit, EvenementType, BeginDatum, EindDatum, locatieID) 
                                    VALUES (@Naam, @Beschrijving, @Capaciteit, @EvenementType, @BeginDatum, @EindDatum, @locatieID)";
                SqlCommand cmd = new SqlCommand(sqlString, connection);
                cmd.Parameters.AddWithValue("@Naam", dto.Naam);
                cmd.Parameters.AddWithValue("@Beschrijving", dto.Beschrijving);
                cmd.Parameters.AddWithValue("@Capaciteit", dto.Capaciteit);
                cmd.Parameters.AddWithValue("@EvenementType", dto.EvenementType);
                cmd.Parameters.AddWithValue("@BeginDatum", dto.BeginDatum);
                cmd.Parameters.AddWithValue("@EindDatum", dto.EindDatum);
                cmd.Parameters.AddWithValue("@locatieID", dto.LocatieID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<EvenementDTO> Ontvang10Evenementen()
        {
            List<EvenementDTO> evenementDTOs = new List<EvenementDTO>();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlString = @"SELECT Id, Naam, LocatieID, EvenementType, BeginDatum, EindDatum 
                                   FROM EVENEMENT ORDER BY Id 
                                   OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY;";
                SqlCommand cmd = new SqlCommand(sqlString, connection);
                connection.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EvenementDTO dto = new EvenementDTO();
                        dto.Naam = reader["Naam"].ToString();
                        dto.BeginDatum = Convert.ToDateTime(reader["BeginDatum"]);
                        dto.EindDatum = Convert.ToDateTime(reader["EindDatum"]);
                        dto.EvenementType = Convert.ToInt32(reader["EvenementType"]);
                        dto.LocatieID = Convert.ToInt32(reader["LocatieID"]);
                        evenementDTOs.Add(dto);
                    }
                }
            }
            return evenementDTOs;
        }
    }
}
