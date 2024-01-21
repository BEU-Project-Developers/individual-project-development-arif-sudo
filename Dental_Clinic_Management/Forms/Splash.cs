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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        // Variable to track the progress of the progress bar.
        int startpoint = 0;

        // Event handler for the tick event of the timer.
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Incrementing the progress value.
            startpoint += 1;

            // Setting the progress bar value.
            MyProgressBar.Value = startpoint;

            // Checking if the progress bar reaches 100%.
            if (MyProgressBar.Value == 100)
            {
                // Resetting the progress bar.
                MyProgressBar.Value = 0;
                timer1.Stop(); // Stopping the timer.

                // Creating an instance of the Login form and displaying it.
                Login login = new Login();
                login.Show();
                this.Hide();// Hiding the current splash screen form.
            }
        }

        // Event handler for the load event of the Splash form.
        private void Splash_Load(object sender, EventArgs e)
        {
            // Starting the timer to initiate progress updates.
            timer1.Start();
        }
    }
}
