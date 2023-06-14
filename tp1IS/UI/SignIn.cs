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
using System.Drawing;
using System.ComponentModel;
using servicios.ClasesMultiLenguaje;
using BLL;
using System.Collections.Generic;

namespace UI
{
    public partial class SignIn : MetroFramework.Forms.MetroForm,IdiomaObserver
    {
        public SignIn()
        {
            InitializeComponent();
            groupBox1.Hide();
        }
        BLLUsuario oLog = new BLLUsuario();
        BLL.BLLDv OBLLDV = new BLLDv();
        BEUsuario oUsuraio;
        public bool ojoOpen;
        public void limpiar()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox4.Text = null;
        }
        validaciones validar = new validaciones();
        public void SignIn_Load(object sender, EventArgs e)
        {
            ojoOpen = false;
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\ojoCerrado.png");
            botonOjo.Image = imagen;
            textBox2.UseSystemPasswordChar = true;
            SessionManager.agregarObservador(this);

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
        
        public void logIn(string username,int d)
        {
            try
            {

                if (oLog.es_activo(username))
                {
                    BEUsuario user=  oLog.buscar_usuario(username);
                    user.permisos = oComp.GetPermisosdeUser(user.id);
                    SessionManager u = SessionManager.GetInstance;
                    SessionManager.Login(user);
                    oBit.guardar_logIn();
                  
                    BE.DigitoV DV = new BE.DigitoV();
                    DV.DigitovBaseDeDatos = OBLLDV.BuscarDVS();
                    List<string> ListaDV = oLog.BuscarUsuariosYgenerarDV();
                    DV.DigitovActual = GenerarVD.generarDigitoVS(ListaDV);
                    if (DV.DigitovBaseDeDatos == DV.DigitovActual)
                    {

                        if (SessionManager.tiene_permiso(5))
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
                        MessageBox.Show("Error de Digito Verificador");
                        if (SessionManager.tiene_permiso(5))
                        {
                            this.Hide();
                            ErrorDV form = new ErrorDV();
                            form.Show();
                        }
                        else
                        {

                        }
                    }

                }
                else
                {
                    MetroMessageBox.Show(this, "The user is disabled");
                }
            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
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
                if (textBox1.Text == string.Empty || !validar.usuario(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "The username should not have special characters");
                    error++;

                }
                if (textBox2.Text == string.Empty || !validar.contrasena(textBox2.Text))
                {
                    errorProvider1.SetError(textBox2, "You should enter a password with at least 1 number and 5 letters");
                    error++;
                }
                if(error == 0)
                {
                    oUsuraio = new BEUsuario(textBox1.Text, textBox2.Text);
                    if (oLog.validar(oUsuraio))
                    {
                       
                            logIn(textBox1.Text,0);
                      
                        

                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Incorrect user or password");
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
                if (textBox1.Text == string.Empty || !validar.usuario(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "The username should not have special character");
                    error++;

                }
                if (textBox2.Text == string.Empty || !validar.contrasena(textBox2.Text))
                {
                    errorProvider1.SetError(textBox2, "You should enter a password with at least 1 number and 5 letters");
                    error++;
                }

                if (textBox4.Text == string.Empty || !validar.id(textBox4.Text))
                {
                    errorProvider1.SetError(textBox4, "You should enter an id with 1 to 9 numbers");
                    error++;
                }
                if (metroDateTime1.Value == null)
                {
                    errorProvider1.SetError(metroDateTime1, "You should enter a date");
                    error++;
                }

                if(error == 0)
                {
                    if (oLog.usuario_existente(Convert.ToInt32(textBox4.Text))) MessageBox.Show("There is an user with that id already", "ERROR");
                    else
                    {
                        oUsuraio = new BEUsuario(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox4.Text), metroDateTime1.Value.ToString());
                        oUsuraio.DV = GenerarVD.generarDigitoVU(oUsuraio);
                        if (oLog.cargar_usuario(oUsuraio))
                        {
                            
                            actualizarDVSxnewUser(oUsuraio);
                            MetroMessageBox.Show(this, "User created");
                            limpiar();
                            logIn(oUsuraio.user,1);
                        }
                        else
                        {
                            limpiar();
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
       public void actualizarDVSxnewUser(BEUsuario Ousuario)
        {
          
            List<string> ListaDVU = oLog.BuscarUsuariosYgenerarDV();

            OBLLDV.actualizarDV(servicios.GenerarVD.generarDigitoVS(ListaDVU));
          
        }
      
        public void CambiarIdioma(Idioma Idioma)
        {

        }
        private void botonOjo_Click(object sender, EventArgs e)
        {
            
           

            if (ojoOpen == true)
            {
                textBox2.UseSystemPasswordChar = true;
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\ojoCerrado.png");
                botonOjo.Image = imagen;
                ojoOpen = false;

            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\ojoabierto.png");
                botonOjo.Image = imagen;
                ojoOpen = true;
            }
           

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}