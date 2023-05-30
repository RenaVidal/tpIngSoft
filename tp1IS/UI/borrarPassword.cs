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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class borrarPassword : MetroFramework.Forms.MetroForm
    {
        public borrarPassword()
        {
            InitializeComponent();
        }

        private void borrarPassword_Load(object sender, EventArgs e)
        {

        }
        BLLUsuario oLog = new BLLUsuario();
        BEUsuario oUsuraio;
        BLLBitacora oBit = new BLLBitacora();
        validaciones validar = new validaciones();
        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var error = 0;
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "");
                errorProvider1.SetError(textBox2, "");
                if (textBox1.Text == string.Empty || !validar.id(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "You should enter an id with 1 to 9 numbers");
                    error++;
                }
                if (textBox2.Text == string.Empty || !validar.contrasena(textBox2.Text))
                {
                    errorProvider1.SetError(textBox2, "You should enter a password with at least 1 number and 5 letters");
                    error++;
                }
                if (error == 0)
                {
                    if (oLog.usuario_existente(Convert.ToInt32( textBox1.Text)))
                    {

                        if (oLog.cambiar_contrasena(Convert.ToInt32( textBox1.Text), textBox2.Text))
                        {
                            var accion = "cambio la contraseña del usuario de id" + textBox1.Text;
                            oBit.guardar_accion(accion);
                            MetroMessageBox.Show(this, "Password changed");
                            this.Hide();
                        }
                        else MetroMessageBox.Show(this, "Error");
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "There is no active user with provided id");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
