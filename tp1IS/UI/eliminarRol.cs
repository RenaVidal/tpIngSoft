using BE;
using BLL;
using MetroFramework;
using MetroFramework.Controls;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using servicios.ClasesMultiLenguaje;
using Patrones.Singleton.Core;
namespace UI
{
    public partial class eliminarRol : MetroFramework.Forms.MetroForm,IdiomaObserver
    {
        public eliminarRol()
        {
            InitializeComponent();
        }
        BLLComposite oComp = new BLLComposite();
        private void eliminarRol_Load(object sender, EventArgs e)
        {
            try
            {
                servicios.Observer.agregarObservador(this);
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

        private void eliminarRol_FormClosing(object sender, FormClosingEventArgs e)
        {
            servicios.Observer.eliminarObservador(this);
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
                      //  MessageBox.Show("The lenguaje change is not complete for " + Idioma.Nombre);
                    }
                    else
                    {
                   
                        if (metroButton2.Tag != null && traducciones.ContainsKey(metroButton2.Tag.ToString()))
                        {
                            this.metroButton2.Text = traducciones[metroButton2.Tag.ToString()].texto;
                        }
                      
                        if (metroLabel1.Tag != null && traducciones.ContainsKey(metroLabel1.Tag.ToString()))
                        {
                            this.metroLabel1.Text = traducciones[metroLabel1.Tag.ToString()].texto;
                        }

                    }
                }
            }catch(Exception ex)
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


                if (metroButton2.Tag != null && palabras.Contains(metroButton2.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(metroButton2.Tag.ToString()));
                    this.metroButton2.Text = traduccion;
                }
               
                if (metroLabel1.Tag != null && palabras.Contains(metroLabel1.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(metroLabel1.Tag.ToString()));
                    this.metroLabel1.Text = traduccion;
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
        public Componente findInList(IList<Componente> list, string nombre)
        {
            try
            {
                Componente encontrado = null;
                foreach (Componente item in list)
                {
                    if (item != null)
                    {
                        if (item.Nombre == nombre) return item;
                        if (item.Hijos != null) encontrado = findInList(item.Hijos, nombre);
                        if (encontrado != null)
                        {
                            return encontrado;
                        }
                    }

                }
                return null;
            }
             catch (Exception ex) {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        BLLUsuario oUser = new BLLUsuario();
        
        BLLBitacora oBit = new BLLBitacora();
        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                errorProvider1.SetError(treeView2, "");
                if (treeView2.SelectedNode == null)
                {
                    errorProvider1.SetError(treeView2, "Select a role");
                }
                else
                {
                    IList<Componente> list = oComp.GetFamilias();
                    Componente item = findInList(list, treeView2.SelectedNode.Text);
                    if (item != null && !oComp.es_patente(item.Nombre))
                    {
                        int rolID = oComp.buscar_id(item.Nombre);
                        if (!oComp.buscar_rol_usado(rolID)) 
                        {
                            var accion = "elimino el rol " + item.Nombre;
                            oBit.guardar_accion(accion, 2);
                            oComp.borrar(rolID);
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "the role is being used, it can not be deleted");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(treeView2, "Select a father role different from Main");
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
            //throw new NotImplementedException();
            Traducir();
            ListarIdiomas();
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
