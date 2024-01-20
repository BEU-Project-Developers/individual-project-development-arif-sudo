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
        }

        private void prescSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = prescName.Text;
                string treatment = prescTreatment.Text;
                string cost = prescCost.Text;
                string medicines = prescMedicines.Text;
                string quantity = prescQuantity.Text;

                //patient.AddPatient(name, phone, address, dateOfBirth, gender, allergies);
                //MessageBox.Show("Prescripiton added succesfully");
                //this.Populate_PatientDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
