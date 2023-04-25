using BE;
using MetroFramework;
using Negocio;
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
        private void darAdmin_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == string.Empty || !Regex.IsMatch(textBox2.Text, "^([0-9]{1,9}$)"))
                {
                    errorProvider1.SetError(textBox2, "Debe ingresar un id de 1 a 9 numeros");
                }
                else
                {
                    if (oLog.usuario_existente(Convert.ToInt32(textBox2.Text))){
                       if( oLog.dar_admin(Convert.ToInt32(textBox2.Text)))
                        {
                            MetroMessageBox.Show(this, "El usuario indicado ya posee provilegios de administrador");
                            this.Hide();
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "Ocurrio un error");
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
    }
}
