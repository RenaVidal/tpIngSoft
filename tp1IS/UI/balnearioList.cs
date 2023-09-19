using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UI
{
    public partial class balnearioList : UserControl
    {
        private PictureBox pictureBox; 
        public int id;
        public string name;
        public Label labelName;
        public balnearioList(int idP, string nameP)
        {
                this.BackColor = Color.FromArgb(240, 255, 255, 255);
                this.BorderStyle = BorderStyle.None;


                this.Padding = new Padding(10);

                pictureBox = new PictureBox();

                pictureBox.Dock = DockStyle.Top;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                
                labelName = new Label();
                Font centuryGothicFont = new Font("Century Gothic", 14, FontStyle.Bold);
                labelName.Text = nameP;
                labelName.Dock = DockStyle.Bottom;
                labelName.Font = centuryGothicFont;
                labelName.TextAlign = ContentAlignment.MiddleCenter;

                id = idP;
                name = nameP;

                this.Controls.Add(pictureBox);
                this.Controls.Add(labelName);

            }

            public Image Picture
            {
                get { return pictureBox.Image; }
                set { pictureBox.Image = value; }
            }

            public event EventHandler Button1Click;

            

            private void InitializeComponent()
            {
                this.SuspendLayout();
                // 
                // CustomComponent
                // 
                this.Name = "Balneario List";
                this.Load += new System.EventHandler(this.CustomComponent_Load);
                this.ResumeLayout(false);

            }
        

        private void CustomComponent_Load(object sender, EventArgs e)
        {

        }
    }
}
