using BE;
using Patrones.Singleton.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace servicios
{
    internal class bitacora
    {
        public void guardar_accion(string accion)
        {
            SessionManager u = SessionManager.GetInstance;
            BEUsuario user = u.Usuario;
            DateTime fecha = DateTime.Now;
        }
        public void guardar_logIn()
        {
            SessionManager u = SessionManager.GetInstance;
            BEUsuario user=  u.Usuario;
            DateTime fecha = u.FechaInicio;
            string accion = "logged in";
        }
        public void guardar_logOut()
        {
            SessionManager u = SessionManager.GetInstance;
            BEUsuario user = u.Usuario;
            DateTime fecha = DateTime.Now;
            string accion = "logged out";
        }
    }
}
