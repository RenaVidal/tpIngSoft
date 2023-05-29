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
using servicios.ClasesMultiLenguaje;
using Patrones.Singleton.Core;


//using Negocio;
namespace UI
{
    public partial class crearAdmin : MetroFramework.Forms.MetroForm,IdiomaObserver
    {
        public crearAdmin()
        {
            InitializeComponent();
        }
        BLLUsuario oLog = new BLLUsuario();
        BEUsuario oUsuraio;
        BLLBitacora oBit = new BLLBitacora();
        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                
                var error = 0;
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "");
                errorProvider1.SetError(textBox2, "");
                errorProvider1.SetError(textBox3, "");
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
                            var accion = "creo el usuario admin" + textBox1.Text;
                            oBit.guardar_accion(accion);
                            MetroMessageBox.Show(this, "Usuario admin rcreado");
                            this.Hide();
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "Ocurrio un error, pruebe modificando el nombre de usuario");
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       // void CambiarIdioma(Iidioma Idioma);
        public void CambiarIdioma(Idioma Idioma)
        {
           
            ListarIdiomas();
            traducir();
        }

        public void traducir()
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
                    if (metroLabel1.Tag != null && traducciones.ContainsKey(metroLabel1.Tag.ToString()))
                    {
                        this.metroLabel1.Text = traducciones[metroLabel1.Tag.ToString()].texto;
                    }
                    if (metroLabel2.Tag != null && traducciones.ContainsKey(metroLabel2.Tag.ToString()))
                    {
                        this.metroLabel2.Text = traducciones[metroLabel2.Tag.ToString()].texto;
                    }
                    if (metroLabel3.Tag != null && traducciones.ContainsKey(metroLabel3.Tag.ToString()))
                    {
                        this.metroLabel3.Text = traducciones[metroLabel3.Tag.ToString()].texto;
                    }
                    if (metroLabel6.Tag != null && traducciones.ContainsKey(metroLabel6.Tag.ToString()))
                    {
                        this.metroLabel6.Text = traducciones[metroLabel6.Tag.ToString()].texto;
                    }
                }
              

            }

        }
        public void ListarIdiomas()
        {
            comboBox1.Items.Clear();
            BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
            var ListaIdiomas = Traductor.ObtenerIdiomas();

            foreach (Idioma idioma in ListaIdiomas)
            {
                comboBox1.Items.Add(idioma.Nombre);
              
            }
        }
        public void VolverAidiomaOriginal()
        {
            BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
            List<string> palabras = Traductor.obtenerIdiomaOriginal();

            if (metroButton4.Tag != null && palabras.Contains(metroButton4.Tag.ToString()))
            {
                string traduccion = palabras.Find(p => p.Equals(metroButton4.Tag.ToString()));
                this.metroButton4.Text = traduccion;
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
            if (metroLabel3.Tag != null && palabras.Contains(metroLabel3.Tag.ToString()))
            {
                string traduccion = palabras.Find(p => p.Equals(metroLabel3.Tag.ToString()));
                this.metroLabel3.Text = traduccion;
            }
            if (metroLabel6.Tag != null && palabras.Contains(metroLabel6.Tag.ToString()))
            {
                string traduccion = palabras.Find(p => p.Equals(metroLabel6.Tag.ToString()));
                this.metroLabel6.Text = traduccion;
            }
        }
        private void crearAdmin_Load(object sender, EventArgs e)
        {
            // SessionManager.agregarObservador(this);
            servicios.Observer.agregarObservador(this);
            ListarIdiomas();
            traducir();
        }

        private void crearAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            servicios.Observer.eliminarObservador(this);
           // SessionManager.eliminarObservador(this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                string idiomaSelec = comboBox1.SelectedItem.ToString();
                BLL.BLLTraductor traductor = new BLL.BLLTraductor();
                Idioma Oidioma = new Idioma();
                Oidioma = traductor.TraerIdioma(idiomaSelec);

            // SessionManager.cambiarIdioma(Oidioma);
            servicios.Observer.cambiarIdioma(Oidioma);
     
            
        }
    }
}
