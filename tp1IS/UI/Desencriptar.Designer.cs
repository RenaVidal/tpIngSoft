
namespace UI
{
    partial class Desencriptar
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 2;
            this.label2.Tag = "id";
            this.label2.Text = "id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 3;
            this.label3.Tag = "password";
            this.label3.Text = "password";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 120);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(90, 226);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(119, 20);
            this.textBox2.TabIndex = 5;
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton1.ForeColor = System.Drawing.SystemColors.Info;
            this.metroButton1.Location = new System.Drawing.Point(79, 169);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(2);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(139, 31);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Magenta;
            this.metroButton1.TabIndex = 6;
            this.metroButton1.Tag = "search password";
            this.metroButton1.Text = "search password";
            this.metroButton1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.UseMnemonic = false;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(295, 291);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Desencriptar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 319);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Desencriptar";
            this.Text = "decrypt";
            this.Load += new System.EventHandler(this.Desencriptar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}