namespace UI
{
    partial class crearRol
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
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.treeView3 = new System.Windows.Forms.TreeView();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(47, 130);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(371, 388);
            this.treeView2.TabIndex = 14;
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(434, 498);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(112, 20);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "name of the role";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(434, 264);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(171, 27);
            this.metroButton1.TabIndex = 0;
            this.metroButton1.Text = "add";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(47, 99);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(311, 20);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "select the permission you want to add to the role";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(434, 297);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(212, 181);
            this.treeView1.TabIndex = 3;
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(434, 572);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(171, 27);
            this.metroButton2.TabIndex = 3;
            this.metroButton2.Text = "confirm";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(434, 521);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(171, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // treeView3
            // 
            this.treeView3.Location = new System.Drawing.Point(652, 297);
            this.treeView3.Name = "treeView3";
            this.treeView3.Size = new System.Drawing.Size(212, 61);
            this.treeView3.TabIndex = 13;
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(652, 264);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(171, 27);
            this.metroButton3.TabIndex = 1;
            this.metroButton3.Text = "select as father node";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(552, 187);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(170, 24);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(434, 187);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(81, 20);
            this.metroLabel3.TabIndex = 16;
            this.metroLabel3.Text = "Permissions";
            this.metroLabel3.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(434, 141);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(129, 20);
            this.metroLabel5.TabIndex = 19;
            this.metroLabel5.Text = "or Select from here";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(434, 217);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(42, 20);
            this.metroLabel4.TabIndex = 18;
            this.metroLabel4.Text = "Roles";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(552, 217);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(170, 24);
            this.comboBox2.TabIndex = 17;
            // 
            // crearRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 848);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.treeView3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.treeView2);
            this.Name = "crearRol";
            this.Text = "Create Rol";
            this.Load += new System.EventHandler(this.crearRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView2;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.TreeView treeView1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TreeView treeView3;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.ComboBox comboBox2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}