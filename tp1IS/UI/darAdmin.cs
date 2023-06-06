using BE;
using MetroFramework;
using Negocio;
using servicios;
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
using Patrones.Singleton.Core;
using servicios.ClasesMultiLenguaje;
namespace UI
{
    public partial class darAdmin : MetroFramework.Forms.MetroForm, IdiomaObserver
    {
        public darAdmin()
        {
            InitializeComponent();
        }
        BLLUsuario oLog = new BLLUsuario();
        BEUsuario oUsuraio;
        validaciones validar = new validaciones();
        private void darAdmin_Load(object sender, EventArgs e)
        {
            //SessionManager.agregarObservador(this);
            servicios.Observer.agregarObservador(this);
            ListarIdiomas();
            traducir();
        }

        private void darAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // SessionManager.eliminarObservador(this);
            servicios.Observer.eliminarObservador(this);
        }
        private void metroLabel3_Click(object sender, EventArgs e)
        {
        }
        BLLBitacora oBit = new BLLBitacora();
        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "");
                if (textBox2.Text == string.Empty || !validar.id(textBox2.Text))
                {
                    errorProvider1.SetError(textBox2, "You should enter an id with 1 to 9 numbers");
                }
                else
                {
                    if (oLog.usuario_existente(Convert.ToInt32(textBox2.Text))) {
                        if (oLog.dar_admin(Convert.ToInt32(textBox2.Text)))
                        {
                            var accion = "dio privilegios de admin a el usuario" + textBox2.Text;
                            oBit.guardar_accion(accion, 2);
                            MetroMessageBox.Show(this, "Success");
                            this.Hide();
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "Error");
                        }
                    }
                    else { MetroMessageBox.Show(this, "There are no users with provided id"); }
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

                    if (metroButton1.Tag != null && traducciones.ContainsKey(metroButton1.Tag.ToString()))
                    {
                        this.metroButton1.Text = traducciones[metroButton1.Tag.ToString()].texto;
                    }
                    if (metroLabel3.Tag != null && traducciones.ContainsKey(metroLabel3.Tag.ToString()))
                    {
                        this.metroLabel3.Text = traducciones[metroLabel3.Tag.ToString()].texto;
                    }
                    if (metroLabel4.Tag != null && traducciones.ContainsKey(metroLabel4.Tag.ToString()))
                    {
                        this.metroLabel4.Text = traducciones[metroLabel4.Tag.ToString()].texto;
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

            if (metroLabel3.Tag != null && palabras.Contains(metroLabel3.Tag.ToString()))
            {
                string traduccion = palabras.Find(p => p.Equals(metroLabel3.Tag.ToString()));
                this.metroLabel3.Text = traduccion;
            }

            if (metroLabel4.Tag != null && palabras.Contains(metroLabel4.Tag.ToString()))
            {
                string traduccion = palabras.Find(p => p.Equals(metroLabel4.Tag.ToString()));
                this.metroLabel4.Text = traduccion;
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
