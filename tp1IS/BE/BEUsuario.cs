using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEUsuario : Entidad
    {
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public BEUsuario(string usuario_e, string contrasena_e)
        {
            this.usuario = usuario_e;
            this.contrasena = contrasena_e;
        }
    }
}
