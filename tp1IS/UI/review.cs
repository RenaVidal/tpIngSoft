using BE;
using BLL;
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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

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
            try { 
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
            try { 
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
    }
}
