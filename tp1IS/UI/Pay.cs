using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using QRCoder;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Xml.Linq;
using Negocio;
using servicios.ClasesMultiLenguaje;
using Patrones.Singleton.Core;

namespace UI
{
    public partial class Pay : Form, IdiomaObserver
    {
        public int TotalC;
        BLLBitacora oBit = new BLLBitacora();
        public Pay(int total)
        {
            InitializeComponent();
            TotalC = total;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        static string qrData;
        public void CambiarIdioma(Idioma Idioma)
        {
            traducir();
        }

        private void Pay_Load(object sender, EventArgs e)
        {
            try
            {
                servicios.Observer.agregarObservador(this);
                label1.Text = TotalC.ToString();
                generarQr(qrData);
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
        void VolverAidiomaOriginal()
        {
            try
            {
                BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
                palabras = Traductor.obtenerIdiomaOriginal();

                RecorrerPanel(this, 2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        Dictionary<string, Traduccion> traducciones = new Dictionary<string, Traduccion>();
        List<string> palabras = new List<string>();
        void RecorrerPanel(Control panel, int v)
        {
            foreach (Control control in panel.Controls)
            {
                if (v == 1)
                {

                    if (control.Tag != null && traducciones.ContainsKey(control.Tag.ToString()))
                    {
                        control.Text = traducciones[control.Tag.ToString()].texto;
                    }
                }
                else
                {
                    if (control.Tag != null && palabras.Contains(control.Tag.ToString()))
                    {
                        string traduccion = palabras.Find(p => p.Equals(control.Tag.ToString()));
                        control.Text = traduccion;
                    }
                }

            }
        }
        void traducir()
        {
            try
            {
                Idioma Idioma = null;

                if (SessionManager.TraerUsuario())
                    Idioma = SessionManager.GetInstance.idioma;
                if (Idioma.Nombre == "Ingles")
                {
                    VolverAidiomaOriginal();
                }
                else
                {
                    BLL.BLLTraductor Traductor = new BLL.BLLTraductor();


                    traducciones = Traductor.obtenertraducciones(Idioma);
                    List<string> Lista = new List<string>();
                    Lista = Traductor.obtenerIdiomaOriginal();
                    if (traducciones.Values.Count != Lista.Count)
                    {

                    }
                    else
                    {
                        RecorrerPanel(this, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void generarQr(string qrData)
        {
            try { 
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                string urlPagoMercadoPago = "https://www.mercadopago.com/link-de-pago";
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(urlPagoMercadoPago, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                pictureBox1.Image = qrCodeImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
