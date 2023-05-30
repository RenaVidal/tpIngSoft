using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLComposite
    {
        MPPComposite mPPComposite = new MPPComposite();
        public bool escribir_relacion(int hijo, int padre)
        {
            try
            {
                return mPPComposite.escribir_relacion(hijo, padre);

            }
            catch (Exception ex) { throw ex; }
        }
        public bool escribir(Componente componente)
        {
            try
            {
                return mPPComposite.escribir(componente);

            }
            catch (Exception ex) { throw ex; }
        }
        public IList<Componente> GetAll(int familia)
        {
            try
            {
                return mPPComposite.GetAll(familia);

            }
            catch (Exception ex) { throw ex; }
        }
        public bool hacer_patente(Componente componente, bool patente)
        {
            try
            {
                return mPPComposite.hacer_patente(componente, patente);

            }
            catch (Exception ex) { throw ex; }
        }
        public IList<Componente> GetFamilias()
        {
            try
            {
                return mPPComposite.GetFamilias();

            }
            catch (Exception ex) { throw ex; }
        }
        public IList<Componente> GetPermisos()
        {
            try
            {
                return mPPComposite.GetPermisos();

            }
            catch (Exception ex) { throw ex; }
        }
        public List<int> get_permisos(int rol)
        {
            try
            {
                return mPPComposite.get_permisos(rol);

            }
            catch (Exception ex) { throw ex; }
        }
        public int buscar_id(string nombre)
        {
            try
            {
                return mPPComposite.buscar_id(nombre);

            }
            catch (Exception ex) { throw ex; }
        }
        public int escribir_retorno_id(string nombre)
        {
            try
            {
                return mPPComposite.escribir_retorno_id(nombre);

            }
            catch (Exception ex) { throw ex; }
        }
        public bool es_patente(string nombre)
        {
            try
            {
                return mPPComposite.es_patente(nombre);

            }
            catch (Exception ex) { throw ex; }
        }
        public bool borrar(int id)
        {
            try
            {
                return mPPComposite.borrar(id);

            }
            catch (Exception ex) { throw ex; }
        }
        public bool buscar_rol_usado(int rol)
        {
            try
            {
                return mPPComposite.buscar_rol_usado(rol);

            }
            catch (Exception ex) { throw ex; }
        }


    }
}
