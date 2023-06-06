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
using servicios.ClasesMultiLenguaje;
namespace UI
{
    public partial class UserHome : MetroFramework.Forms.MetroForm,IdiomaObserver
    {
        public UserHome()
        {
            InitializeComponent();
        }
        BLL.BLLTraductor Otraductor = new BLL.BLLTraductor();
        private void UserHome_Load(object sender, EventArgs e)
        {
            servicios.Observer.agregarObservador(this);
           //SessionManager.agregarObservador(this);
            ListarIdiomas();
            SessionManager.GetInstance.idioma = Otraductor.ObtenerIdiomaBase();
            traducir();

        }
        private Form formularioAbierto = null;
        private void AbrirFormulario(Form formulario)
        {
            try
            {
                if (formularioAbierto != null)
                {
                    formularioAbierto.Close();
                }

                formularioAbierto = formulario;
                formularioAbierto.Show();
            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }

        }

        private void UserHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            servicios.Observer.eliminarObservador(this);
           // SessionManager.eliminarObservador(this);
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
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
        }

        public void CambiarIdioma(Idioma Idioma)
        {
            //throw new NotImplementedException();
            //marcarIdioma();
         //   if (Idioma.Nombre == "Ingles")
         //   {
         //       VolverAidiomaOriginal();
          //  }
           // else
           // {
                ListarIdiomas();
                traducir();
           // }
            
        }

        private void ListarIdiomas()
        {
            comboBox1.Items.Clear();
            BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
            var ListaIdiomas = Traductor.ObtenerIdiomas();
            
            foreach(Idioma idioma in ListaIdiomas)
            {
                comboBox1.Items.Add(idioma.Nombre);
        //gas        comboBox1.Items[(comboBox1.Items.Count - 1)].tag = idioma;
            }

        }
        private void VolverAidiomaOriginal()
        {
            BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
            List<string> palabras = Traductor.obtenerIdiomaOriginal();

            if (metroButton4.Tag != null && palabras.Contains(metroButton4.Tag.ToString()))
            {
                string traduccion = palabras.Find(p => p.Equals(metroButton4.Tag.ToString()));
                this.metroButton4.Text = traduccion;
            }
        }
        private void traducir()
        {
            Idioma Idioma = null;

            if (SessionManager.TraerUsuario())
                Idioma = SessionManager.GetInstance.idioma;
            if (Idioma.Nombre == "ingles")
            {
                VolverAidiomaOriginal();
            }
            else
            {
                BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
                var traducciones = Traductor.obtenertraducciones(Idioma);
                List<string> Lista = new List<string>();
                Lista = Traductor.obtenerIdiomaOriginal();
                if (traducciones.Values.Count != Lista.Count)
                {
                    MessageBox.Show("The lenguaje change is not complete for " + Idioma.Nombre);
                }
                else
                {
                    if (metroButton4.Tag != null && traducciones.ContainsKey(metroButton4.Tag.ToString()))
                    {
                        this.metroButton4.Text = traducciones[metroButton4.Tag.ToString()].texto;
                    }
                }
              
            }
            

           /* if (UserHome.ActiveForm.Tag != null && traducciones.ContainsKey(UserHome.ActiveForm.Tag.ToString()))
            {
                UserHome.ActiveForm.Tag = traducciones[UserHome.ActiveForm.Tag.ToString()].texto;
            }*/
              

            
           // var traducciones=BLL.BLLTraductor.obte
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idiomaSelec = comboBox1.SelectedItem.ToString();
            BLL.BLLTraductor traductor = new BLL.BLLTraductor();
            Idioma Oidioma = new Idioma();
            Oidioma = traductor.TraerIdioma(idiomaSelec);

            //   SessionManager.cambiarIdioma(Oidioma);
            servicios.Observer.cambiarIdioma(Oidioma);
            //Iidioma idioma = new Idioma();
            // idioma.Nombre = comboBox1.SelectedItem.ToString();
            // SessionManager.cambiarIdioma(idioma);
           // SessionManager.cambiarIdioma(((Iidioma)((ComboBox)sender).Tag));
           // SessionManager.cambiarIdioma(((Iidioma)((comboBox1.SelectedItem.)sender).tag));
        }

        
    }
}
