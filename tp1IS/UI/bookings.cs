using BE;
using BLL;
using MetroFramework;
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
using Newtonsoft.Json;
using System.IO;
using Telerik.Charting;

namespace UI
{
    public partial class bookings : Form, IdiomaObserver
    {
        public bookings()
        {
            InitializeComponent();
            groupBox1.Hide();
            button6.Enabled = false;
        }
        BLLBalneario oBAl = new BLLBalneario();
        BLLBitacora oBit = new BLLBitacora();
        IList<BEEalquiler> alquileresPasados;
        IList<BEEalquiler> alquileresFuturos;
        int paginaP;
        int paginaF;
        IList<BEBalneario> balnearios;
        SessionManager session = SessionManager.GetInstance;
        JsonSerializer serializer = new JsonSerializer();
        public void getAlquileresP(int id, int pag)
        {
            try
            {
                alquileresPasados = oBAl.GetAllAlquileresD(Convert.ToInt32(textBox1.Text), DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), 1, paginaP, session.Usuario.id); 

                if (alquileresPasados.Count == 0) { button3.Enabled = false; }
                else { button3.Enabled = true; }
                flowLayoutPanel2.Controls.Clear();

                foreach (BEEalquiler alq in alquileresPasados)
                {
                    BEBalneario bal = balnearios.FirstOrDefault(b => b.Id == alq.idBalneario);
                    AddGalleryItemP(bal.Image, bal.Id, alq.Id, bal.Name, alq.fechaInicio, alq.fechaFin);
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
            try
            {
                alquileresFuturos = oBAl.GetAllAlquileresD(Convert.ToInt32(textBox1.Text), DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), 0, paginaF, session.Usuario.id);
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

        validaciones validar = new validaciones();
        BLLUsuario oLog = new BLLUsuario();
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text == string.Empty || !validar.id(textBox1.Text))
                {
                    MetroMessageBox.Show(this, "The id has an incorrect format");
                    return;
                }
                if (!oLog.usuario_existente(Convert.ToInt32(textBox1.Text)))
                {
                    MessageBox.Show("There is not user with that id", "ERROR");
                    return;
                }
                paginaP = 1;
                paginaF = 1;
                alquileresPasados = oBAl.GetAllAlquileresD(Convert.ToInt32(textBox1.Text), DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), 1, paginaP, session.Usuario.id);  
                alquileresFuturos = oBAl.GetAllAlquileresD(Convert.ToInt32(textBox1.Text), DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), 0, paginaF, session.Usuario.id); 
                button4.Enabled = false;
                button1.Enabled = false;
                if (alquileresFuturos.Count > 0) button6.Enabled = true;
                else button6.Enabled = false;
                user = oLog.buscar_usuarioxid(Convert.ToInt32(textBox1.Text));
                balnearios = oBAl.GetAllBalneariosNoP();
                getAlquileresF(Convert.ToInt32(textBox1.Text), 1);
                getAlquileresP(Convert.ToInt32(textBox1.Text), 1);
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

        private void AddGalleryItemP(byte[] imagePath, int idBal, int id, string name, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                alquileres customComponent = new alquileres(id, name, DateTime.ParseExact(fechaInicio.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), DateTime.ParseExact(fechaFin.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null));
                customComponent.Picture = Image.FromStream(new System.IO.MemoryStream(imagePath));
                customComponent.button1.Hide();
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
        BEUsuario user;

        private void AddGalleryItemF(byte[] imagePath, BEEalquiler alquiler, string name)
        {
            try
            {
                alquileres customComponent = new alquileres(alquiler.Id, name, DateTime.ParseExact(alquiler.fechaInicio.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), DateTime.ParseExact(alquiler.fechaFin.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null));
                customComponent.Picture = Image.FromStream(new System.IO.MemoryStream(imagePath));
                customComponent.button1.Text = "Cancel";
                customComponent.Button1Click += async (sender, e) =>
                {
                    
                        groupBox1.Show();
                        this.Enabled = false;
                        Task oTask = Task.Run(() => oBAl.enviarMail(user, alquiler));
                        await oTask;
                        groupBox1.Hide();
                        this.Enabled = true;
                        MetroMessageBox.Show(this, "Reservation canceled, we sent you an email with the credit corresponding the booking value");
                        oBAl.eliminar_reserva(customComponent.id);
                        getAlquileresF(session.Usuario.id, paginaP);

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
                getAlquileresF(Convert.ToInt32(textBox1.Text), paginaF); 
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
                if (paginaF > 0) getAlquileresF(Convert.ToInt32(textBox1.Text), paginaF); 
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
                getAlquileresP(Convert.ToInt32(textBox1.Text), paginaP); 
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
                if (paginaP > 0) getAlquileresP(Convert.ToInt32(textBox1.Text), paginaP); 
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
        private void bookings_Load(object sender, EventArgs e)
        {
            Observer.agregarObservador(this);
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

        void RecorrerPanel(System.Windows.Forms.Control panel, int v)
        {
            try { 
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
            catch (Exception ex)
            {
                throw ex;
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
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        string archivo = "alquileres.json";
        private void button6_Click(object sender, EventArgs e)
        {
            try { 

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos JSON|*.json";
                saveFileDialog.Title = "Guardar archivo JSON";
                saveFileDialog.FileName = "reservasFuturas.json";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivo = saveFileDialog.FileName;

                    using (FileStream fs = new FileStream(rutaArchivo, FileMode.Append, FileAccess.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(fs))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Serialize(writer, alquileresFuturos);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
