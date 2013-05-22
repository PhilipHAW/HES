using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using WaWiSubSystem.LagerLogKomponente;

namespace LagerLogKomponente.Mapping
{
    class WarenAusgangsMeldungMap : ClassMap<WarenAusgangsMeldung>
    {
        public WarenAusgangsMeldungMap() {

            Id(x => x.Id);
            Map(x => x.Datum);
            Map(x => x.Produktnummer);
            Map(x => x.Anzahl);
     }

      
    }
}
