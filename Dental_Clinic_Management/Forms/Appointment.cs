using Dental_Clinic_Management.Connection;
using Dental_Clinic_Management.ImageProcess;
using Dental_Clinic_Management.My;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using System.Windows.Input;


namespace Dental_Clinic_Management.Forms
{
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
            //ImageProcessor imageProcessor = new ImageProcessor();
            //string inputImagePath = "../Resources/tooth1.jpg";
            //string outputImagePath = "../Resources/toot1_rounded.jpg";
            //int cornerRadius = 25;
            //Color backgroundColor = Color.White;

            //imageProcessor.ProcessImage(inputImagePath, outputImagePath, cornerRadius, backgroundColor);
        }

        public static ConnectionString MyConnection = new ConnectionString();
        public static MyAppointment appointment = new MyAppointment();
        public static int key = 0;
        // static keyword used to create variable with access within entire class

        private void fillPatient()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Select PatName From PatientTable", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("PatName", typeof(string));
                    dt.Load(reader);

                    aptPatientComboBox.DisplayMember = "PatName";  // Set DisplayMember
                    aptPatientComboBox.ValueMember = "PatName";
                    aptPatientComboBox.DataSource = dt;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void fillTreatment()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(MyConnection.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Select TreatName From TreatmentTable", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("TreatName", typeof (string));
                        dt.Load(reader);
                        aptTreatmentComboBox.DisplayMember = "TreatName";  // Set DisplayMember
                        aptTreatmentComboBox.ValueMember = "TreatName";
                        aptTreatmentComboBox.DataSource = dt;

                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Filter()
        {
            try
            {
                string query = "SELECT * FROM AppointmentTable " +
                    "Where AptPatient like '%" + aptSearchTextBox.Text + "%'";
                DataSet ds = appointment.ShowAppointment(query);
                aptDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Appointment_Load(object sender, EventArgs e)
        {
            this.fillPatient();
            this.fillTreatment();

            this.Populate_Appointment();
        }
        private void Populate_Appointment()
        {
            try
            {
                string query = "Select * From AppointmentTable";
                DataSet ds = appointment.ShowAppointment(query);
                aptDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void aptSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string patient = aptPatientComboBox.SelectedValue?.ToString();
                string treatment = aptTreatmentComboBox.SelectedValue?.ToString();
                DateTime date = aptDate.Value.Date;
                TimeSpan time = aptTime.Value.TimeOfDay;
                appointment.AddAppointment(patient, treatment, date, time);
                MessageBox.Show("Appointment recoreded succesfully");
                this.Populate_Appointment();

            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void aptDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Please select appointment to cancel");
                }
                else
                {
                    string query = "DELETE FROM AppointmentTable WHERE AptId=" + key + "";
                    appointment.DeleteAppointment(query);
                    MessageBox.Show("Appointment canceled succesfully");
                    aptPatientComboBox.SelectedValue = "";
                    aptTreatmentComboBox.SelectedValue = "";
                    this.Populate_Appointment();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void aptEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Please select appointment to update");
                }
                else
                {
                    string patient = aptPatientComboBox.SelectedValue?.ToString();
                    string treatment = aptTreatmentComboBox.SelectedValue?.ToString();
                    DateTime date = aptDate.Value.Date;
                    TimeSpan time = aptTime.Value.TimeOfDay;
                    appointment.UpdateAppointment(patient, treatment, date, time, key);
                    MessageBox.Show("Appointment updated succesfully");
                    this.Populate_Appointment();
                }
                
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            

        }
        private void aptDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                aptPatientComboBox.SelectedValue = aptDGV.SelectedRows[0].Cells[1].Value.ToString();
                aptTreatmentComboBox.SelectedValue = aptDGV.SelectedRows[0].Cells[2].Value.ToString();
                aptDate.Text = aptDGV.SelectedRows[0].Cells[3].Value.ToString();
                aptTime.Text = aptDGV.SelectedRows[0].Cells[4].Value.ToString();

                if (aptPatientComboBox.SelectedValue == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(aptDGV.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void aptSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            this.Filter();
        }

        private void aptSearchTextBox_Enter(object sender, EventArgs e)
        {
            aptSearchTextBox.Text = "";
            aptSearchTextBox.Focus();
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
