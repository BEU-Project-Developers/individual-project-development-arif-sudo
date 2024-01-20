using Dental_Clinic_Management.Connection;
using MySql.Data.MySqlClient;
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
        public static ConnectionString MyConnection = new ConnectionString();// instantiating a new static ConnectionString class
        public void AddTreatment(string name, int cost, string description)
        {
            string query = "INSERT INTO TreatmentTable (TreatName, TreatCost, TreatDesc) " +
             "values(@Name, @Cost, @Description)"; // query to add new treatment to the database

            
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))// using GetConnectionString method of ConnectionString class to access connection string
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Cost", cost);
                    command.Parameters.AddWithValue("@Description", description);

                    command.ExecuteNonQuery(); // returns the number of rows affected
                    connection.Close(); // not necessary, because using statement automatically closes it after execution
                }
            }
        }
        public void DeleteTreatment(string query)
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
        public void UpdateTreatment(string name, int cost, string description, int key)
        {
            string query = "Update TreatmentTable " +
                    "Set TreatName = @Name, " +
                    "TreatCost = @Cost, " +
                    "TreatDesc = @Description " +
                    "Where TreatId = @Key";
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Cost", cost);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Key", key);
                    command.ExecuteNonQuery();
                }
            }
        }
        public DataSet ShowTreatment(string query)
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
