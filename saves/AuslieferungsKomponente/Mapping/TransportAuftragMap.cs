using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using AuslieferungsKomponente.Entitäten;

namespace AuslieferungsKomponente.Mapping
{
    public class TransportAuftragMap : ClassMap<TransportAuftrag>
    {
        public TransportAuftragMap() {
            Id(x => x.id);
            Map(x => x.transportAuftragNummer);
            Map(x => x.ausgangsDatum);
            Map(x => x.lieferungErfolgt);
            Map(x => x.lieferDatum);
            Map(x => x.transportDienstleister);
            References(x => x.lieferung).Unique();

        }
    }
}
