using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections; //para el arraylist
using BE;

namespace DAL
{
    public class Acceso
    {
        public SqlConnection oCnn = new SqlConnection(System.Configuration.ConfigurationManager.
    ConnectionStrings["ConnectionString"].ConnectionString);
        public SqlTransaction Tranx;
        public SqlCommand Cmd;


        public string TestConnection()
        {
            oCnn.Open();
            if (oCnn.State == ConnectionState.Open)
            {
                return "Conexion con la bdd establecida";
            }
            else
            {
                return "No se pudo establecer la conexion con la base de datos";
            }
        }


        public int LeerCantidad(string Consulta, Hashtable Hdatos)
        {
            oCnn.Open();
            Cmd = new SqlCommand(Consulta, oCnn);
            Cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                if ((Hdatos != null))
                {
                    foreach (string dato in Hdatos.Keys)
                    {
                        Cmd.Parameters.AddWithValue(dato, Hdatos[dato]);
                    }
                }

                int Respuesta = Convert.ToInt32(Cmd.ExecuteScalar());
                oCnn.Close();
                return Respuesta;
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
        }

        public bool LeerScalar(string Consulta, Hashtable Hdatos)
        {
            oCnn.Open();
            Cmd = new SqlCommand(Consulta, oCnn);
            Cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                if ((Hdatos != null))
                {
                    foreach (string dato in Hdatos.Keys)
                    {
                        Cmd.Parameters.AddWithValue(dato, Hdatos[dato]);
                    }
                }

                int Respuesta = Convert.ToInt32(Cmd.ExecuteScalar());
                oCnn.Close();
                if (Respuesta > 0)
                { return true; }
                else
                { return false; }
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable Leer(string Consulta, Hashtable Hdatos)
        {
            if (oCnn.State == ConnectionState.Closed)
            {
                oCnn.Open();
            }
            DataTable Dt = new DataTable();
            SqlDataAdapter Da;
            Cmd = new SqlCommand(Consulta, oCnn);
            Cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                Da = new SqlDataAdapter(Cmd);

                if ((Hdatos != null))
                {
                    foreach (string dato in Hdatos.Keys)
                    {
                        Cmd.Parameters.AddWithValue(dato, Hdatos[dato]);
                    }
                }

            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
            finally
            { oCnn.Close(); }
            Da.Fill(Dt);
            return Dt;



        }
        public bool Escribir(string consulta, Hashtable Hdatos)
        {

            if (oCnn.State == ConnectionState.Closed)
            {
                oCnn.Open();
            }

            try
            {
                Tranx = oCnn.BeginTransaction();
                Cmd = new SqlCommand(consulta, oCnn, Tranx);
                Cmd.CommandType = CommandType.StoredProcedure;

                if ((Hdatos != null))
                {
                    foreach (string dato in Hdatos.Keys)
                    {
                        Cmd.Parameters.AddWithValue(dato, Hdatos[dato]);
                    }
                }

                int respuesta = Cmd.ExecuteNonQuery();
                Tranx.Commit();
                return true;

            }

            catch (SqlException ex)
            {
                Tranx.Rollback();
                return false;
            }
            catch (Exception ex)
            {
                Tranx.Rollback();
                return false;
            }
            finally
            { oCnn.Close(); }

        }

        public IList<Componente> GetAll(int familia)
        {
          

            try
            {
                if (oCnn.State == ConnectionState.Closed)
                {
                    oCnn.Open();
                }
                var sql = "s_composite_obtener";
                Cmd = new SqlCommand(sql, oCnn);
                Cmd.CommandType = CommandType.StoredProcedure;
                int  where = 0;
                if (familia != 0)
                {
                    where = familia;
                }
                Hashtable Hdatos = new Hashtable();
                Hdatos.Add("@where", where);
                if ((Hdatos != null))
                {
                    foreach (string dato in Hdatos.Keys)
                    {
                        Cmd.Parameters.AddWithValue(dato, Hdatos[dato]);
                    }
                }

                var reader = Cmd.ExecuteReader();

                var lista = new List<Componente>();

                while (reader.Read())
                {
                    int id_padre = 0;
                    if (reader["id_permiso_padre"] != DBNull.Value)
                    {
                        id_padre = reader.GetInt32(reader.GetOrdinal("id_permiso_padre"));
                    }

                    var id = reader.GetInt32(reader.GetOrdinal("id"));
                    var nombre = reader.GetString(reader.GetOrdinal("nombre"));
                    var patente = reader.GetBoolean(reader.GetOrdinal("es_patente"));


                    Componente c;

                    if (!patente)
                        c = new Familia();
                    else
                        c = new Patente();

                    c.Id = id;
                    c.Nombre = nombre;

                    var padre = GetComponent(id_padre, lista);

                    if (padre == null)
                    {
                        lista.Add(c);
                    }
                    else
                    {
                        padre.AgregarHijo(c);
                    }
                }
                reader.Close();
                oCnn.Close();
                return lista;
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
            finally
            { oCnn.Close(); }
        }

        public bool IsInRole(int id)
        {
            var lista = GetAll(0);

            var c = GetComponent(id, lista);

            return c != null;
        }


        private Componente GetComponent(int id, IList<Componente> lista)
        {

            Componente component = lista != null ? lista.Where(i => i.Id.Equals(id)).FirstOrDefault() : null;

            if (component == null && lista != null)
            {
                foreach (var c in lista)
                {

                    var l = GetComponent(id, c.Hijos);
                    if (l != null && l.Id == id) return l;
                    else
                    if (l != null)
                        return GetComponent(id, l.Hijos);

                }
            }



            return component;



        }

    }
}




