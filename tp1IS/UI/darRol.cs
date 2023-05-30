using BE;
using BLL;
using MetroFramework;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class darRol : MetroFramework.Forms.MetroForm
    {
        public darRol()
        {
            InitializeComponent();
            llenarComboBox();
        } 
        BLLBitacora oBit = new BLLBitacora();
        public void llenarComboBox()
        {
            IList<Componente> lista = oComp.GetFamilias();
            List<string> familias = new List<string>();
            foreach (Componente componente in lista)
            {
                familias.Add(componente.Nombre);
            }
            comboBox2.DataSource = familias;
            IList<Componente> lista2 = oComp.GetPermisos();
            List<string> permisos = new List<string>();
            foreach (Componente componente in lista2)
            {
                permisos.Add(componente.Nombre);
            }
            comboBox1.DataSource = permisos;
        }
        private void darRol_Load(object sender, EventArgs e)
        {

        }
        BLLComposite oComp = new BLLComposite();
        BLLUsuario oLog = new BLLUsuario();
        public Componente findInList(IList<Componente> list, string nombre)
        {
            Componente encontrado = null;
            foreach (Componente item in list)
            {
                if (item != null)
                {
                    if (item.Nombre == nombre) return item;
                    if (item.Hijos != null) encontrado = findInList(item.Hijos, nombre);
                    if (encontrado != null)
                    {
                        return encontrado;
                    }
                }

            }
            return null;
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                errorProvider1.SetError(treeView2, "");
                errorProvider1.SetError(textBox1, "");
                if (treeView2.SelectedNode == null && comboBox1.SelectedIndex == -1 && comboBox2.SelectedIndex == -1) 
                {
                    errorProvider1.SetError(treeView2, "Seleccione un rol o permiso para asignar");
                }
                if (textBox1.Text == string.Empty || !Regex.IsMatch(textBox1.Text, "^([0-9]{1,9}$)"))
                {
                    errorProvider1.SetError(textBox1, "Debe ingresar un id de 1 a 9 numeros");
                }
                IList<Componente> listFam = oComp.GetFamilias();
                IList<Componente> listPer = oComp.GetPermisos();
                Componente itemPatente = null;
                Componente itemFamilia = null;
                if (treeView2.SelectedNode != null)
                {
                    itemPatente = findInList(listPer, treeView2.SelectedNode.Text);
                    itemFamilia = findInList(listFam, treeView2.SelectedNode.Text);
                }
                else if (comboBox1.SelectedIndex != -1)
                {
                    itemPatente = findInList(listPer, comboBox1.SelectedItem.ToString());
                }
                else if (comboBox2.SelectedIndex != -1)
                {
                    itemFamilia = findInList(listFam, comboBox2.SelectedItem.ToString());
                }
               
                else
                {
                    if (oLog.usuario_existente(Convert.ToInt32(textBox1.Text)) && (itemFamilia != null || itemPatente != null)) { 
                        if(itemPatente != null)
                        {
                            var accion = "dio al usuario " + textBox1.Text + " el permiso " + itemPatente.Id.ToString();
                            oBit.guardar_accion(accion);
                            if (oLog.cambiar_rol(Convert.ToInt32(textBox1.Text), itemPatente.Id)) MetroMessageBox.Show(this, "rol asignado");
                        }
                        else if(itemFamilia != null)
                        {
                            var accion = "dio al usuario " + textBox1.Text + " el rol " + itemFamilia.Id.ToString();
                            oBit.guardar_accion(accion);
                            if (oLog.cambiar_rol(Convert.ToInt32(textBox1.Text), itemFamilia.Id)) MetroMessageBox.Show(this, "rol asignado");
                        }
                        
                        else MetroMessageBox.Show(this, "No pudo asignarse el rol, intente nuevamente");


                    }
                    else
                    {
                        errorProvider1.SetError(treeView2, "Seleccione un rol padre diferente a Main");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider1.SetError(textBox1, "");
            if (textBox1.Text == string.Empty || !Regex.IsMatch(textBox1.Text, "^([0-9]{1,9}$)"))
            {
                errorProvider1.SetError(textBox1, "Debe ingresar un id de 1 a 9 numeros");
            }
            else
            {
                if (oLog.usuario_existente(Convert.ToInt32(textBox1.Text))){
                    var accion = "desasigno el rol del usuario " + textBox1.Text;
                    oBit.guardar_accion(accion);
                    if (oLog.borrar_rol(Convert.ToInt32(textBox1.Text))) MetroMessageBox.Show(this, "Rol desasignado");
                    else MetroMessageBox.Show(this, "No pudo desasignarse el rol, intente nuevamente");
                }
            }
        }
    }
}
