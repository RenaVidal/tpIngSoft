using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstraccion
{
    public interface IBitacoraFilters
    {
        string Username { get; set; }
        DateTime From { get; set; }
        DateTime To { get; set; }
        int Type { get; set; }
        string Like { get; set; }
    }
}
