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
        void inicializar_filtros()
        {
            textBox1.Text = string.Empty;
            List<string> tipos = new List<string>() { "error", "information"};
            metroComboBox1.DataSource = tipos;
            metroComboBox1.SelectedIndex = -1;
        }
        BLLBitacora oBit = new BLLBitacora();
        validaciones validar = new validaciones();
        IList<IBitacora> listBitacora;
        IBitacoraFilters filters = new BEBitacoraFilters() { From = DateTime.Now, To = DateTime.Now };
        private void Bitacora_Load(object sender, EventArgs e)
        {
            listBitacora = oBit.GetAll(filters);
            dataGridView1.DataSource = listBitacora;
        }
        BLLUsuario oLog = new BLLUsuario();
        public void buscar()
        {
            listBitacora = oBit.GetAll(filters);
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
                if (!validar.usuario(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "The username should not have any special characters");
                    error++;

                }
                else if (metroDateTime1.Value == null && metroDateTime2.Value == null && metroComboBox1.SelectedIndex == -1 && textBox1.Text == string.Empty)
                {
                    errorProvider1.SetError(Apply, "You should pick a filter");
                    error++;
                }

                if (error == 0)
                {

                    if (oLog.username_existente(textBox1.Text)){
                        filters = new BEBitacoraFilters() { From = metroDateTime1.Value, To = metroDateTime2.Value, Username = textBox1.Text, Type= Convert.ToInt32(metroComboBox1.SelectedItem.ToString()) };
                        buscar();
                    }
                    else { MetroMessageBox.Show(this, "there are no users associated with that id"); }


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
            buscar();
        }
    }
}
