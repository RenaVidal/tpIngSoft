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
                if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty || metroDateTime2.Value == null)
                {
                    throw new Exception();
                }
                bool respuesta = Regex.IsMatch(textBox1.Text, "^([a-zA-Z0-9]{1,25}$)") && Regex.IsMatch(textBox2.Text, "^([a-zA-Z]{5,15})([1-9]{1,10}$)");
                bool respuestaID = Regex.IsMatch(textBox3.Text, "^([0-9]{1,9}$)");
                if (respuesta == false)
                {
                    MetroMessageBox.Show(this, "La contraseña debe poseer al menos un numero y 5 letras, el usuario no debe poseer caracteres especiales", "ERROR");
                }
                else if (respuestaID == false)
                {
                    MetroMessageBox.Show(this, "El ID deben ser de 1 a 9 numeros", "ERROR");
                }

                else
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
