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

namespace UI
{
    public partial class Pay : Form
    {
        public int TotalC;
        
        public Pay(int total)
        {
            InitializeComponent();
            TotalC = total;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        static string qrData;
        private void Pay_Load(object sender, EventArgs e)
        {
          
            label1.Text = TotalC.ToString();
            generarQr(qrData);

        }
       
        

        public void generarQr(string qrData)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            string urlPagoMercadoPago = "https://www.mercadopago.com/link-de-pago";
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(urlPagoMercadoPago, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            pictureBox1.Image = qrCodeImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
