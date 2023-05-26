using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abstraccion;
using servicios;
namespace servicios.ClasesMultiLenguaje
{
  public class Idioma:EntidadServicio,Iidioma
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public bool Default { get; set; }
    }
}
