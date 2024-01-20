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
        public static ConnectionString MyConnection = new ConnectionString();// instantiating a new public static ConnectionString class
        public void AddUser(string name, string phone, string password)
        {

            string query = "INSERT INTO UsersTable (UName, UPassword, UPhone) " +
           "values(@Name, @Password, @Phone)"; // query to add new user to database

            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))// using GetCon method of ConnectionString class to get connection string
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Password", password); // Have to store hashed format here
                    command.Parameters.AddWithValue("@Phone", phone);

                    command.ExecuteNonQuery(); // returns the number of rows affected
                    connection.Close(); // not necessary, because using statement automatically closes it after execution
                }
            }
        }
        public void DeleteUser(string query)
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
        public void UpdateUser(string name, string phone, string password, int key)
        {

            string query = "UPDATE UsersTable " +
           "SET UName = @Name, " +
           "    UPhone = @Phone, " +
           "    UPassword = @Password " +
           "WHERE UId = @Key"; // query to edit selected user 

            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))// using GetCon method of ConnectionString class to get connection string
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Key", key);

                    command.ExecuteNonQuery(); // returns the number of rows 
                }
            }
        }

        public DataSet ShowUsers(string query)
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
