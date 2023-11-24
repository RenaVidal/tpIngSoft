using servicios;
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
using Negocio;
using System.Drawing.Imaging;
using Patrones.Singleton.Core;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace UI
{
    public partial class CrearBalneario : Form, IdiomaObserver
    {
        public CrearBalneario()
        {
            InitializeComponent();
        }
        private Form formularioAbierto = null;
        BLLBitacora oBit = new BLLBitacora();
        bool isExpanded = false;
        BLL.BLLTraductor Otraductor = new BLL.BLLTraductor();
        SessionManager session = SessionManager.GetInstance;
        private void AbrirFormulario(Form formulario)
        {
            try
            {
                if (formularioAbierto != null)
                {

                    formularioAbierto.Close();
                }

                formularioAbierto = formulario;
                formularioAbierto.Dock = DockStyle.Fill;
                formularioAbierto.Show();
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
        public void CambiarIdioma(Idioma Idioma)
        {

            ListarIdiomas();
            traducir();


        }

        private void ListarIdiomas()
        {
            try
            {
                comboBox1.Items.Clear();
                BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
                var ListaIdiomas = Traductor.ObtenerIdiomas();

                foreach (Idioma idioma in ListaIdiomas)
                {
                    var traducciones = Traductor.obtenertraducciones(idioma);
                    List<string> Lista = new List<string>();
                    Lista = Traductor.obtenerIdiomaOriginal();
                    if (traducciones.Values.Count == Lista.Count)
                    {
                        comboBox1.Items.Add(idioma.Nombre);
                    }
                    else
                    {
                        if (idioma.Default == true)
                        {
                            comboBox1.Items.Add(idioma.Nombre);
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
        void VolverAidiomaOriginal()
        {
            try
            {
                BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
                palabras = Traductor.obtenerIdiomaOriginal();

                RecorrerPanel(this, 2);
                RecorrerPanel(panel2, 2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        void RecorrerPanel(System.Windows.Forms.Control panel, int v)
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
        private void CrearBalneario_Load(object sender, EventArgs e)
        {

            try
            {
                groupBox1.Visible = false;
                servicios.Observer.agregarObservador(this);
                ListarIdiomas();
                SessionManager.GetInstance.idioma = Otraductor.ObtenerIdiomaBase();
                traducir();
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

        Dictionary<string, Traduccion> traducciones = new Dictionary<string, Traduccion>();
        List<string> palabras = new List<string>();
        void RecorrerPanel(Panel panel, int v)
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
                        RecorrerPanel(panel2, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
         
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();

                Observer.eliminarObservador(this);
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
        private void abrirForm(object formHijo)
        {
            try
            {
                if (this.panel3.Controls.Count > 0)
                {
                    servicios.Observer.eliminarObservador((IdiomaObserver)panel3.Controls[0].Tag);
                    this.panel3.Controls.RemoveAt(0);
                }
                    
                Form fh = formHijo as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.panel3.Controls.Add(fh);
                this.panel3.Tag = formHijo;
                fh.Show();
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
        private void button2_Click(object sender, EventArgs e)
        {
            abrirForm(new CrearB());
        }

        private void panel3_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            abrirForm(new Ratings());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            abrirForm(new bookings());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            abrirForm(new myResorts());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
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

        private void button7_Click(object sender, EventArgs e)
        {
            try { 
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
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
        BLL.BLLDv ODV = new BLL.BLLDv();
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                ODV.actualizarDV(servicios.GenerarVD.generarDigitoVS(ODV.BuscarDVUsuarios()));
                oBit.guardar_logOut();
                SessionManager.Logout();
                var formularios = Application.OpenForms;

                var copiaFormularios = new List<Form>(formularios.OfType<Form>());

                foreach (Form formulario in copiaFormularios)
                {
                    if (formulario.Text != "Welcome!")
                    {
                        formulario.Close();

                    }
                }
                SignIn form = new SignIn();
                form.Show();

                servicios.Observer.eliminarObservador(this);
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
                string idiomaSelec = comboBox1.SelectedItem.ToString();
                BLL.BLLTraductor traductor = new BLL.BLLTraductor();
                Idioma Oidioma = new Idioma();
                Oidioma = traductor.TraerIdioma(idiomaSelec);

                servicios.Observer.cambiarIdioma(Oidioma);

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (groupBox1.Visible)
                {
                    groupBox1.Visible = false;
                }
                else
                {
                    string contenidoTexto = Properties.Resources.manualUsuario;
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Archivos PDF|*.pdf";
                    saveFileDialog.Title = "Descargar Manual en PDF";
                    saveFileDialog.FileName = "ManualUsuarioInnTent.pdf";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (var writer = new PdfWriter(saveFileDialog.FileName))
                        {
                            using (var pdf = new PdfDocument(writer))
                            {
                                var document = new Document(pdf);
                                document.Add(new Paragraph(contenidoTexto));
                            }
                        }
                    }

                    groupBox1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
