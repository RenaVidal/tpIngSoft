using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class CustomComponent : UserControl
    {
        private PictureBox pictureBox;
        public Button button1;
        public Label labelName;
        public int id;
        public string name;
        public CustomComponent(int idP, string nameP)
        {
            this.BackColor = Color.FromArgb(240, 255, 255, 255);
            this.BorderStyle = BorderStyle.None;


            this.Padding = new Padding(10);

            pictureBox = new PictureBox();
            button1 = new CustomButton();
            labelName = new Label();
            Font centuryGothicFont = new Font("Century Gothic", 14, FontStyle.Bold);
            labelName.Text = nameP;
            labelName.Dock = DockStyle.Bottom;
            labelName.Font = centuryGothicFont;
            labelName.TextAlign = ContentAlignment.MiddleCenter;
            labelName.Margin = new Padding(0,10,0,10);
            pictureBox.Dock = DockStyle.Top;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            button1.Dock = DockStyle.Bottom;

            button1.Click += Button1_Click;

            this.Controls.Add(pictureBox);
           
            this.Controls.Add(labelName);
            this.Controls.Add(button1);
            id = idP;
            name = nameP;
        }

        public Image Picture
        {
            get { return pictureBox.Image; }
            set { pictureBox.Image = value; }
        }

        public event EventHandler Button1Click;

        private void Button1_Click(object sender, EventArgs e)
        {
            Button1Click?.Invoke(this, EventArgs.Empty);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CustomComponent
            // 
            this.Name = "CustomComponent";
            this.Load += new System.EventHandler(this.CustomComponent_Load);
            this.ResumeLayout(false);

        }

        private void CustomComponent_Load(object sender, EventArgs e)
        {

        }
    }
}
