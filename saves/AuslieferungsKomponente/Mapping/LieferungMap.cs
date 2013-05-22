using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using AuslieferungsKomponente.Entitäten;

namespace AuslieferungsKomponente.Mapping
{
    public class LieferungMap : ClassMap<Lieferung>
    {
        public LieferungMap() {
            Id(x=> x.id);
            Map(x => x.lieferNummer);
            Map(x => x.LieferungErfolgt);
            HasOne(x => x.transportAuftrag).PropertyRef(x => x.lieferung);
        }
    }
}
