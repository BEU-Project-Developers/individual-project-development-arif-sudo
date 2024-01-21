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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }
        // Static variable to represent the key (UId) for database operations.
        public static int key = 0;

        // Instance of MyUser class for database operations.
        public static MyUser user = new MyUser();

        // Event handler for Save button click
        private void userSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Extracting data from the form
                string name = UName.Text;
                string phone = UPhone.Text;
                string password = UPassword.Text;

                // Add user details to the database
                user.AddUser(name, phone, password);

                //Display a success message
                MessageBox.Show("User added succesfully");

                // Refreshing the User DataGridView with updated data
                this.Populate_UserDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // Event handler for Delete button click
        private void userDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Checking if a user is selected for deletion
                if (key == 0)
                {
                    MessageBox.Show("Please select user to delete");
                }
                else
                {
                    // Query to delete a user based on the key
                    string query = "DELETE FROM UsersTable WHERE UId=" + key + "";

                    // Deleting treatment using the DeleteUser method
                    user.DeleteUser(query);

                    // Displaying a success message
                    MessageBox.Show("User deleted succesfully");

                    // Clearing form fields and refreshing the User DataGridView
                    UName.Text = "";
                    UPhone.Text = "";
                    UPassword.Text = "";
                    this.Populate_UserDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;

            }
        }

        // Event handler for the Edit button click
        private void userEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Extracting data from the form
                string name = UName.Text;
                string phone = UPhone.Text;
                string password = UPassword.Text;

                // Checking if a treatment is selected for updating
                if (key == 0)
                {
                    MessageBox.Show("Select user to update");
                }
                else
                {
                    // Updating user using the UpdateTreatment method
                    user.UpdateUser(name, phone, password, key);

                    // Displaying a success message
                    MessageBox.Show("User updated succesfully");

                    // Refreshing the User DataGridView with updated data
                    this.Populate_UserDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // Method to populate the User DataGridView
        private void Populate_UserDGV()
        {
            try
            {
                // Query to retrieve all data from the UsersTable
                string query = "SELECT * FROM UsersTable";

                // Retrieving data using the ShowUsers method of the MyTreatment class
                DataSet ds = user.ShowUsers(query);

                // Setting the DataGridView's DataSource to the retrieved data
                userDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Event handler for the form load event
        private void User_Load(object sender, EventArgs e)
        {
            // Populating the User DataGridView on form load
            this.Populate_UserDGV();

        }

        // Method to filter the User DataGridView based on search criteria
        private void Filter()
        {
            try
            {
                // Query to filter data based on the user name
                string query = "SELECT * FROM UsersTable " +
                    "Where UName like '%" + userSearchTextBox.Text + "%'";

                // Retrieving and displaying filtered data
                DataSet ds = user.ShowUsers(query);
                userDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Event handler for clicking a cell in the User DataGridView
        private void userDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Populating the form fields with data from the selected DataGridView row
                UName.Text = userDGV.SelectedRows[0].Cells[1].Value.ToString();
                UPassword.Text = userDGV.SelectedRows[0].Cells[2].Value.ToString();
                UPhone.Text = userDGV.SelectedRows[0].Cells[3].Value.ToString();

                // Setting the key for deletion or update
                if (UName.Text == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(userDGV.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // Event handler for the "TextChanged" event of the search text box
        private void userSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            // Triggering the Filter method when the text in the search text box changes
            this.Filter();
        }

        // Event handler for the "Enter" event of the search text box
        private void userSearchTextBox_Enter(object sender, EventArgs e)
        {
            // Clearing the text in the search text box when it receives focus
            userSearchTextBox.Text = "";

            // Setting focus to the search text box
            userSearchTextBox.Focus();
            
        }

        // The click functions below are used to create a new instance of corresponding form,show that form and hide current form
        // These codes are repeated in all fomrs
        private void logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void dashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void appointment_Click(object sender, EventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.Show();
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
