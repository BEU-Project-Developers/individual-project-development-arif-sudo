using Dental_Clinic_Management.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic_Management.My
{
    public class MyTreatment
    {
        // Instantiating a new static ConnectionString class
        public static ConnectionString MyConnection = new ConnectionString();

        // Method to add a new treatment to the database
        public void AddTreatment(string name, int cost, string description)
        {
            // SQL query to add a new treatment to the database
            string query = "INSERT INTO TreatmentTable (TreatName, TreatCost, TreatDesc) " +
                            "values(@Name, @Cost, @Description)";

            // Using statement for automatic disposal of resources
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
            {
                connection.Open();

                // Using SqlCommand to execute the SQL query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adding parameters to the SqlCommand
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Cost", cost);
                    command.Parameters.AddWithValue("@Description", description);

                    // Executing the query; returns the number of rows affected
                    command.ExecuteNonQuery();

                    // Not necessary, because using statement automatically closes the connection after execution
                    connection.Close();
                }
            }
        }

        // Method to delete a treatment from the database based on the provided query
        public void DeleteTreatment(string query)
        {
            // Using statement for automatic disposal of resources
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
            {
                connection.Open();

                // Using SqlCommand to execute the SQL query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Executing the query; returns the number of rows affected
                    command.ExecuteNonQuery();
                }
            }
        }

        // Method to update treatment information in the database
        public void UpdateTreatment(string name, int cost, string description, int key)
        {
            // SQL query to update selected treatment information
            string query = "Update TreatmentTable " +
                            "Set TreatName = @Name, " +
                            "TreatCost = @Cost, " +
                            "TreatDesc = @Description " +
                            "Where TreatId = @Key";

            // Using statement for automatic disposal of resources
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
            {
                connection.Open();

                // Using SqlCommand to execute the SQL query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adding parameters to the SqlCommand
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Cost", cost);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Key", key);

                    // Executing the query; returns the number of rows affected
                    command.ExecuteNonQuery();
                }
            }
        }

        // Method to retrieve treatment data based on the provided query and return a DataSet
        public DataSet ShowTreatment(string query)
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
