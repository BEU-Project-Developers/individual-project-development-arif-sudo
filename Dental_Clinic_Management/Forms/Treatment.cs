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

        private void treatSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                MyTreatment treatment = new MyTreatment();
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
        int key = 0;
        private void treatDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                MyTreatment treatment = new MyTreatment();
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
                MyTreatment treatment = new MyTreatment();
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

        private void treatEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (key  == 0)
                {
                    MessageBox.Show("Please select treatment to delete");
                }
                else
                {
                    MyTreatment treatment = new MyTreatment();
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
    }
}
