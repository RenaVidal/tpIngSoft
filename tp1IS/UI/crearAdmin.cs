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
        validaciones validar = new validaciones();
        BLL.BLLDv OVd = new BLL.BLLDv();
        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                
                var error = 0;
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "");
                errorProvider1.SetError(textBox2, "");
                errorProvider1.SetError(textBox3, "");
                if (textBox1.Text == string.Empty || !validar.usuario(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "You should enter a name without special characters");
                    error++;

                }
                if (textBox2.Text == string.Empty || !validar.contrasena(textBox2.Text))
                {
                    errorProvider1.SetError(textBox2, "You should enter a password with at least 1 number and 5 letters");
                    error++;
                }

                if (textBox3.Text == string.Empty || !validar.id(textBox3.Text))
                {
                    errorProvider1.SetError(textBox3, "You should enter an id with 1 to 9 numbers");
                    error++;
                }
                if (metroDateTime2.Value == null)
                {
                    errorProvider1.SetError(metroDateTime2, "You should enter a date");
                    error++;
                }

                if (error == 0)
                {
                    if (oLog.usuario_existente(Convert.ToInt32(textBox3.Text))) MessageBox.Show("There is a user with that id already", "ERROR");
                    else
                    {
                        oUsuraio = new BEUsuario(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text), metroDateTime2.Value.ToString());
               
                        if (oLog.crear_admin(oUsuraio))
                        {
                            var accion = "creo el usuario admin" + textBox1.Text;
                            oBit.guardar_accion(accion, 2);
                            MetroMessageBox.Show(this, "Admin user created");
                            this.Hide();
                            List<string> ListaDVU = OVd.BuscarDVUsuarios();
                            string DVS = servicios.GenerarVD.generarDigitoVS(ListaDVU);
                            OVd.actualizarDV(DVS);
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "There has been an error, try changing the username");
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
       // void CambiarIdioma(Iidioma Idioma);
        public void CambiarIdioma(Idioma Idioma)
        {
           
            ListarIdiomas();
            traducir();
        }

        public void traducir()
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
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
            

        }
        public void ListarIdiomas()
        {
            try
            {
                comboBox1.Items.Clear();
                BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
                var ListaIdiomas = Traductor.ObtenerIdiomas();

                foreach (Idioma idioma in ListaIdiomas)
                {
                    var traducciones = Traductor.obtenertraducciones(idioma);
                    List<string> Lista = new List<string>();
                    Lista = Traductor.obtenerIdiomaOriginal();
                    if (traducciones.Values.Count == Lista.Count)
                    {
                        comboBox1.Items.Add(idioma.Nombre);
                    }
                    else
                    {
                        if (idioma.Default == true)
                        {
                            comboBox1.Items.Add(idioma.Nombre);
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
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
           
        }
        private void crearAdmin_Load(object sender, EventArgs e)
        {
            try
            {

                servicios.Observer.agregarObservador(this);
                ListarIdiomas();
                traducir();
            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
          
        }

        private void crearAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            servicios.Observer.eliminarObservador(this);
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
