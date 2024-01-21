using Dental_Clinic_Management.Connection;
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
using System.Xml.Linq;


namespace Dental_Clinic_Management.Forms
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        // Event handler for the click event of the Login label.
        private void label5_Click(object sender, EventArgs e)
        {
            // Creating an instance of the Login form and displaying it.
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        // Event handler for the click event of the close label ("X").s
        private void label6_Click(object sender, EventArgs e)
        {
            // Exiting the application.
            Application.Exit();
        }

        // Event handler for the click event of the register button
        private void registerButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Usage of GetConnectionString method of ConnectionString class to get connection string
                ConnectionString MyConnection = new ConnectionString();
                if (registerUserTextBox.Text == "" || registerPassTextBox.Text == "")
                {
                    MessageBox.Show("Fill the input to register!");
                    return;
                }

                string query = "INSERT INTO UsersTable (UName, UPassword, UPhone) " +
                "values(@Name, @Password, @Phone)";

                // Using statement for automatic disposal of resources
                
                using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
                {
                    connection.Open();

                    // Using SqlCommand to execute the SQL query
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        // Adding parameters to the SqlCommand
                        command.Parameters.AddWithValue("@Name", registerUserTextBox.Text);
                        command.Parameters.AddWithValue("@Password", registerPassTextBox.Text); // Store password in hashed format later
                        command.Parameters.AddWithValue("@Phone", registerPhoneTextBox.Text);

                        // Executing the query;
                        command.ExecuteNonQuery();
                        Login login = new Login();
                        login.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
    }
}
