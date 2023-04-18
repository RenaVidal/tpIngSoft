using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;
using BE;

namespace Negocio
{
    public class BLLUsuario
    {
        public BLLUsuario()
        {
            oUsuario = new MPPUsuario();
        }
        MPPUsuario oUsuario;
        public bool validar(BEUsuario usuario)
        {
            return oUsuario.validar(usuario);
        }
        public bool cargar_usuario(BEUsuario usuario)
        {
            return oUsuario.cargar_usuario(usuario);
        }
    }
}
