using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servicios
{
    public class Servicios
    {
        Hashtable Hdatos;
        public Hashtable encriptar(string usuario, string contrasena)
        {
            Hdatos = new Hashtable();

            Hdatos.Add("@usuario", usuario);

            Hdatos.Add("@contrasena", contrasena);
            return Hdatos;
        }
    }
    
}
