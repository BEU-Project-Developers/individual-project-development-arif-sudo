using Dental_Clinic_Management.Connection;
using Dental_Clinic_Management.My;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic_Management.Forms
{
    public partial class Prescription : Form
    {
        public Prescription()
        {
            InitializeComponent();
        }
        public static int key = 0; // key here represents PatId in database // later we can use key to delete columns 
        public static MyPrescription prescription = new MyPrescription();
        public static ConnectionString MyConnection = new ConnectionString();

        private string ExtractId(string input)
        {
            string[] parts = input.Split('-');
            string idPart = parts.Length > 0 ? parts[0].Trim() : string.Empty;
            return idPart;
        }
        private void fillPatient()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Select CONCAT(AptId, ' - ', AptPatient) AS IdName From AppointmentTable", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("IdName", typeof(string));
                    dt.Load(reader);

                    prescPatComboBox.ValueMember = "IdName";
                    prescPatComboBox.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void GetPatientName()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Select AptPatient From AppointmentTable Where AptId=" + ExtractId(prescPatComboBox.SelectedValue.ToString()) + "", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count > 0)
                    {
                        // Set the text of the TextBox with the value from the first row of the DataTable
                        prescName.Text = dt.Rows[0]["AptPatient"].ToString();
                    }
                    else
                    {
                        // Handle the case where there are no rows in the DataTable
                        prescName.Text = "No data available";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void GetTreatment()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Select AptTreatment From AppointmentTable Where AptId=" + ExtractId(prescPatComboBox.SelectedValue.ToString()) +"", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count > 0)
                    {
                        // Set the text of the TextBox with the value from the first row of the DataTable
                        prescTreatment.Text = dt.Rows[0]["AptTreatment"].ToString();
                    }
                    else
                    {
                        // Handle the case where there are no rows in the DataTable
                        prescTreatment.Text = "No data available";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void GetPrice()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Select TreatCost From TreatmentTable Where TreatName=@Name",connection);
                    command.Parameters.AddWithValue("@Name", prescTreatment.Text);

                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count > 0)
                    {
                        // Set the text of the TextBox with the value from the first row of the DataTable
                        prescCost.Text = dt.Rows[0]["TreatCost"].ToString();
                    }
                    else
                    {
                        // Handle the case where there are no rows in the DataTable
                        prescCost.Text = "No data available";
                    }
                }
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
                string query = "SELECT * FROM PrescriptionTable " +
                    "Where PatName like '%" + prescSearchTextBox.Text + "%'";
                DataSet ds = prescription.ShowPrescription(query);
                prescriptionDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void prescPatComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.GetPatientName();
            this.GetTreatment();
            this.GetPrice();
        }
     
        private void Prescription_Load(object sender, EventArgs e)
        {
            this.fillPatient();
            this.GetPatientName();
            this.GetTreatment();
            this.GetPrice();
            this.Populate_PrescriptionDGV();
        }

        private void Populate_PrescriptionDGV()
        {
            try
            {
                string query = "SELECT * FROM PrescriptionTable";
                DataSet ds = prescription.ShowPrescription(query);
                prescriptionDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void prescSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = prescName.Text;
                string treatment = prescTreatment.Text;
                int cost = Convert.ToInt32(prescCost.Text);
                string medicines = prescMedicines.Text;
                int quantity = Convert.ToInt32(prescQuantity.Text);

                prescription.AddPrescription(name, treatment, cost, medicines, quantity);
                MessageBox.Show("Prescripiton added succesfully");
                this.Populate_PrescriptionDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void prescDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Please select prescription to delete");
                }
                else
                {
                    string query = "DELETE FROM PrescriptionTable WHERE PrescId=" + key + "";
                    prescription.DeletePrescription(query);
                    MessageBox.Show("Prescription deleted succesfully");
                    prescName.Text = "";
                    prescTreatment.Text = "";
                    prescCost.Text = "";
                    prescMedicines.Text = "";
                    prescQuantity.Text = "";
                    prescPatComboBox.SelectedValue = "";
                    this.Populate_PrescriptionDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void prescEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = prescName.Text;
                string treatment = prescTreatment.Text;
                int cost = Convert.ToInt32(prescCost.Text);
                string medicines = prescMedicines.Text;
                int quantity = Convert.ToInt32(prescQuantity.Text);

                if (key == 0)
                {
                    MessageBox.Show("Select prescription to update");
                }
                else
                {
                    prescription.UpdatePatient(name, treatment, cost, medicines, quantity, key);
                  
                    MessageBox.Show("Prescription updated succesfully");
                    this.Populate_PrescriptionDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void prescriptionDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                prescName.Text = prescriptionDGV.SelectedRows[0].Cells[1].Value.ToString();
                prescTreatment.Text = prescriptionDGV.SelectedRows[0].Cells[2].Value.ToString();
                prescCost.Text = prescriptionDGV.SelectedRows[0].Cells[3].Value.ToString();
                prescMedicines.Text = prescriptionDGV.SelectedRows[0].Cells[4].Value.ToString();
                prescQuantity.Text = prescriptionDGV.SelectedRows[0].Cells[5].Value.ToString();
                prescPatComboBox.SelectedItem = prescriptionDGV.SelectedRows[0].Cells[0].Value.ToString() + " - " + prescName.Text;

                if (prescName.Text == "" || prescName.Text == "No data available")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(prescriptionDGV.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void prescSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            this.Filter();
        }

        private void prescSearchTextBox_Enter(object sender, EventArgs e)
        {
            prescSearchTextBox.Text = "";
            prescSearchTextBox.Focus();
        }
    }
}
