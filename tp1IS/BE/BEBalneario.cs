using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEBalneario 
    {
        public int Id { get; set; }
        public int price { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Extras { get; set; }
        public bool permiteNinos { get; set; }
        public bool permiteMascotas { get; set; }
        public int rating { get; set; }
        public BEBalneario(string name, string extras, bool ninos, bool mascotas, byte[] image, int priceP)
        {
            Name = name;
            Extras = extras;
            permiteNinos = ninos;
            permiteMascotas = mascotas;
            Image = image;
            price = priceP;
        }
        public BEBalneario() { }

    }
}
