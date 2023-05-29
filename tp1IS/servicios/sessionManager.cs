using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using servicios.ClasesMultiLenguaje;
namespace Patrones.Singleton.Core
{
    public class SessionManager
    {

        private static object _lock = new Object();
        private static SessionManager _session;

        public Idioma idioma { get; set; }

       static IList<IdiomaObserver> Observadores = new List<IdiomaObserver>();  //creo lista de observadores
        public BEUsuario Usuario { get; set; }
        public DateTime FechaInicio { get; set; }

        public static SessionManager GetInstance
        {
            get
            {
                if (_session == null) throw new Exception("Sesión no iniciada");

                return _session;
            }
        }

        public static void Login(BEUsuario usuario)
        {

            lock (_lock)
            {
                if (_session == null)
                {
                    _session = new SessionManager();
                    _session.Usuario = usuario;
                    _session.FechaInicio = DateTime.Now;
                }
                else
                {
                    throw new Exception("Sesión ya iniciada");
                }
            }
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
        public static bool TraerUsuario()
        {
            if (_session != null)
            {
                return _session.Usuario!=null;
            }
            return false;
        }
        public static void agregarObservador(IdiomaObserver Observer)    //se agregan observadores
        {
            Observadores.Add(Observer);
        }

        public static void eliminarObservador(IdiomaObserver Observer)  //se eliminan observadores
        {
            Observadores.Remove(Observer);
        }

        public static void notificarObeservadores(Idioma Idioma)   //se notifica a los observadores
        {
            foreach(var observer in Observadores)
            {
                observer.CambiarIdioma(Idioma);
            }
        }

        public static void cambiarIdioma(Idioma Idioma)    //Cambio de idioma
        {
            if (_session != null)
            {
                // _session.Usuario.Idioma = Idioma;
                _session.idioma = Idioma;
                notificarObeservadores(Idioma);
            }
        }

        
    }
}
