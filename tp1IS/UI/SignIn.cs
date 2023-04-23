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
        public void logIn(string username)
        {
            try
            {
                if (oLog.es_activo(username))
                {
                    BEUsuario user=  oLog.buscar_usuario(username);
                    SessionManager.Login(user);
                    SessionManager u = SessionManager.GetInstance;
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
                if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
                {
                    throw new Exception();
                }
                oUsuraio = new BEUsuario(textBox1.Text,textBox2.Text);
                if (oLog.validar(oUsuraio))
                {
                    logIn(textBox1.Text);

                }
                else
                {
                    MetroMessageBox.Show(this, "Usuario o contraseña incorrecta ");
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
                if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox4.Text == string.Empty || metroDateTime1.Value == null)
                {
                    throw new Exception();
                }
                bool respuesta = Regex.IsMatch(textBox1.Text, "^([a-zA-Z]{1,25}$)") && Regex.IsMatch(textBox2.Text, "^([a-zA-Z]{5,15})([1-9]{1,10}$)");
                bool respuestaID = Regex.IsMatch(textBox4.Text, "^([0-9]{1,9}$)");
                if (respuesta == false)
                {
                    MetroMessageBox.Show(this, "La contraseña debe poseer al menos un numero y 5 letras, el usuario no debe poseer caracteres especiales", "ERROR");
                }
                else if (respuestaID == false)
                {
                    MetroMessageBox.Show(this, "El ID deben ser de 1 a 9 numeros", "ERROR");
                }

                else
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
                            MetroMessageBox.Show(this, "Ocurrio un error");
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}