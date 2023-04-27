namespace UI
{
    partial class UserHome
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
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroButton4
            // 
            this.metroButton4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.metroButton4.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.metroButton4.Location = new System.Drawing.Point(679, 90);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(98, 154);
            this.metroButton4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton4.TabIndex = 8;
            this.metroButton4.Text = "Sign out";
            this.metroButton4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.metroButton4.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton4.UseCustomBackColor = true;
            this.metroButton4.UseCustomForeColor = true;
            this.metroButton4.UseSelectable = true;
            this.metroButton4.UseStyleColors = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // UserHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroButton4);
            this.Name = "UserHome";
            this.Text = "User Home";
            this.Load += new System.EventHandler(this.UserHome_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton metroButton4;
    }
}