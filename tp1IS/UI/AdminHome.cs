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

        private Form formularioAbierto = null;
        private void AbrirFormulario(Form formulario)
        {
            if (formularioAbierto != null)
            {
                formularioAbierto.Close();
            }

            formularioAbierto = formulario;
            formularioAbierto.Show();
        }
        private void AdminHome_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
           if( MetroMessageBox.Show(this, "Yes/No",  "¿Do you wish to give admin privileges to a user that already exist?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                darAdmin formadmin = new darAdmin();
                AbrirFormulario(formadmin);
            }
            else
            {
                crearAdmin formcrearAdmin = new crearAdmin();
                AbrirFormulario(formcrearAdmin);

            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
        }
        SessionManager session = SessionManager.GetInstance;
        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "");
                if (textBox1.Text == string.Empty || !Regex.IsMatch(textBox1.Text, "^([0-9]{1,9}$)"))
                {
                    errorProvider1.SetError(textBox1, "You should enter an id from 1 to 9 numbers");
                }
                else
                {
                    if (oLog.usuario_existente(Convert.ToInt32(textBox1.Text)))
                    {
                        if (oLog.eliminar_usuario(Convert.ToInt32(textBox1.Text)))
                        {
                            var accion = " elimino el usuario " + textBox1.Text;
                            oBit.guardar_accion(accion);
                            MetroMessageBox.Show(this, "User deleted");
                            if(Convert.ToInt32( textBox1.Text) == session.Usuario.id)
                            {
                                MetroMessageBox.Show(this, "Your user is disabled, you are going to be redirected to log in page");
                                this.Hide();
                            }
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "There has been an error deleting the user");
                        }
                    }
                       
                    else { MetroMessageBox.Show(this, "There are no users registered with this is"); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        BLLBitacora oBit = new BLLBitacora();
        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                oBit.guardar_logOut();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            borrarPassword passForm = new borrarPassword();
            AbrirFormulario(passForm);
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            crearRol rol = new crearRol();
            AbrirFormulario(rol);
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            darRol darRol = new darRol();
            AbrirFormulario(darRol);
        }
    }
}
