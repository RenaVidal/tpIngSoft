using BE;
using MetroFramework;
using Negocio;
using servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class darAdmin : MetroFramework.Forms.MetroForm 
    { 
        public darAdmin()
        {
            InitializeComponent();
        }
        BLLUsuario oLog = new BLLUsuario();
        BEUsuario oUsuraio;
        validaciones validar = new validaciones();
        private void darAdmin_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {
        }
        BLLBitacora oBit = new BLLBitacora();
        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "");
                if (textBox2.Text == string.Empty || !validar.id(textBox2.Text))
                {
                    errorProvider1.SetError(textBox2, "You should enter an id with 1 to 9 numbers");
                }
                else
                {
                    if (oLog.usuario_existente(Convert.ToInt32(textBox2.Text))){
                       if( oLog.dar_admin(Convert.ToInt32(textBox2.Text)))
                        {
                            var accion = "dio privilegios de admin a el usuario" + textBox2.Text;
                            oBit.guardar_accion(accion, 2);
                            MetroMessageBox.Show(this, "Success");
                            this.Hide();
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "Error");
                        }
                    }
                    else { MetroMessageBox.Show(this, "There are no users with provided id"); }
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
