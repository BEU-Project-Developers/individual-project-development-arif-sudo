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
        public static MyTreatment treatment = new MyTreatment();
        public static int key = 0;
        private void treatSaveButton_Click(object sender, EventArgs e)
        {
            try
            {   
                string name = treatName.Text;
                int cost = Convert.ToInt32(treatCost.Text);
                string description = treatDesc.Text;
                treatment.AddTreatment(name, cost, description);
                MessageBox.Show("Treatment added succesfully");
                this.Populate_TreatmentDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void treatDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (key  == 0)
                {
                    MessageBox.Show("Please select treatment to delete");
                }
                else
                {   
                    string query = "DELETE FROM TreatmentTable WHERE TreatId=" + key + "";
                    treatment.DeleteTreatment(query);
                    MessageBox.Show("Treatment deleted succesfully");
                    treatName.Text = "";
                    treatCost.Text = "";
                    treatDesc.Text = "";
                    this.Populate_TreatmentDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void treatmentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                treatName.Text = treatmentDGV.SelectedRows[0].Cells[1].Value.ToString();
                treatCost.Text = treatmentDGV.SelectedRows[0].Cells[2].Value.ToString();
                treatDesc.Text = treatmentDGV.SelectedRows[0].Cells[3].Value.ToString();
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
        private void Populate_TreatmentDGV()
        {
            try
            {
                string query = "SELECT * FROM TreatmentTable";
                DataSet ds = treatment.ShowTreatment(query);
                treatmentDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void Treatment_Load(object sender, EventArgs e)
        {
            this.Populate_TreatmentDGV();
        }
        private void Filter()
        {
            try
            {
                string query = "SELECT * FROM TreatmentTable " +
                    "Where TreatName like '%" + treatSearchTextBox.Text + "%'";
                DataSet ds = treatment.ShowTreatment(query);
                treatmentDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void treatEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (key  == 0)
                {
                    MessageBox.Show("Please select treatment to edit");
                }
                else
                {
                    string name = treatName.Text;
                    int cost = Convert.ToInt32(treatCost.Text);
                    string description = treatDesc.Text;
                    treatment.UpdateTreatment(name, cost, description, key);
                    MessageBox.Show("Treatment succefully updated");
                    this.Populate_TreatmentDGV();
                }
               
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treatSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            this.Filter();
        }

        private void treatSearchTextBox_Enter(object sender, EventArgs e)
        {
            treatSearchTextBox.Text = "";
            treatSearchTextBox.Focus();
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

        private void treatments_Click(object sender, EventArgs e)
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
