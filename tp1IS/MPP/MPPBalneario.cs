using BE;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPBalneario
    {
        Acceso oDatos;
        Hashtable Hdatos;
       
        public bool incribir_balneario(BEBalneario balneario, List<BECarpa> carpas, byte[] imageData)
        {
            try
            {
                Hdatos = new Hashtable();
                string Consulta = "InsertCarpaData";
                Hdatos.Add("@nombre", balneario.Name);
                Hdatos.Add("@extras", balneario.Extras);
                Hdatos.Add("@ninos", balneario.permiteNinos);
                Hdatos.Add("@mascotas", balneario.permiteMascotas);
                Hdatos.Add("@price", balneario.price);


                DataTable carpaDataTable = new DataTable();
                carpaDataTable.Columns.Add("Fila", typeof(int));
                carpaDataTable.Columns.Add("Columna", typeof(int));
                carpaDataTable.Columns.Add("idBalneario", typeof(int));

                Hdatos.Add("@image", imageData);

                foreach (var carpa in carpas)
                {
                    carpaDataTable.Rows.Add(0, carpa.fila, carpa.columna);
                }
                Hdatos.Add("@CarpaData", carpaDataTable);
                oDatos = new Acceso();
                DataTable Ds2 = new DataTable();
                return oDatos.Escribir(Consulta, Hdatos);
            

            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<BEBalneario> GetAllBalnearios(int idUser, int pag)
        {
            try
            {
                oDatos = new Acceso();
                return oDatos.GetAllBalnearios(idUser, pag);

            }
            catch (Exception ex) { throw ex; }
        }
        public IList<BEBalneario> GetFIlterBalnearios(int pag, string nombre, int permiteninos, int permitemascotas, string extras)
        {
            try
            {
                oDatos = new Acceso();
                return oDatos.GetFIlterBalnearios(pag, nombre, permiteninos, permitemascotas, extras);

            }
            catch (Exception ex) { throw ex; }
        }

        public bool eliminar_balneario(int id)
        {
            try
            {
                Hdatos = new Hashtable();
                string Consulta = "s_balneario_eliminar";
                Hdatos.Add("@id", id);
                oDatos = new Acceso();
                return oDatos.Escribir(Consulta, Hdatos);
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
