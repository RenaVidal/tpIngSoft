using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;
namespace UI
{
    public partial class ErrorDV : MetroFramework.Forms.MetroForm
    {
        public ErrorDV()
        {
            InitializeComponent();
        }
        BLL.BLLDv OBLLDV = new BLLDv();
        private void ErrorDV_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            List<string> ListaDVU = OBLLDV.BuscarDVUsuarios();

            OBLLDV.actualizarDV(servicios.GenerarVD.generarDigitoVS(ListaDVU));
            AdminHome form = new AdminHome();
            form.Show();
            this.Hide();
        }

        
    }
}
