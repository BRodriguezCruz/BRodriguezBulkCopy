using Microsoft.Extensions.Configuration;

namespace DL
{
    public class Conexion
    {
        public static string GetConnectionString()
        {
            
            string connectionString = "Data Source=.;Initial Catalog=BRodriguezBulkCopy;User ID=sa;Password=pass@word1;TrustServerCertificate = True";
            return connectionString;
            
        }

    }
}