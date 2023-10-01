using BE;
using BLL;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace UI
{
    public partial class buscador : Form
    {
        Panel panel3;
        public buscador(Panel Panel3)
        {
            InitializeComponent();
            SetRoundedPanel(panel1, 20);
            panel3 = Panel3;

        }
        public int BorderRadius { get; set; } = 10;
      
       
        private void SetRoundedPanel(Panel panel, int borderRadius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, borderRadius * 2, borderRadius * 2), 180, 90);
            path.AddLine(borderRadius, 0, panel.Width - borderRadius, 0);
            path.AddArc(new Rectangle(panel.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2), -90, 90);
            path.AddLine(panel.Width, borderRadius, panel.Width, panel.Height - borderRadius);
            path.AddArc(new Rectangle(panel.Width - borderRadius * 2, panel.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2), 0, 90);
            path.AddLine(panel.Width - borderRadius, panel.Height, borderRadius, panel.Height);
            path.AddArc(new Rectangle(0, panel.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2), 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
        }

    

        private void buscador_Load(object sender, EventArgs e)
        {

            pag = 1;
            setBalnearios();
            button1.Enabled = false;
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            IList<BEBalneario> balnearios = oBAl.GetAllBalnearios(00000000000, 00000000000);
            comboBox1.DataSource = balnearios;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.SelectedItem = null;

        }
        private void buscador_Close(object sender, EventArgs e)
        {

            

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
        string nombre = null;
        int permiteninos = 2;
        int permitemascotas = 2;
        private List<string> extras = new List<string>();


        public void setBalnearios()
        {
            string extrasP = null;
            if (extras.Count != 0)  extrasP = string.Join(", ", extras);
            IList<BEBalneario> balnearios = oBAl.GetFIlterBalnearios(pag, nombre, permiteninos, permitemascotas, extrasP);
            if (balnearios.Count == 0) { button2.Enabled = false; }
            else { button2.Enabled = true; }
            flowLayoutPanel1.Controls.Clear();
            foreach (BEBalneario balneario in balnearios)
            {
                AddGalleryItem(balneario);
            }
        }
        private void AddGalleryItem(BEBalneario balneario)
        {
            balnearioList customComponent = new balnearioList(balneario.Id, balneario.Name, balneario.rating);
            customComponent.Picture = Image.FromStream(new System.IO.MemoryStream(balneario.Image));
            customComponent.Click += (sender, e) =>
            {
                this.Hide();
                UserHome.abrirForm(panel3, new Alquilar(balneario));
            };
            flowLayoutPanel1.Controls.Add(customComponent);

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = true;
                pag += 1;
                setBalnearios(); 
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
                if (pag > 0) setBalnearios();
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

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (comboBox1.SelectedIndex == -1) nombre = null;
                else nombre = ((BEBalneario)comboBox1.SelectedItem).Name;
                setBalnearios();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked) permiteninos =  1;
                else permiteninos = 2;
                setBalnearios();
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox2.Checked) permitemascotas = 1;
                else permitemascotas = 2;
                setBalnearios();
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

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox4.Checked) extras.Add("Bar");
                else extras.Remove("Bar");
                setBalnearios();
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

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox3.Checked) extras.Add("Pileta");
                else extras.Remove("Pileta");
                setBalnearios();
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

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox7.Checked) extras.Add("Vestuario");
                else extras.Remove("Vestuario");
                setBalnearios();
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

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox5.Checked) extras.Add("Restaurante");
                else extras.Remove("Restaurante");
                setBalnearios();
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

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox6.Checked) extras.Add("Juegos");
                else extras.Remove("Juegos");
                setBalnearios();
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = true;
                pag += 1;
                setBalnearios();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                pag -= 1;
                button1.Enabled = true;
                if (pag <= 1) button1.Enabled = false;
                if (pag > 0) setBalnearios();
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
