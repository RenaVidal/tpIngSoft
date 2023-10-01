using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class alquileres : UserControl
    {
        private PictureBox pictureBox;
        public Button button1;
        public Label labelName;
        public Label fechaI;
        public Label fechaF;
        public int id;
        public string name;
        public alquileres(int idP, string nameP, DateTime fechaIs, DateTime fechafs)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(240, 255, 255, 255);
            this.BorderStyle = BorderStyle.None;

            this.Padding = new Padding(10);

            pictureBox = new PictureBox();
            button1 = new CustomButton();

            labelName = new Label();
            Font centuryGothicFont = new Font("Century Gothic", 10, FontStyle.Bold);
            labelName.Text = nameP;
            labelName.Dock = DockStyle.Bottom;
            labelName.Font = centuryGothicFont;
            labelName.TextAlign = ContentAlignment.MiddleCenter;
            labelName.Margin = new Padding(0, 10, 0, 10);

            Font centuryGothicFontLight = new Font("Century Gothic", 10, FontStyle.Italic);
            fechaI = new Label();
            fechaI.Text = fechaIs.ToString("yyyy-MM-dd");
            fechaI.Dock = DockStyle.Bottom;
            fechaI.Font = centuryGothicFontLight;
            fechaI.TextAlign = ContentAlignment.MiddleCenter;

            fechaF = new Label();
            fechaF.Text = fechafs.ToString("yyyy-MM-dd");
            fechaF.Dock = DockStyle.Bottom;
            fechaF.Font = centuryGothicFontLight;
            fechaF.TextAlign = ContentAlignment.MiddleCenter;


            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            button1.Dock = DockStyle.Bottom;

            button1.Click += Button1_Click;

            this.Controls.Add(pictureBox);

            this.Controls.Add(labelName);
            this.Controls.Add(fechaF);
            this.Controls.Add(fechaI);
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
            // alquileres
            // 
            this.Name = "alquileres";
            this.Size = new System.Drawing.Size(165, 201);
            this.Load += new System.EventHandler(this.CustomComponent_Load);
            this.ResumeLayout(false);

        }

        private void CustomComponent_Load(object sender, EventArgs e)
        {

        }
    }
}
