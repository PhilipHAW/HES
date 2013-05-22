using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace WaWiSubSystem.NachbestellungsKomponente.Mapping
{
    class EinkaufsInfoSatzMap : ClassMap<WaWiSubSystem.NachbestellungsKomponente.EinkaufsInfoSatz>
    {
        public EinkaufsInfoSatzMap()
        {
            Id(x => x.Id);
            Map(x => x.GueltigAb);
            Map(x => x.GueltigBis);
            Map(x => x.PlanlieferZeit);
            Map(x => x.NormalMenge);
            Map(x => x.Preis);
            Map(x => x.ProduktId);

        }
    }
}
