using BE;
using BLL;
using MetroFramework;
using Negocio;
using Patrones.Singleton.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace UI
{
    public partial class myResorts : Form
    {
        public myResorts()
        {
            InitializeComponent();
            groupBox1.Hide();
        }

        private void myResorts_Load(object sender, EventArgs e)
        {
            pag = 1;
            getBalnearios(pag);
        }
        SessionManager session = SessionManager.GetInstance;
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
        public void getBalnearios( int pag)
        {
            IList<BEBalneario> images = oBAl.GetAllBalnearios(session.Usuario.id, pag);
            if (images.Count == 0) { button2.Enabled = false; }
            else { button2.Enabled = true; }
            flowLayoutPanel1.Controls.Clear(); 
            foreach (BEBalneario image in images)
            {
                AddGalleryItem(image.Image, image.Id, image.Name);
            }
        }
       

        private void AddGalleryItem(byte[] imagePath, int id, string name)
        {
            CustomComponent customComponent = new CustomComponent(id, name);
            customComponent.Picture = Image.FromStream(new System.IO.MemoryStream(imagePath));
            customComponent.button1.Text = "Remove";
            customComponent.Button1Click += async (sender, e) =>
            {
                groupBox1.Show();
                this.Enabled = false;
                Task oTask = Task.Run(() => oBAl.eliminar_balneario(customComponent.id));
                await oTask;
                groupBox1.Hide();
                this.Enabled = true;
                getBalnearios(pag);
                MetroMessageBox.Show(this, "Users will get credit for their bookings here");
            };
            flowLayoutPanel1.Controls.Add(customComponent);

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = true;
                pag += 1;
                getBalnearios( pag); 
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
                if (pag > 0) getBalnearios( pag); 
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
