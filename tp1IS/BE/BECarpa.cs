using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECarpa
    {
        public int fila { get; set; }
        public int columna { get; set; }

        public int balneario { get; set; }

        public BECarpa(int filaP, int columnaP) { 
            fila = filaP;
            columna = columnaP;
        }
        public BECarpa() { }
    }
}
