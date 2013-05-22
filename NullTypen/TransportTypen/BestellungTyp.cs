using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;

namespace NullTypen.TransportTypen
{
    public class BestellungTyp
    {
        private ProduktTyp produktTyp;
        private int p;

        public BestellungTyp(ProduktTyp produktTyp, int p)
        {
            // TODO: Complete member initialization
            this.produktTyp = produktTyp;
            this.p = p;
        }
    }
}
