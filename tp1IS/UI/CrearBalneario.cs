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
using servicios.ClasesMultiLenguaje;
using Negocio;
using System.Drawing.Imaging;
using Patrones.Singleton.Core;

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
        private void CrearBalneario_Load(object sender, EventArgs e)
        {
        }
        public void CambiarIdioma(Idioma Idioma)
        {

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
                if(this.panel3.Controls.Count>0)
                    this.panel3.Controls.RemoveAt(0);
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
    }
}
