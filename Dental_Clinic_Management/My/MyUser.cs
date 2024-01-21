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
    public class MyUser
    {
        // Instantiating a new public static ConnectionString class
        public static ConnectionString MyConnection = new ConnectionString();// instantiating a new public static ConnectionString class

        // Method to add a new user to the database
        public void AddUser(string name, string phone, string password)
        {
            // SQL query to add a new user to the database
            string query = "INSERT INTO UsersTable (UName, UPassword, UPhone) " +
           "values(@Name, @Password, @Phone)";

            // Using statement for automatic disposal of resources
            // Usage of GetConnectionString method of ConnectionString class to get connection string
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))// using GetCon method of ConnectionString class to get connection string
            {
                connection.Open();

                // Using SqlCommand to execute the SQL query
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    // Adding parameters to the SqlCommand
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Password", password); // Store password in hashed format later
                    command.Parameters.AddWithValue("@Phone", phone);

                    // Executing the query;
                    command.ExecuteNonQuery();

                    // Not necessary, because using statement automatically closes the connection after execution
                    connection.Close(); 
                }
            }
        }

        // Method to delete a user from the database based on the provided query
        public void DeleteUser(string query)
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

        // Method to update user information in the database
        public void UpdateUser(string name, string phone, string password, int key)
        {
            // SQL query to update selected user information
            string query = "UPDATE UsersTable " +
           "SET UName = @Name, " +
           "    UPhone = @Phone, " +
           "    UPassword = @Password " +
           "WHERE UId = @Key";

            // Using statement for automatic disposal of resources
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))// using GetCon method of ConnectionString class to get connection string
            {
                connection.Open();
                // Using SqlCommand to execute the SQL query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adding parameters to the SqlCommand
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Key", key);

                    // Executing the query;
                    command.ExecuteNonQuery();
                }
            }
        }

        // Method to retrieve user data based on the provided query and return a DataSet
        public DataSet ShowUsers(string query)
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
