﻿using BE;
using MetroFramework;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class borrarPassword : MetroFramework.Forms.MetroForm
    {
        public borrarPassword()
        {
            InitializeComponent();
        }

        private void borrarPassword_Load(object sender, EventArgs e)
        {

        }
        BLLUsuario oLog = new BLLUsuario();
        BEUsuario oUsuraio;
        BLLBitacora oBit = new BLLBitacora();
        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var error = 0;
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "");
                errorProvider1.SetError(textBox2, "");
                if (textBox1.Text == string.Empty || !Regex.IsMatch(textBox1.Text, "^([0-9]{1,9}$)"))
                {
                    errorProvider1.SetError(textBox1, "Debe ingresar un id de 1 a 9 numeros");
                    error++;
                }
                if (textBox2.Text == string.Empty || !Regex.IsMatch(textBox2.Text, "^([a-zA-Z]{5,15})([1-9]{1,10}$)"))
                {
                    errorProvider1.SetError(textBox2, "Debe ingresar una contraseña de 1 a 10 numeros y 5-15 letras");
                    error++;
                }
                if (error == 0)
                {
                    if (oLog.usuario_existente(Convert.ToInt32( textBox1.Text)))
                    {

                        if (oLog.cambiar_contrasena(Convert.ToInt32( textBox1.Text), textBox2.Text))
                        {
                            var accion = "cambio la contraseña del usuario de id" + textBox1.Text;
                            oBit.guardar_accion(accion);
                            MetroMessageBox.Show(this, "Contrasena modificada");
                            this.Hide();
                        }
                        else MetroMessageBox.Show(this, "Ocurrio un error");
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Usuario inexistente o deshabilitado ");
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
