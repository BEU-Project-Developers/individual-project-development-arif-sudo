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
            try
            {
                MyPatient patient = new MyPatient(); // instantiating a new MyPatient class
                string name = patName.Text;
                string phone = patPhone.Text;
                string address = patAddress.Text;
                DateTime dateOfBirth = patDateTimePicker.Value.Date;
                string gender = patGenderCommoBox.SelectedItem?.ToString();
                string allergies = patAllergies.Text;

                patient.AddPatient(name, phone, address, dateOfBirth, gender, allergies);
                MessageBox.Show("Patient added succesfully");
                this.Populate_PatientDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void Populate_PatientDGV()
        {
            try
            {
                MyPatient patient = new MyPatient();
                string query = "SELECT * FROM PatientTable";
                DataSet ds = patient.ShowPatient(query);
                patientDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Patient_Load(object sender, EventArgs e)
        {
            this.Populate_PatientDGV();
        }

        int key = 0; // key here represents PatId in database
        // later we can use key to delete columns 
        private void patientDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                patName.Text = patientDGV.SelectedRows[0].Cells[1].Value.ToString();
                patPhone.Text = patientDGV.SelectedRows[0].Cells[2].Value.ToString();
                patAddress.Text = patientDGV.SelectedRows[0].Cells[3].Value.ToString();
                patGenderCommoBox.SelectedItem = patientDGV.SelectedRows[0].Cells[5].Value.ToString();
                patAllergies.Text = patientDGV.SelectedRows[0].Cells[6].Value.ToString();
                if (patName.Text == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(patientDGV.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void patDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                MyPatient patient = new MyPatient();
                if (key == 0)
                {
                    MessageBox.Show("Please select patient to delete");
                }
                else
                {
                    string query = "DELETE FROM PatientTable WHERE PatId=" + key + "";
                    patient.DeletePatient(query);
                    MessageBox.Show("Patient deleted succesfully");
                    patName.Text = "";
                    patPhone.Text = "";
                    patAddress.Text = "";
                    patGenderCommoBox.SelectedItem = default;
                    patAllergies.Text = "";
                    this.Populate_PatientDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void patEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                MyPatient patient = new MyPatient();
                string name = patName.Text;
                string phone = patPhone.Text;
                string address = patAddress.Text;
                DateTime dateOfBirth = patDateTimePicker.Value.Date;
                string gender = patGenderCommoBox.SelectedItem?.ToString();
                string allergies = patAllergies.Text;
                if (key == 0)
                {
                    MessageBox.Show("Select patient to update");
                }
                else
                {
                    patient.UpdatePatient(name, phone, address, dateOfBirth, gender, allergies, key);
                    MessageBox.Show("Patient updated succesfully");
                    this.Populate_PatientDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
