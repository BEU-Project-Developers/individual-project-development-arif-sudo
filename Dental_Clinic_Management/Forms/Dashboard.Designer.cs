namespace Dental_Clinic_Management.Forms
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.userProgressBar = new CircularProgressBar.CircularProgressBar();
            this.aptProgressBar = new CircularProgressBar.CircularProgressBar();
            this.nextAptProgressBar = new CircularProgressBar.CircularProgressBar();
            this.patientProgressBar = new CircularProgressBar.CircularProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 132);
            this.panel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label5.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1132, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 37);
            this.label5.TabIndex = 8;
            this.label5.Text = "x";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(505, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(134, 104);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // userProgressBar
            // 
            this.userProgressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.userProgressBar.AnimationSpeed = 500;
            this.userProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.userProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userProgressBar.InnerColor = System.Drawing.Color.White;
            this.userProgressBar.InnerMargin = 3;
            this.userProgressBar.InnerWidth = -1;
            this.userProgressBar.Location = new System.Drawing.Point(226, 207);
            this.userProgressBar.MarqueeAnimationSpeed = 2000;
            this.userProgressBar.Name = "userProgressBar";
            this.userProgressBar.OuterColor = System.Drawing.Color.Silver;
            this.userProgressBar.OuterMargin = -25;
            this.userProgressBar.OuterWidth = 20;
            this.userProgressBar.ProgressColor = System.Drawing.Color.Teal;
            this.userProgressBar.ProgressWidth = 23;
            this.userProgressBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userProgressBar.Size = new System.Drawing.Size(200, 180);
            this.userProgressBar.StartAngle = 270;
            this.userProgressBar.SubscriptColor = System.Drawing.Color.Empty;
            this.userProgressBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.userProgressBar.SubscriptText = ".23";
            this.userProgressBar.SuperscriptColor = System.Drawing.Color.Empty;
            this.userProgressBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.userProgressBar.SuperscriptText = "°C";
            this.userProgressBar.TabIndex = 9;
            this.userProgressBar.TextMargin = new System.Windows.Forms.Padding(25, 0, 25, 0);
            this.userProgressBar.Value = 68;
            // 
            // aptProgressBar
            // 
            this.aptProgressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.aptProgressBar.AnimationSpeed = 500;
            this.aptProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.aptProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aptProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aptProgressBar.InnerColor = System.Drawing.Color.White;
            this.aptProgressBar.InnerMargin = 2;
            this.aptProgressBar.InnerWidth = -1;
            this.aptProgressBar.Location = new System.Drawing.Point(742, 207);
            this.aptProgressBar.MarqueeAnimationSpeed = 2000;
            this.aptProgressBar.Name = "aptProgressBar";
            this.aptProgressBar.OuterColor = System.Drawing.Color.Silver;
            this.aptProgressBar.OuterMargin = -25;
            this.aptProgressBar.OuterWidth = 20;
            this.aptProgressBar.ProgressColor = System.Drawing.Color.Navy;
            this.aptProgressBar.ProgressWidth = 23;
            this.aptProgressBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aptProgressBar.Size = new System.Drawing.Size(200, 180);
            this.aptProgressBar.StartAngle = 270;
            this.aptProgressBar.SubscriptColor = System.Drawing.Color.Empty;
            this.aptProgressBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.aptProgressBar.SubscriptText = ".23";
            this.aptProgressBar.SuperscriptColor = System.Drawing.Color.Empty;
            this.aptProgressBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.aptProgressBar.SuperscriptText = "°C";
            this.aptProgressBar.TabIndex = 10;
            this.aptProgressBar.TextMargin = new System.Windows.Forms.Padding(25, 0, 25, 0);
            this.aptProgressBar.Value = 68;
            // 
            // nextAptProgressBar
            // 
            this.nextAptProgressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.nextAptProgressBar.AnimationSpeed = 500;
            this.nextAptProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.nextAptProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextAptProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nextAptProgressBar.InnerColor = System.Drawing.Color.White;
            this.nextAptProgressBar.InnerMargin = 2;
            this.nextAptProgressBar.InnerWidth = -1;
            this.nextAptProgressBar.Location = new System.Drawing.Point(742, 426);
            this.nextAptProgressBar.MarqueeAnimationSpeed = 2000;
            this.nextAptProgressBar.Name = "nextAptProgressBar";
            this.nextAptProgressBar.OuterColor = System.Drawing.Color.Silver;
            this.nextAptProgressBar.OuterMargin = -25;
            this.nextAptProgressBar.OuterWidth = 20;
            this.nextAptProgressBar.ProgressColor = System.Drawing.Color.LightSlateGray;
            this.nextAptProgressBar.ProgressWidth = 23;
            this.nextAptProgressBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.nextAptProgressBar.Size = new System.Drawing.Size(200, 180);
            this.nextAptProgressBar.StartAngle = 270;
            this.nextAptProgressBar.SubscriptColor = System.Drawing.Color.Empty;
            this.nextAptProgressBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.nextAptProgressBar.SubscriptText = ".23";
            this.nextAptProgressBar.SuperscriptColor = System.Drawing.Color.Empty;
            this.nextAptProgressBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.nextAptProgressBar.SuperscriptText = "°C";
            this.nextAptProgressBar.TabIndex = 12;
            this.nextAptProgressBar.TextMargin = new System.Windows.Forms.Padding(25, 0, 25, 0);
            this.nextAptProgressBar.Value = 68;
            // 
            // patientProgressBar
            // 
            this.patientProgressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.patientProgressBar.AnimationSpeed = 500;
            this.patientProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.patientProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.patientProgressBar.InnerColor = System.Drawing.Color.Transparent;
            this.patientProgressBar.InnerMargin = 2;
            this.patientProgressBar.InnerWidth = -1;
            this.patientProgressBar.Location = new System.Drawing.Point(226, 426);
            this.patientProgressBar.MarqueeAnimationSpeed = 2000;
            this.patientProgressBar.Name = "patientProgressBar";
            this.patientProgressBar.OuterColor = System.Drawing.Color.Silver;
            this.patientProgressBar.OuterMargin = -25;
            this.patientProgressBar.OuterWidth = 20;
            this.patientProgressBar.ProgressColor = System.Drawing.Color.DarkViolet;
            this.patientProgressBar.ProgressWidth = 23;
            this.patientProgressBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientProgressBar.Size = new System.Drawing.Size(200, 180);
            this.patientProgressBar.StartAngle = 270;
            this.patientProgressBar.SubscriptColor = System.Drawing.Color.Empty;
            this.patientProgressBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.patientProgressBar.SubscriptText = ".23";
            this.patientProgressBar.SuperscriptColor = System.Drawing.Color.Empty;
            this.patientProgressBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.patientProgressBar.SuperscriptText = "°C";
            this.patientProgressBar.TabIndex = 11;
            this.patientProgressBar.TextMargin = new System.Windows.Forms.Padding(25, 0, 25, 0);
            this.patientProgressBar.Value = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(501, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 34);
            this.label1.TabIndex = 13;
            this.label1.Text = "Dashboard";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(130, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Users";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(604, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Appointments";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(130, 426);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Patients";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(604, 426);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "Next appointment";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(549, 586);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Back";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1163, 631);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nextAptProgressBar);
            this.Controls.Add(this.patientProgressBar);
            this.Controls.Add(this.aptProgressBar);
            this.Controls.Add(this.userProgressBar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private CircularProgressBar.CircularProgressBar userProgressBar;
        private CircularProgressBar.CircularProgressBar aptProgressBar;
        private CircularProgressBar.CircularProgressBar nextAptProgressBar;
        private CircularProgressBar.CircularProgressBar patientProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}