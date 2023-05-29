using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;
using servicios.ClasesMultiLenguaje;
namespace BLL
{
   public class BLLTraductor
    {
      //  MPP.MPPtraductor OMPPTraductor = new MPP.MPPtraductor();

        MPP.MPPtraductor omppT = new MPP.MPPtraductor();
        public BLLTraductor()
        {
            OMPPtraductor = new MPPtraductor();
        }
        MPPtraductor OMPPtraductor;
       public  Idioma ObtenerIdiomaBase()
        {
            // return ObtenerIdiomas().Where(i => i.Default).FirstOrDefault();
            return OMPPtraductor.ObtenerIdiomaBase();
        }
       
        public List<Idioma> ObtenerIdiomas()
        {
            return OMPPtraductor.ObtenerIdiomas();
        }
        public Dictionary<string,Traduccion> obtenertraducciones(Idioma Idioma)
        {
            //return OMPPtraductor.obtenertraducciones(Idioma);
            return OMPPtraductor.obtenertraducciones(Idioma);
        }

        public List<string> obtenerIdiomaOriginal()
        {
            return OMPPtraductor.obtenerIdiomaOriginal();
        }

        public Idioma TraerIdioma(string idioma)
        {
            return OMPPtraductor.TrarIdioma(idioma);
        }

        public bool CrearIdioma(Idioma Oidioma)
        {
            return OMPPtraductor.CrearIdioma(Oidioma);
        }

        public bool IdiomaExistente(string idioma)
        {
            return OMPPtraductor.idiomaExistente(idioma);
        }

        public bool TraduccionExistente(int id_idioma,int id_palabra)
        {
            return OMPPtraductor.TraduccionExistente(id_idioma,id_palabra);
        }

        public Palabra TraerPalbra(string palabra)
        {
            return OMPPtraductor.TraerPalbra(palabra);
        }

        public bool CrearTraduccion(int ID_idioma,Traduccion Otraduccion)
        {
            return OMPPtraductor.CrearTraduccion(ID_idioma, Otraduccion);
        }
    }
}
