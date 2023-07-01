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
using BLL;
using BE;
using servicios;
using Negocio;
using Patrones.Singleton.Core;

namespace UI
{
    public partial class Desencriptar : MetroFramework.Forms.MetroForm, IdiomaObserver
    {
        public Desencriptar()
        {
            InitializeComponent();
        }
        BLLBitacora oBit = new BLLBitacora();
        public void CambiarIdioma(Idioma Idioma)
        {
            try
            {
                Traducir();
                ListarIdiomas();

            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
        }


        private void Desencriptar_Load(object sender, EventArgs e)
        {
            servicios.Observer.agregarObservador(this);
            ListarIdiomas();
        }
        validaciones validar = new validaciones();
        BLLUsuario oLog = new BLLUsuario();
        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var error = 0;
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "");
                if (textBox1.Text == string.Empty || !validar.id(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "You should enter an id with 1 to 9 numbers");
                    error++;
                }
                if (error==0)
                {
                    if (oLog.usuario_existente(Convert.ToInt32(textBox1.Text)))
                    {
                        BEUsuario Ousuario = new BEUsuario();
                        Ousuario = oLog.buscar_usuarioxid(Convert.ToInt32(textBox1.Text));
                        string contraseña = servicios.encriptar.Desencriptar(Ousuario.password);
                        textBox2.Text = contraseña;
                    }
                    else
                    {
                        errorProvider1.SetError(textBox1, "there is no user with that id");
                    }
                }
               
            }
            catch(Exception ex)
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
                if (Idioma.Nombre == "Ingles")
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
                        if (metroButton1.Tag != null && traducciones.ContainsKey(metroButton1.Tag.ToString()))
                        {
                            this.metroButton1.Text = traducciones[metroButton1.Tag.ToString()].texto;
                        }
                        if (label2.Tag != null && traducciones.ContainsKey(label2.Tag.ToString()))
                        {
                            this.label2.Text = traducciones[label2.Tag.ToString()].texto;
                        }
                        if (label3.Tag != null && traducciones.ContainsKey(label3.Tag.ToString()))
                        {
                            this.label3.Text = traducciones[label3.Tag.ToString()].texto;
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
                if (label2.Tag != null && palabras.Contains(label2.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(label2.Tag.ToString()));
                    this.label2.Text = traduccion;
                }
                if (label3.Tag != null && palabras.Contains(label3.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(label3.Tag.ToString()));
                    this.label3.Text = traduccion;
                }


            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }

        }
        private void ListarIdiomas()
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
