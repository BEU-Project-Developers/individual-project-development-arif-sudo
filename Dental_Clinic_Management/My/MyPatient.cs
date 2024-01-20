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
        public static ConnectionString MyConnection = new ConnectionString();// instantiating a new public static ConnectionString class
        public void AddPatient(string name, string phone, string address, DateTime dob, string gender, string allergies)
        {

            string query = "INSERT INTO PatientTable (PatName, PatPhone, PatAddress, PatDob, PatGender, PatAllergies) " +
           "values(@Name, @Phone, @Address, @Dateofbirth, @Gender, @Allergies)"; // query to add new patient to database

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
                    connection.Close(); // not necessary, because using statement automatically closes it after execution
                }
            }
        }


        public void DeletePatient(string query)
        {
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }


        public void UpdatePatient(string name, string phone, string address, DateTime dob, string gender, string allergies, int key)
        {

            string query = "UPDATE PatientTable " +
           "SET PatName = @Name, " +
           "    PatPhone = @Phone, " +
           "    PatAddress = @Address, " +
           "    PatDob = @DateOfBirth, " +
           "    PatGender = @Gender, " +
           "    PatAllergies = @Allergies " +
           "WHERE PatId = @Key"; // query to edit selected patient 

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
                    command.Parameters.AddWithValue("@Key", key);

                    command.ExecuteNonQuery(); // returns the number of rows affected
                    connection.Close(); // not necessary, because using statement automatically closes it after execution
                }
            }
        }



        public DataSet ShowPatient(string query)
        {
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
