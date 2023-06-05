namespace UI
{
    partial class darRol
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
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(143, 701);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(171, 27);
            this.metroButton2.TabIndex = 22;
            this.metroButton2.Text = "confirm";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(23, 107);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(119, 25);
            this.metroLabel1.TabIndex = 21;
            this.metroLabel1.Text = "Select the role";
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(20, 192);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(371, 388);
            this.treeView2.TabIndex = 20;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(25, 70);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(63, 25);
            this.metroLabel3.TabIndex = 25;
            this.metroLabel3.Text = "user id";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 73);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 22);
            this.textBox1.TabIndex = 23;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.Location = new System.Drawing.Point(20, 583);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(157, 25);
            this.metroLabel5.TabIndex = 30;
            this.metroLabel5.Text = "or Select from here";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(20, 651);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(52, 25);
            this.metroLabel4.TabIndex = 29;
            this.metroLabel4.Text = "Roles";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(144, 651);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(170, 24);
            this.comboBox2.TabIndex = 28;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(20, 620);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(100, 25);
            this.metroLabel2.TabIndex = 27;
            this.metroLabel2.Text = "Permissions";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(144, 621);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(170, 24);
            this.comboBox1.TabIndex = 26;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(459, 596);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(171, 27);
            this.metroButton1.TabIndex = 31;
            this.metroButton1.Text = "remove role";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(459, 192);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(371, 388);
            this.treeView1.TabIndex = 32;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.Location = new System.Drawing.Point(20, 164);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(72, 25);
            this.metroLabel6.TabIndex = 33;
            this.metroLabel6.Text = "All roles";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel7.Location = new System.Drawing.Point(459, 164);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(87, 25);
            this.metroLabel7.TabIndex = 34;
            this.metroLabel7.Text = "User roles";
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(280, 73);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(86, 27);
            this.metroButton3.TabIndex = 35;
            this.metroButton3.Text = "search";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // darRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 748);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.treeView2);
            this.Name = "darRol";
            this.Text = "Assing role";
            this.Load += new System.EventHandler(this.darRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.TreeView treeView2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.ComboBox comboBox2;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.TreeView treeView1;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroButton metroButton3;
    }
}