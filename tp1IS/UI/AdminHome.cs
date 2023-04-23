using BE;
using MetroFramework;
using Negocio;
using Patrones.Singleton.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class AdminHome : MetroFramework.Forms.MetroForm
    {
        public AdminHome()
        {
            InitializeComponent();
            groupBox1.Hide();
        }
        BLLUsuario oLog = new BLLUsuario();
        BEUsuario oUsuraio;
        private void AdminHome_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
           if( MetroMessageBox.Show(this, "Yes/No",  "¿Do you wish to give admin privileges to a user that already exist?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                darAdmin formadmin = new darAdmin();
                formadmin.ShowDialog();
            }
            else
            {
                crearAdmin formcrearAdmin = new crearAdmin();
                formcrearAdmin.ShowDialog();
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == null)
                {
                    throw new Exception();
                }
                bool respuestaID = Regex.IsMatch(textBox1.Text, "^([0-9]{1,9}$)");
                if (!respuestaID)
                {
                    MetroMessageBox.Show(this, "El ID deben ser de 1 a 9 numeros", "ERROR");
                }

                else
                {
                    if (oLog.usuario_existente(Convert.ToInt32(textBox1.Text)))
                    {
                        if (oLog.eliminar_usuario(Convert.ToInt32(textBox1.Text)))
                        {
                            MetroMessageBox.Show(this, "Usuario borrado");
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "Hubo un problema borrando el usuario");
                        }
                    }
                       
                    else { MetroMessageBox.Show(this, "No hay usuarios registrados con ese ID"); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                SessionManager.Logout();
                this.Hide();
                SignIn form = new SignIn();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
