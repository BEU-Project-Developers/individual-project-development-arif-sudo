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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Dental_Clinic_Management.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        // Event handler for the click event of the "Admin Login" label.
        private void label4_Click(object sender, EventArgs e)
        {
            // Creating an instance of the AdminLogin form and displaying it.
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
            this.Hide();
        }

        // Event handler for the click event of the close label ("X").
        private void label6_Click(object sender, EventArgs e)
        {
            // Exiting the application.
            Application.Exit();
        }

        // Event handler for the click event of the login button.
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionString MyConnection = new ConnectionString();

                // Establishing a connection to the database using the connection string.
                using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
                {
                    connection.Open(); // Opening the connection to the database.

                    // SQL query to check the validity of the entered username and password.
                    string query = "Select count(*) From UsersTable Where UName='" + loginUserTextBox.Text + "' And UPassword='" + loginPassTextBox.Text + "'";
                    //string query = $"Select count(*) From UsersTable Where UName={loginUserTextBox.Text} And UPassword={loginPassTextBox.Text}";

                    // Creating a data adapter to execute the query and fill a DataTable with the results.
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);


                    // Checking if there is at least one row with the entered credentials.
                    if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
                    {
                        // If credentials are valid, create an instance of the Appointment form and display it.
                        Appointment appointment = new Appointment();
                        appointment.Show();
                        this.Hide();
                    }
                    else
                    {
                        // If credentials are invalid, show an error message and clear the textboxes.
                        MessageBox.Show("Wrong Username or Password");
                        loginUserTextBox.Text = "";
                        loginPassTextBox.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }
    }
}
