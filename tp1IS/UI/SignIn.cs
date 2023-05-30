using BE;
using Negocio;
using servicios;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MetroFramework;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Patrones.Singleton.Core;
using BLL;
using System.Collections.Generic;

namespace UI
{
    public partial class SignIn : MetroFramework.Forms.MetroForm
    {
        public SignIn()
        {
            InitializeComponent();
            groupBox1.Hide();
        }
        BLLUsuario oLog = new BLLUsuario();
        BEUsuario oUsuraio;
        public void limpiar()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox4.Text = null;
        }
        public void SignIn_Load(object sender, EventArgs e)
        {
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
           

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        BLLBitacora oBit = new BLLBitacora();
        BLLComposite oComp = new BLLComposite();
        public void logIn(string username)
        {
            try
            {
                if (oLog.es_activo(username))
                {
                    BEUsuario user=  oLog.buscar_usuario(username);
                    List<int> permisos = oComp.get_permisos(user.rol);
                    if (permisos.Count == 0 && user.rol != 0) permisos.Add(user.rol);
                    user.permisos = permisos;
                    SessionManager u = SessionManager.GetInstance;
                    SessionManager.Login(user);
                    oBit.guardar_logIn();

                    if (oLog.es_admin(username))
                    {
                        this.Hide();
                        AdminHome home = new AdminHome();
                        home.Show();
                    }
                    else
                    {
                        this.Hide();
                        UserHome home = new UserHome();
                        home.Show();
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "El usuario se encuentra deshabilitado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "");
                errorProvider1.SetError(textBox2, "");
                var error = 0;
                if (textBox1.Text == string.Empty || !Regex.IsMatch(textBox1.Text, "^([a-zA-Z]{1,25}$)"))
                {
                    errorProvider1.SetError(textBox1, "Debe ingresar un usuario sin caracteres especiales");
                    error++;

                }
                if (textBox2.Text == string.Empty || !Regex.IsMatch(textBox2.Text, "^([a-zA-Z]{5,15})([1-9]{1,10}$)"))
                {
                    errorProvider1.SetError(textBox2, "Debe ingresar una contraseña de 1 a 10 numeros y 5-15 letras");
                    error++;
                }
                if(error == 0)
                {
                    oUsuraio = new BEUsuario(textBox1.Text, textBox2.Text);
                    if (oLog.validar(oUsuraio))
                    {
                        logIn(textBox1.Text);

                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Usuario o contraseña incorrecta ");
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            groupBox1.Show();
        }
       
        private void metroButton3_Click_1(object sender, EventArgs e)
        {
            try
            {
                var error = 0;
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "");
                errorProvider1.SetError(textBox2, "");
                errorProvider1.SetError(textBox4, "");
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

                if (textBox4.Text == string.Empty || !Regex.IsMatch(textBox4.Text, "^([0-9]{1,9}$)"))
                {
                    errorProvider1.SetError(textBox4, "Debe ingresar un id de 1 a 9 numeros");
                    error++;
                }
                if (metroDateTime1.Value == null)
                {
                    errorProvider1.SetError(metroDateTime1, "Debe ingresar una fecha");
                    error++;
                }

                if(error == 0)
                {
                    if (oLog.usuario_existente(Convert.ToInt32(textBox4.Text))) MessageBox.Show("Ya hay un usuario registrado con este id", "ERROR");
                    else
                    {
                        oUsuraio = new BEUsuario(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox4.Text), metroDateTime1.Value.ToString());
                        if (oLog.cargar_usuario(oUsuraio))
                        {
                            MetroMessageBox.Show(this, "Usuario creado");
                            limpiar();
                            logIn(oUsuraio.user);
                        }
                        else
                        {
                            limpiar();
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

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}