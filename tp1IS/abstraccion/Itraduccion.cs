using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstraccion
{
   public interface Itraduccion
    {
        Ipalabra Palabra { get; set; }
        string texto { get; set; }
    }
}
