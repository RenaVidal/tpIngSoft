using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using servicios.ClasesMultiLenguaje;
using abstraccion;
namespace servicios
{
  public static class Observer
    {
        
        
               
        static IList<IdiomaObserver> Observadores = new List<IdiomaObserver>();  //creo lista de observadores
        public static void agregarObservador(IdiomaObserver Observer)    //se agregan observadores
        {
            Observadores.Add(Observer);
        }

        public static void eliminarObservador(IdiomaObserver Observer)  //se eliminan observadores
        {
            Observadores.Remove(Observer);
        }
        

        public static void notificarObeservadores(Iidioma Idioma)   //se notifica a los observadores
        {
            foreach (var observer in Observadores)
            {
                observer.CambiarIdioma(Idioma);
            }
        }

        public static void cambiarIdioma(Iidioma Idioma)    //Cambio de idioma
        {
            
            
            /*  if (_session != null)
              {
                  _session.Usuario.Idioma = Idioma;
                  notificarObeservadores(Idioma);
              }
          */
            
        }
    }
}
