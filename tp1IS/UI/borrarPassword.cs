using BE;
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
            servicios.Observer.agregarObservador(this);
            ListarIidomas();
            Traducir();
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
        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var error = 0;
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "");
                errorProvider1.SetError(textBox2, "");
                if (textBox1.Text == string.Empty || !Regex.IsMatch(textBox1.Text, "^([0-9]{1,9}$)"))
                {
                    errorProvider1.SetError(textBox1, "Debe ingresar un id de 1 a 9 numeros");
                    error++;
                }
                if (textBox2.Text == string.Empty || !Regex.IsMatch(textBox2.Text, "^([a-zA-Z]{5,15})([1-9]{1,10}$)"))
                {
                    errorProvider1.SetError(textBox2, "Debe ingresar una contraseña de 1 a 10 numeros y 5-15 letras");
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
                            MetroMessageBox.Show(this, "Contrasena modificada");
                            this.Hide();
                        }
                        else MetroMessageBox.Show(this, "Ocurrio un error");
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Usuario inexistente o deshabilitado ");
                    }
                }

            }
            catch (Exception ex)
            {
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

            comboBox1.Items.Clear();
            BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
            var ListaIdiomas = Traductor.ObtenerIdiomas();

            foreach (Idioma idioma in ListaIdiomas)
            {
                comboBox1.Items.Add(idioma.Nombre);
             
            }

        }
        public void Traducir()
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
        public void VolverAidiomaOriginal()
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string idiomaSelec = comboBox1.SelectedItem.ToString();
            BLL.BLLTraductor traductor = new BLL.BLLTraductor();
            Idioma Oidioma = new Idioma();
            Oidioma = traductor.TraerIdioma(idiomaSelec);

            //SessionManager.cambiarIdioma(Oidioma);
            servicios.Observer.cambiarIdioma(Oidioma);
        }
    }
}
