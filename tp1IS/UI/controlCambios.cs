using abstraccion;
using BE;
using BLL;
using MetroFramework;
using MetroFramework.Controls;
using Negocio;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class Changes : MetroFramework.Forms.MetroForm
    {
        public Changes()
        {
            InitializeComponent();
            buscar(null, 1);
            
        }
        validaciones validar = new validaciones();
        BLLUsuario oLog = new BLLUsuario();
        int pag;
        IList<BEUsuario> usuarios;
        BLLBitacora oBit = new BLLBitacora();
        string nombre;
        private void controlCambios_Load(object sender, EventArgs e)
        {
            pag = 1;
            button1.Enabled = false;
        }
       
        public void buscar(string nombre, int pag)
        {
            try
            {
                usuarios = oLog.GetAllHistorico(nombre, pag);
                if (usuarios.Count == 0) { button2.Enabled = false; }
                else { button2.Enabled = true; }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = usuarios;
                dataGridView1.Columns["permisos"].Visible = false;
                dataGridView1.Columns["rol"].Visible = false;
                dataGridView1.Columns["DV"].Visible = false;
            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
        }
        private void Apply_Click(object sender, EventArgs e)
        {
            try
            {
                var error = 0;
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "");
                errorProvider1.SetError(Apply, "");
                
                if (textBox1.Text != string.Empty)
                {
                    if (!validar.usuario(textBox1.Text))
                    {
                        errorProvider1.SetError(textBox1, "The username should not have any special characters");
                        error++;
                        if (oLog.username_existente(textBox1.Text))
                        {
                            errorProvider1.SetError(textBox1, "There are no users associated with that username");
                        }
                    }
                    else
                    {
                        nombre = textBox1.Text;
                    }
                }
                if (error == 0)
                {
                    buscar(nombre, 1);
                    pag = 1;
                }

            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                nombre = null;
                textBox1.Text = string.Empty;
                buscar(null, 1);
                pag = 1;
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
                pag += 1;
                buscar(nombre, pag);
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
                pag -= 1;
                button1.Enabled = true;
                if (pag <= 1) button1.Enabled = false;
                if (pag > 0) buscar(nombre, pag);
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
            try
            {
                textBox1.Text = string.Empty;
            }catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
        }
        BLLDv OBLLdv = new BLLDv();

        public void actualizar_verificador()
        {
            try
            {
                string dv = servicios.GenerarVD.generarDigitoVS(OBLLdv.BuscarDVUsuarios());
                OBLLdv.actualizarDV(dv);
            }
            catch (Exception ex){
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if(dataGridView1.SelectedCells.Count == 1 )
                {
                    BEUsuario user = (BEUsuario)dataGridView1.CurrentRow.DataBoundItem;
                    if (user != null)
                    {
                        if (oLog.restaurar_usuario(user))
                        {
                            actualizar_verificador();
                            MetroMessageBox.Show(this, "user restored");
                        }
                        else MetroMessageBox.Show(this, "Error, try again");
                        buscar(null, 1);
                        pag = 1;
                    }
                    else
                    {
                        errorProvider1.SetError(dataGridView1, "select a user to restore");
                    }
                }
                else
                {
                    errorProvider1.SetError(dataGridView1, "select a user to restore");
                }

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
