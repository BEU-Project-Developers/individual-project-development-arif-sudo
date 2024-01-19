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
    }

}
