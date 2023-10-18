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

        public bool incribir_balneario(BEBalneario balneario, List<BECarpa> carpas, byte[] imageData, int idUser)
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
                Hdatos.Add("@idUser", idUser);


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
        public DataTable get_stars(int balneario, DateTime inicio, DateTime fin)
        {
            try
            {
                Hdatos = new Hashtable();
                string Consulta = "s_rating_obtener";
                Hdatos.Add("@idBalneario", balneario);
                Hdatos.Add("@inicio", inicio);
                Hdatos.Add("@fin", fin);


                oDatos = new Acceso();
                DataTable Ds2 = new DataTable();
                return oDatos.Leer(Consulta, Hdatos);


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
        public DataTable busca_eliminar_balneario(int balneario)
        {
            try
            {
                Hdatos = new Hashtable();
                string Consulta = "s_alquiler_buscar_balneario";
                Hdatos.Add("@id", balneario);


                oDatos = new Acceso();
                DataTable Ds2 = new DataTable();
                return oDatos.Leer(Consulta, Hdatos);


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
        public DataTable get_revenue(int balneario, DateTime inicio, DateTime fin)
        {
            try
            {
                Hdatos = new Hashtable();
                string Consulta = "s_recaudacion_obtener";
                Hdatos.Add("@id", balneario);
                Hdatos.Add("@inicio", inicio);
                Hdatos.Add("@fin", fin);


                oDatos = new Acceso();
                DataTable Ds2 = new DataTable();
                return oDatos.Leer(Consulta, Hdatos);


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
        public DataTable get_messages(int balneario, DateTime inicio, DateTime fin)
        {
            try
            {
                Hdatos = new Hashtable();
                string Consulta = "s_feedbacks_obtener";
                Hdatos.Add("@idBalneario", balneario);
                Hdatos.Add("@inicio", inicio);
                Hdatos.Add("@fin", fin);


                oDatos = new Acceso();
                DataTable Ds2 = new DataTable();
                return oDatos.Leer(Consulta, Hdatos);


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
        public bool incribir_alquiler(BEBalneario balneario, IList<BECarpa> carpas, DateTime inicio, DateTime fin, int id, int total)
        {
            try
            {
                Hdatos = new Hashtable();
                string Consulta = "s_alquiler_crear";
                Hdatos.Add("@idBalneario", balneario.Id);
                Hdatos.Add("@fechaInicio", inicio);
                Hdatos.Add("@precio", total);
                Hdatos.Add("@idUsuario", id);
                Hdatos.Add("@fechafin",fin);
                string carpasString = string.Join(",", carpas.Select(carpa => carpa.Id));
                Hdatos.Add("@idCarpaList", carpasString);


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

        public bool crear_feedback(int balneario, int usuario, string mensaje,  DateTime fecha, int estrellas)
        {
            try
            {
                Hdatos = new Hashtable();
                string Consulta = "s_feedback_crear";
                Hdatos.Add("@idBalneario", balneario);
                Hdatos.Add("@fecha", fecha);
                Hdatos.Add("@mensaje", mensaje);
                Hdatos.Add("@rating", estrellas);
                Hdatos.Add("@idUsuario", usuario);


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


        public IList<BEEalquiler> GetAllAlquileres(int id, DateTime fecha, int past, int pagina) // si past es 1 me trae los alquileres pasados
        {
            try
            {
                oDatos = new Acceso();
                return oDatos.GetAllAlquileres(id, fecha, past,  pagina);
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
        public IList<BEEalquiler> GetAllAlquileresD(int id, DateTime fecha, int past, int pagina, int dueno) // si past es 1 me trae los alquileres pasados
        {
            try
            {
                oDatos = new Acceso();
                return oDatos.GetAllAlquileresD(id, fecha, past, pagina, dueno);
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
        public IList<BEBalneario> GetAllBalneariosNoP()
        {
            try
            {
                oDatos = new Acceso();
                return oDatos.GetAllBalneariosNoP();
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

        public IList<BECarpa> GetAllCarpas(int id, DateTime inicio, DateTime fin)
        {
            try
            {
                oDatos = new Acceso();
                return oDatos.GetAllCarpas(id, inicio, fin);
            }
            catch (Exception ex) { throw ex; }
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
        public bool eliminar_reserva(int id)
        {
            try
            {
                Hdatos = new Hashtable();
                string Consulta = "s_reserva_eliminar";
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
