namespace UI
{
    partial class SignIn
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            metroLabel1 = new MetroFramework.Controls.MetroLabel();
            metroLabel2 = new MetroFramework.Controls.MetroLabel();
            metroButton1 = new MetroFramework.Controls.MetroButton();
            metroButton2 = new MetroFramework.Controls.MetroButton();
            groupBox1 = new GroupBox();
            metroDateTime1 = new MetroFramework.Controls.MetroDateTime();
            metroLabel3 = new MetroFramework.Controls.MetroLabel();
            textBox4 = new TextBox();
            metroLabel4 = new MetroFramework.Controls.MetroLabel();
            metroRadioButton1 = new MetroFramework.Controls.MetroRadioButton();
            metroRadioButton2 = new MetroFramework.Controls.MetroRadioButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(135, 93);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(219, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(135, 140);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(219, 27);
            textBox2.TabIndex = 1;
            // 
            // metroLabel1
            // 
            metroLabel1.AutoSize = true;
            metroLabel1.Location = new Point(45, 93);
            metroLabel1.Name = "metroLabel1";
            metroLabel1.Size = new Size(73, 20);
            metroLabel1.TabIndex = 2;
            metroLabel1.Text = "Username";
            // 
            // metroLabel2
            // 
            metroLabel2.AutoSize = true;
            metroLabel2.Location = new Point(45, 140);
            metroLabel2.Name = "metroLabel2";
            metroLabel2.Size = new Size(66, 20);
            metroLabel2.TabIndex = 3;
            metroLabel2.Text = "Password";
            // 
            // metroButton1
            // 
            metroButton1.Location = new Point(234, 189);
            metroButton1.Name = "metroButton1";
            metroButton1.Size = new Size(120, 32);
            metroButton1.TabIndex = 4;
            metroButton1.Text = "Sign In";
            metroButton1.UseSelectable = true;
            // 
            // metroButton2
            // 
            metroButton2.Location = new Point(108, 189);
            metroButton2.Name = "metroButton2";
            metroButton2.Size = new Size(120, 32);
            metroButton2.TabIndex = 5;
            metroButton2.Text = "Sign Up";
            metroButton2.UseSelectable = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(metroRadioButton2);
            groupBox1.Controls.Add(metroRadioButton1);
            groupBox1.Controls.Add(metroDateTime1);
            groupBox1.Controls.Add(metroLabel3);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(metroLabel4);
            groupBox1.Location = new Point(37, 249);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(317, 166);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sign Up Data";
            // 
            // metroDateTime1
            // 
            metroDateTime1.Location = new Point(147, 81);
            metroDateTime1.MinimumSize = new Size(0, 30);
            metroDateTime1.Name = "metroDateTime1";
            metroDateTime1.Size = new Size(162, 30);
            metroDateTime1.TabIndex = 7;
            // 
            // metroLabel3
            // 
            metroLabel3.AutoSize = true;
            metroLabel3.Location = new Point(10, 91);
            metroLabel3.Name = "metroLabel3";
            metroLabel3.Size = new Size(71, 20);
            metroLabel3.TabIndex = 10;
            metroLabel3.Text = "Birth Date";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(147, 44);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(162, 27);
            textBox4.TabIndex = 7;
            // 
            // metroLabel4
            // 
            metroLabel4.AutoSize = true;
            metroLabel4.Location = new Point(10, 44);
            metroLabel4.Name = "metroLabel4";
            metroLabel4.Size = new Size(20, 20);
            metroLabel4.TabIndex = 9;
            metroLabel4.Text = "id";
            // 
            // metroRadioButton1
            // 
            metroRadioButton1.AutoSize = true;
            metroRadioButton1.Location = new Point(147, 131);
            metroRadioButton1.Name = "metroRadioButton1";
            metroRadioButton1.Size = new Size(49, 17);
            metroRadioButton1.TabIndex = 7;
            metroRadioButton1.Text = "user";
            metroRadioButton1.UseSelectable = true;
            // 
            // metroRadioButton2
            // 
            metroRadioButton2.AutoSize = true;
            metroRadioButton2.Location = new Point(215, 131);
            metroRadioButton2.Name = "metroRadioButton2";
            metroRadioButton2.Size = new Size(60, 17);
            metroRadioButton2.TabIndex = 11;
            metroRadioButton2.Text = "admin";
            metroRadioButton2.UseSelectable = true;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(metroButton2);
            Controls.Add(metroButton1);
            Controls.Add(metroLabel2);
            Controls.Add(metroLabel1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "SignIn";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private GroupBox groupBox1;
        private MetroFramework.Controls.MetroDateTime metroDateTime1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private TextBox textBox4;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton2;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton1;
    }
}