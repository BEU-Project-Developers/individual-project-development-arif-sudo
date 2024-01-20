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

        private void label4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (adminPassword.Text == "")
            {
                MessageBox.Show("Enter the Admin Password to Continue");
            }
            else if (adminPassword.Text == "Password123")
            {
                User user = new User();
                user.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong password, try again");
            }
        }
    }
}
