using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace Patrones.Singleton.Core
{
    public class SessionManager
    {

        private static object _lock = new Object();
        private static SessionManager _session;

        public BEUsuario Usuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public List<int> permisos { get; set; }

        public static SessionManager GetInstance
        {
            get
            {
                if (_session == null) _session = new SessionManager();

                return _session;
            }
        }
        
        public static void Login(BEUsuario usuario)
        {

            lock (_lock)
            {
                if (_session != null)
                {
                    _session.Usuario = usuario;
                    _session.FechaInicio = DateTime.Now;
                }
                else
                {
                    throw new Exception("No hay sesion iniciada");
                }
            }
        }
        public static bool recursiva(int id, IList<Componente> roles)
        {
            foreach (Componente rol in _session.Usuario.permisos)
            {
                if (rol.Id == id) return true;
                if (rol.Hijos != null) return recursiva(id, rol.Hijos);
            }
            return false;
        }
        public static bool tiene_permiso(int id)
        {
            foreach(Componente rol in _session.Usuario.permisos)
            {
                if (rol.Id == id) return true;
                if (rol.Hijos != null) return recursiva(id, rol.Hijos);
            }
            return false;
        }
        public static void Logout()
        {
            lock (_lock)
            {
                if (_session != null)
                {
                    _session = null;
                }
                else
                {
                    throw new Exception("Sesión no iniciada");
                }
            }


        }

        private SessionManager()
        {

        }


    }
}
