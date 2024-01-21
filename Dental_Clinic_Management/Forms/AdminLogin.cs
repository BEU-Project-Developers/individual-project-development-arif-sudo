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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        // Event handler for the click event of the "Back to Login" label
        private void label4_Click(object sender, EventArgs e)
        {
            // Creating an instance of the Login form and displaying it.
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        // Event handler for the click event of the close label ("X").
        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Event handler for the click event of the login button.
        private void button1_Click(object sender, EventArgs e)
        {
            // Checking if the admin password textbox is empty.
            if (adminPassword.Text == "")
            {
                MessageBox.Show("Enter the Admin Password to Continue");
            }
            // Checking if the entered admin password is correct
            else if (adminPassword.Text == "Password123")
            {
                // If the password is correct, create an instance of the User form and display it.
                User user = new User();
                user.Show();
                this.Hide();
            }
            else
            {
                // If the entered password is incorrect, show an error message.
                MessageBox.Show("Wrong password, try again");
                return;
            }
        }
    }
}
