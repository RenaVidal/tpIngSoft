using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BE;
using System.Linq;
namespace servicios
{
   public class GenerarVD
    {

        public static string generarDigitoVU(BEUsuario Usuario)
        {
            string DigitoV = string.Empty;

            
             Type C = Usuario.GetType();
             string dvU = string.Empty;
             var props = C.GetProperties();

            //var attrs = C.GetCustomAttributes(false);
            //preguntar a santi
            /*var verificable = (VerificableAttribute) attrs.Where(i => i.GetType().Equals(typeof(VerificableAttribute))).FirstOrDefault();

            if (verificable != null)
                dvh += $"{verificable.Prefix}_";
            */
             foreach(var item in props)
            {
                if (item.PropertyType.FullName.Equals(typeof(DateTime).FullName))
                {
                    DateTime fecha = (DateTime)item.GetValue(Usuario);
                    dvU += fecha.ToString("ddmmyyyyhhmmss");
                }
                else
                {
                    if (item.Name != "DV"&& item.Name!="permisos")
                    {
                        dvU += item.GetValue(Usuario).ToString();
                    }
                    
                }
            }
            return encriptar.GenerarSHA(dvU);

        }



        public static string generarDigitoVS(List<string> Lista)
        {
            string dvS = string.Empty;

            foreach(var items in Lista)
            {
                dvS += items.ToString();
            }
            return encriptar.GenerarSHA(dvS);
        }

        public static string generarDigitoVUCN(BEUsuario Usuario,string contraseña)
        {
            string DigitoV = string.Empty;

           // Usuario.password = contraseña;
            Type C = Usuario.GetType();
            string dvU = string.Empty;
            var props = C.GetProperties();

            //var attrs = C.GetCustomAttributes(false);
            //preguntar a santi
            /*var verificable = (VerificableAttribute) attrs.Where(i => i.GetType().Equals(typeof(VerificableAttribute))).FirstOrDefault();

            if (verificable != null)
                dvh += $"{verificable.Prefix}_";
            */
            foreach (var item in props)
            {
                if (item.PropertyType.FullName.Equals(typeof(DateTime).FullName))
                {
                    DateTime fecha = (DateTime)item.GetValue(Usuario);
                    dvU += fecha.ToString("ddmmyyyyhhmmss");
                }
                else
                {
                    dvU += item.GetValue(Usuario).ToString();
                }
            }
            return encriptar.GenerarSHA(dvU);

        }
    }
}
