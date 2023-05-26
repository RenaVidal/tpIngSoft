using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abstraccion;
using DAL;
using System.Collections;
using System.Data;
using servicios.ClasesMultiLenguaje;
using System.Data.SqlClient;
namespace MPP
{
   public class MPPtraductor
    {
        public MPPtraductor()
        {
            Datos = new Acceso();
        }
        Acceso Datos;
        Hashtable Hdatos;
        public IList<Iidioma> ObtenerIdiomas()
        {
            IList<Iidioma> ListaIdiomas = new List<Iidioma>();
            try
            {
                DataTable DT = new DataTable();
                string consulta="S_Listar_idioma";
                DT= Datos.Leer(consulta,null);
                
                foreach(DataRow fila in DT.Rows)
                {
                    Idioma OIdioma = new Idioma();
                    OIdioma.ID = Convert.ToInt32(fila["ID"].ToString());
                    OIdioma.Nombre = fila["Idioma"].ToString();
                     OIdioma.Default = bool.Parse(fila["predeterminado"].ToString());
                    ListaIdiomas.Add(OIdioma);
                }
                //return ListaIdiomas;
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return ListaIdiomas;
        }

        public Iidioma ObtenerIdiomaBase()
        {
            return ObtenerIdiomas().Where(idioma => idioma.Default).FirstOrDefault();
        }
        public IDictionary<string, Itraduccion> obtenertraducciones(Iidioma Idioma)
        {
            if (Idioma == null)
            {
                Idioma=ObtenerIdiomaBase();
            }

            IDictionary<string, Itraduccion> Traducciones = new Dictionary<string, Itraduccion>();

            try
            {
                string consulta="S_Traer_Traducciones";
                Hashtable Hdatos = new Hashtable();
                 Hdatos.Add("@ID", Idioma.ID);
              //  Hdatos.Add("@ID", 2);
                DataTable DT = new DataTable();
                DT = Datos.Leer(consulta, Hdatos);
                foreach(DataRow fila in DT.Rows)
                {
                    var Palabra = fila["Palabra"].ToString();
                    Traduccion OTraduccion = new Traduccion();
                    OTraduccion.texto = fila["traduccion"].ToString();

                    Palabra OPalabra = new Palabra();
                    OPalabra.ID = Convert.ToInt32(fila["ID"].ToString());
                    OPalabra.Nombre = Palabra;

                    //  Traducciones.Add(Palabra, OTraduccion);
                    //si   Traducciones[Palabra] = OTraduccion;
                    Traducciones.Add(Palabra, OTraduccion);
                }

                return Traducciones;
            }catch(Exception ex)
            {
                throw ex;
            }
            //return Traducciones;
        }

        public List<string> obtenerIdiomaOriginal()
        {
            // IDictionary<string,Ipalabra> Palabras = new IDictionary<string,Ipalabra>();
            List<string> Palabras = new List<string>();
            try
            {
                string consulta = "S_Traer_Palabras";
                Hashtable Hdatos = new Hashtable();
                DataTable DT = new DataTable();
                DT = Datos.Leer(consulta, null);

                foreach(DataRow fila in DT.Rows)
                {
                    string Palabraa = fila["palabra"].ToString();
                    Palabra Opalabra = new Palabra();
                    Opalabra.Id = Convert.ToInt32(fila["id"].ToString());
                    Opalabra.Nombre = Palabraa;

                    Palabras.Add(Palabraa);
                }
                return Palabras;
            }catch(Exception ex)
            {
                throw ex;
            }

        }

        public Idioma TrarIdioma(string Oidioma)
        {
            Idioma IdiomaSelec = new Idioma();

            try
            {
                string consulta = "S_Traer_unIdioma";
                Hashtable Hdatos = new Hashtable();
                Hdatos.Add("@Idioma", Oidioma);
                DataTable tabla = new DataTable();
                tabla = Datos.Leer(consulta, Hdatos);

                foreach(DataRow fila in tabla.Rows)
                {
                    IdiomaSelec.ID = Convert.ToInt32(fila["ID"].ToString());
                    IdiomaSelec.Nombre = fila["idioma"].ToString();
                    IdiomaSelec.Default = Convert.ToBoolean(fila["predeterminado"]);
                }

                return IdiomaSelec;
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public bool CrearIdioma(Idioma Oidioma)
        {
            try
            {
                Hashtable hdatos = new Hashtable();
                string consulta = "S_Crear_Idioma";
                hdatos.Add("@id", Oidioma.ID);
                hdatos.Add("idioma", Oidioma.Nombre);
                hdatos.Add("predeterminado", Oidioma.Default);
                Datos = new Acceso();
                return Datos.Escribir(consulta, hdatos);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool idiomaExistente(int id,string idioma)
        {
            string consulta = "S_Listar_Idioma";

            DataTable DT = new DataTable();

            DT = Datos.Leer(consulta, null);
            foreach (DataRow fila in DT.Rows)
            {
                if (id == Convert.ToInt32(fila["id"])|| idioma == fila["idioma"].ToString()) return true;
               
            }
            return false;
        }

        public Palabra TraerPalbra(string palabra)
        {
            string consulta = "S_Traer_UnaPalabra";
            Palabra Opalabra = new Palabra();
            DataTable DT = new DataTable();
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@palabra", palabra);
            DT = Datos.Leer(consulta,Hdatos);
            foreach(DataRow fila in DT.Rows)
            {
                if(palabra == fila["palabra"].ToString())
                {
                   // Palabra Opalabra = new Palabra();
                    Opalabra.ID = Convert.ToInt32(fila["ID"]);
                    Opalabra.Nombre = palabra;
                    return Opalabra;
                }
                else
                {
                    return null;
                }
            }
            //return null;
            return Opalabra;
        }
        public bool TraduccionExistente(int id_Idioma,int id_Palabra)
        {
            string consulta = "S_Listar_TraduccionesxIdioma";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@id",id_Idioma);
            DataTable DT = new DataTable();
            DT = Datos.Leer(consulta, Hdatos);
            foreach (DataRow fila in DT.Rows)
            {
                if (id_Palabra == Convert.ToInt32(fila["IDpalabra"])) return true;
            }
              
            return false;
        }

        public bool CrearTraduccion(int ID_idioma,Traduccion Otraduccion)
        {

            try
            {
                string consulta = "S_altaTraduccion";
                Hdatos = new Hashtable();
                Hdatos.Add("@IDidioma", ID_idioma);
                Hdatos.Add("@IDpalabra", Otraduccion.Palabra);
                Hdatos.Add("@traduccion", Otraduccion.texto);
                Datos = new Acceso();
                return Datos.Escribir(consulta, Hdatos);

               // return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
                
            
         
        }
    }
}
