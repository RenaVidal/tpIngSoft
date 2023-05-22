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
            return mPPComposite.escribir_relacion(hijo, padre);
        }
        public bool escribir(Componente componente)
        {
            return mPPComposite.escribir(componente);
        }
        public IList<Componente> GetAll(int familia)
        {
            return mPPComposite.GetAll(familia);
        }
        public bool hacer_patente(Componente componente, bool patente)
        {
            return mPPComposite.hacer_patente(componente, patente);
        }
        public int buscar_id(string nombre)
        {
            return mPPComposite.buscar_id(nombre);
        }
        public int escribir_retorno_id(string nombre)
        {
            return mPPComposite.escribir_retorno_id(nombre);
        }
        public bool es_patente(string nombre)
        {
            return mPPComposite.es_patente(nombre);
        }


    }
}
