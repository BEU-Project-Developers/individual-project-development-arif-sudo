using Dental_Clinic_Management.Connection;
using Dental_Clinic_Management.My;
using ServiceStack;
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

namespace Dental_Clinic_Management.Forms
{
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }

        private void patSaveButton_Click(object sender, EventArgs e)
        {
            string name = patName.Text;
            string phone = patPhone.Text;
            string address = patAddress.Text;
            DateTime dateOfBirth = patDateTimePicker.Value.Date;
            string gender = patGenderCommoBox.SelectedItem?.ToString();
            string allergies = patAllergies.Text;

            MyPatient patient = new MyPatient(); // instantiating a new MyPatient class
            try
            {
                patient.AddPatient(name, phone, address, dateOfBirth, gender, allergies);
                MessageBox.Show("Patient added succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            MyPatient patient = new MyPatient();
            string query = "SELECT * FROM PatientTable";
            DataSet ds = patient.ShowPatient(query);
            patientDGV.DataSource = ds.Tables[0];
        }

        int key = 0;
        private void patientDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            patName.Text = patientDGV.SelectedRows[0].Cells[1].Value.ToString();
            patPhone.Text = patientDGV.SelectedRows[0].Cells[2].Value.ToString();
            patAddress.Text = patientDGV.SelectedRows[0].Cells[3].Value.ToString();
            patGenderCommoBox.SelectedItem = patientDGV.SelectedRows[0].Cells[5].Value.ToString();
            patAllergies.Text = patientDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (patName.Text == "")
            {
                key = 0;
            }else
            {
                key = Convert.ToInt32(patientDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }

}
