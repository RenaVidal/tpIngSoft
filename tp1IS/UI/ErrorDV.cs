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
using servicios.ClasesMultiLenguaje;
using Negocio;
using Patrones.Singleton.Core;
namespace UI
{
    public partial class ErrorDV : MetroFramework.Forms.MetroForm,IdiomaObserver
    {
        public ErrorDV()
        {
            InitializeComponent();
        }
        BLL.BLLDv OBLLDV = new BLLDv();
        BLLBitacora oBit = new BLLBitacora();
        
        private void ErrorDV_Load(object sender, EventArgs e)
        {
            ListarIdiomas();
            Traducir();
            servicios.Observer.agregarObservador(this);
        }
        private void ErrorDV_FormClosing(object sender, EventArgs e)
        {
            try
            {
                servicios.Observer.eliminarObservador(this);

            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }



        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            List<string> ListaDVU = OBLLDV.BuscarDVUsuarios();

            OBLLDV.actualizarDV(servicios.GenerarVD.generarDigitoVS(ListaDVU));
            AdminHome form = new AdminHome();
            form.Show();
            this.Hide();
        }
        public void CambiarIdioma(Idioma Idioma)
        {
            Traducir();
            ListarIdiomas();
        }
        public void Traducir()
        {

            try
            {
                Idioma Idioma = null;

                if (SessionManager.TraerUsuario())
                    Idioma = SessionManager.GetInstance.idioma;

                if (Idioma == null)
                {

                }
                else
                {
                    if (Idioma.Nombre == "ingles")
                    {
                        VolverAlIdiomaOriginal();
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
        public void VolverAlIdiomaOriginal()
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
