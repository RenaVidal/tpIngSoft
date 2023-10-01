using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEEalquiler
    {
        public int Id { get; set; }
        public int idBalneario { get; set; }

        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public int idUsuario { get; set; }
        public int precio { get; set; }

        public BEEalquiler(int idP, int idBalnearioP, DateTime inicioP, DateTime finP, int idUsuarioP, int precioP) {
            Id = idP;
            idBalneario = idBalnearioP;
            fechaInicio = inicioP;
            fechaFin = finP;
            idUsuario = idUsuarioP;
            precio = precioP;
        }
        public BEEalquiler() { }
    }
}
