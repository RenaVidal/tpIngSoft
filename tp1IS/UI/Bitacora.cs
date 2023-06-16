using abstraccion;
using BE;
using MetroFramework;
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
    public partial class Bitacora : MetroFramework.Forms.MetroForm
    {
        public Bitacora()
        {
            InitializeComponent();
            inicializar_filtros();
        }
        public int pag;
        void inicializar_filtros()
        {
            textBox1.Text = string.Empty;
            List<string> tipos = new List<string>() { "error", "information"};
            metroComboBox1.DataSource = tipos;
            metroComboBox1.SelectedIndex = -1;
            filters = new BEBitacoraFilters() { From = DateTime.Now, To = DateTime.Now, Username = null, Like = null, Type = null };
        }
        BLLBitacora oBit = new BLLBitacora();
        validaciones validar = new validaciones();
        IList<IBitacora> listBitacora;
        IBitacoraFilters filters = new BEBitacoraFilters() { From = DateTime.Now, To = DateTime.Now };
        private void Bitacora_Load(object sender, EventArgs e)
        {
            listBitacora = oBit.GetAll(filters, 1);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listBitacora;
            pag = 1;
            button1.Enabled = false;
        }
        BLLUsuario oLog = new BLLUsuario();
        public void buscar(int pag)
        {
            listBitacora = oBit.GetAll(filters, pag);
            if (listBitacora.Count == 0) { button2.Enabled = false; }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listBitacora;
        }
        private void Apply_Click(object sender, EventArgs e)
        {
            try
            {
                var error = 0;
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "");
                errorProvider1.SetError(metroDateTime1, "");
                errorProvider1.SetError(metroDateTime2, "");
                errorProvider1.SetError(metroComboBox1, "");
                errorProvider1.SetError(Apply, "");
                string name = null;
                Nullable<DateTime> from = null;
                Nullable<DateTime> to = null;
                Nullable <int> type = null;
                if (metroDateTime1.Value == null && metroDateTime2.Value == null && metroComboBox1.SelectedIndex == -1 && textBox1.Text == string.Empty)
                {
                    errorProvider1.SetError(Apply, "You should pick a filter");
                    error++;
                }
                if(textBox1.Text != string.Empty)
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
                        name = textBox1.Text;
                    }
                }
                if(metroDateTime2.Value != null)
                {
                    to = metroDateTime2.Value;
                }
                if (metroDateTime1.Value != null)
                {
                    from = metroDateTime1.Value;
                }
                if (metroComboBox1.SelectedIndex != -1)
                {
                    if (metroComboBox1.SelectedItem.ToString() == "error") type = 1;
                    else type = 2;
                }
                if (error == 0)
                {
                    filters = new BEBitacoraFilters() { From = from, To = to, Username = name, Type= type };
                    buscar(1);
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
            inicializar_filtros();
            buscar(1);
            pag = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            pag += 1;
            buscar(pag);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pag -= 1;
            if(pag <= 1) button1.Enabled = false;
            buscar(pag);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            metroComboBox1.SelectedIndex = -1;
        }
    }
}
