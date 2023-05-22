using BE;
using BLL;
using MetroFramework.Controls;
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



        private void metroButton2_Click(object sender, EventArgs e)
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
                        //borrar
                        //fijarse que no lo tengo asignado ningun user
                    }
                    else
                    {
                        errorProvider1.SetError(treeView2, "Seleccione un rol padre diferente a Main");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
          
        }
    }
}
