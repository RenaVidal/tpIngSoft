using BE;
using BLL;
using MetroFramework;
using Negocio;
using Patrones.Singleton.Core;
using servicios;
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
    public partial class bookings : Form
    {
        public bookings()
        {
            InitializeComponent();
        }
        BLLBalneario oBAl = new BLLBalneario();
        BLLBitacora oBit = new BLLBitacora();
        IList<BEEalquiler> alquileresPasados;
        IList<BEEalquiler> alquileresFuturos;
        int paginaP;
        int paginaF;
        IList<BEBalneario> balnearios;
        SessionManager session = SessionManager.GetInstance;
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
                    AddGalleryItemF(bal.Image, alq.Id, bal.Name, alq.fechaInicio, alq.fechaFin, alq.precio);
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
                customComponent.button1.Text = "Review";
                customComponent.Button1Click += (sender, e) =>
                {
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
        private void AddGalleryItemF(byte[] imagePath, int id, string name, DateTime fechaInicio, DateTime fechaFin, int precio)
        {
            try
            {
                alquileres customComponent = new alquileres(id, name, DateTime.ParseExact(fechaInicio.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), DateTime.ParseExact(fechaFin.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null));
                customComponent.Picture = Image.FromStream(new System.IO.MemoryStream(imagePath));
                customComponent.button1.Text = "Cancel";
                customComponent.Button1Click += (sender, e) =>
                {
                   
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

        private void bookings_Load(object sender, EventArgs e)
        {

        }
    }
}
