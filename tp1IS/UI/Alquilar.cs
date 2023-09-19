using BE;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Alquilar : Form
    {
        public Alquilar(BEBalneario balneario)
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Alquilar_Load(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
        }
        private PictureBox[,] pictureBoxMatrix;
        BLLBitacora oBit = new BLLBitacora();
        private void InitializePictureBoxMatrix()
        {
            try
            {
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
                    dataTable.Columns.Add(i.ToString(), typeof(System.Drawing.Image));
                }
                for (int i = 0; i < rows; i++)
                {
                    DataRow row = dataTable.NewRow();
                    for (int j = 0; j < columns; j++)
                    {
                        pictureBoxMatrix[i, j] = new PictureBox
                        {
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Image = resizedImage,
                            Tag = "Empty"
                        };
                        row[j] = pictureBoxMatrix[i, j].Image;

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
    }
}
