using Dental_Clinic_Management.My;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic_Management.Forms
{
    public partial class Treatment : Form
    {
        public Treatment()
        {
            InitializeComponent();
        }
        // Instantiating a new MyTreatment class
        public static MyTreatment treatment = new MyTreatment();

        // Represents the key for the selected treatment
        public static int key = 0;

        // Event handler for the "Save" button click
        private void treatSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Extracting data from the form
                string name = treatName.Text;
                int cost = Convert.ToInt32(treatCost.Text);
                string description = treatDesc.Text;

                // Adding treatment using MyTreatment class
                treatment.AddTreatment(name, cost, description);

                // Displaying a success message
                MessageBox.Show("Treatment added succesfully");

                // Refreshing the Treatment DataGridView with updated data
                this.Populate_TreatmentDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // Event handler for the "Delete" button click
        private void treatDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Checking if a treatment is selected for deletion
                if (key == 0)
                {
                    MessageBox.Show("Please select a treatment to delete");
                }
                else
                {
                    // Query to delete a treatment based on the key
                    string query = "DELETE FROM TreatmentTable WHERE TreatId=" + key + "";

                    // Deleting treatment using the DeleteTreatment method of the MyTreatment class
                    treatment.DeleteTreatment(query);

                    // Displaying a success message
                    MessageBox.Show("Treatment deleted succesfully");

                    // Clearing form fields and refreshing the Treatment DataGridView
                    treatName.Text = "";
                    treatCost.Text = "";
                    treatDesc.Text = "";

                    // Populating the Treatment DataGridView
                    this.Populate_TreatmentDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        // Event handler for clicking a cell in the Treatment DataGridView
        private void treatmentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Populating the form fields with data from the selected DataGridView row
                treatName.Text = treatmentDGV.SelectedRows[0].Cells[1].Value.ToString();
                treatCost.Text = treatmentDGV.SelectedRows[0].Cells[2].Value.ToString();
                treatDesc.Text = treatmentDGV.SelectedRows[0].Cells[3].Value.ToString();

                // Setting the key for deletion or update
                if (treatName.Text == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(treatmentDGV.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        // Method to populate the Treatment DataGridView
        private void Populate_TreatmentDGV()
        {
            try
            {
                // Query to retrieve all data from the TreatmentTable
                string query = "SELECT * FROM TreatmentTable";

                // Retrieving data using the ShowTreatment method of the MyTreatment class
                DataSet ds = treatment.ShowTreatment(query);

                // Setting the DataGridView's DataSource to the retrieved data
                treatmentDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // Event handler for the form load event
        private void Treatment_Load(object sender, EventArgs e)
        {
            // Populating the Treatment DataGridView on form load
            this.Populate_TreatmentDGV();
        }

        // Method to filter the Treatment DataGridView based on search criteria
        private void Filter()
        {
            try
            {
                // Query to filter data based on the treatment name
                string query = "SELECT * FROM TreatmentTable " +
                    "Where TreatName like '%" + treatSearchTextBox.Text + "%'";

                // Retrieving and displaying filtered data
                DataSet ds = treatment.ShowTreatment(query);
                treatmentDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Event handler for the "Edit" button click
        private void treatEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Checking if a treatment is selected for updating
                if (key == 0)
                {
                    MessageBox.Show("Please select treatment to edit");
                }
                else
                {
                    // Extracting data from the form
                    string name = treatName.Text;
                    int cost = Convert.ToInt32(treatCost.Text);
                    string description = treatDesc.Text;

                    // Updating treatment using the UpdateTreatment method of the MyTreatment class
                    treatment.UpdateTreatment(name, cost, description, key);

                    // Displaying a success message
                    MessageBox.Show("Treatment succefully updated");

                    // Refreshing the Treatment DataGridView with updated data
                    this.Populate_TreatmentDGV();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Event handler for the "TextChanged" event of the search text box
        private void treatSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            // Triggering the Filter method when the text in the search text box changes
            this.Filter();
        }

        // Event handler for the "Enter" event of the search text box
        private void treatSearchTextBox_Enter(object sender, EventArgs e)
        {
            // Clearing the text in the search text box when it receives focus
            treatSearchTextBox.Text = "";

            // Setting focus to the search text box
            treatSearchTextBox.Focus();
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

        // Event handler for the "Click" event of the "Dashboard" button
        private void dashboard_Click(object sender, EventArgs e)
        {
            // Creating and showing a new instance of the Dashboard form
            Dashboard dashboard = new Dashboard();
            dashboard.Show();

            // Hiding the current form
            this.Hide();
        }

        private void appointment_Click(object sender, EventArgs e)
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

        private void treatments_Click(object sender, EventArgs e)
        {
            // Creating and showing a new instance of the Treatment form
            Treatment treatment = new Treatment();
            treatment.Show();

            // Hiding the current form
            this.Hide();
        }

        private void patient_Click(object sender, EventArgs e)
        {
            // Creating and showing a new instance of the Patient form
            Patient patient = new Patient();
            patient.Show();

            // Hiding the current form
            this.Hide();
        }
    }
}
