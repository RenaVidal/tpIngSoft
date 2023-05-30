using BE;
using BLL;
using MetroFramework;
using MetroFramework.Controls;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class eliminarRol : MetroFramework.Forms.MetroForm
    {
        public eliminarRol()
        {
            InitializeComponent();
        }
        BLLComposite oComp = new BLLComposite();
        private void eliminarRol_Load(object sender, EventArgs e)
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
                    if (item.Hijos != null) encontrado = findInList(item.Hijos, nombre);
                    if (encontrado != null)
                    {
                        return encontrado;
                    }
                }

            }
            return null;
        }

        BLLUsuario oUser = new BLLUsuario();
        
        BLLBitacora oBit = new BLLBitacora();
        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                errorProvider1.SetError(treeView2, "");
                if (treeView2.SelectedNode == null)
                {
                    errorProvider1.SetError(treeView2, "Select a role");
                }
                else
                {
                    IList<Componente> list = oComp.GetFamilias();
                    Componente item = findInList(list, treeView2.SelectedNode.Text);
                    if (item != null && !oComp.es_patente(item.Nombre))
                    {
                        int rolID = oComp.buscar_id(item.Nombre);
                        if (!oComp.buscar_rol_usado(rolID)) 
                        {
                            var accion = "elimino el rol " + item.Nombre;
                            oBit.guardar_accion(accion);
                            oComp.borrar(rolID);
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "the role is being used, it can not be deleted");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(treeView2, "Select a father role different from Main");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
          
        }
    }
}
