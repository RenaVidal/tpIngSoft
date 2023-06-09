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
using servicios.ClasesMultiLenguaje;
using servicios;
using Patrones.Singleton.Core;
namespace UI
{
    public partial class borrarPassword : MetroFramework.Forms.MetroForm,IdiomaObserver
    {
        public borrarPassword()
        {
            InitializeComponent();
        }

        private void borrarPassword_Load(object sender, EventArgs e)
        {
            //SessionManager.agregarObservador(this);

            try
            {

                servicios.Observer.agregarObservador(this);
                ListarIidomas();
                Traducir();
            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
           
        }
        
        private void borrarPassword_FormClosing(object sender, EventArgs e)
        {
            //SessionManager.agregarObservador(this);
            servicios.Observer.eliminarObservador(this);
          //  ListarIidomas();
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
                            oBit.guardar_accion(accion, 2);
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
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
        }
       public void CambiarIdioma(Idioma Idioma)
        {
            ListarIidomas();
            Traducir();
        }
        public void ListarIidomas()
        {

            try
            {
                comboBox1.Items.Clear();
                BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
                var ListaIdiomas = Traductor.ObtenerIdiomas();

                foreach (Idioma idioma in ListaIdiomas)
                {
                    comboBox1.Items.Add(idioma.Nombre);

                }

            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
          

        }
        public void Traducir()
        {

            try
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
                        if (metroButton1.Tag != null && traducciones.ContainsKey(metroButton1.Tag.ToString()))
                        {
                            this.metroButton1.Text = traducciones[metroButton1.Tag.ToString()].texto;
                        }
                        if (metroLabel1.Tag != null && traducciones.ContainsKey(metroLabel1.Tag.ToString()))
                        {
                            this.metroLabel1.Text = traducciones[metroLabel1.Tag.ToString()].texto;
                        }
                        if (metroLabel2.Tag != null && traducciones.ContainsKey(metroLabel2.Tag.ToString()))
                        {
                            this.metroLabel2.Text = traducciones[metroLabel2.Tag.ToString()].texto;
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
        public void VolverAidiomaOriginal()
        {

            try
            {
                BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
                List<string> palabras = Traductor.obtenerIdiomaOriginal();

                if (metroButton1.Tag != null && palabras.Contains(metroButton1.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(metroButton1.Tag.ToString()));
                    this.metroButton1.Text = traduccion;
                }
                if (metroLabel1.Tag != null && palabras.Contains(metroLabel1.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(metroLabel1.Tag.ToString()));
                    this.metroLabel1.Text = traduccion;
                }
                if (metroLabel2.Tag != null && palabras.Contains(metroLabel2.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(metroLabel2.Tag.ToString()));
                    this.metroLabel2.Text = traduccion;
                }


            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
         
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            try
            {
                string idiomaSelec = comboBox1.SelectedItem.ToString();
                BLL.BLLTraductor traductor = new BLL.BLLTraductor();
                Idioma Oidioma = new Idioma();
                Oidioma = traductor.TraerIdioma(idiomaSelec);
                servicios.Observer.cambiarIdioma(Oidioma);

            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
