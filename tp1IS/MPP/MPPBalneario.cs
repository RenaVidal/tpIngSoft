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
       
        public bool incribir_balneario(BEBalneario balneario, List<BECarpa> carpas)
        {
            try
            {
                Hdatos = new Hashtable();
                string Consulta = "InsertCarpaData";
                Hdatos.Add("@nombre", balneario.Name);
                Hdatos.Add("@extras", balneario.Extras);
                Hdatos.Add("@ninos", balneario.permiteNinos);
                Hdatos.Add("@mascotas", balneario.permiteMascotas);
                Hdatos.Add("@image", balneario.Image);


                DataTable carpaDataTable = new DataTable();
                carpaDataTable.Columns.Add("Fila", typeof(int));
                carpaDataTable.Columns.Add("Columna", typeof(int));
                carpaDataTable.Columns.Add("idBalneario", typeof(int));

                // Populate the DataTable with data from the list
                foreach (var carpa in carpas)
                {
                    carpaDataTable.Rows.Add(carpa.fila, carpa.columna, 0);
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
    }
}
