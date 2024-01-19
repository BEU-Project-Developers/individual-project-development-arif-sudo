using Dental_Clinic_Management.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic_Management.My
{
    public class MyPatient
    {
        public void AddPatient(string query) {
            try
            {
                ConnectionString MyConnection = new ConnectionString(); // instantiating a new ConnectionString class
                SqlConnection connection = MyConnection.GetCon(); // using GetCon method of ConnectionString class to get connection string
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                connection.Open();
                cmd.CommandText = query; // setting command text to our query that we get as parametr
                cmd.ExecuteNonQuery(); // returns the number of rows affected
                connection.Close();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            } 
        }
    }
}
