using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Xml.Linq;

namespace UI
{
    public partial class balnearioList : UserControl
    {
      
        public int id;
        public string name;
        int ratingP;
        private PictureBox pictureBoxF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public balnearioList(int idP, string nameP, int rating)
        {
            InitializeComponent();
            ratingP = rating;
            this.BackColor = System.Drawing.Color.White;

            this.BorderStyle = BorderStyle.None;


            this.Padding = new Padding(10);



            //for (int i = 1; i <= 5; i++)
            //{
            //    PictureBox star = panel1.Controls["pictureBox" + i.ToString()] as PictureBox;
            //    if (i <= rating)
            //    {
            //        star.BackgroundImage = Properties.Resources.star;
            //        star.BackgroundImageLayout = ImageLayout.Zoom;
            //    }
            //    else
            //    {
            //        star.BackgroundImage = Properties.Resources.estar;
            //        star.BackgroundImageLayout = ImageLayout.Zoom;
            //    }
            //}
            pictureBoxF.Dock = DockStyle.Top;
            pictureBoxF.SizeMode = PictureBoxSizeMode.Zoom;

            Font centuryGothicFont = new Font("Century Gothic", 14, FontStyle.Bold);
            label1.Text = nameP;
            // label1.Dock = DockStyle.Bottom;
            label1.Font = centuryGothicFont;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            
            for (int i = 0;i< rating; i++)
            {
                label2.Text += char.ConvertFromUtf32(9733).ToString();
            }
            label2.ForeColor = System.Drawing.Color.FromArgb(0xF1FF37);
            label2.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(label2);
            id = idP;
            name = nameP;
            this.Controls.Add(label1);
            this.Controls.Add(pictureBoxF);


        }

            public Image Picture
            {
                get { return pictureBoxF.Image; }
                set { pictureBoxF.Image = value; }
            }

            public event EventHandler Button1Click;

            

            private void InitializeComponent()
            {
            this.pictureBoxF = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxF)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxF
            // 
            this.pictureBoxF.Location = new System.Drawing.Point(21, 17);
            this.pictureBoxF.Name = "pictureBoxF";
            this.pictureBoxF.Size = new System.Drawing.Size(177, 156);
            this.pictureBoxF.TabIndex = 20;
            this.pictureBoxF.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 47);
            this.label2.TabIndex = 21;
            // 
            // balnearioList
            // 
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBoxF);
            this.Controls.Add(this.label1);
            this.Name = "balnearioList";
            this.Size = new System.Drawing.Size(218, 266);
            this.Load += new System.EventHandler(this.CustomComponent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }
       

        private void CustomComponent_Load(object sender, EventArgs e)
        {

           
        }
    }
}
