using BE;
using BLL;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class myResorts : Form
    {
        public myResorts()
        {
            InitializeComponent();
        }

        private void myResorts_Load(object sender, EventArgs e)
        {
            pag = 1;
            getBalnearios(0,pag);
        }
        public class GalleryItem
        {
            public Image Image { get; set; }
            public System.Windows.Forms.Button Button { get; set; }
        }
        List<GalleryItem> galleryItems = new List<GalleryItem>();
        List<BEBalneario> images = new List<BEBalneario>();
        BLLBalneario oBAl = new BLLBalneario();
        BLLBitacora oBit = new BLLBitacora();
        int pag;
        public void getBalnearios(int id, int pag)
        {
            IList<BEBalneario> images = oBAl.GetAllBalnearios(42933252, pag);
            if (images.Count == 0) { button2.Enabled = false; }
            else { button2.Enabled = true; }
            flowLayoutPanel1.Controls.Remove(flowLayoutPanel1); // --------------------- acaaaa
            foreach (BEBalneario image in images)
            {
                AddGalleryItem(image.Image);
            }
        }
        private void AddGalleryItem(string imagePath)
        {
            string imageDirectory = Path.Combine(System.Windows.Forms.Application.StartupPath, "Images");
            string imagePathComplete = Path.Combine(imageDirectory, imagePath);
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile(imagePathComplete);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Width = 150;
            pictureBox.Height = 150;

            System.Windows.Forms.Button button = new System.Windows.Forms.Button();
            button.Text = "Eliminar";
            button.Click += (sender, e) =>
            {
                // Maneja el evento de clic para eliminar el elemento de galería.
                // Puedes implementar la lógica de eliminación aquí.
                flowLayoutPanel1.Controls.Remove(pictureBox);
                flowLayoutPanel1.Controls.Remove(button);
            };

            flowLayoutPanel1.Controls.Add(pictureBox);
            flowLayoutPanel1.Controls.Add(button);

            GalleryItem galleryItem = new GalleryItem
            {
                Image = pictureBox.Image,
                Button = button
            };

            galleryItems.Add(galleryItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = true;
                pag += 1;
                getBalnearios(0, pag); //-------------------------------------------------------- aca id
            }
            catch (NullReferenceException ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                pag -= 1;
                button1.Enabled = true;
                if (pag <= 1) button1.Enabled = false;
                if (pag > 0) getBalnearios(0, pag); //-------------------------------------------------------- aca id
            }
            catch (NullReferenceException ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
