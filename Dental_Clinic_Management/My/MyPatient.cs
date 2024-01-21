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
        // Instantiating a new public static ConnectionString class
        public static ConnectionString MyConnection = new ConnectionString();

        // Method to add a new patient to the database
        public void AddPatient(string name, string phone, string address, DateTime dob, string gender, string allergies)
        {
            // SQL query to add a new patient to the database
            string query = "INSERT INTO PatientTable (PatName, PatPhone, PatAddress, PatDob, PatGender, PatAllergies) " +
           "values(@Name, @Phone, @Address, @Dateofbirth, @Gender, @Allergies)";

            // Using statement for automatic disposal of resources
            // Usage of GetConnectionString method of ConnectionString class to get connection string
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
            {
                connection.Open();

                // Using SqlCommand to execute the SQL query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adding parameters to the SqlCommand
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@DateOfBirth", dob);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Allergies", allergies);

                    // Executing the query; returns the number of rows affected
                    command.ExecuteNonQuery();

                    // Not necessary, because using statement automatically closes the connection after execution
                    connection.Close(); 
                }
            }
        }

        // Method to delete a patient from the database based on the provided query
        public void DeletePatient(string query)
        {
            // Using statement for automatic disposal of resources
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
            {
                connection.Open();
                // Using SqlCommand to execute the SQL query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Executing the query;
                    command.ExecuteNonQuery();
                }
            }
        }

        // Method to update patient information in the database
        public void UpdatePatient(string name, string phone, string address, DateTime dob, string gender, string allergies, int key)
        {
            // SQL query to update selected patient information
            string query = "UPDATE PatientTable " +
           "SET PatName = @Name, " +
           "    PatPhone = @Phone, " +
           "    PatAddress = @Address, " +
           "    PatDob = @DateOfBirth, " +
           "    PatGender = @Gender, " +
           "    PatAllergies = @Allergies " +
           "WHERE PatId = @Key"; 

            // Using statement for automatic disposal of resources
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))// using GetCon method of ConnectionString class to get connection string
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adding parameters to the SqlCommand
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@DateOfBirth", dob);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Allergies", allergies);
                    command.Parameters.AddWithValue("@Key", key);

                    // Executing the query; returns the number of rows affected
                    command.ExecuteNonQuery();

                    // Not necessary, because using statement automatically closes the connection after execution
                    connection.Close();
                }
            }
        }

        // Method to retrieve patient data based on the provided query and return a DataSet
        public DataSet ShowPatient(string query)
        {
            // Using statement for automatic disposal of resources
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
            {
                connection.Open();

                // Using SqlCommand to execute the SQL query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Using SqlDataAdapter to fill a DataSet with the results of the query
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    // Returning the filled DataSet
                    return ds;
                }
            }
        }
    }
}
