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
        public static ConnectionString MyConnection = new ConnectionString();// instantiating a new public static ConnectionString class
        public void AddPrescription(string name, string treatment, int cost, string medicines, int quantity)
        {

            string query = "INSERT INTO PrescriptionTable (PatName, TreatName, TreatCost, Medicines, MedQty) " +
           "values(@Name, @Treatment, @Cost, @Medicines, @Quantity)"; // query to add new prescription to database

            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))// using GetCon method of ConnectionString class to get connection string
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Treatment", treatment);
                    command.Parameters.AddWithValue("@Cost", cost);
                    command.Parameters.AddWithValue("@Medicines", medicines);
                    command.Parameters.AddWithValue("@Quantity", quantity);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeletePrescription(string query)
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

        public void UpdatePatient(string name, string treatment, int cost, string medicines, int quantity, int key)
        {

            string query = "UPDATE PrescriptionTable " +
           "SET PatName = @Patient, " +
           "    TreatName = @Treatment, " +
           "    TreatCost = @Cost, " +
           "    Medicines = @Medicines  , " +
           "    MedQty = @MedQty " +
           "WHERE PrescId = @Key"; // query to edit selected prescription 

            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))// using GetCon method of ConnectionString class to get connection string
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Patient", name);
                    command.Parameters.AddWithValue("@Treatment", treatment);
                    command.Parameters.AddWithValue("@Cost", cost);
                    command.Parameters.AddWithValue("@Medicines", medicines);
                    command.Parameters.AddWithValue("@MedQty", quantity);
                    command.Parameters.AddWithValue("@Key", key);

                    command.ExecuteNonQuery(); 
                }
            }
        }

        public DataSet ShowPrescription(string query)
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
