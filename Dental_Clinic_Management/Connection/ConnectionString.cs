using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic_Management.Connection
{
    public class ConnectionString
    {
        public String GetConnectionString() {
            // Database name
            string databaseName = "DentalClinic";

            // Connection string with server name, initial catalog (database name), and integrated security
            string connectionString = $"Data Source=EARESTIN\\SQLEXPRESS;Initial Catalog={databaseName};Integrated Security=True";

            // Return the constructed connection string
            return connectionString; 
        }
    }
}
