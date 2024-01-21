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
using System.Drawing.Printing;
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

        //The click functions below are used to create a new instance of corresponding form,show that form and hide current form
        //These codes are repeated in all fomrs
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

        private void prescriptions_Click(object sender, EventArgs e)
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
        // Declaring a Bitmap object to store the content of the DataGridView
        Bitmap bitmap = null;
        // Event handler for the button click event to initiate the printing process
        private void printButton_Click(object sender, EventArgs e)
        {

            // Getting the current height of the DataGridView
            int height = prescriptionDGV.Height;

            // Setting the DataGridView height to accommodate all rows for printing
            prescriptionDGV.Height = prescriptionDGV.RowCount * prescriptionDGV.RowTemplate.Height * 2;

            // Creating a new Bitmap with the dimensions of the DataGridView
            bitmap = new Bitmap(prescriptionDGV.Width, prescriptionDGV.Height);

            // Drawing the DataGridView content onto the Bitmap
            prescriptionDGV.DrawToBitmap(bitmap, new Rectangle(0, 10, prescriptionDGV.Width, prescriptionDGV.Height));

            // Restore the original height of the DataGridView
            prescriptionDGV.Height = height;

            // Show the print preview dialog to preview the printed content
            printPreviewDialog1.ShowDialog();
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Calculate the scaling factors to fit the DataGridView content to the page
            float scaleWidth = e.PageBounds.Width / (float)bitmap.Width;
            float scaleHeight = e.PageBounds.Height / (float)bitmap.Height;

            // Choose the smaller of the two scaling factors to maintain aspect ratio
            float scale = Math.Min(scaleWidth, scaleHeight);

            // Apply the scaling transformation
            e.Graphics.ScaleTransform(scale, scale);


            // Draw the previously created Bitmap onto the printer's Graphics object
            e.Graphics.DrawImage(bitmap, 0, 0);

        }
    }
}
