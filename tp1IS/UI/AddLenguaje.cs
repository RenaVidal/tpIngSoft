﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using servicios.ClasesMultiLenguaje;
using System.Text.RegularExpressions;
using Patrones.Singleton.Core;
using Negocio;
using BLL;

namespace UI
{
    public partial class AddLenguaje : MetroFramework.Forms.MetroForm, IdiomaObserver
    {
        BLLBitacora oBit = new BLLBitacora();
        public AddLenguaje()
        {
            InitializeComponent();
        }
        BLLTraductor Otraductor = new BLLTraductor();
        servicios.validaciones validar = new servicios.validaciones();
        private void AddLenguaje_Load(object sender, EventArgs e)
        {
            try
            {
                servicios.Observer.agregarObservador(this);
                Escondercontroles();
                ListarIdiomas();
                ListarPalabras();
                Traducir();
            }
            catch(Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
           
        }
        private void AddLenguaje_FormClosing(object sender, EventArgs e)
        {
            servicios.Observer.eliminarObservador(this);
        }
        public void ListarIdiomas()
        {
            try
            {
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
                var ListaIdiomas = Traductor.ObtenerIdiomas();

                foreach (Idioma idioma in ListaIdiomas)
                {
                    if (idioma.Nombre == "ingles")
                    {

                    }
                    else
                    {
                        comboBox2.Items.Add(idioma.Nombre);
                    }
                    
                    comboBox3.Items.Add(idioma.Nombre);

                }
            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
           

        }
        public void Escondercontroles()
        {

            try
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
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
          
        }
        public void ListarPalabras()
        {

            try
            {

                BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
                List<string> ListaPalabras = Traductor.obtenerIdiomaOriginal();
                foreach (string Opalabra in ListaPalabras)
                {
                    comboBox1.Items.Add(Opalabra);
                }
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
            try
            {
                BLLBitacora Obitacora = new BLLBitacora();
                Idioma NewIdioma = new Idioma();
                int error = 0;
                BLL.BLLTraductor Otraductor = new BLL.BLLTraductor();
                if (textBox1.Text == string.Empty || !(validar.usuario(textBox1.Text)))
                {
                    errorProvider1.SetError(textBox1, "Debe ingresar un idioma sin caracteres especiales");
                    error++;
                }

                if (error == 0)
                {
                    if (Otraductor.IdiomaExistente(textBox1.Text)) MessageBox.Show("this language already exists or the id is busy");
                    else
                    {
                        NewIdioma.Nombre = textBox1.Text;
                        NewIdioma.Default = false;

                        Otraductor.CrearIdioma(NewIdioma);

                        MessageBox.Show("Languaje create");
                        textBox1.Text = "";
                        string accion = "creo el idioma: " + NewIdioma.Nombre + " ";
                        Obitacora.guardar_accion(accion,2);
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
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }


        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            BLLBitacora Obitacora = new BLLBitacora();
            try
            {
                int error = 0;
                BLL.BLLTraductor OBLLtraductor = new BLL.BLLTraductor();
                if (textBox2.Text == string.Empty || !validar.traduccion(textBox2.Text))
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
                        Obitacora.guardar_accion(accion,2);
                        MessageBox.Show("you create new traduccion in lenguaje" +Oidioma.Nombre);
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {


            try
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
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
          
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string idiomaSelec = comboBox3.SelectedItem.ToString();
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

        public void Traducir()
        {
            try
            {
                Idioma Idioma = null;

                if (SessionManager.TraerUsuario())
                    Idioma = SessionManager.GetInstance.idioma;
                if (Idioma.Nombre == "ingles")
                {

                    VolverAIdiomaoriginal();
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
                        if (metroButton2.Tag != null && traducciones.ContainsKey(metroButton2.Tag.ToString()))
                        {
                            this.metroButton2.Text = traducciones[metroButton2.Tag.ToString()].texto;
                        }
                        if (metroLabel1.Tag != null && traducciones.ContainsKey(metroLabel1.Tag.ToString()))
                        {
                            this.metroLabel1.Text = traducciones[metroLabel1.Tag.ToString()].texto;
                        }
                        if (metroLabel2.Tag != null && traducciones.ContainsKey(metroLabel2.Tag.ToString()))
                        {
                            this.metroLabel2.Text = traducciones[metroLabel2.Tag.ToString()].texto;
                        }
                        if (metroLabel3.Tag != null && traducciones.ContainsKey(metroLabel3.Tag.ToString()))
                        {
                            this.metroLabel3.Text = traducciones[metroLabel3.Tag.ToString()].texto;
                        }
                        if (metroLabel4.Tag != null && traducciones.ContainsKey(metroLabel4.Tag.ToString()))
                        {
                            this.metroLabel4.Text = traducciones[metroLabel4.Tag.ToString()].texto;
                        }
                        if (radioButton1.Tag != null && traducciones.ContainsKey(radioButton1.Tag.ToString()))
                        {
                            this.radioButton1.Text = traducciones[radioButton1.Tag.ToString()].texto;
                        }
                        if (radioButton2.Tag != null && traducciones.ContainsKey(radioButton2.Tag.ToString()))
                        {
                            this.radioButton2.Text = traducciones[radioButton2.Tag.ToString()].texto;
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
        private void metroButton3_Click(object sender, EventArgs e)
        {


            try
            {
                dataGridView1.DataSource = null;

                servicios.ClasesMultiLenguaje.Idioma Oidioma = Otraductor.TraerIdioma(comboBox2.SelectedItem.ToString());


                dataGridView1.DataSource = Otraductor.traerTablaxIdioma(Oidioma.ID);
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Columns["IDidioma"].Visible = false;
                dataGridView1.Columns["ID"].Visible = false;


            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
           

        }
        public void VolverAIdiomaoriginal()
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
                if (metroLabel3.Tag != null && palabras.Contains(metroLabel3.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(metroLabel3.Tag.ToString()));
                    this.metroLabel3.Text = traduccion;
                }
                if (metroLabel4.Tag != null && palabras.Contains(metroLabel4.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(metroLabel4.Tag.ToString()));
                    this.metroLabel4.Text = traduccion;
                }
                if (radioButton1.Tag != null && palabras.Contains(radioButton1.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(radioButton1.Tag.ToString()));
                    this.radioButton1.Text = traduccion;
                }
                if (radioButton2.Tag != null && palabras.Contains(radioButton2.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(radioButton2.Tag.ToString()));
                    this.radioButton2.Text = traduccion;
                }

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

