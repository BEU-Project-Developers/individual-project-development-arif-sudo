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
        public SqlConnection GetCon() { 
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\USER\\Desktop\\individual-project-development-arif-sudo\\Dental_Clinic_Management\\DentalClinicDb.mdf;Integrated Security=True;Connect Timeout=30";
            return connection; 
        }
    }
}
