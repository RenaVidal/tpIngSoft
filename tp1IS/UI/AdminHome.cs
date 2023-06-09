using BE;
using MetroFramework;
using Negocio;
using Patrones.Singleton.Core;
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
using servicios.ClasesMultiLenguaje;
using servicios;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BLL;

namespace UI
{
    public partial class AdminHome : MetroFramework.Forms.MetroForm,IdiomaObserver
    {
        public AdminHome()
        {
            InitializeComponent();
            groupBox1.Hide();
        }
        BLLUsuario oLog = new BLLUsuario();
        BEUsuario oUsuraio;

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
        BLLTraductor Otraductor = new BLLTraductor();
        private void AdminHome_Load(object sender, EventArgs e)
        {
            try
            {
                ListarIdiomas();
                //  SessionManager.agregarObservador(this);
                servicios.Observer.agregarObservador(this);
                SessionManager.GetInstance.idioma = Otraductor.ObtenerIdiomaBase();
                traducir();

            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
           
            
        }

     
         private void AdminHome_FormClosing(object sender, EventArgs e)
        {
            // ListarIdiomas();
            //SessionManager.agregarObservador(this);
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
          
            // traducir();

        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MetroMessageBox.Show(this, "Yes/No", "¿Do you wish to give admin privileges to a user that already exist?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    darAdmin formadmin = new darAdmin();
                    AbrirFormulario(formadmin);
                }
                else
                {
                    crearAdmin formcrearAdmin = new crearAdmin();
                    AbrirFormulario(formcrearAdmin);

                }
            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
        }
        SessionManager session = SessionManager.GetInstance;
        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "");
                if (textBox1.Text == string.Empty || !Regex.IsMatch(textBox1.Text, "^([0-9]{1,9}$)"))
                {
                    errorProvider1.SetError(textBox1, "You should enter an id from 1 to 9 numbers");
                }
                else
                {
                    if (oLog.usuario_existente(Convert.ToInt32(textBox1.Text)))
                    {
                        if (oLog.eliminar_usuario(Convert.ToInt32(textBox1.Text)))
                        {
                            var accion = " elimino el usuario " + textBox1.Text;
                            oBit.guardar_accion(accion,2);
                            MetroMessageBox.Show(this, "User deleted");
                            if(Convert.ToInt32( textBox1.Text) == session.Usuario.id)
                            {
                                MetroMessageBox.Show(this, "Your user is disabled, you are going to be redirected to log in page");
                                this.Hide();
                            }
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "There has been an error deleting the user");
                        }
                    }
                       
                    else { MetroMessageBox.Show(this, "There are no users registered with this is"); }
                }
            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
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
            SessionManager.eliminarObservador(this);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            borrarPassword passForm = new borrarPassword();
            AbrirFormulario(passForm);
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            crearRol rol = new crearRol();
            AbrirFormulario(rol);
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            darRol darRol = new darRol();
            AbrirFormulario(darRol);
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

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
                    comboBox1.Items.Add(idioma.Nombre);

                }
            }
            catch(Exception ex)
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

        private void traducir()
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
                        if (metroButton2.Tag != null && traducciones.ContainsKey(metroButton2.Tag.ToString()))
                        {
                            this.metroButton2.Text = traducciones[metroButton2.Tag.ToString()].texto;
                        }
                        if (metroButton3.Tag != null && traducciones.ContainsKey(metroButton3.Tag.ToString()))
                        {
                            this.metroButton3.Text = traducciones[metroButton3.Tag.ToString()].texto;
                        }
                        if (metroButton4.Tag != null && traducciones.ContainsKey(metroButton4.Tag.ToString()))
                        {
                            this.metroButton4.Text = traducciones[metroButton4.Tag.ToString()].texto;
                        }
                        if (metroButton5.Tag != null && traducciones.ContainsKey(metroButton5.Tag.ToString()))
                        {
                            this.metroButton5.Text = traducciones[metroButton5.Tag.ToString()].texto;
                        }
                        if (metroButton6.Tag != null && traducciones.ContainsKey(metroButton6.Tag.ToString()))
                        {
                            this.metroButton6.Text = traducciones[metroButton6.Tag.ToString()].texto;
                        }
                        if (metroLabel1.Tag != null && traducciones.ContainsKey(metroLabel1.Tag.ToString()))
                        {
                            this.metroLabel1.Text = traducciones[metroLabel1.Tag.ToString()].texto;
                        }
                        if (metroLabel2.Tag != null && traducciones.ContainsKey(metroLabel2.Tag.ToString()))
                        {
                            this.metroLabel2.Text = traducciones[metroLabel2.Tag.ToString()].texto;
                        }
                        if (groupBox1.Tag != null && traducciones.ContainsKey(groupBox1.Tag.ToString()))
                        {
                            this.groupBox1.Text = traducciones[groupBox1.Tag.ToString()].texto;
                        }
                        if (metroButton7.Tag != null && traducciones.ContainsKey(metroButton7.Tag.ToString()))
                        {
                            this.metroButton7.Text = traducciones[metroButton7.Tag.ToString()].texto;
                        }
                        if (metroButton8.Tag != null && traducciones.ContainsKey(metroButton8.Tag.ToString()))
                        {
                            this.metroButton8.Text = traducciones[metroButton8.Tag.ToString()].texto;
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

        private void VolverAidiomaOriginal()
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
                if (metroButton2.Tag != null && palabras.Contains(metroButton2.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(metroButton2.Tag.ToString()));
                    this.metroButton2.Text = traduccion;
                }
                if (metroButton3.Tag != null && palabras.Contains(metroButton3.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(metroButton3.Tag.ToString()));
                    this.metroButton3.Text = traduccion;
                }
                if (metroButton4.Tag != null && palabras.Contains(metroButton4.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(metroButton4.Tag.ToString()));
                    this.metroButton4.Text = traduccion;
                }
                if (metroButton5.Tag != null && palabras.Contains(metroButton5.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(metroButton5.Tag.ToString()));
                    this.metroButton5.Text = traduccion;
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
                if (groupBox1.Tag != null && palabras.Contains(groupBox1.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(groupBox1.Tag.ToString()));
                    this.groupBox1.Text = traduccion;
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

        private void metroButton8_Click(object sender, EventArgs e)
        {
            AddLenguaje from = new AddLenguaje();
            from.Show();
        }
    }
}
