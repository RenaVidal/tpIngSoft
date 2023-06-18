﻿using System;
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
            foreach (Componente rol in roles)
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
                if (rol.Hijos != null)
                {
                    if (recursiva(id, rol.Hijos)) return true;

                }
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
                _session.idioma = Idioma;
                notificarObeservadores(Idioma);
            }
        }

        
    }
}
