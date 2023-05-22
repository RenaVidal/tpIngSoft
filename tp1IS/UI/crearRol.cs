using BLL;
using MetroFramework;
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
using BE;
using System.Collections;

namespace UI
{
    public partial class crearRol : MetroFramework.Forms.MetroForm
    {
        public crearRol()
        {
            InitializeComponent();
            BLLComposite oComp = new BLLComposite();
            iniciarTreeView();
        }
        BLLComposite oComp = new BLLComposite();

        public void iniciarTreeView() {
            treeView2.Nodes.Clear();
            IList<Componente> list = oComp.GetAll(4);
            TreeNode parent = new TreeNode("Main");
            treeView2.Nodes.Add(parent);
            cargarTreeView(list, parent);
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

        private void crearRol_Load(object sender, EventArgs e)
        {

        }
        public bool recursiva(TreeNode padre, TreeNode original)
        {
            bool se_repite = false;
            try
            {
                if (padre.Parent == null)
                {
                    if (padre.Parent.Text == original.Text)
                    {
                        return true;
                    }
                    else
                    {
                        return recursiva(padre.Parent, original);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return se_repite;
        }
        public bool chequear_padres(System.Windows.Forms.TreeView tree, TreeNode padre)
        {
            bool se_repite = false;
            try
            {
                foreach (TreeNode item in tree.Nodes)
                {
                    if (padre.Parent == null)
                    {
                        return false;
                    }
                    else
                    {
                        if (padre.Text == item.Text)
                        {
                            return true;
                        }
                        else
                        {
                            return recursiva(padre, item);
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return se_repite;
        }
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
       
        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                errorProvider1.SetError(treeView2, "");
                IList<Componente> list = oComp.GetAll(4);
                Componente item = findInList(list, treeView2.SelectedNode.Text);
                if (treeView2.SelectedNode == null)
                {
                    errorProvider1.SetError(treeView2, "Selecciona un permiso para agregar");
                }
               
                else if (item != null && oComp.es_patente(item.Nombre))
                {
                    TreeNode node = new TreeNode(treeView2.SelectedNode.Text);
                    treeView1.Nodes.Add(node);
                }
                else
                {
                    errorProvider1.SetError(treeView2, "Selecciona un permiso no padre");
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }    
        }
        public void cargar_familia()
        {
            try { 
                TreeNodeCollection tree = treeView1.Nodes;
                TreeNode nodoPadre = treeView3.Nodes[0];
                int id_hijo;
                int id_padre;
                int id_abuelo;

                if (nodoPadre != null)
                {
                    Componente componente = new Patente();
                    Componente padre = new Patente();
                    Componente abuelo = new Patente();
                    abuelo.Nombre = nodoPadre.Text;
                    padre.Nombre = textBox1.Text;
                    id_padre = oComp.escribir_retorno_id(padre.Nombre);
                    id_abuelo = oComp.buscar_id(abuelo.Nombre);
                    if (id_abuelo != 0 && id_padre != 0) oComp.escribir_relacion(id_padre, id_abuelo);
                    for (int i = 0; i < tree.Count ; i++)
                    {
                        componente.Nombre = tree[0].Text;
                        id_hijo = oComp.buscar_id(componente.Nombre);
                        if (id_hijo != 0 && id_padre != 0) oComp.escribir_relacion(id_hijo, id_padre);
                        else { MetroMessageBox.Show(this, "Hubo un error guardando los datos, intente nuevamente"); return; }
                    }
                }
                else { MetroMessageBox.Show(this, "Hubo un error guardando los datos, intente nuevamente"); return; }

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

        }
      
        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "");
                errorProvider1.SetError(treeView1, "");
                errorProvider1.SetError(treeView3, "");
                if (treeView1.Nodes == null)
                {
                    errorProvider1.SetError(treeView1, "Debe seleccionar un nodo");
                }
                else if (textBox1.Text == string.Empty || !Regex.IsMatch(textBox1.Text, "^([a-zA-Z]{1,25}$)"))
                {
                    errorProvider1.SetError(textBox1, "Debe ingresar un nombre sin caracteres especiales");
                }
                else if (treeView3.Nodes == null)
                {
                    errorProvider1.SetError(treeView2, "Debe seleccionar un nodo padre");
                }
                else if (findInList(oComp.GetAll(4), textBox1.Text) != null)
                {
                    errorProvider1.SetError(textBox1, "Debe seleccionar un nombre que no exista dentro de los permisos");
                }
                else
                {
                    if (!chequear_padres(treeView1, treeView3.Nodes[0]))
                    {
                        cargar_familia();
                        iniciarTreeView();
                        treeView1.Nodes.Clear();
                        MetroMessageBox.Show(this, "Rol agregado");
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "No es posible agregar este rol");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                errorProvider1.SetError(treeView2, "");
                if (treeView2.SelectedNode == null)
                {
                    errorProvider1.SetError(treeView2, "Seleccione un rol");
                }
                else
                {
                    IList<Componente> list = oComp.GetAll(4);
                    Componente item = findInList(list, treeView2.SelectedNode.Text);
                    if (item != null && !oComp.es_patente(item.Nombre))
                    {
                        TreeNode node = new TreeNode(treeView2.SelectedNode.Text);
                        treeView3.Nodes.Clear();
                        treeView3.Nodes.Add(node);
                    }
                    else
                    {
                        errorProvider1.SetError(treeView2, "Seleccione un rol padre diferente a Main");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
