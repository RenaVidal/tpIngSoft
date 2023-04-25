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

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {

                var error = 0;
                if (textBox1.Text == string.Empty || !Regex.IsMatch(textBox1.Text, "^([a-zA-Z]{1,25}$)"))
                {
                    errorProvider1.SetError(textBox1, "Debe ingresar un usuario sin caracteres especiales");
                    error++;

                }
                if (textBox2.Text == string.Empty || !Regex.IsMatch(textBox2.Text, "^([a-zA-Z]{5,15})([1-9]{1,10}$)"))
                {
                    errorProvider1.SetError(textBox2, "Debe ingresar una contraseña de al menos un numero y 5 letras");
                    error++;
                }

                if (textBox3.Text == string.Empty || !Regex.IsMatch(textBox3.Text, "^([0-9]{1,9}$)"))
                {
                    errorProvider1.SetError(textBox3, "Debe ingresar un id de 1 a 9 numeros");
                    error++;
                }
                if (metroDateTime2.Value == null)
                {
                    errorProvider1.SetError(metroDateTime2, "Debe ingresar una fecha");
                    error++;
                }

                if (error == 0)
                {
                    if (oLog.usuario_existente(Convert.ToInt32(textBox3.Text))) MessageBox.Show("Ya hay un usuario registrado con este id", "ERROR");
                    else
                    {
                        oUsuraio = new BEUsuario(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text), metroDateTime2.Value.ToString());
                        if (oLog.crear_admin(oUsuraio))
                        {
                            MetroMessageBox.Show(this, "Usuario admin rcreado");
                            this.Hide();
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "Ocurrio un error");
                        }
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
