using BE;
using BLL;
using MetroFramework;
using Negocio;
using Patrones.Singleton.Core;
using servicios.ClasesMultiLenguaje;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Interop;
using System.Windows.Media.Media3D;
using Telerik.Charting;
using Telerik.WinControls.UI;

namespace UI
{
    public partial class Ratings : Form, IdiomaObserver
    {
        int id;
        DateTime inicio;
        DateTime fin;
        IList<BEBalneario> balnearios;
        SessionManager session = SessionManager.GetInstance;
        public Ratings()
        {
            try { 
                InitializeComponent();
                id = 0;
                inicio = DateTime.ParseExact(metroDateTime1.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null);
                fin = DateTime.ParseExact(metroDateTime2.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null);
                balnearios = oBAl.GetAllBalnearios(session.Usuario.id, 00000000000);
                metroComboBox1.DataSource = balnearios;
                metroComboBox1.DisplayMember = "Name";
                metroComboBox1.SelectedIndex = -1;
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
        BLLBalneario oBAl = new BLLBalneario();
        BLLBitacora oBit = new BLLBitacora();
        public void CambiarIdioma(Idioma Idioma)
        {
           
            traducir();
        }

        public void actualizar()
        {
            setGraphs(id,  inicio,  fin);
            fill_general_graphs();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
     
        public void setGraphs(int id, DateTime inicio, DateTime fin)
        {
            try { 
                if(id != 0)
                {
                    DataTable dataTable = oBAl.get_stars(id, inicio, fin);
                    chart2.Series.Clear();

                    if (dataTable.Rows.Count > 0)
                    {
                        chart2.DataSource = dataTable;
                        chart2.Series.Add("estrellas");
                        chart2.Series["estrellas"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
                        chart2.Series["estrellas"].Points.DataBind(dataTable.AsEnumerable(), "estrellas", "cantidad_de_feedbacks", "");

                    }



                    DataTable mensajes = oBAl.get_messages(id, inicio, fin);
                    if (mensajes.Rows.Count > 0)
                    {
                        var rowsToRemove = mensajes.AsEnumerable().Where(row => row.ItemArray.Any(field => field == DBNull.Value || (field is string && string.IsNullOrWhiteSpace(field as string))));

                        foreach (var row in rowsToRemove.ToArray())
                        {
                            mensajes.Rows.Remove(row);
                        }
                    }
                    dataGridView1.DataSource = null;
                    if (mensajes.Rows.Count > 0)
                    {
                       
                        dataGridView1.DataSource = mensajes;
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
        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (metroComboBox1.SelectedIndex == -1) id = 00000000000;
                else
                {
                    id = ((BEBalneario)metroComboBox1.SelectedItem).Id;
                    setGraphs(id, inicio, fin);
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

        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (metroDateTime1.Value == null || DateTime.ParseExact(metroDateTime2.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null) < DateTime.ParseExact(metroDateTime1.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null))
                {
                    MetroMessageBox.Show(this, "incorrect dating format");
                    metroDateTime1.Value = DateTime.Now;
                }
                else
                {
                    inicio = DateTime.ParseExact(metroDateTime1.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null);
                    fin = DateTime.ParseExact(metroDateTime2.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null);
                    actualizar();
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
            try
            {
                if (metroDateTime1.Value == null || DateTime.ParseExact(metroDateTime2.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null) < DateTime.ParseExact(metroDateTime1.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null))
                {
                    MetroMessageBox.Show(this, "incorrect dating format");
                    metroDateTime1.Value = DateTime.Now;
                }
                else
                {
                    inicio = DateTime.ParseExact(metroDateTime1.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null);
                    fin = DateTime.ParseExact(metroDateTime2.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null);
                    actualizar();
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
        public void fill_general_graphs()
        {
            try
            {
                DataTable dataTable;
                DataTable dataTableResultado = new DataTable();
                DataTable dataTablexB = new DataTable();
                DataTable intermedia = new DataTable();
                dataTableResultado.Columns.Add("Fecha", typeof(DateTime));
                dataTableResultado.Columns.Add("Total", typeof(int));
                intermedia.Columns.Add("Fecha", typeof(DateTime));
                intermedia.Columns.Add("Total", typeof(int));
                dataTablexB.Columns.Add("Balneario", typeof(string));
                dataTablexB.Columns.Add("Total", typeof(int));
                dataTablexB.Rows.Clear();
                chart3.Series.Clear();
                foreach (BEBalneario balneario in balnearios)
                {
                    dataTable = oBAl.get_revenue(balneario.Id, inicio, fin);
                    int numeroX = 0;
                    intermedia.Rows.Clear();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        
                        int anio = Convert.ToInt32(row["Anio"]);
                        int mes = Convert.ToInt32(row["Mes"]);

                        DateTime fecha = new DateTime(anio, mes, 1);
                        int numero = Convert.ToInt32(row["TotalMoney"]);
                        DataRow resultadoRowP = null;
                        if(intermedia.Rows.Count > 0)
                        {
                            resultadoRowP = intermedia.AsEnumerable()
                           .FirstOrDefault(r => (DateTime)r["Fecha"] == fecha);
                        }

                        if (resultadoRowP != null)
                        {
                            int parcial = (int)resultadoRowP["Total"] + numero;
                            intermedia.Rows.Remove(resultadoRowP);
                            intermedia.Rows.Add(fecha, parcial);

                        }
                        else
                        {
                            intermedia.Rows.Add(fecha, numero);
                        }

                        DataRow resultadoRow = null;
                        if (dataTableResultado.Rows.Count > 0)
                        {
                            resultadoRow = dataTableResultado.AsEnumerable()
                            .FirstOrDefault(r => (DateTime)r["Fecha"] == fecha);
                        }
                        if (resultadoRow != null)
                        {
                            int parcial = (int)resultadoRow["Total"] + numero;
                            dataTableResultado.Rows.Remove(resultadoRow);
                            dataTableResultado.Rows.Add(fecha, parcial);

                        }
                        else
                        {
                            dataTableResultado.Rows.Add(fecha, numero);
                        }
                        numeroX += numero;
                       
                    }
                    if (intermedia.Rows.Count > 0)
                    {
                        intermedia = intermedia.AsEnumerable()
                        .OrderBy(row => (DateTime)row["Fecha"])
                        .CopyToDataTable();
                    }
                    chart3.Series.Add(balneario.Name);
                    chart3.Series[balneario.Name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                    chart3.Series[balneario.Name].BorderDashStyle = ChartDashStyle.Solid;
                    chart3.Series[balneario.Name].BorderWidth = 3;
                    chart3.Series[balneario.Name].XValueMember = "Fecha";
                    chart3.Series[balneario.Name].YValueMembers = "Total";
                    chart3.Series[balneario.Name].IsVisibleInLegend = true;
                    if (intermedia.Rows.Count > 0)
                    {
                        chart3.Series[balneario.Name].Points.DataBind(intermedia.AsEnumerable(), "Fecha", "Total", "");
                    }
                    DataRow rowV = dataTablexB.NewRow();
                    rowV["Balneario"] = balneario.Name;
                    rowV["Total"] = numeroX;
                    dataTablexB.Rows.Add(rowV);
                }
                chart3.Series.Add("Total");
                chart3.Series["Total"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                chart3.Series["Total"].BorderDashStyle = ChartDashStyle.DashDot;
                chart3.Series["Total"].BorderWidth = 3;
                chart3.Series["Total"].XValueMember = "Fecha";
                chart3.Series["Total"].YValueMembers = "Total";
                if (dataTableResultado.Rows.Count > 0)
                {
                    dataTableResultado = dataTableResultado.AsEnumerable()
                    .OrderBy(row => (DateTime)row["Fecha"])
                    .CopyToDataTable();
                }
                if (dataTableResultado.Rows.Count > 0)
                {
                    DateTime firstDate = (DateTime)dataTableResultado.Rows[0]["Fecha"];
                    DateTime lastDate = (DateTime)dataTableResultado.Rows[dataTableResultado.Rows.Count - 1]["Fecha"];
                    chart3.ChartAreas[0].AxisX.Minimum = firstDate.ToOADate();
                    chart3.ChartAreas[0].AxisX.Maximum = lastDate.ToOADate();
                    chart3.Series["Total"].Points.DataBind(dataTableResultado.AsEnumerable(), "Fecha", "Total", "");
                }

                //Chart 1
                chart1.Series.Clear();
                chart1.Series.Add("bar");
                chart1.Series["bar"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
                if (dataTablexB.Rows.Count > 0)
                {
                    chart1.Series["bar"].Points.DataBind(dataTablexB.AsEnumerable(), "Balneario", "Total", "");
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
        private void Ratings_Load(object sender, EventArgs e)
        {
            fill_general_graphs();
            servicios.Observer.agregarObservador(this);
            traducir();
        }

        Dictionary<string, Traduccion> traducciones = new Dictionary<string, Traduccion>();
        List<string> palabras = new List<string>();
        void RecorrerPanel(Control panel, int v)
        {
            foreach (Control control in panel.Controls)
            {
                if (v == 1)
                {

                    if (control.Tag != null && traducciones.ContainsKey(control.Tag.ToString()))
                    {
                        control.Text = traducciones[control.Tag.ToString()].texto;
                    }
                }
                else
                {
                    if (control.Tag != null && palabras.Contains(control.Tag.ToString()))
                    {
                        string traduccion = palabras.Find(p => p.Equals(control.Tag.ToString()));
                        control.Text = traduccion;
                    }
                }

            }
        }

        void VolverAidiomaOriginal()
        {
            try
            {
                BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
                palabras = Traductor.obtenerIdiomaOriginal();

                RecorrerPanel(this, 2);
                RecorrerPanel(panel1, 2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void traducir()
        {
            try
            {
                Idioma Idioma = null;

                if (SessionManager.TraerUsuario())
                    Idioma = SessionManager.GetInstance.idioma;
                if (Idioma.Nombre == "Ingles")
                {
                    VolverAidiomaOriginal();
                }
                else
                {
                    BLL.BLLTraductor Traductor = new BLL.BLLTraductor();


                    traducciones = Traductor.obtenertraducciones(Idioma);
                    List<string> Lista = new List<string>();
                    Lista = Traductor.obtenerIdiomaOriginal();
                    if (traducciones.Values.Count != Lista.Count)
                    {

                    }
                    else
                    {
                        RecorrerPanel(this, 1);
                        RecorrerPanel(panel1, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }
    }
}
