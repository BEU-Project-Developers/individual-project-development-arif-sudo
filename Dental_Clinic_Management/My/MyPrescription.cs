using Dental_Clinic_Management.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic_Management.My
{
    public class MyPrescription
    {
        // Instantiating a new static ConnectionString class
        public static ConnectionString MyConnection = new ConnectionString();

        // Method to add a new prescription to the database
        public void AddPrescription(string name, string treatment, int cost, string medicines, int quantity)
        {
            // SQL query to add a new prescription to the database
            string query = "INSERT INTO PrescriptionTable (PatName, TreatName, TreatCost, Medicines, MedQty) " +
           "values(@Name, @Treatment, @Cost, @Medicines, @Quantity)"; // query to add new prescription to database

            // Using statement for automatic disposal of resources
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
            {
                connection.Open();

                // Using SqlCommand to execute the SQL query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adding parameters to the SqlCommand
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Treatment", treatment);
                    command.Parameters.AddWithValue("@Cost", cost);
                    command.Parameters.AddWithValue("@Medicines", medicines);
                    command.Parameters.AddWithValue("@Quantity", quantity);

                    // Executing the query;
                    command.ExecuteNonQuery();
                }
            }
        }

        // Method to delete a prescription from the database based on the provided query
        public void DeletePrescription(string query)
        {
            // Using statement for automatic disposal of resources
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
            {
                connection.Open();

                // Using SqlCommand to execute the SQL query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Executing the query
                    command.ExecuteNonQuery();
                }
            }
        }

        // Method to update prescription information in the database
        public void UpdatePrescription(string name, string treatment, int cost, string medicines, int quantity, int key)
        {
            // SQL query to update selected prescription information
            string query = "UPDATE PrescriptionTable " +
           "SET PatName = @Patient, " +
           "    TreatName = @Treatment, " +
           "    TreatCost = @Cost, " +
           "    Medicines = @Medicines  , " +
           "    MedQty = @MedQty " +
           "WHERE PrescId = @Key";

            // Using statement for automatic disposal of resources
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
            {
                connection.Open();

                // Using SqlCommand to execute the SQL query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adding parameters to the SqlCommand
                    command.Parameters.AddWithValue("@Patient", name);
                    command.Parameters.AddWithValue("@Treatment", treatment);
                    command.Parameters.AddWithValue("@Cost", cost);
                    command.Parameters.AddWithValue("@Medicines", medicines);
                    command.Parameters.AddWithValue("@MedQty", quantity);
                    command.Parameters.AddWithValue("@Key", key);

                    // Executing the query;
                    command.ExecuteNonQuery(); 
                }
            }
        }

        // Method to retrieve prescription data based on the provided query and return a DataSet
        public DataSet ShowPrescription(string query)
        {
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
