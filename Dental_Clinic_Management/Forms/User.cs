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
        public static int key = 0;
        public static MyUser user = new MyUser();
        private void userSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = UName.Text;
                string phone = UPhone.Text;
                string password = UPassword.Text;

                user.AddUser(name, phone, password);
                MessageBox.Show("User added succesfully");
                this.Populate_UserDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void userDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Please select user to delete");
                }
                else
                {
                    string query = "DELETE FROM UsersTable WHERE UId=" + key + "";
                    user.DeleteUser(query);
                    MessageBox.Show("User deleted succesfully");
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
        private void userEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = UName.Text;
                string phone = UPhone.Text;
                string password = UPassword.Text;
                
                if (key == 0)
                {
                    MessageBox.Show("Select user to update");
                }
                else
                {
                    user.UpdateUser(name, phone, password, key);
                    MessageBox.Show("User updated succesfully");
                    this.Populate_UserDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void Populate_UserDGV()
        {
            try
            {
                string query = "SELECT * FROM UsersTable";
                DataSet ds = user.ShowUsers(query);
                userDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void User_Load(object sender, EventArgs e)
        {
            this.Populate_UserDGV();

        }
        private void Filter()
        {
            try
            {
                string query = "SELECT * FROM UsersTable " +
                    "Where UName like '%" + userSearchTextBox.Text + "%'";
                DataSet ds = user.ShowUsers(query);
                userDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void userDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                UName.Text = userDGV.SelectedRows[0].Cells[1].Value.ToString();
                UPassword.Text = userDGV.SelectedRows[0].Cells[2].Value.ToString();
                UPhone.Text = userDGV.SelectedRows[0].Cells[3].Value.ToString();
               
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

        private void userSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            this.Filter();
        }

        private void userSearchTextBox_Enter(object sender, EventArgs e)
        {
            userSearchTextBox.Text = "";
            userSearchTextBox.Focus();
            
        }

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

        private void users_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Show();
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
