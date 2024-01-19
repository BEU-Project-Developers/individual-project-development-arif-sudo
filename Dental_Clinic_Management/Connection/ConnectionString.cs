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
            string databaseName = "DentalClinic";
            string connectionString = $"Data Source=EARESTIN\\SQLEXPRESS;Initial Catalog={databaseName};Integrated Security=True";
            return connectionString; 
        }
    }
}
