using BE;
using Negocio;
using servicios;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
        }
        public void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
                {
                    throw new Exception();
                }
                oUsuraio = new BEUsuario(Servicios.Encriptar(textBox1.Text), Servicios.Encriptar(textBox2.Text));
                if (oLog.validar(oUsuraio))
                {
                    limpiar();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(" Usuario o contraseña incorrecta ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox2.Text == string.Empty || textBox4.Text == string.Empty || metroDateTime1.Value == null)
                {
                    throw new Exception();
                }
                bool respuesta = Regex.IsMatch(textBox1.Text, "^([a-zA-Z0-9]{1,25}$)") && Regex.IsMatch(textBox2.Text, "^([a-zA-Z]{5,15})([1-9]{1,10}$)");
                bool respuestaID = Regex.IsMatch(textBox4.Text, "^([0-9]{1,9}$)");
                if (respuesta == false)
                {
                    MessageBox.Show("La contraseña debe poseer al menos un numero y 5 letras, el usuario no debe poseer caracteres especiales", "ERROR");
                }
                else if(respuestaID == false)
                {
                    MessageBox.Show("El ID deben ser de 1 a 9 numeros", "ERROR");
                }
                else
                {
                    oUsuraio = new BEUsuario(Servicios.Encriptar(textBox1.Text), Servicios.Encriptar(textBox2.Text));
                    if (oLog.cargar_usuario(oUsuraio))
                    {
                        MessageBox.Show("Usuario creado");
                        limpiar();
                    }
                    else
                    {
                        limpiar();
                        MessageBox.Show("Ocurrio un error");
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