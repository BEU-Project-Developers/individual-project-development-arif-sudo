using Dental_Clinic_Management.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic_Management.My
{
    public class MyAppointment
    {

        private static ConnectionString MyConnection = new ConnectionString();// instantiating a new static ConnectionString class
        public void AddAppointment(string patient, string treatment,  DateTime date, TimeSpan time)
        {

            string query = "INSERT INTO AppointmentTable (AptPatient, AptTreatment, AptDate, AptTime) " +
           "values(@Patient, @Treatment, @Date, @Time)"; // query to add new Appointment to database

            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))// using GetCon method of ConnectionString class to get connection string
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Patient", patient);
                    command.Parameters.AddWithValue("@Treatment", treatment);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Time", time);

                    command.ExecuteNonQuery(); // returns the number of rows 
                }
            }
        }


        public void DeleteAppointment(string query)
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


        public void UpdateAppointment(string patient, string treatment, DateTime date, TimeSpan time,int key)
        {

            string query = "UPDATE AppointmentTable " +
           "SET AptPatient = @Patient, " +
           "    AptTreatment = @Treatment, " +
           "    AptDate = @Date, " +
           "    AptTime = @Time " +
           "WHERE AptId = @Key"; // query to edit selected appointment 

            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))// using GetCon method of ConnectionString class to get connection string
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Patient", patient);
                    command.Parameters.AddWithValue("@Treatment", treatment);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Time", time);
                    command.Parameters.AddWithValue("@Key", key);

                    command.ExecuteNonQuery(); // returns the number of rows affected
                }
            }
        }



        public DataSet ShowAppointment(string query)
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
