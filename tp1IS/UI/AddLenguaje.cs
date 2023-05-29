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
using Patrones.Singleton.Core;
using System.Text.RegularExpressions;
using Negocio;
namespace UI
{
    public partial class AddLenguaje : Form
    {
        public AddLenguaje()
        {
            InitializeComponent();
        }

        private void AddLenguaje_Load(object sender, EventArgs e)
        {
            Escondercontroles();
            ListarIdiomas();
            ListarPalabras();
        }

        public void ListarIdiomas()
        {
            comboBox2.Items.Clear();
            BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
            var ListaIdiomas = Traductor.ObtenerIdiomas();

            foreach (Idioma idioma in ListaIdiomas)
            {
                comboBox2.Items.Add(idioma.Nombre);

            }

        }
        public void Escondercontroles()
        {
            metroButton1.Visible = false;
            metroLabel4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            metroButton2.Visible = false;
            metroLabel1.Visible = false;
            metroLabel2.Visible = false;
            metroLabel3.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
        }
        public void ListarPalabras()
        {
            BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
            List<string> ListaPalabras = Traductor.obtenerIdiomaOriginal();
            foreach(string Opalabra in ListaPalabras)
            {
                comboBox1.Items.Add(Opalabra);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                BLLBitacora Obitacora = new BLLBitacora();
                Idioma NewIdioma = new Idioma();
                int error = 0;
                BLL.BLLTraductor Otraductor = new BLL.BLLTraductor();
                // IList<Iidioma> Idiomas = Otraductor.ObtenerIdiomas();
                if (textBox1.Text == string.Empty || !Regex.IsMatch(textBox1.Text, "^([a-zA-Z]{1,25}$)"))
                {
                    errorProvider1.SetError(textBox1, "Debe ingresar un idioma sin caracteres especiales");
                    error++;
                }
                /*if (textBox1.Text == string.Empty || Regex.IsMatch(textBox1.Text, "^([0-9]{1,9}$)"))
                {
                    errorProvider1.SetError(textBox1, "Debe ingresar un id de 1 a 9 numeros");
                    error++;
                }*/

                if (error == 0)
                {
                    if (Otraductor.IdiomaExistente(textBox1.Text)) MessageBox.Show("this language already exists or the id is busy");
                    else
                    {

                        //  NewIdioma.ID = Convert.ToInt32(textBox3.Text);
                        NewIdioma.Nombre = textBox1.Text;
                        NewIdioma.Default = false;
                        
                        Otraductor.CrearIdioma(NewIdioma);

                        MessageBox.Show("Languaje create");
                        textBox1.Text = "";
                        string accion ="creo el idioma: "+NewIdioma.Nombre+" ";
                        Obitacora.guardar_accion(accion);
                    }

                }
                else
                {
                    MessageBox.Show("No se pudo crear el idioma");
                }

                ListarIdiomas();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            BLLBitacora Obitacora = new BLLBitacora();
            try
            {
                int error = 0;
              //  if (textBox1.Text == string.Empty || !Regex.IsMatch(textBox1.Text, "^([a-zA-Z]{1,25}$)"))
                    BLL.BLLTraductor OBLLtraductor = new BLL.BLLTraductor();
                if (textBox2.Text == string.Empty ||  !Regex.IsMatch(textBox2.Text, "^[a-zA-Z\\s]{1,200}$"))
                {
                    errorProvider1.SetError(textBox2, "The translation should not have special characters");
                    error++;
                }
                if (error == 0)
                {
                    string Palabra = comboBox1.SelectedItem.ToString();
                    Palabra Opalbra = new Palabra();
                    Opalbra = OBLLtraductor.TraerPalbra(Palabra);
                    string Idioma = comboBox2.SelectedItem.ToString();
                    Idioma Oidioma = new Idioma();
                    Oidioma = OBLLtraductor.TraerIdioma(Idioma);

                    if (OBLLtraductor.TraduccionExistente(Oidioma.ID, Opalbra.ID)) MessageBox.Show("La traduccion de esa palabra en el idioma elegido ya existe");
                    else
                    {
                        Traduccion Otraduccion = new Traduccion();
                        Otraduccion.texto = textBox2.Text;
                        Otraduccion.Palabra = Opalbra;
                        OBLLtraductor.CrearTraduccion(Oidioma.ID, Otraduccion);
                        string accion = "creo la traduccion: " + Otraduccion.texto + " ";
                        Obitacora.guardar_accion(accion);
                    }

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
          
            //traductor.obtener idioma
            //traductor.obtener. palabra

            //busco en la tabla traduccion si existe una traduccion para el id.idioma y palabra id.idioma
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                metroButton1.Visible = true;
                metroLabel4.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = false;
                metroButton2.Visible = false;
                metroLabel1.Visible = false;
                metroLabel2.Visible = false;
                metroLabel3.Visible = false;
                comboBox1.Visible = false;
                comboBox2.Visible = false;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                metroButton1.Visible = false;
                metroLabel4.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = true;
                metroButton2.Visible = true;
                metroLabel1.Visible = true;
                metroLabel2.Visible = true;
                metroLabel3.Visible = true;
                comboBox1.Visible = true;
                comboBox2.Visible = true;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idiomaSelec = comboBox1.SelectedItem.ToString();
            BLL.BLLTraductor traductor = new BLL.BLLTraductor();
            Idioma Oidioma = new Idioma();
            Oidioma = traductor.TraerIdioma(idiomaSelec);
            servicios.Observer.cambiarIdioma(Oidioma);
        }
    }
}
