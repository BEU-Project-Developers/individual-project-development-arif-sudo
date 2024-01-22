using Dental_Clinic_Management.Connection;
using Dental_Clinic_Management.ImageProcess;
using Dental_Clinic_Management.My;
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
using System.Web.Services.Description;
using System.Windows.Forms;
using System.Windows.Input;


namespace Dental_Clinic_Management.Forms
{
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
            //ImageProcessor imageProcessor = new ImageProcessor();
            //string inputImagePath = "../Resources/tooth1.jpg";
            //string outputImagePath = "../Resources/toot1_rounded.jpg";
            //int cornerRadius = 25;
            //Color backgroundColor = Color.White;

            //imageProcessor.ProcessImage(inputImagePath, outputImagePath, cornerRadius, backgroundColor);
        }

        // Static keyword used to create variable with access within entire class
        public static ConnectionString MyConnection = new ConnectionString();
        public static MyAppointment appointment = new MyAppointment();

        // Represents the key for the selected treatment
        public static int key = 0;


        // Method to fill the patient ComboBox with patient names from the database.
        private void fillPatient()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
                {
                    connection.Open();
                    // Creating a SQL command to select the 'PatName' column from the 'PatientTable'.
                    SqlCommand command = new SqlCommand("Select PatName From PatientTable", connection);

                    // Executing the command and obtain a SqlDataReader to read the results.
                    SqlDataReader reader = command.ExecuteReader();

                    // Creating a new DataTable to store the patient names.
                    DataTable dt = new DataTable();

                    // Adding a column named 'PatName' with data type 'string' to the DataTable.
                    dt.Columns.Add("PatName", typeof(string));

                    // Loading the data from the SqlDataReader into the DataTable.
                    dt.Load(reader);

                    // Setting the 'PatName' column as the DisplayMember for the ComboBox.
                    aptPatientComboBox.DisplayMember = "PatName";

                    // Setting the 'PatName' column as the ValueMember for the ComboBox.
                    aptPatientComboBox.ValueMember = "PatName";

                    // Setting the ComboBox's data source to the DataTable containing patient names.
                    aptPatientComboBox.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        // Method to fill the treatment ComboBox with treatment names from the database.
        private void fillTreatment()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
                {
                    connection.Open();
                    // Creating a SQL command to select the 'TreatName' column from the 'TreatmentTable'.
                    using (SqlCommand command = new SqlCommand("Select TreatName From TreatmentTable", connection))
                    {
                        // Executing the command and obtain a SqlDataReader to read the results
                        SqlDataReader reader = command.ExecuteReader();

                        // Creating a new DataTable to store the patient names.
                        DataTable dt = new DataTable();

                        // Adding a column named 'PatName' with data type 'string' to the DataTable.
                        dt.Columns.Add("TreatName", typeof(string));

                        // Loading the data from the SqlDataReader into the DataTable.
                        dt.Load(reader);

                        // Setting the 'TreatName' column as the DisplayMember for the ComboBox.
                        aptTreatmentComboBox.DisplayMember = "TreatName";

                        // Setting the 'TreatName' column as the ValueMember for the ComboBox.
                        aptTreatmentComboBox.ValueMember = "TreatName";

                        // Setting the ComboBox's data source to the DataTable containing patient names.
                        aptTreatmentComboBox.DataSource = dt;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        // Method to filter the appointments based on the patient's name.
        private void Filter()
        {
            try
            {
                // Constructing a SQL query to select all columns from 'AppointmentTable'
                // where the 'AptPatient' column is currently containing the text in the search box.
                string query = "SELECT * FROM AppointmentTable " +
                    "Where AptPatient like '%" + aptSearchTextBox.Text + "%'";

                // Fetching appointment data based on the constructed query.
                DataSet ds = appointment.ShowAppointment(query);

                // Setting the DataGridView's DataSource to the first table in the fetched DataSet.
                aptDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        // Event handler for the Appointment form's Load event
        // Used to fill patient and treatment ComboBoxes and populate the DataGridView.
        private void Appointment_Load(object sender, EventArgs e)
        {
            // Fill the patient ComboBox with available patient names
            this.fillPatient();

            // Fill the treatment ComboBox with available treatment names
            this.fillTreatment();

            // Populate the DataGridView with existing appointments.
            this.Populate_Appointment();
        }

        // Method to populate the appointment DataGridView
        private void Populate_Appointment()
        {
            try
            {
                // Constructing a SQL query to select all columns from 'AppointmentTable'
                string query = "Select * From AppointmentTable";

                // Fetching appointment data based on the constructed query.
                DataSet ds = appointment.ShowAppointment(query);

                // Setting the DataGridView's DataSource to the first table in the fetched DataSet.
                aptDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // Event handler for the Save button in the appointment form.
        private void aptSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Extracting data from the Appointment form
                string patient = aptPatientComboBox.SelectedValue?.ToString();
                string treatment = aptTreatmentComboBox.SelectedValue?.ToString();
                DateTime date = aptDate.Value.Date;
                TimeSpan time = aptTime.Value.TimeOfDay;

                // Adding appointment using MyAppointment class
                appointment.AddAppointment(patient, treatment, date, time);

                // Displaying a success message
                MessageBox.Show("Appointment recorded succesfully");

                // Refreshing the Appointment DataGridView with updated data
                this.Populate_Appointment();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // Event handler for the Delete button in the appointment form.
        private void aptDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Checking if an appointment is selected for deletion
                if (key == 0)
                {
                    MessageBox.Show("Please select appointment to cancel");
                }
                else
                {
                    // Query to delete an appointment based on the key
                    string query = "DELETE FROM AppointmentTable WHERE AptId=" + key + "";

                    // Deleting appointment using the DeleteAppointmeby method of the MyAppointmeny class
                    appointment.DeleteAppointment(query);

                    // Displaying a success message
                    MessageBox.Show("Appointment canceled succesfully");

                    // Clearing form fields and refreshing the Appointment DataGridView
                    aptPatientComboBox.SelectedValue = "";
                    aptTreatmentComboBox.SelectedValue = "";

                    // Populating the Appointment DataGridView
                    this.Populate_Appointment();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // Event handler for the Edit button in the appointment form.
        private void aptEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Checking if an appointment is selected for updating
                if (key == 0)
                {
                    MessageBox.Show("Please select appointment to update");
                }
                else
                {
                    // Extracting data from the form
                    string patient = aptPatientComboBox.SelectedValue?.ToString();
                    string treatment = aptTreatmentComboBox.SelectedValue?.ToString();
                    DateTime date = aptDate.Value.Date;
                    TimeSpan time = aptTime.Value.TimeOfDay;

                    // Updating appointment using the UpdateAppointment method of the MyAppointment class
                    appointment.UpdateAppointment(patient, treatment, date, time, key);

                    // Displaying a success message
                    MessageBox.Show("Appointment updated succesfully");

                    // Populating the Appointment DataGridView
                    this.Populate_Appointment();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        // Method called when a cell in the DataGridView is clicked.
        private void aptDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Populating the form fields with data from the selected DataGridView row
                aptPatientComboBox.SelectedItem = aptDGV.SelectedRows[0].Cells[1].Value.ToString();
                aptTreatmentComboBox.SelectedItem = aptDGV.SelectedRows[0].Cells[2].Value.ToString();

                string dateString = aptDGV.SelectedRows[0].Cells[3].Value.ToString();
                if (!string.IsNullOrEmpty(dateString))
                {
                    // Parse the string to a DateTime object
                    if (DateTime.TryParse(dateString, out DateTime dateValue))
                    {
                        aptDate.Value = dateValue.Date;
                    }
                }
                string timeString = aptDGV.SelectedRows[0].Cells[3].Value.ToString();
                if (!string.IsNullOrEmpty(timeString))
                {
                    // Parse the string to a DateTime object
                    if (TimeSpan.TryParse(timeString, out TimeSpan timeValue))
                    {
                        DateTime currentDate = DateTime.Today;
                        DateTime selectedDateTime = currentDate.Add(timeValue);
                        aptTime.Value = selectedDateTime;
                    }
                }

                // Setting the key for deletion or update
                if (aptPatientComboBox.SelectedValue == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(aptDGV.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // Event handler for the "TextChanged" event of the search text box
        private void aptSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            // Triggering the Filter method when the text in the search text box changes
            this.Filter();
        }

        // Event handler for the "Enter" event of the search text box
        private void aptSearchTextBox_Enter(object sender, EventArgs e)
        {
            // Clearing the text in the search text box when it receives focus
            aptSearchTextBox.Text = "";

            // Setting focus to the search text box
            aptSearchTextBox.Focus();
        }

        // Event handler for the "Click" event of the "Logout" button
        private void logout_Click(object sender, EventArgs e)
        {
            // Creating and showing a new instance of the Login form
            Login login = new Login();
            login.Show();

            // Hiding the current form
            this.Hide();
        }

        private void dashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }


        private void prescription_Click(object sender, EventArgs e)
        {
            Prescription prescription = new Prescription();
            prescription.Show();
            this.Hide();
        }

        private void treatment_Click(object sender, EventArgs e)
        {
            Treatment treatment = new Treatment();
            treatment.Show();
            this.Hide();
        }

        private void patient_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Show();
            this.Hide();
        }
    }
}
