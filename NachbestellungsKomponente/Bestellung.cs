using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;

namespace WaWiSubSystem.NachbestellungsKomponente
{
    public class Bestellung
    {
        private ProduktTyp ProduktTyp;
        private int Anzahl;

        public Bestellung(ProduktTyp produktTyp,  int anzahl) {
            this.ProduktTyp = produktTyp;
            this.Anzahl = anzahl;
        }

        public BestellungTyp GibTransprotObjekt()
        {
            return new BestellungTyp(this.ProduktTyp, this.Anzahl);
        }
    }
}
