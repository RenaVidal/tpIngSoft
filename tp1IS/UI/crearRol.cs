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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Negocio;
using System.Security.Cryptography.X509Certificates;

namespace UI
{
    public partial class crearRol : MetroFramework.Forms.MetroForm
    {
        public crearRol()
        {
            InitializeComponent();
            BLLComposite oComp = new BLLComposite();
            iniciarTreeView();
            llenarComboBox();
            resetControls();
        }
        BLLComposite oComp = new BLLComposite();
        BLLBitacora oBit = new BLLBitacora();
        public void resetControls()
        {
            comboBox1.SelectedIndex = -1; comboBox2.SelectedIndex = -1;
            treeView2.Nodes[0].TreeView.SelectedNode = null;
            treeView2.SelectedNode = null;
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
        public void iniciarTreeView() {
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

        private void crearRol_Load(object sender, EventArgs e)
        {

        }
       
        public Componente findInList(IList<Componente> list, string nombre)
        {
            Componente encontrado = null;
            foreach (Componente item in list)
            {
                if (item != null)
                {
                    if (item.Nombre == nombre) return item;
                    //if (item.Hijos != null) encontrado = findInList(item.Hijos, nombre);
                    if (encontrado != null)
                    {
                        return encontrado;
                    }
                }
               
            }
            return null;
        }
        public bool noRepite(Componente item)
        {
            foreach(TreeNode node in treeView1.Nodes)
            {
                if(node.Text == item.Nombre) return false;
            }
            return true;
        }
       
        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                errorProvider1.SetError(metroButton1, "");
                if (treeView2.SelectedNode == null && comboBox1.SelectedIndex == -1 && comboBox2.SelectedIndex == -1)
                {
                    errorProvider1.SetError(metroButton1, "Selecciona un permiso o rol para agregar");
                }
                IList<Componente> listFam = oComp.GetFamilias();
                IList<Componente> listPer = oComp.GetPermisos();
                Componente itemPatente = null;
                Componente itemFamilia = null;
               if(treeView2.SelectedNode != null)
                {
                     itemPatente = findInList(listPer, treeView2.SelectedNode.Text); 
                     itemFamilia = findInList(listFam, treeView2.SelectedNode.Text);
                }
               else if(comboBox1.SelectedIndex != -1)
                {
                    itemPatente = findInList(listPer, comboBox1.SelectedItem.ToString());
                }
               else if(comboBox2.SelectedIndex != -1)
                {
                    itemFamilia = findInList(listFam, comboBox2.SelectedItem.ToString());
                }
                
                if (itemPatente != null)
                {
                    if (noRepite(itemPatente))
                    {
                        TreeNode node = new TreeNode(itemPatente.Nombre);
                        treeView1.Nodes.Add(node);
                    }
                    else
                    {
                        errorProvider1.SetError(metroButton1, "No debe agregar roles o permisos repetidos");
                    }
                }
                else if (itemFamilia != null)
                {
                    if (noRepite(itemFamilia))
                    {
                        TreeNode node = new TreeNode(itemFamilia.Nombre);
                        treeView1.Nodes.Add(node);
                    }
                    else
                    {
                        errorProvider1.SetError(metroButton1, "No debe agregar roles o permisos repetidos");
                    }
                    
                }
                else
                {
                    MetroMessageBox.Show(this, "Ocurrio un problema agregando el rol, seleccione un rol o permiso diferente de main");
                }
                resetControls();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }    
        }
        public bool contiene(Componente padre, Componente Hijo)
        {
            foreach( Componente comp in padre.Hijos)
            {
                if (comp.Nombre == Hijo.Nombre) return true;
                else if(comp.Hijos != null) return contiene(comp, Hijo);
            }
            return false;
        }
        public Componente llenar_padre(Componente padre)
        {
            IList<Componente> HijosFamilia = oComp.GetAll(padre.Id);


            foreach (var item in HijosFamilia)
            {
                padre.AgregarHijo(item);
            }

            return padre;
        }
        public bool evitar_loop(Componente padre, Componente hijo)
        {
            padre = llenar_padre(padre);
            hijo = llenar_padre(hijo);
            if (padre.Nombre == hijo.Nombre) return true;
            else return (padre.Hijos.Contains(hijo) || contiene(hijo, padre));

        }
        public bool cargar_familia()
        {
            try { 
                TreeNodeCollection tree = treeView1.Nodes;
                TreeNode nodoPadre = treeView3.Nodes[0];
                int id_hijo;
                int id_padre;
                int id_abuelo;
                IList<Componente> listFam = oComp.GetFamilias();
                IList<Componente> listPer = oComp.GetPermisos();
                Componente abuelo = findInList(listFam, nodoPadre.Text);
                Componente hijoPer = null;
                Componente hijoFam = null;
                foreach (TreeNode comp in tree) //if padre does not have hijos and hijos does not have padres its all good
                {
                    hijoFam = findInList(listFam, comp.Text);
                    hijoPer =findInList(listPer, comp.Text);
                    if(hijoFam != null) {
                        if (evitar_loop(abuelo, hijoFam)) {
                            MetroMessageBox.Show(this, "esta accion no es posible");
                            return false; 
                        }
                    }
                    else if(hijoPer != null)
                    {
                        if (evitar_loop(abuelo, hijoPer)) {
                            MetroMessageBox.Show(this, "esta accion no es posible");
                            return false; 
                        }
                    }
                    
                }

                if (nodoPadre != null)
                {
                    Componente componente = new Patente();
                    Componente padre = new Patente();
                    padre.Nombre = textBox1.Text;
                    id_padre = oComp.escribir_retorno_id(padre.Nombre);
                    id_abuelo = abuelo.Id;
                    if (id_abuelo != 0 && id_padre != 0) oComp.escribir_relacion(id_padre, id_abuelo);
                    for (int i = 0; i < tree.Count ; i++)
                    {
                        componente.Nombre = tree[0].Text;
                        id_hijo = oComp.buscar_id(componente.Nombre);
                        if (id_hijo != 0 && id_padre != 0) oComp.escribir_relacion(id_hijo, id_padre);
                        else { MetroMessageBox.Show(this, "Hubo un error guardando los datos, intente nuevamente"); return false; }
                    }
                }
                else { MetroMessageBox.Show(this, "Hubo un error guardando los datos, intente nuevamente"); return false; }

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            return true;

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
                else if (findInList(oComp.GetFamilias(), textBox1.Text) != null || findInList(oComp.GetPermisos(), textBox1.Text) != null)
                {
                    errorProvider1.SetError(textBox1, "Debe seleccionar un nombre que no exista dentro de los permisos");
                }
                else
                {
                        var accion = "creo el rol " + textBox1.Text;
                        //oBit.guardar_accion(accion);  //ACA SACAR EL COMENTADO
                        if (cargar_familia())
                        {
                            iniciarTreeView();
                            treeView1.Nodes.Clear();
                            MetroMessageBox.Show(this, "Rol agregado");
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "Ocurrio un error");
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
                Componente itemFamilia = null;

                if (treeView2.SelectedNode == null && comboBox2.SelectedIndex == -1)
                {
                    errorProvider1.SetError(treeView2, "Seleccione un rol");
                }
                else
                {
                    IList<Componente> listFam = oComp.GetFamilias();
                    if (treeView2.SelectedNode != null)
                    {
                        itemFamilia = findInList(listFam, treeView2.SelectedNode.Text);
                    }
                    else if (comboBox2.SelectedIndex != -1)
                    {
                        itemFamilia = findInList(listFam, comboBox2.SelectedItem.ToString());
                    }
                    
                    if (itemFamilia != null && !oComp.es_patente(itemFamilia.Nombre))
                    {
                        TreeNode node = new TreeNode(itemFamilia.Nombre);
                        treeView3.Nodes.Clear();
                        treeView3.Nodes.Add(node);
                    }
                    else
                    {
                        errorProvider1.SetError(treeView2, "Seleccione un rol padre diferente a Main");
                    }
                }
                resetControls();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
