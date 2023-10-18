using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
        }
        private int ciclo = 0;
        private string[] valores = { ".", "..", "..." };

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = valores[ciclo];
            ciclo = (ciclo + 1) % valores.Length; 
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true; 
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false; 
        }
    }
}
