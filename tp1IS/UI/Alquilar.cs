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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Telerik.WinControls.Themes.ControlDefault;

namespace UI
{
    public partial class Alquilar : Form
    {
        BEBalneario balnearioC;
        SessionManager session = SessionManager.GetInstance;
        public Alquilar(BEBalneario balneario)
        {
            InitializeComponent();
            label7.Text = balneario.Name;
            label2.Text = balneario.Extras;
            string[] extras = balneario.Extras.Split(',');
            if(balneario.permiteMascotas) checkBox2.Checked = true;
            if(balneario.permiteNinos) checkBox1.Checked = true;
            balnearioC = balneario;
            label8.Text = balneario.price.ToString();
            metroDateTime1.Format = DateTimePickerFormat.Custom;
            metroDateTime2.Format = DateTimePickerFormat.Custom;
            metroDateTime1.CustomFormat = "yyyy/MM/dd";
            metroDateTime2.CustomFormat = "yyyy/MM/dd";
        }
        int total = 0;
        BLLBalneario oBal = new BLLBalneario();
        IList<BECarpa> carpaList;
        List<BECarpa> alquiladas = new List<BECarpa>();
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
            carpaList = oBal.GetAllCarpas(balnearioC.Id, DateTime.ParseExact(metroDateTime1.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), DateTime.ParseExact(metroDateTime2.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null));
            InitializePictureBoxMatrix();

        }
        private PictureBox[,] pictureBoxMatrix;
        BLLBitacora oBit = new BLLBitacora();
        private void ColocarImagenesEnMatriz(PictureBox[,] pictureBoxMatrix, IList<BECarpa> carpaList)
        {
            try
            {
                foreach (BECarpa carpa in carpaList)
                {
                        int fila = carpa.fila;
                        int columna = carpa.columna;

                        if (fila >= 0 && fila < pictureBoxMatrix.GetLength(0) &&
                            columna >= 0 && columna < pictureBoxMatrix.GetLength(1))
                        {
                            if(carpa.estado == false)
                            {
                                Bitmap imagen = Properties.Resources.carpaOc;

                                pictureBoxMatrix[fila, columna] = new PictureBox
                                {
                                    SizeMode = PictureBoxSizeMode.Zoom,
                                    Image = imagen,
                                    Tag = "Ocupado"
                                };
                            }
                            else
                            {
                                Bitmap imagen = Properties.Resources.carpaAz;
                                pictureBoxMatrix[fila, columna] = new PictureBox
                                {
                                    SizeMode = PictureBoxSizeMode.Zoom,
                                    Image = imagen,
                                    Tag = "Libre"
                                };
                            }
                           
                        }
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
                ColocarImagenesEnMatriz(pictureBoxMatrix, carpaList);

                for (int i = 0; i < columns; i++)
                {
                    dataTable.Columns.Add(i.ToString(), typeof(System.Drawing.Image));
                }
                for (int i = 0; i < rows; i++)
                {
                    DataRow row = dataTable.NewRow();
                    for (int j = 0; j < columns; j++)
                    {
                        if(pictureBoxMatrix[i, j] == null)
                        {
                            pictureBoxMatrix[i, j] = new PictureBox
                            {
                                SizeMode = PictureBoxSizeMode.Zoom,
                                Image = resizedImage,
                                Tag = "Empty"
                            };
                        }
                        
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
       
        private void PictureBox_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (pictureBoxMatrix[e.RowIndex, e.ColumnIndex] != null && pictureBoxMatrix[e.RowIndex, e.ColumnIndex].Tag == "Libre")
                {
                    Bitmap imagen = Properties.Resources.carpadis;
                    pictureBoxMatrix[e.RowIndex, e.ColumnIndex].Image = imagen;
                    pictureBoxMatrix[e.RowIndex, e.ColumnIndex].SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBoxMatrix[e.RowIndex, e.ColumnIndex].Tag = "Seleccionada";
                    BECarpa carpaI = carpaList.FirstOrDefault(carpa => carpa.fila == e.RowIndex && carpa.columna == e.ColumnIndex);
                    alquiladas.Add(carpaI);

                }
                else if (pictureBoxMatrix[e.RowIndex, e.ColumnIndex] != null && pictureBoxMatrix[e.RowIndex, e.ColumnIndex].Tag == "Seleccionada")
                {
                    Bitmap imagen = Properties.Resources.carpaAz;
                    pictureBoxMatrix[e.RowIndex, e.ColumnIndex].Image = imagen;
                    pictureBoxMatrix[e.RowIndex, e.ColumnIndex].SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBoxMatrix[e.RowIndex, e.ColumnIndex].Tag = "Libre";
                    BECarpa carpaI = carpaList.FirstOrDefault(carpa => carpa.fila == e.RowIndex && carpa.columna == e.ColumnIndex);
                    alquiladas.Remove(carpaI);
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

        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {
            try { 
                if (metroDateTime1.Value == null || DateTime.ParseExact(metroDateTime1.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null) < DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null) || DateTime.ParseExact(metroDateTime2.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null) < DateTime.ParseExact(metroDateTime1.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null))
                {
                    MetroMessageBox.Show(this, "you should not make a booking for a date in the past");
                    metroDateTime1.Value = DateTime.Now;
                }
                else
                {
                    carpaList = oBal.GetAllCarpas(balnearioC.Id, DateTime.ParseExact(metroDateTime1.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), DateTime.ParseExact(metroDateTime2.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null));
                    InitializePictureBoxMatrix();
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

        private void metroDateTime2_ValueChanged(object sender, EventArgs e)
        {
            try { 
                if (metroDateTime2.Value == null || DateTime.ParseExact(metroDateTime2.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null) < DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null) || DateTime.ParseExact(metroDateTime2.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null) < DateTime.ParseExact(metroDateTime1.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null))
                {
                    MetroMessageBox.Show(this, "you should not make a booking for a date in the past");
                    metroDateTime2.Value = DateTime.Now;
                }
                else
                {
                    carpaList = oBal.GetAllCarpas(balnearioC.Id, DateTime.ParseExact(metroDateTime1.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), DateTime.ParseExact(metroDateTime2.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null));
                    InitializePictureBoxMatrix();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (metroDateTime1.Value == null || DateTime.ParseExact(metroDateTime1.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null) < DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null) || DateTime.ParseExact(metroDateTime2.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null) < DateTime.ParseExact(metroDateTime1.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null))
                {
                    MetroMessageBox.Show(this, "you should not make a booking for a date in the past");
                    return;
                }
                if (metroDateTime2.Value == null || DateTime.ParseExact(metroDateTime2.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null) < DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null) || DateTime.ParseExact(metroDateTime2.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null) < DateTime.ParseExact(metroDateTime1.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null))
                {
                    MetroMessageBox.Show(this, "you should not make a booking for a date in the past");
                    return;
                }
                if(balnearioC == null)
                {
                    MetroMessageBox.Show(this, "Ups! something went wrong");
                    return;
                }
                if(alquiladas.Count == 0)
                {
                    MetroMessageBox.Show(this, "you should select at least one tent");
                    return;
                }
                DateTime fechaInicio = DateTime.ParseExact(metroDateTime1.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null);
                DateTime fechaFin = DateTime.ParseExact(metroDateTime2.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null);
                TimeSpan diferencia = fechaFin - fechaInicio;
                int cantidadDias = diferencia.Days + 1;

                total = (balnearioC.price * (cantidadDias)) * alquiladas.Count;
                DateTime datetime;
                oBal.incribir_alquiler(balnearioC,  alquiladas, DateTime.ParseExact(metroDateTime1.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null) , DateTime.ParseExact(metroDateTime2.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), session.Usuario.id, total);
            
                Pay payment = new Pay(total);
                payment.FormClosed += Pay_FormClosed; 
                this.Enabled = false; 
                payment.Show();
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

        private void Pay_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { 
                this.Enabled = true;
                this.Close();
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
