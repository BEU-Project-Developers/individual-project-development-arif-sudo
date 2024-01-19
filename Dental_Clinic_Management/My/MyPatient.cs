using Dental_Clinic_Management.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Dental_Clinic_Management.My
{
    public class MyPatient
    {
        public void AddPatient(string name, string phone, string address, DateTime dob, string gender, string allergies ) {
            try
            {
                string query = "INSERT INTO PatientTable (PatName, PatPhone, PatAddress, PatDob, PatGender, PatAllergies) " +
               "values(@Name, @Phone, @Address, @Dateofbirth, @Gender, @Allergies)"; // query to add new patient to database
              
                ConnectionString MyConnection = new ConnectionString();// instantiating a new ConnectionString class
                using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))// using GetCon method of ConnectionString class to get connection string
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@DateOfBirth", dob);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Allergies", allergies);

                        command.ExecuteNonQuery(); // returns the number of rows affected
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
        public void DeletePatient() { }

        public DataSet ShowPatient(string query)
        {
            ConnectionString MyConnection = new ConnectionString();
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                    
                }

            }

        }
    }
}
