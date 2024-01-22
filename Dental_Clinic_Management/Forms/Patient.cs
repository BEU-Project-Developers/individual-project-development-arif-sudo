using Dental_Clinic_Management.Connection;
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
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dental_Clinic_Management.Forms
{
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
            patGenderCommoBox.Items.Add("Male");
            patGenderCommoBox.Items.Add("Female");
        }
        // Key here represents PatId in database; later used to delete columns
        public static int key = 0;

        // Instantiating a new MyPatient class
        public static MyPatient patient = new MyPatient();

        // Event handler for the "Save" button click
        private void patSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Extracting and saving data from the form
                string name = patName.Text;
                string phone = patPhone.Text;
                string address = patAddress.Text;
                DateTime dateOfBirth = patDateTimePicker.Value.Date;
                string gender = "";
                if (patGenderCommoBox.SelectedItem != null)
                {
                    gender = patGenderCommoBox.SelectedItem.ToString();
                }
                string allergies = patAllergies.Text;

                // Adding patient using custom MyPatient class
                patient.AddPatient(name, phone, address, dateOfBirth, gender, allergies);

                // Displaying a success message
                MessageBox.Show("Patient added succesfully");

                // Refreshing the DataGridView with updated data
                this.Populate_PatientDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        // Populates the Patient DataGridView
        private void Populate_PatientDGV()
        {
            try
            {
                // Query to retrieve all data from the PatientTable 
                string query = "SELECT * FROM PatientTable";

                // Retrieving data using the ShowPatient method of the MyPatient class
                DataSet ds = patient.ShowPatient(query);

                // Setting the DataGridView's DataSource to the retrieved data
                patientDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void Filter()
        {
            try
            {
                // Query to retrieve all data from the PatientTable with filter search
                string query = "SELECT * FROM PatientTable " +
                    "Where PatName like '%" + patSearchTextBox.Text + "%'";

                // Retrieving and displaying filtered data
                DataSet ds = patient.ShowPatient(query);
                patientDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void Patient_Load(object sender, EventArgs e)
        {
            // Populating the Patient DataGridView on form load
            this.Populate_PatientDGV();
        }

        private void patientDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Populating the form fields with data from the selected DataGridView row
                patName.Text = patientDGV.SelectedRows[0].Cells[1].Value.ToString();
                patPhone.Text = patientDGV.SelectedRows[0].Cells[2].Value.ToString();
                patAddress.Text = patientDGV.SelectedRows[0].Cells[3].Value.ToString();
                patGenderCommoBox.SelectedItem = patientDGV.SelectedRows[0].Cells[5].Value.ToString();
                patAllergies.Text = patientDGV.SelectedRows[0].Cells[6].Value.ToString();

                string dateString = patientDGV.SelectedRows[0].Cells[4].Value.ToString();
                if (!string.IsNullOrEmpty(dateString))
                {
                    // Parse the string to a DateTime object
                    if (DateTime.TryParse(dateString, out DateTime dateValue))
                    {
                        // Assign the DateTime value to the DateTimePicker
                        patDateTimePicker.Value = dateValue.Date;
                    }
                }
                // Setting the key for deletion or update
                if (patName.Text == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(patientDGV.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void patDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Checking if a patient is selected for deletion
                if (key == 0)
                {
                    MessageBox.Show("Please select patient to delete");
                }
                else
                {
                    // Query to delete a patient based on the key
                    string query = "DELETE FROM PatientTable WHERE PatId=" + key + "";

                    // Deleting patient using the DeletePatient method of the MyPatient class
                    patient.DeletePatient(query);

                    // Displaying a success message
                    MessageBox.Show("Patient deleted succesfully");

                    // Clearing form fields and refreshing the DataGridView
                    patName.Text = "";
                    patPhone.Text = "";
                    patAddress.Text = "";
                    patGenderCommoBox.SelectedItem = ""; // selected item -> selected value !!!
                    patAllergies.Text = "";
                    this.Populate_PatientDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void patEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Extracting data from the form
                string name = patName.Text;
                string phone = patPhone.Text;
                string address = patAddress.Text;
                DateTime dateOfBirth = patDateTimePicker.Value.Date;
                string gender = "";
                if (patGenderCommoBox.SelectedItem != null)
                {
                    gender = patGenderCommoBox.SelectedItem.ToString();
                }
                string allergies = patAllergies.Text;

                // Checking if a patient is selected for updating
                if (key == 0)
                {
                    MessageBox.Show("Select patient to update");
                }
                else
                {
                    // Updating patient using the UpdatePatient method of the MyPatient class
                    patient.UpdatePatient(name, phone, address, dateOfBirth, gender, allergies, key);

                    // Displaying a success message
                    MessageBox.Show("Patient updated succesfully");

                    // Refreshing the DataGridView with updated data
                    this.Populate_PatientDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // Event handler for the "TextChanged" event of the search text box
        private void patSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            // Triggering the Filter method when the text in the search text box changes
            this.Filter();
        }

        // Event handler for the "MouseEnter" event of the search text box
        private void patSearchTextBox_MouseEnter(object sender, EventArgs e)
        {
            // Clearing the text in the search text box when the mouse enters
            patSearchTextBox.Text = "";

            // Setting focus to the search text box
            patSearchTextBox.Focus();
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
            // Creating and showing a new instance of the Dashboard form
            Dashboard dashboard = new Dashboard();
            dashboard.Show();

            // Hiding the current form
            this.Hide();
        }

        private void appointment_Click_1(object sender, EventArgs e)
        {
            // Creating and showing a new instance of the Appointment form
            Appointment appointment = new Appointment();
            appointment.Show();

            // Hiding the current form
            this.Hide();
        }

        private void prescription_Click(object sender, EventArgs e)
        {
            // Creating and showing a new instance of the Prescription form
            Prescription prescription = new Prescription();
            prescription.Show();

            // Hiding the current form
            this.Hide();
        }

        private void treatment_Click(object sender, EventArgs e)
        {
            // Creating and showing a new instance of the Treatment form
            Treatment treatment = new Treatment();
            treatment.Show();

            // Hiding the current form
            this.Hide();
        }
    }
}
