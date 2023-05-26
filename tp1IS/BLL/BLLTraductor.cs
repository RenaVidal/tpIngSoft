using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abstraccion;
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
      /*  public  Iidioma ObtenerIdiomaBase()
        {
            // return ObtenerIdiomas().Where(i => i.Default).FirstOrDefault();
            return OMPPtraductor.ObtenerIdiomaBase();
        }*/
       
        public IList<Iidioma> ObtenerIdiomas()
        {
            return OMPPtraductor.ObtenerIdiomas();
        }
        public IDictionary<string,Itraduccion> obtenertraducciones(Iidioma Idioma)
        {
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

        public bool IdiomaExistente(int id,string idioma)
        {
            return OMPPtraductor.idiomaExistente(id,idioma);
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
