using BE;
using Patrones.Singleton.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BLLBitacora
    {
        MPP.MPPBitacora oBit = new MPP.MPPBitacora();
        public void guardar_accion(string accion)
        {
            try
            {
            SessionManager u = SessionManager.GetInstance;
            BEUsuario user = u.Usuario;
            DateTime fecha = DateTime.Now;
            oBit.cargar_bitacora(user, fecha, accion);
            }
            catch (Exception ex) { throw ex; }
        }
        public void guardar_logIn()
        {
           try
           {
            SessionManager u = SessionManager.GetInstance;
            BEUsuario user = u.Usuario;
            DateTime fecha = u.FechaInicio;
            string accion = "logged in";
            oBit.cargar_bitacora(user,fecha,accion);
            }
            catch (Exception ex) { throw ex; }
            }
        public void guardar_logOut()
        {
         try
          {
            SessionManager u = SessionManager.GetInstance;
            BEUsuario user = u.Usuario;
             DateTime fecha = DateTime.Now;
             string accion = "logged out";
             oBit.cargar_bitacora(user, fecha, accion);
             }catch (Exception ex) { throw ex; }
        }
    }
}
