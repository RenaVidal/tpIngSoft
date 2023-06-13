using abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEBitacoraFilters : IBitacoraFilters
    {
        public string Username { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Type { get; set; }
        public string Like { get; set; }
    }
}
