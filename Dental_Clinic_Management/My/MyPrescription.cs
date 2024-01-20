using Dental_Clinic_Management.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic_Management.My
{
    public class MyPrescription
    {
        public static ConnectionString MyConnection = new ConnectionString();// instantiating a new public static ConnectionString class
        //public void AddPrescription(string name, string patient, string treatment, int quantity, string patient, int cost, string medicines )
        //{

        //    string query = "INSERT INTO PrescriptionTable (PatName, TreatName, TreatCost, Medicines, MedQty) " +
        //   "values(@Name, @Phone, @Address, @Dateofbirth, @Gender, @Allergies)"; // query to add new patient to database

        //    using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))// using GetCon method of ConnectionString class to get connection string
        //    {
        //        connection.Open();
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@Name", name);
        //            command.Parameters.AddWithValue("@Phone", phone);
        //            command.Parameters.AddWithValue("@Address", address);
        //            command.Parameters.AddWithValue("@DateOfBirth", dob);
        //            command.Parameters.AddWithValue("@Gender", gender);
        //            command.Parameters.AddWithValue("@Allergies", allergies);

        //            command.ExecuteNonQuery(); // returns the number of rows affected
        //            connection.Close(); // not necessary, because using statement automatically closes it after execution
        //        }
        //    }
        //}

    }
}
