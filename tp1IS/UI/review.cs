using BLL;
using MetroFramework;
using Negocio;
using Patrones.Singleton.Core;
using servicios.ClasesMultiLenguaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class review : Form
    {
        public int BalnearioID;
        public review(int bID)
        {
            InitializeComponent();
            BalnearioID = bID;
        }
        int set = 0;
        int score = 0;
        BLLBitacora oBit = new BLLBitacora();
        SessionManager session = SessionManager.GetInstance;

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                PictureBox pictureBox = sender as PictureBox;
                int rating = Convert.ToInt32(pictureBox.Tag);
                for (int i = 1; i <= 5; i++)
                {
                    PictureBox star = panel1.Controls["pictureBox" + i.ToString()] as PictureBox;
                    if (i <= rating)
                    {
                        star.BackgroundImage = Properties.Resources.star;
                        star.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else
                    {
                        star.BackgroundImage = Properties.Resources.estar;
                        star.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                }
                set = 1;
                score = rating;
            }
            catch (NullReferenceException ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }

        }
        //private void review_FormClosing(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        servicios.Observer.eliminarObservador(this);

        //    }
        //    catch (NullReferenceException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                if (set == 0)
                {
                    PictureBox pictureBox = sender as PictureBox;
                    int rating = Convert.ToInt32(pictureBox.Tag);

                    for (int i = 1; i <= rating; i++)
                    {
                        PictureBox star = panel1.Controls["pictureBox" + i.ToString()] as PictureBox;
                        if (i <= rating)
                        {
                            star.BackgroundImage = Properties.Resources.star;
                            star.BackgroundImageLayout = ImageLayout.Zoom;
                        }
                        else
                        {
                            star.BackgroundImage = Properties.Resources.estar;
                            star.BackgroundImageLayout = ImageLayout.Zoom;
                        }
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }

        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (set == 0)
                {
                    PictureBox pictureBox = sender as PictureBox;
                    int rating = Convert.ToInt32(pictureBox.Tag);
                    for (int i = 1; i <= rating; i++)
                    {
                        PictureBox star = panel1.Controls["pictureBox" + i.ToString()] as PictureBox;
                        star.BackgroundImage = Properties.Resources.estar;
                        star.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string message = string.Empty;
                int stars = score;
                if (richTextBox1.Text != string.Empty)
                {
                    message = richTextBox1.Text;
                }
                if (score == 0)
                {
                    DialogResult resultado = MetroMessageBox.Show(this, "Are you sure you will rate this resort 0 stars?", "Confirm", MessageBoxButtons.YesNo);
                    if (resultado == DialogResult.Yes)
                    {
                        stars = 0;
                    }
                    else if (resultado == DialogResult.No)
                    {
                        return;
                    }
                }
                BLLBalneario oBAl = new BLLBalneario();
                oBAl.crear_feedback(BalnearioID, session.Usuario.id, message, DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null), stars);
                this.Close();
            }
            catch (NullReferenceException ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                var accion = ex.Message;
                oBit.guardar_accion(accion, 1);
                MessageBox.Show(ex.Message);
            }
        }

        private void review_Load(object sender, EventArgs e)
        {
           
        }

      

       

    //private void traducir()
    //{
    //    try
    //    {
    //        BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
    //        Idioma Idioma = null;


    //        Idioma = Traductor.TraerIdioma(comboBox1.SelectedItem.ToString());
    //        if (Idioma.Nombre == "Ingles")
    //        {
    //            VolverAidiomaOriginal();
    //        }
    //        else
    //        {



    //            var traducciones = Traductor.obtenertraducciones(Idioma);
    //            List<string> Lista = new List<string>();
    //            Lista = Traductor.obtenerIdiomaOriginal();
    //            if (traducciones.Values.Count != Lista.Count)
    //            {

    //            }
    //            else
    //            {

    //                if (this.Tag != null && traducciones.ContainsKey(this.Tag.ToString()))
    //                {
    //                    this.Text = traducciones[this.Tag.ToString()].texto;
    //                }
    //                if (button1.Tag != null && traducciones.ContainsKey(button1.Tag.ToString()))
    //                {
    //                    this.button1.Text = traducciones[button1.Tag.ToString()].texto;
    //                }
    //                if (label2.Tag != null && traducciones.ContainsKey(label2.Tag.ToString()))
    //                {
    //                    this.label2.Text = traducciones[label2.Tag.ToString()].texto;
    //                }
    //                if (label3.Tag != null && traducciones.ContainsKey(label3.Tag.ToString()))
    //                {
    //                    this.label3.Text = traducciones[label3.Tag.ToString()].texto;
    //                }
    //            }

    //        }

    //    }
    //    catch (NullReferenceException ex)
    //    {
    //        MessageBox.Show(ex.Message);
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(ex.Message);
    //    }

    //}

    //private void VolverAidiomaOriginal()
    //{
    //    try
    //    {

    //        BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
    //        List<string> palabras = Traductor.obtenerIdiomaOriginal();


    //        if (this.Tag != null && palabras.Contains(this.Tag.ToString()))
    //        {
    //            string traduccion = palabras.Find(p => p.Equals(this.Tag.ToString()));
    //            this.Text = traduccion;
    //        }
    //        if (button1.Tag != null && palabras.Contains(button1.Tag.ToString()))
    //        {
    //            string traduccion = palabras.Find(p => p.Equals(button1.Tag.ToString()));
    //            this.button1.Text = traduccion;
    //        }
    //        if (label2.Tag != null && palabras.Contains(label2.Tag.ToString()))
    //        {
    //            string traduccion = palabras.Find(p => p.Equals(label2.Tag.ToString()));
    //            this.label2.Text = traduccion;
    //        }
    //        if (label3.Tag != null && palabras.Contains(label3.Tag.ToString()))
    //        {
    //            string traduccion = palabras.Find(p => p.Equals(label3.Tag.ToString()));
    //            this.label3.Text = traduccion;
    //        }


    //    }
    //    catch (NullReferenceException ex)
    //    {
    //        MessageBox.Show(ex.Message);
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(ex.Message);
    //    }

    //}
}
}
