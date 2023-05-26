using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstraccion
{
   public interface Iidioma
    {
        int ID { get; set; }

        string Nombre { get; set; }
        bool Default { get; set; }
    }
}
