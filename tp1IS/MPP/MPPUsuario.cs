using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using BE;
using servicios;
using System.Collections;

namespace MPP
{
    public class MPPUsuario
    {
        Acceso oDatos;
        Hashtable Hdatos;
        Servicios servicioUsuario = new Servicios();
        public bool validar(BEUsuario usuario)
        {
            DataTable Ds2 = new DataTable();
            Acceso oDatos = new Acceso();
            string Consulta = "s_Usuario_listar";
            Ds2 = oDatos.Leer(Consulta, null);
            foreach (DataRow fila in Ds2.Rows)
            {
                if (usuario.usuario == fila["usuario"].ToString() && usuario.contrasena == fila["contrasena"].ToString()) return true;
            }
            return false;
        }
        public bool cargar_usuario(BEUsuario usuario)
        {
            Hdatos = new Hashtable();
            string Consulta = "s_Usuario_crear";

            Hdatos.Add("@usuario", usuario.usuario);
            Hdatos.Add("@contrasena", usuario.contrasena);

            oDatos = new Acceso();
            return oDatos.Escribir(Consulta, Hdatos);
        }
    }
}
