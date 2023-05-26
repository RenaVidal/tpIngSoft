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
using abstraccion;
using servicios.ClasesMultiLenguaje;
namespace UI
{
    public partial class UserHome : MetroFramework.Forms.MetroForm,IdiomaObserver
    {
        public UserHome()
        {
            InitializeComponent();
        }

        private void UserHome_Load(object sender, EventArgs e)
        {
           SessionManager.agregarObservador(this);
            ListarIdiomas();
            
        }

        private void UserHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.eliminarObservador(this);
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

        public void CambiarIdioma(Iidioma Idioma)
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
            
            foreach(Iidioma idioma in ListaIdiomas)
            {
                comboBox1.Items.Add(idioma.Nombre);
        //gas        comboBox1.Items[(comboBox1.Items.Count - 1)].tag = idioma;
            }

        }
        private void VolverAidiomaOriginal()
        {
           // Iidioma Idioma = null;

          //  if (SessionManager.TraerUsuario())
            //    Idioma = SessionManager.GetInstance.Usuario.Idioma;

            //BLL.BLLTraductor Traductor = new BLL.BLLTraductor();

            /*   if (metroButton4.Tag != null && Palabras.Contains(metroButton4.Tag.ToString()))
               {
                   this.metroButton4.Text = Palabras[metroButton4.Tag.ToString()].texto;
               }*/
            /*  BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
              var Palabras = Traductor.obtenerIdiomaOriginal();
              string idiomaOriginal = Traductor.obtenerIdiomaOriginal();

              // Asegúrate de que el método obtenerIdiomaOriginal() devuelva un diccionario o una estructura que contenga las palabras en el idioma original

              if (metroButton4.Tag != null)
              {
                  string clave = metroButton4.Tag.ToString();
                  if (Palabras.ContainsKey(clave))
                  {
                      this.metroButton4.Text = Palabras[clave].texto;
                  }
              }*/
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
            Iidioma Idioma = null;

            if (SessionManager.TraerUsuario())
                Idioma = SessionManager.GetInstance.Usuario.Idioma;
            if (Idioma.Nombre == "ingles")
            {
                VolverAidiomaOriginal();
            }
            else
            {
                BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
                var traducciones = Traductor.obtenertraducciones(Idioma);
                if (metroButton4.Tag != null && traducciones.ContainsKey(metroButton4.Tag.ToString()))
                {
                    this.metroButton4.Text = traducciones[metroButton4.Tag.ToString()].texto;
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

            SessionManager.cambiarIdioma(Oidioma);
            //Iidioma idioma = new Idioma();
            // idioma.Nombre = comboBox1.SelectedItem.ToString();
            // SessionManager.cambiarIdioma(idioma);
           // SessionManager.cambiarIdioma(((Iidioma)((ComboBox)sender).Tag));
           // SessionManager.cambiarIdioma(((Iidioma)((comboBox1.SelectedItem.)sender).tag));
        }

        
    }
}
