using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;

namespace WaWiSubSystem.NachbestellungsKomponente
{
    public interface INachbestellungMgmt
    {
        BestellungTyp ProdukteBestellen(String Produktnumer);
        EinkaufInfoSatzTyp EinkaufsInfoSatzTypErstellen(DateTime gueltigAb, DateTime gueltigBis, TimeSpan planlieferZeit, int normalMenge, float preis);
        
    }
}
