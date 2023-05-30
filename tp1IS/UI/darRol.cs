using BE;
using BLL;
using MetroFramework;
using Negocio;
using Patrones.Singleton.Core;
using servicios;
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
            iniciarTreeView();
            resetControls();
        } 
        BLLBitacora oBit = new BLLBitacora();
        validaciones validar = new validaciones();
        public void resetControls()
        {
            comboBox1.SelectedIndex = -1; comboBox2.SelectedIndex = -1;
            treeView2.Nodes[0].TreeView.SelectedNode = null;
            treeView2.SelectedNode = null;
        }
        public void iniciarTreeView()
        {
            treeView2.Nodes.Clear();
            IList<Componente> lista = oComp.GetFamilias();
            IList<Componente> cada_Flia;
            TreeNode padre = new TreeNode("Main");
            TreeNode familia;
            foreach (Componente comp in lista)
            {
                cada_Flia = oComp.GetAll(comp.Id);
                familia = new TreeNode(comp.Nombre);

                cargarTreeView(cada_Flia, familia);
                padre.Nodes.Add(familia);
            }
            treeView2.Nodes.Add(padre);

        }

        public void cargarTreeView(IList<Componente> list, TreeNode parentNode)
        {
            foreach (var item in list)
            {
                TreeNode newNode = new TreeNode(item.Nombre);
                parentNode.Nodes.Add(newNode);
                if (item.Hijos != null && item.Hijos.Count != 0) cargarTreeView(item.Hijos, newNode);
            }
        }
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
                    errorProvider1.SetError(treeView2, "Select a role");
                }
                if (textBox1.Text == string.Empty || !validar.id(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "You should enter an id with 1 to 9 numbers");
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
                    if (oLog.usuario_existente(Convert.ToInt32(textBox1.Text)) && (itemFamilia != null || itemPatente != null)) { 
                        if(itemPatente != null)
                        {
                            var accion = "dio al usuario " + textBox1.Text + " el permiso " + itemPatente.Id.ToString();
                            oBit.guardar_accion(accion);
                            if (!oLog.tiene_rol(Convert.ToInt32(textBox1.Text), itemPatente.Id))
                            {
                                if (oLog.agregar_rol(Convert.ToInt32(textBox1.Text), itemPatente.Id)) MetroMessageBox.Show(this, "rol asignado");
                            }
                        else MetroMessageBox.Show(this, "Selected user already has that rol");


                    }
                        else if(itemFamilia != null)
                        {
                            var accion = "dio al usuario " + textBox1.Text + " el rol " + itemFamilia.Id.ToString();
                            oBit.guardar_accion(accion);
                            if (!oLog.tiene_rol(Convert.ToInt32(textBox1.Text), itemFamilia.Id))
                            {
                                if (oLog.agregar_rol(Convert.ToInt32(textBox1.Text), itemFamilia.Id)) MetroMessageBox.Show(this, "rol asignado");
                            }
                        else MetroMessageBox.Show(this, "Selected user already has that rol");
                    }
                        
                        else MetroMessageBox.Show(this, "Error, try again");


                    }
                    else
                    {
                        errorProvider1.SetError(treeView2, "Select a father role different from main");
                    }
                resetControls();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        SessionManager u = SessionManager.GetInstance;
        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                
                errorProvider1.Clear();
                errorProvider1.SetError(treeView2, "");
                errorProvider1.SetError(textBox1, "");
                if (treeView2.SelectedNode == null && comboBox1.SelectedIndex == -1 && comboBox2.SelectedIndex == -1)
                {
                    errorProvider1.SetError(treeView2, "Select a role to delete");
                }
                if (textBox1.Text == string.Empty || !validar.id(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "You should enter an id with 1 to 9 numbers");
                }
                if (u.Usuario.id == Convert.ToInt32(textBox1.Text)) errorProvider1.SetError(treeView2, "You can not delete roles from yourself");
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
                    if (oLog.usuario_existente(Convert.ToInt32(textBox1.Text)) && (itemFamilia != null || itemPatente != null))
                    {
                        if (itemPatente != null)
                        {
                            var accion = "desasigno al usuario " + textBox1.Text + " el permiso " + itemPatente.Id.ToString();
                            //oBit.guardar_accion(accion);
                            if (oLog.borrar_rol(Convert.ToInt32(textBox1.Text), itemPatente.Id)) MetroMessageBox.Show(this, "Role unasigned");
                            else MetroMessageBox.Show(this, "Role not found asigned to user");
                        }
                        else if (itemFamilia != null)
                        {
                            var accion = "desasigno al usuario " + textBox1.Text + " el rol " + itemFamilia.Id.ToString();
                            //oBit.guardar_accion(accion);
                            if (oLog.borrar_rol(Convert.ToInt32(textBox1.Text), itemFamilia.Id)) MetroMessageBox.Show(this, "Role unasigned");
                            else MetroMessageBox.Show(this, "Role not found asigned to user");

                        }

                        else MetroMessageBox.Show(this, "Error, try again");


                    }
                resetControls();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
