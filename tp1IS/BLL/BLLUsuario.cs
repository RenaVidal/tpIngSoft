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
        public bool validar(BEUsuario usuario)
        {
            usuario.password = encriptar.Encriptar(usuario.password);
            return oUsuario.validar(usuario);
        }
        public BEUsuario buscar_usuario(string username)
        {
            return oUsuario.buscar_usuario(username);
        }
        public bool usuario_existente(int id)
        {
            return oUsuario.usuario_existente(id);
        }
        public bool eliminar_usuario(int id)
        {
            return oUsuario.eliminar_usuario(id);
        }
        public bool cargar_usuario(BEUsuario usuario)
        {
            usuario.password = encriptar.Encriptar(usuario.password);
            return oUsuario.cargar_usuario(usuario);
        }
        public bool es_admin(string username)
        {
            return oUsuario.es_admin(username);
        }
        public  bool dar_admin(int id)
        {
            return oUsuario.dar_admin(id);
        }
        public bool crear_admin(BEUsuario usuario)
        {
            usuario.password = encriptar.Encriptar(usuario.password);
            return oUsuario.crear_admin(usuario);
        }
        public bool es_activo(string username)
        {
            return oUsuario.es_activo(username);
        }
    }
    
}
