using Negocio;
using Patrones.Singleton.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class UserHome : MetroFramework.Forms.MetroForm
    {
        public UserHome()
        {
            InitializeComponent();
        }

        private void UserHome_Load(object sender, EventArgs e)
        {

        }
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
    }
}
