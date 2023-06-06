namespace UI
{
    partial class AdminHome
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
            this.components = new System.ComponentModel.Container();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.metroButton7 = new MetroFramework.Controls.MetroButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton1.ForeColor = System.Drawing.SystemColors.Info;
            this.metroButton1.Location = new System.Drawing.Point(5, 51);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(2);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(132, 147);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Magenta;
            this.metroButton1.TabIndex = 3;
            this.metroButton1.Tag = "create admin";
            this.metroButton1.Text = "Create Admin";
            this.metroButton1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.UseMnemonic = false;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.metroButton2.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.metroButton2.Location = new System.Drawing.Point(141, 51);
            this.metroButton2.Margin = new System.Windows.Forms.Padding(2);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(131, 147);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton2.TabIndex = 4;
            this.metroButton2.Tag = "delete user";
            this.metroButton2.Text = "Delete User";
            this.metroButton2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton2.UseCustomBackColor = true;
            this.metroButton2.UseCustomForeColor = true;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.UseStyleColors = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 44);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(142, 20);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.metroButton3);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(17, 214);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(255, 132);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "delete user";
            this.groupBox1.Text = "Delete user";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(14, 15);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(294, 19);
            this.metroLabel2.TabIndex = 8;
            this.metroLabel2.Tag = "please insert the id of the user you wish to delete";
            this.metroLabel2.Text = "Please insert the id of the user you wish to delete";
            this.metroLabel2.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(150, 78);
            this.metroButton3.Margin = new System.Windows.Forms.Padding(2);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(88, 28);
            this.metroButton3.TabIndex = 7;
            this.metroButton3.Tag = "delete user";
            this.metroButton3.Text = "delete user";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(69, 46);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(20, 19);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Tag = "id";
            this.metroLabel1.Text = "id";
            // 
            // metroButton4
            // 
            this.metroButton4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.metroButton4.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.metroButton4.Location = new System.Drawing.Point(682, 51);
            this.metroButton4.Margin = new System.Windows.Forms.Padding(2);
            this.metroButton4.Location = new System.Drawing.Point(976, 63);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(76, 147);
            this.metroButton4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton4.TabIndex = 7;
            this.metroButton4.Tag = "sign out";
            this.metroButton4.Text = "Sign out";
            this.metroButton4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.metroButton4.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton4.UseCustomBackColor = true;
            this.metroButton4.UseCustomForeColor = true;
            this.metroButton4.UseSelectable = true;
            this.metroButton4.UseStyleColors = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // metroButton5
            // 
            this.metroButton5.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.metroButton5.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.metroButton5.Location = new System.Drawing.Point(282, 51);
            this.metroButton5.Margin = new System.Windows.Forms.Padding(2);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(140, 147);
            this.metroButton5.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton5.TabIndex = 8;
            this.metroButton5.Tag = "reset password";
            this.metroButton5.Text = "Reset Password";
            this.metroButton5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.metroButton5.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton5.UseCustomBackColor = true;
            this.metroButton5.UseCustomForeColor = true;
            this.metroButton5.UseSelectable = true;
            this.metroButton5.UseStyleColors = true;
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(637, 342);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // metroButton6
            // 
            this.metroButton6.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.metroButton6.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.metroButton6.Location = new System.Drawing.Point(436, 51);
            this.metroButton6.Margin = new System.Windows.Forms.Padding(2);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Size = new System.Drawing.Size(124, 147);
            this.metroButton6.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton6.TabIndex = 10;
            this.metroButton6.Tag = "new lenguaje";
            this.metroButton6.Text = "New  Lenguaje";
            this.metroButton6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.metroButton6.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton6.UseCustomBackColor = true;
            this.metroButton6.UseCustomForeColor = true;
            this.metroButton6.UseSelectable = true;
            this.metroButton6.UseStyleColors = true;
            this.metroButton6.Click += new System.EventHandler(this.metroButton6_Click);
            // 
            // metroButton6
            // 
            this.metroButton6.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.metroButton6.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.metroButton6.Location = new System.Drawing.Point(436, 63);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Size = new System.Drawing.Size(138, 181);
            this.metroButton6.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton6.TabIndex = 9;
            this.metroButton6.Text = "Create Rol";
            this.metroButton6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.metroButton6.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton6.UseCustomBackColor = true;
            this.metroButton6.UseCustomForeColor = true;
            this.metroButton6.UseSelectable = true;
            this.metroButton6.UseStyleColors = true;
            this.metroButton6.Click += new System.EventHandler(this.metroButton6_Click);
            // 
            // metroButton7
            // 
            this.metroButton7.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.metroButton7.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.metroButton7.Location = new System.Drawing.Point(580, 63);
            this.metroButton7.Name = "metroButton7";
            this.metroButton7.Size = new System.Drawing.Size(191, 181);
            this.metroButton7.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton7.TabIndex = 10;
            this.metroButton7.Text = "Asign or Delete Role";
            this.metroButton7.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.metroButton7.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton7.UseCustomBackColor = true;
            this.metroButton7.UseCustomForeColor = true;
            this.metroButton7.UseSelectable = true;
            this.metroButton7.UseStyleColors = true;
            this.metroButton7.Click += new System.EventHandler(this.metroButton7_Click);
            // 
            // AdminHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 366);
            this.Controls.Add(this.metroButton6);
            this.Controls.Add(this.comboBox1);
            this.ClientSize = new System.Drawing.Size(1169, 450);
            this.Controls.Add(this.metroButton7);
            this.Controls.Add(this.metroButton6);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdminHome";
            this.Padding = new System.Windows.Forms.Padding(15, 60, 15, 16);
            this.Tag = "admin home";
            this.Text = "New Lenguaje";
            this.Load += new System.EventHandler(this.AdminHome_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButton4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private MetroFramework.Controls.MetroButton metroButton5;
        private System.Windows.Forms.ComboBox comboBox1;
        private MetroFramework.Controls.MetroButton metroButton6;
        private MetroFramework.Controls.MetroButton metroButton7;
    }
}