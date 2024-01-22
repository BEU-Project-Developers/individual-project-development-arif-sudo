using Dental_Clinic_Management.Connection;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic_Management.Forms
{
    public partial class Dashboard : Form
    {
        public  ConnectionString MyConnection = new ConnectionString();
        public Dashboard()
        {
            InitializeComponent();
        }

        // Event handler for the click event of the close label ("X").
        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Event handler for the load event of the Dashboard form.
        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Initializing and setting up progress bars on the dashboard.
            userProgressBar.Value = 0;
            userProgressBar.Minimum = 0;
            userProgressBar.Maximum = 30;

            aptProgressBar.Value = 0;
            aptProgressBar.Minimum = 0;
            aptProgressBar.Maximum = 30;

            patientProgressBar.Value = 0;
            patientProgressBar.Minimum = 0;
            patientProgressBar.Maximum = 30;

            nextAptProgressBar.Value = 0;

            // Using SqlConnection to interact with the database.
            using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
            {
                try
                {
                    connection.Open(); // Opening the database connection.

                    // Retrieving and displaying user count and updating the progress bar.
                    SqlDataAdapter sda1 = new SqlDataAdapter("Select Count(*) From UsersTable", connection);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    userProgressBar.Text = dt1.Rows[0][0].ToString();
                    userProgressBar.Value = Convert.ToInt32(dt1.Rows[0][0].ToString());

                    // Retrieving and displaying appointment count and updating the progress bar.
                    SqlDataAdapter sda2 = new SqlDataAdapter("Select Count(*) From AppointmentTable", connection);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);
                    aptProgressBar.Text = dt2.Rows[0][0].ToString();
                    aptProgressBar.Value = Convert.ToInt32(dt2.Rows[0][0].ToString());

                    // Retrieving and displaying patient count and updating the progress bar.
                    SqlDataAdapter sda3 = new SqlDataAdapter("Select Count(*) From PatientTable", connection);
                    DataTable dt3 = new DataTable();
                    sda3.Fill(dt3);
                    patientProgressBar.Text = dt3.Rows[0][0].ToString();
                    patientProgressBar.Value = Convert.ToInt32(dt3.Rows[0][0].ToString());

                    // Retrieving the minimum appointment date and updating the progress bar.
                    SqlDataAdapter sda4 = new SqlDataAdapter("Select Min(AptDate) From AppointmentTable", connection);
                    DataTable dt4 = new DataTable();
                    sda4.Fill(dt4);
                    string[] parts = dt4.Rows[0][0].ToString().Split(' ');

                    string result;

                    if (parts.Length > 1)
                    {
                        result = parts[0] + "\n" + parts[1];
                    }
                    else if (parts.Length > 0)
                    {
                        result = parts[0];
                    }
                    else
                    {
                        result = "None";
                    }

                    nextAptProgressBar.Text = result;
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    return;
                }   
            }
        }

        // Event handler for the click event of the "Back" label.
        private void label7_Click(object sender, EventArgs e)
        {
            // Creating an instance of the Appointment form and displaying it.
            Appointment appointment = new Appointment();
            appointment.Show();
            this.Hide();
        }
    }
}
