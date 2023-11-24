using BE;
using BLL;
using MetroFramework;
using MetroFramework.Controls;
using Negocio;
using Patrones.Singleton.Core;
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

namespace UI
{
    public partial class mybookings : Form, IdiomaObserver
    {
        public mybookings()
        {
            InitializeComponent();
            groupBox1.Hide();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        BLLBalneario oBAl = new BLLBalneario();
        BLLBitacora oBit = new BLLBitacora();
        IList<BEEalquiler> alquileresPasados;
        IList<BEEalquiler> alquileresFuturos;
        int paginaP;
        int paginaF;
        IList<BEBalneario> balnearios;
        SessionManager session = SessionManager.GetInstance;
        Dictionary<string, Traduccion> traducciones = new Dictionary<string, Traduccion>();
        List<string> palabras = new List<string>();
        private void mybookings_Load(object sender, EventArgs e)
        {
            try { 
               paginaP = 1;
               paginaF = 1;
               alquileresPasados = oBAl.GetAllAlquileres(session.Usuario.id, DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), 1, paginaP);  
               alquileresFuturos = oBAl.GetAllAlquileres(session.Usuario.id, DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), 0, paginaF); 
                button4.Enabled = false;
                button1.Enabled = false;
                Observer.agregarObservador(this);
                balnearios = oBAl.GetAllBalneariosNoP();
                getAlquileresF(session.Usuario.id, 1);
                getAlquileresP(session.Usuario.id, 1);
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
            // throw new NotImplementedException();
            traducir();
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
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void getAlquileresP(int id, int pag)
        {
            try { 
                alquileresPasados = oBAl.GetAllAlquileres(session.Usuario.id, DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), 1, paginaP);  
           
                if (alquileresPasados.Count == 0) { button3.Enabled = false; }
                else { button3.Enabled = true; }
                flowLayoutPanel2.Controls.Clear();

                foreach (BEEalquiler alq in alquileresPasados)
                {
                    BEBalneario bal = balnearios.FirstOrDefault(b => b.Id == alq.idBalneario);
                    AddGalleryItemP(bal.Image,bal.Id, alq.Id, bal.Name, alq.fechaInicio, alq.fechaFin);
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

        public void getAlquileresF(int id, int pag)
        {
            try { 
                alquileresFuturos = oBAl.GetAllAlquileres(session.Usuario.id, DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), 0, paginaF); 
                if (alquileresFuturos.Count == 0) { button2.Enabled = false; }
                else { button2.Enabled = true; }
                flowLayoutPanel1.Controls.Clear();
                foreach (BEEalquiler alq in alquileresFuturos)
                {
                    BEBalneario bal = balnearios.FirstOrDefault(b => b.Id == alq.idBalneario);
                    AddGalleryItemF(bal.Image, alq, bal.Name);
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
       

        private void AddGalleryItemP(byte[] imagePath,int idBal, int id, string name, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                alquileres customComponent = new alquileres(id, name, DateTime.ParseExact(fechaInicio.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), DateTime.ParseExact(fechaFin.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null));
                customComponent.Picture = Image.FromStream(new System.IO.MemoryStream(imagePath));
                customComponent.button1.Text = "Review";
                customComponent.Button1Click += (sender, e) =>
                {
                    review form = new review(idBal);
                    form.FormClosed += Rate_FormClosed;
                    form.Show();
                    this.Enabled = false;
                };
                flowLayoutPanel2.Controls.Add(customComponent);
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
        private void AddGalleryItemF(byte[] imagePath, BEEalquiler alquiler, string name)
        {
            try { 
                alquileres customComponent = new alquileres(alquiler.Id, name, DateTime.ParseExact(alquiler.fechaInicio.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), DateTime.ParseExact(alquiler.fechaFin.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null));
                customComponent.Picture = Image.FromStream(new System.IO.MemoryStream(imagePath));
                customComponent.button1.Text = "Cancel";
                customComponent.Button1Click += async (sender, e) =>
                {
                    if (DateTime.ParseExact(alquiler.fechaInicio.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null) >= (DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null).AddHours(48))){
                        groupBox1.Show();
                        this.Enabled = false;
                        Task oTask = Task.Run(() => oBAl.eliminar_reserva(customComponent.id));
                        await oTask;
                        groupBox1.Hide();
                        this.Enabled = true;
                        getAlquileresF(session.Usuario.id, paginaP); 
                        MetroMessageBox.Show(this, "Reservation canceled, we sent you an email with the credit corresponding the booking value");
                        oBAl.enviarMail(session.Usuario, alquiler);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Reservations can be canceled until 48 hrs prior to their start date");
                    }
                }; 
                flowLayoutPanel1.Controls.Add(customComponent);
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
            try
            {
                button1.Enabled = true;
                paginaF += 1;
                getAlquileresF(session.Usuario.id, paginaF);
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
                paginaF -= 1;
                button1.Enabled = true;
                if (paginaF <= 1) button1.Enabled = false;
                if (paginaF > 0) getAlquileresF(session.Usuario.id, paginaF); 
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                button4.Enabled = true;
                paginaP += 1;
                getAlquileresP(session.Usuario.id, paginaP);
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

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                paginaP -= 1;
                button4.Enabled = true;
                if (paginaP <= 1) button4.Enabled = false;
                if (paginaP > 0) getAlquileresP(session.Usuario.id, paginaP); 
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

        private void Rate_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
        }
    }
}
