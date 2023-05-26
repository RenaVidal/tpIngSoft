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
using abstraccion;
using Patrones.Singleton.Core;
using System.Text.RegularExpressions;
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
            Idioma NewIdioma = new Idioma();
            int error = 0;
            BLL.BLLTraductor Otraductor = new BLL.BLLTraductor();
            // IList<Iidioma> Idiomas = Otraductor.ObtenerIdiomas();
            if (textBox1.Text == string.Empty || !Regex.IsMatch(textBox1.Text, "^([a-zA-Z]{1,25}$)"))
            {
                errorProvider1.SetError(textBox1, "Debe ingresar un idioma sin caracteres especiales");
                error ++;
            }
            if (textBox1.Text == string.Empty || Regex.IsMatch(textBox1.Text, "^([0-9]{1,9}$)"))
            {
                errorProvider1.SetError(textBox1, "Debe ingresar un id de 1 a 9 numeros");
                error++;
            }

            if (error == 0)
            {
                if (Otraductor.IdiomaExistente(Convert.ToInt32(textBox3.Text), textBox1.Text)) MessageBox.Show("this language already exists or the id is busy");
                else
                {

                    NewIdioma.ID = Convert.ToInt32(textBox3.Text);
                    NewIdioma.Nombre = textBox1.Text;
                    NewIdioma.Default = false;

                    Otraductor.CrearIdioma(NewIdioma);

                    MessageBox.Show("Languaje create");
                    textBox1.Text = "";
                    textBox3.Text = "";
                }

            }
            else
            {
                MessageBox.Show("No se pudo crear el idioma");
            }

            ListarIdiomas();

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            BLL.BLLTraductor OBLLtraductor = new BLL.BLLTraductor();
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
            }


            //traductor.obtener idioma
            //traductor.obtener. palabra

            //busco en la tabla traduccion si existe una traduccion para el id.idioma y palabra id.idioma
        }
    }
}
