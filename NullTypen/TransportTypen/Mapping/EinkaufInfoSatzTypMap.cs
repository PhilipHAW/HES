using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace NullTypen.TransportTypen.Mapping
{
    public class EinkaufInfoSatzTypMap : ComponentMap<EinkaufInfoSatzTyp>
    {

        public EinkaufInfoSatzTypMap()
       {
            Map(x => x.GueltigAb);
            Map(x => x.GueltigBis);
            Map(x => x.NormalMenge);
            Map(x => x.PlanlieferZeit);
            Map(x => x.Preis);
            Map(x => x.ProduktId);
            
       
       }

    }
}
