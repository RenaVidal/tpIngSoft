using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;
using BE;
using servicios;

namespace Negocio
{
    public class BLLUsuario
    {
        public BLLUsuario()
        {
            oUsuario = new MPPUsuario();
        }
        MPPUsuario oUsuario;
        
        public bool cambiar_contrasena(int id, string contra)
        {
            try
            {
                string contrasena = encriptar.Encriptar(contra);
                return oUsuario.cambiar_contrasena(id, contrasena);
            }
            catch (Exception ex) { throw ex; }
        }

        public BEUsuario buscar_usuarioxid(int id)
        {
            try
            {
                return oUsuario.buscar_usuarioporID(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool ActualizarDVxU(int ID,string DV)
        {
            try
            {
                return oUsuario.actualizarDVxUsuario(ID, DV);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool borrar_rol(int id, int rol)
        {
            try
            {
                return oUsuario.borrar_rol(id, rol);
            }
            catch (Exception ex) { throw ex; }
        }
        public bool validar(BEUsuario usuario)
        {
            try
            {
                usuario.password = encriptar.Encriptar(usuario.password);
                return oUsuario.validar(usuario);
            }
            catch (Exception ex) { throw ex; }
        }
        public BEUsuario buscar_usuario(string username)
        {
            try
            {
                return oUsuario.buscar_usuario(username);
            }
            catch (Exception ex) { throw ex; }
        }
        public bool usuario_existente(int id)
        {
            try
            {
                return oUsuario.usuario_existente(id);
            }
            catch (Exception ex) { throw ex; }
        }
        public bool eliminar_usuario(int id)
        {
            try
            {
                return oUsuario.eliminar_usuario(id);
            }
            catch (Exception ex) { throw ex; }
        }
        public bool cargar_usuario(BEUsuario usuario)
        {
            try
            {
                usuario.password = encriptar.Encriptar(usuario.password);
                return oUsuario.cargar_usuario(usuario);
            }
            catch (Exception ex) { throw ex; }
        }
        public bool es_admin(string username)
        {
            try
            {
                return oUsuario.es_admin(username);
            }
            catch (Exception ex) { throw ex; }
        }
        public bool dar_admin(int id)
        {
            try
            {
                return oUsuario.dar_admin(id);
            }
            catch (Exception ex) { throw ex; }
        }
        public bool crear_admin(BEUsuario usuario)
        {
            try
            {
                usuario.password = encriptar.Encriptar(usuario.password);
                return oUsuario.crear_admin(usuario);
            }
            catch (Exception ex) { throw ex; }
        }
        public bool es_activo(string username)
        {
            try
            {
                return oUsuario.es_activo(username);
            }
            catch (Exception ex) { throw ex; }
        }
        public bool agregar_rol(int id, int rol)
        {
            try
            {
                return oUsuario.agregar_rol(id, rol);
            }
            catch (Exception ex) { throw ex; }
        }
        public bool tiene_rol(int id, int rol)
        {
            try
            {
                return oUsuario.tiene_rol(id, rol);
            }
            catch (Exception ex) { throw ex; }
        }
    }
    
}
