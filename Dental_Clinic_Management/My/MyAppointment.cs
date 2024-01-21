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
        // Static variable to hold the connection string, ensuring a single instance for the class.
        private static ConnectionString MyConnection = new ConnectionString();

        // Method to add a new appointment to the database.
        public void AddAppointment(string patient, string treatment, DateTime date, TimeSpan time)
        {
            // SQL query to insert a new appointment into the 'AppointmentTable'.
            string query = "INSERT INTO AppointmentTable (AptPatient, AptTreatment, AptDate, AptTime) " +
                           "values(@Patient, @Treatment, @Date, @Time)";

            // Establishing a connection to the database using the connection string.
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
            {
                connection.Open(); // Opening the connection to the database.

                // Creating a SQL command with parameters for the appointment details.
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adding parameters to the SqlCommand
                    command.Parameters.AddWithValue("@Patient", patient);
                    command.Parameters.AddWithValue("@Treatment", treatment);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Time", time);

                    command.ExecuteNonQuery(); // Executing the SQL command to insert the new appointment.
                }
            }
        }

        // Method to delete an existing appointment from the database.
        public void DeleteAppointment(string query)
        {
            // Establishing a connection to the database using the connection string.
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
            {
                connection.Open(); // Opening the connection to the database.

                // Creating a SQL command to execute the provided deletion query.
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery(); // Executing the SQL command to delete the appointment.
                }
            }
        }

        // Method to update an existing appointment in the database.
        public void UpdateAppointment(string patient, string treatment, DateTime date, TimeSpan time, int key)
        {
            // SQL query to update the details of a selected appointment in the 'AppointmentTable'.
            string query = "UPDATE AppointmentTable " +
                           "SET AptPatient = @Patient, " +
                           "    AptTreatment = @Treatment, " +
                           "    AptDate = @Date, " +
                           "    AptTime = @Time " +
                           "WHERE AptId = @Key";

            // Establishing a connection to the database using the connection string.
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
            {
                connection.Open(); // Opening the connection to the database.

                // Creating a SQL command with parameters for the updated appointment details.
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Patient", patient);
                    command.Parameters.AddWithValue("@Treatment", treatment);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Time", time);
                    command.Parameters.AddWithValue("@Key", key);

                    command.ExecuteNonQuery(); // Executing the SQL command to update the appointment.
                }
            }
        }

        // Method to retrieve appointment data based on a provided query.
        public DataSet ShowAppointment(string query)
        {
            // Establishing a connection to the database using the connection string.
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
            {
                connection.Open(); // Opening the connection to the database.

                // Creating a SQL command to execute the provided query and retrieve data.
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Creating a data adapter to fill a DataSet with the results of the query.
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds); // Filling the DataSet with the retrieved data.

                    return ds; // Returning the filled DataSet.
                }
            }
        }
    }
}
