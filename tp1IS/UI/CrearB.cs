using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Imaging;
using System.Data.Common;
using Telerik.Charting.Styles;
using Negocio;
using System.IO;
using BE;
using MetroFramework;
using servicios;
using BLL;
using Telerik.WinControls.UI;
using Patrones.Singleton.Core;

namespace UI
{
    public partial class CrearB : Form
    {
        public CrearB()
        {
            InitializeComponent();
        }
        private PictureBox[,] pictureBoxMatrix;
        BLLBitacora oBit = new BLLBitacora();
        validaciones validar = new validaciones();
        string Imagename = null;
        SessionManager session = SessionManager.GetInstance;
        private void InitializePictureBoxMatrix()
        {
            try {  
                int rows = 12;
                int columns = 26;

                pictureBoxMatrix = new PictureBox[rows, columns];
                DataTable dataTable = new DataTable();
                    Bitmap imagen = Properties.Resources.Empty;
                    int newWidth = 10; 
                    int newHeight = 10; 
                    Bitmap resizedImage = new Bitmap(imagen, new Size(newWidth, newHeight));

                for (int i = 0; i < columns; i++)
                {
                    dataTable.Columns.Add(i.ToString(),  typeof(System.Drawing.Image));
                }
                for (int i = 0; i < rows; i++)
                {
                    DataRow row = dataTable.NewRow();
                    for (int j = 0; j < columns; j++)
                    {
                        pictureBoxMatrix[i,j] = new PictureBox
                        {
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Image = resizedImage,
                            Tag = "Empty"
                        };
                        row[j] = pictureBoxMatrix[i,j].Image;
                   
                    }
                    dataTable.Rows.Add(row);

                }
                dataGridView1.DataSource = dataTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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
        public DataTable FillDatagrid(PictureBox[,] pictureBox)
        {
            try
            {
                DataTable dataTable = new DataTable();
                for (int i = 0; i < pictureBox.GetLength(1); i++)
                {
                    dataTable.Columns.Add(i.ToString(), typeof(System.Drawing.Image));
                }
                for (int i = 0; i < pictureBox.GetLength(0); i++)
                {
                    DataRow row = dataTable.NewRow();
                    for (int j = 0; j < pictureBox.GetLength(1); j++)
                    {
                        row[j] = pictureBoxMatrix[i, j].Image;

                    }
                    dataTable.Rows.Add(row);

                }
                return dataTable;
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
            return null;
        }
        private void CrearB_Load(object sender, EventArgs e)
        {
            try { 
            InitializePictureBoxMatrix();
                Bitmap imagen = Properties.Resources.mar;
                pictureBox1.Image = imagen;
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
       

        private void PictureBox_Click(object sender, DataGridViewCellEventArgs e)
        {
            try {  
                if (pictureBoxMatrix[e.RowIndex, e.ColumnIndex] != null && pictureBoxMatrix[e.RowIndex, e.ColumnIndex].Tag == "Full")
                {
                    Bitmap imagen = Properties.Resources.Empty;
                    int newWidth = 10; 
                    int newHeight = 10; 
                    Bitmap resizedImage = new Bitmap(imagen, new Size(newWidth, newHeight));
                    pictureBoxMatrix[e.RowIndex, e.ColumnIndex].Image = resizedImage;
                    pictureBoxMatrix[e.RowIndex, e.ColumnIndex].SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBoxMatrix[e.RowIndex, e.ColumnIndex].Tag = "Empty";
                   
                }
                else
                {
                    Bitmap imagen = Properties.Resources.carpa;
                    pictureBoxMatrix[e.RowIndex, e.ColumnIndex].Image = imagen;
                    pictureBoxMatrix[e.RowIndex, e.ColumnIndex].SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBoxMatrix[e.RowIndex, e.ColumnIndex].Tag = "Full";
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = FillDatagrid(pictureBoxMatrix);
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

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void clean()
        {
            InitializePictureBoxMatrix();
            textBox1.Text = string.Empty;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            pictureBox2.Image = null;
        }
        BLLBalneario obLLBalneario = new BLLBalneario();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int carpas = 0;
                List<BECarpa> Carpas = new List<BECarpa>();
                for (int i = 0; i < pictureBoxMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < pictureBoxMatrix.GetLength(1); j++)
                    {
                        if (pictureBoxMatrix[i, j].Tag == "Full")
                        {
                            Carpas.Add(new BECarpa(i, j));
                            carpas++;
                        }


                    }

                }
                if (carpas <= 0) { MetroMessageBox.Show(this, "You should add a tent"); return; }
                if (textBox1.Text == string.Empty || !validar.usuario(textBox1.Text))
                {
                    MetroMessageBox.Show(this, "You should add a name without special characters");
                    return;
                }
                if (pictureBox2.Image == null)
                {
                    MetroMessageBox.Show(this, "You add an image to show what your resort looks like");
                    return;
                }
                if (numericUpDown1.Value == 0)
                {
                    MetroMessageBox.Show(this, "You set the price for a day in a tent");
                    return;
                }
                bool ninos = false;
                bool mascotas = false;
                string name = textBox1.Text;
                List<string> extras = new List<string>();
                if (checkBox1.Checked)
                {
                    extras.Add("Pileta");
                }
                if (checkBox2.Checked)
                {
                    extras.Add("Restaurante");
                }
                if (checkBox3.Checked)
                {
                    extras.Add("Juegos");
                }
                if (checkBox4.Checked)
                {
                    extras.Add("Bar");
                }
                if (checkBox5.Checked)
                {
                    extras.Add("Vestuario");
                }
                string picture = null;
                string extrasString = string.Join(",", extras);
                if (checkBox6.Checked) { ninos = true; }
                if (checkBox7.Checked) { mascotas = true; }
                if (Imagename != null) { picture = Imagename; }

                byte[] imageData = File.ReadAllBytes(System.Windows.Forms.Application.StartupPath + "/Images/" + Imagename);
                BEBalneario balneario = new BEBalneario(name, extrasString, ninos, mascotas, imageData, Convert.ToInt32( numericUpDown1.Value));
                if (obLLBalneario.incribir_balneario(balneario, Carpas, imageData, session.Usuario.id))
                {
                    MetroMessageBox.Show(this, "Success! You can see your resort in -My Resort- section");
                    clean();

                }
                else
                {
                    MetroMessageBox.Show(this, "Ups! Something went wrong, try again.");
                    clean();
                }
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imageDirectory = Path.Combine(System.Windows.Forms.Application.StartupPath, "Images");
                    if (!Directory.Exists(imageDirectory))
                    {
                        Directory.CreateDirectory(imageDirectory);
                    }

                    Imagename = Guid.NewGuid().ToString() + ".jpg";
                    string fileName = Imagename;
                    string imagePath = Path.Combine(imageDirectory, fileName);

                    File.Copy(openFileDialog.FileName, imagePath);

                    pictureBox2.Image = System.Drawing.Image.FromFile(imagePath);
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
