using BE;
using MPP;
using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLBalneario
    {
        MPPBalneario mPPBalneario = new MPPBalneario();
        BLLBitacora oBit = new BLLBitacora();
        public bool incribir_balneario(BEBalneario balneario, List<BECarpa> carpas, byte[] imageData)
        {
            try
            {
                return mPPBalneario.incribir_balneario(balneario, carpas, imageData);

            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }

        public IList<BEBalneario> GetAllBalnearios(int idUser, int pag)
        {
            try
            {
                return mPPBalneario.GetAllBalnearios(idUser, pag);

            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }

        public bool eliminar_balneario(int id)
        {
            try
            {
                return mPPBalneario.eliminar_balneario(id);
            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }

        public IList<BECarpa> GetAllCarpas(int id, DateTime inicio, DateTime fin)
        {
            try
            {
                return mPPBalneario.GetAllCarpas(id, inicio, fin);
            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }

        public IList<BEBalneario> GetFIlterBalnearios(int pag, string nombre, int permiteninos, int permitemascotas, string extras)
        {
            try
            {
                return mPPBalneario.GetFIlterBalnearios(pag, nombre,permiteninos, permitemascotas, extras);

            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }

        public bool incribir_alquiler(BEBalneario balneario, IList<BECarpa> carpas, DateTime inicio, DateTime fin, int id, int total)
        {

            try
            {
                return mPPBalneario.incribir_alquiler(balneario,carpas,inicio,fin, id,  total);

            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }
    }
}
