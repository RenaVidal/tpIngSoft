using BE;
using BLL;
using MetroFramework;
using MetroFramework.Controls;
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
    public partial class mybookings : Form
    {
        public mybookings()
        {
            InitializeComponent();
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
        private void mybookings_Load(object sender, EventArgs e)
        {
            try { 
               paginaP = 1;
               paginaF = 1;
               alquileresPasados = oBAl.GetAllAlquileres(42933252, DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), 1, paginaP);  // CABIAR ACA ID
               alquileresFuturos = oBAl.GetAllAlquileres(42933252, DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), 0, paginaF); // CABIAR ACA ID
                button4.Enabled = false;
                button1.Enabled = false;

                balnearios = oBAl.GetAllBalneariosNoP();
                getAlquileresF(42933252, 1);
                getAlquileresP(42933252, 1);
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
        
        public void getAlquileresP(int id, int pag)
        {
            try { 
                alquileresPasados = oBAl.GetAllAlquileres(42933252, DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), 1, paginaP);  // CABIAR ACA ID
           
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
                alquileresFuturos = oBAl.GetAllAlquileres(42933252, DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), 0, paginaF); // CABIAR ACA ID
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
        private void AddGalleryItemF(byte[] imagePath, int id, string name, DateTime fechaInicio, DateTime fechaFin, int precio)
        {
            try { 
                alquileres customComponent = new alquileres(id, name, DateTime.ParseExact(fechaInicio.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), DateTime.ParseExact(fechaFin.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null));
                customComponent.Picture = Image.FromStream(new System.IO.MemoryStream(imagePath));
                customComponent.button1.Text = "Cancel";
                customComponent.Button1Click += (sender, e) =>
                {
                    if (DateTime.ParseExact(fechaInicio.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null) >= (DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null).AddHours(48))){

                        oBAl.eliminar_reserva(customComponent.id);
                        getAlquileresF(42933252, paginaP); // CAMBIAR ACA ID
                        MetroMessageBox.Show(this, "Reservation canceled " + precio.ToString() + " will be deposited in your account.");
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
                getAlquileresF(42933252, paginaF); //-------------------------------------------------------- aca id
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
                if (paginaF > 0) getAlquileresF(42933252, paginaF); //-------------------------------------------------------- aca id
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
                getAlquileresP(42933252, paginaP); //-------------------------------------------------------- aca id
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
                if (paginaP > 0) getAlquileresP(42933252, paginaP); //-------------------------------------------------------- aca id
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
