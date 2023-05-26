using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abstraccion;
namespace servicios.ClasesMultiLenguaje
{
   public class Palabra:EntidadServicio,Ipalabra
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
    }
}
