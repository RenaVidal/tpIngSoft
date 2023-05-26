using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abstraccion;
namespace servicios.ClasesMultiLenguaje
{
   public class Traduccion:Itraduccion
    {
        public Ipalabra Palabra { get; set; }
        public string texto { get; set; }
    }
}
