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
        public bool cambiar_contrasena(int id, string contrasena)
        {

            Hdatos = new Hashtable();
            string Consulta = "s_Usuario_cambiar_contrasena";
            Hdatos.Add("@id", id);
            Hdatos.Add("@password", contrasena);

            oDatos = new Acceso();
            return oDatos.Escribir(Consulta, Hdatos);
        }
        public bool validar(BEUsuario usuario)
        {
            DataTable Ds2 = new DataTable();
            Acceso oDatos = new Acceso();
            string Consulta = "s_Usuario_listar";
            Ds2 = oDatos.Leer(Consulta, null);
            foreach (DataRow fila in Ds2.Rows)
            {
                if (usuario.user == fila["username"].ToString() && usuario.password == fila["password"].ToString()) return true;
            }
            return false;
        }
        public BEUsuario buscar_usuario(string username)
        {
            BEUsuario user = new BEUsuario();
            DataTable Ds2 = new DataTable();
            Acceso oDatos = new Acceso();
            string Consulta = "s_Usuario_listar";
            Ds2 = oDatos.Leer(Consulta, null);
            foreach (DataRow fila in Ds2.Rows)
            {
                if (username == fila["username"].ToString())
                {
                    user.user = username;
                    user.password = fila["password"].ToString();
                    user.id = Convert.ToInt32(fila["id"]);
                    user.birthDate = fila["birthdate"].ToString();
                }
            }
            return user;
        }
        public bool es_activo(string username)
        {
            DataTable Ds2 = new DataTable();
            Acceso oDatos = new Acceso();
            string Consulta = "s_Usuario_listar";
            Ds2 = oDatos.Leer(Consulta, null);
            foreach (DataRow fila in Ds2.Rows)
            {
                if (username == fila["username"].ToString() && Convert.ToBoolean( fila["active"]) ==true) return true;
            }
            return false;
        }
        public bool usuario_existente(int id)
        {
            DataTable Ds2 = new DataTable();
            Acceso oDatos = new Acceso();
            string Consulta = "s_Usuario_listar";
            Ds2 = oDatos.Leer(Consulta, null);
            foreach (DataRow fila in Ds2.Rows)
            {
                if (id == Convert.ToInt32( fila["id"])) return true;
            }
            return false;
        }
        public bool cargar_usuario(BEUsuario usuario)
        {
            Hdatos = new Hashtable();
            string Consulta = "s_Usuario_crear";
            Hdatos.Add("@id", usuario.id);
            Hdatos.Add("@user", usuario.user);
            Hdatos.Add("@password", usuario.password);
            Hdatos.Add("@admin", false);
            Hdatos.Add("@active", true);
            Hdatos.Add("@birthdate", usuario.birthDate);

            oDatos = new Acceso();
            return oDatos.Escribir(Consulta, Hdatos);
        }
        public bool eliminar_usuario(int id)
        { 
           
            Hdatos = new Hashtable();
            string Consulta = "s_Usuario_eliminar";
            Hdatos.Add("@id", id);
            oDatos = new Acceso();
            return oDatos.Escribir(Consulta, Hdatos);
        }
        public bool es_admin(string username)
        {
            DataTable Ds2 = new DataTable();
            Acceso oDatos = new Acceso();
            string Consulta = "s_Usuario_listar";
            Ds2 = oDatos.Leer(Consulta, null);
            foreach (DataRow fila in Ds2.Rows)
            {
                if (username == fila["username"].ToString() && Convert.ToBoolean( fila["admin"]) == true) return true;
            }
            return false;
        }
        public bool dar_admin(int id)
        {
            Hdatos = new Hashtable();
            string Consulta = "s_Usuario_dar_admin";
            Hdatos.Add("@id", id);
            oDatos = new Acceso();
            return oDatos.Escribir(Consulta, Hdatos);
        }
        public bool crear_admin(BEUsuario usuario)
        {
            Hdatos = new Hashtable();
            string Consulta = "s_Usuario_crear";
            Hdatos.Add("@id", usuario.id);
            Hdatos.Add("@user", usuario.user);
            Hdatos.Add("@password", usuario.password);
            Hdatos.Add("@admin", true);
            Hdatos.Add("@active", true);
            Hdatos.Add("@birthdate", usuario.birthDate);

            oDatos = new Acceso();
            return oDatos.Escribir(Consulta, Hdatos);
        }
    }
}
