using BE;
using MetroFramework.Controls;
using MetroFramework;
using Negocio;
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
using servicios;

namespace UI
{
    public partial class crearAdmin : MetroFramework.Forms.MetroForm
    {
        public crearAdmin()
        {
            InitializeComponent();
        }
        BLLUsuario oLog = new BLLUsuario();
        BEUsuario oUsuraio;
        BLLBitacora oBit = new BLLBitacora();
        validaciones validar = new validaciones();
        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {

                var error = 0;
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "");
                errorProvider1.SetError(textBox2, "");
                errorProvider1.SetError(textBox3, "");
                if (textBox1.Text == string.Empty || !validar.usuario(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "You should enter a name without special characters");
                    error++;

                }
                if (textBox2.Text == string.Empty || !validar.contrasena(textBox2.Text))
                {
                    errorProvider1.SetError(textBox2, "You should enter a password with at least 1 number and 5 letters");
                    error++;
                }

                if (textBox3.Text == string.Empty || !validar.id(textBox3.Text))
                {
                    errorProvider1.SetError(textBox3, "You should enter an id with 1 to 9 numbers");
                    error++;
                }
                if (metroDateTime2.Value == null)
                {
                    errorProvider1.SetError(metroDateTime2, "You should enter a date");
                    error++;
                }

                if (error == 0)
                {
                    if (oLog.usuario_existente(Convert.ToInt32(textBox3.Text))) MessageBox.Show("There is an user with that id already", "ERROR");
                    else
                    {
                        oUsuraio = new BEUsuario(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text), metroDateTime2.Value.ToString());
                        if (oLog.crear_admin(oUsuraio))
                        {
                            var accion = "creo el usuario admin" + textBox1.Text;
                            oBit.guardar_accion(accion, 2);
                            MetroMessageBox.Show(this, "Admin user created");
                            this.Hide();
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "There has been an error, try changing the username");
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
        }

        private void crearAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
