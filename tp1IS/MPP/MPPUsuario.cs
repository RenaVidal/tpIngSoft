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
            try
            {

                Hdatos = new Hashtable();
                string Consulta = "s_Usuario_cambiar_contrasena";
                Hdatos.Add("@id", id);
                Hdatos.Add("@password", contrasena);

                oDatos = new Acceso();
                return oDatos.Escribir(Consulta, Hdatos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool borrar_rol(int id)
        {
            try
            {
                Hdatos = new Hashtable();
                string Consulta = "s_Usuario_sacar_rol";
                Hdatos.Add("@id", id);
                oDatos = new Acceso();
                return oDatos.Escribir(Consulta, Hdatos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool validar(BEUsuario usuario)
        {
            try
            {
                DataTable Ds2 = new DataTable();
                Acceso oDatos = new Acceso();
                Hdatos = new Hashtable();
                string Consulta = "s_Usuario_login";
                Hdatos.Add("@username", usuario.user);
                Hdatos.Add("@password", usuario.password);
                Ds2 = oDatos.Leer(Consulta, Hdatos);
                foreach (DataRow fila in Ds2.Rows)
                {
                    if (usuario.user == fila["username"].ToString() && usuario.password == fila["password"].ToString()) return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public BEUsuario buscar_usuario(string username)
        {
            try
            {
                BEUsuario user = new BEUsuario();
                DataTable Ds2 = new DataTable();
                Acceso oDatos = new Acceso();
                Hdatos = new Hashtable();
                string Consulta = "s_Usuario_buscar";
                Hdatos.Add("@username", username);
                Ds2 = oDatos.Leer(Consulta, Hdatos);
                foreach (DataRow fila in Ds2.Rows)
                {
                    user.user = username;
                    user.password = fila["password"].ToString();
                    user.id = Convert.ToInt32(fila["id"]);
                    user.rol = Convert.ToInt32(fila["rol"]);
                    user.birthDate = fila["birthdate"].ToString();
                }
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool es_activo(string username)
        {
            try
            {
                DataTable Ds2 = new DataTable();
                Acceso oDatos = new Acceso();
                Hdatos = new Hashtable();
                string Consulta = "s_Usuario_activo";
                Hdatos.Add("@username", username);
                Ds2 = oDatos.Leer(Consulta, Hdatos);
                foreach (DataRow fila in Ds2.Rows)
                {
                    if (username == fila["username"].ToString() && true == Convert.ToBoolean(fila["active"])) return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool usuario_existente(int id)
        {
            try
            {
                DataTable Ds2 = new DataTable();
                Acceso oDatos = new Acceso();
                Hdatos = new Hashtable();
                string Consulta = "s_Usuario_porid";
                Hdatos.Add("@id", id);
                Ds2 = oDatos.Leer(Consulta, Hdatos);
                foreach (DataRow fila in Ds2.Rows)
                {
                    if (id == Convert.ToInt32(fila["id"])) return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool cargar_usuario(BEUsuario usuario)
        {
            try
            {
                Hdatos = new Hashtable();
                string Consulta = "s_Usuario_crear";
                Hdatos.Add("@id", usuario.id);
                Hdatos.Add("@user", usuario.user);
                Hdatos.Add("@password", usuario.password);
                Hdatos.Add("@active", true);
                Hdatos.Add("@birthdate", usuario.birthDate);

                oDatos = new Acceso();
                return oDatos.Escribir(Consulta, Hdatos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool eliminar_usuario(int id)
        {
            try
            {
                Hdatos = new Hashtable();
                string Consulta = "s_Usuario_eliminar";
                Hdatos.Add("@id", id);
                oDatos = new Acceso();
                return oDatos.Escribir(Consulta, Hdatos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool es_admin(string username)
        {
            try
            {
                DataTable Ds2 = new DataTable();
                Acceso oDatos = new Acceso();
                Hdatos = new Hashtable();
                string Consulta = "s_Usuario_buscar";
                Hdatos.Add("@username", username);
                Ds2 = oDatos.Leer(Consulta, Hdatos);
                foreach (DataRow fila in Ds2.Rows)
                {
                    if (username == fila["username"].ToString() && Convert.ToInt32(fila["rol"]) == 5) return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool dar_admin(int id)
        {
            try
            {
                Hdatos = new Hashtable();
                string Consulta = "s_Usuario_dar_admin";
                Hdatos.Add("@id", id);
                oDatos = new Acceso();
                return oDatos.Escribir(Consulta, Hdatos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool crear_admin(BEUsuario usuario)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool cambiar_rol(int id, int rol)
        {
            try
            {

                Hdatos = new Hashtable();
                string Consulta = "s_Usuario_cambiar_rol";
                Hdatos.Add("@id", id);
                Hdatos.Add("@rol", rol);

                oDatos = new Acceso();
                return oDatos.Escribir(Consulta, Hdatos);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
