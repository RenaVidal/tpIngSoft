using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;
using servicios.ClasesMultiLenguaje;
using System.Collections;
using System.Data;
namespace BLL
{
   public class BLLTraductor
    {

        MPP.MPPtraductor omppT = new MPP.MPPtraductor();
        public BLLTraductor()
        {
            OMPPtraductor = new MPPtraductor();
        }
        MPPtraductor OMPPtraductor;
       public  Idioma ObtenerIdiomaBase()
        {
            try
            {
                return OMPPtraductor.ObtenerIdiomaBase();
            }
            catch (Exception ex)
            {

                throw ex;

            }
           
        }
        public DataTable traerTablaxIdioma(int id)
        {

            try
            {
                return OMPPtraductor.traerTablaxIdioma(id);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            
        }
        public List<Idioma> ObtenerIdiomas()
        {

            try
            {
                return OMPPtraductor.ObtenerIdiomas();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            
        }
        public Dictionary<string,Traduccion> obtenertraducciones(Idioma Idioma)
        {

            try
            {
                return OMPPtraductor.obtenertraducciones(Idioma);
            }
            catch (Exception ex)
            {
                throw ex;

            }
         
        }

        public List<string> obtenerIdiomaOriginal()
        {

            try
            {
                return OMPPtraductor.obtenerIdiomaOriginal();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            
        }

        public Idioma TraerIdioma(string idioma)
        {

            try
            {
                return OMPPtraductor.TrarIdioma(idioma);
            }
            catch (Exception ex)
            {
                throw ex;

            }
           
        }

        public bool CrearIdioma(Idioma Oidioma)
        {

            try
            {
                return OMPPtraductor.CrearIdioma(Oidioma);
            }
            catch (Exception ex)
            {
                throw ex;

            }
           
        }

        public bool IdiomaExistente(string idioma)
        {

            try
            {
                return OMPPtraductor.idiomaExistente(idioma);
            }
            catch (Exception ex)
            {
                throw ex;

            }
          
        }

        public bool TraduccionExistente(int id_idioma,int id_palabra)
        {

            try
            {
                return OMPPtraductor.TraduccionExistente(id_idioma, id_palabra);
            }
            catch (Exception ex)
            {
                throw ex;

            }
          
        }

        public Palabra TraerPalbra(string palabra)
        {

            try
            {
                return OMPPtraductor.TraerPalbra(palabra);
            }
            catch (Exception ex)
            {
                throw ex;

            }
          
        }

        public bool CrearTraduccion(int ID_idioma,Traduccion Otraduccion)
        {

            try
            {
                return OMPPtraductor.CrearTraduccion(ID_idioma, Otraduccion);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}
