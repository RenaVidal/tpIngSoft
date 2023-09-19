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
    }
}
