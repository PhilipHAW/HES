using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace NullTypen.TransportTypen.Mapping
{
    class ProduktTypMap : ComponentMap<ProduktTyp>
    { 

        public ProduktTypMap()
        {
            Map(x => x.Lagerbestand);
            Map(x => x.Name);
            Map(x => x.Preis);
            Map(x => x.ProduktId);
            HasMany(x => x.EinkaufsInfoSaetze)             
              .Component(y =>
              {
                  y.Map(x => x.GueltigAb);
                  y.Map(x => x.GueltigBis);
                  y.Map(x => x.NormalMenge);
                  y.Map(x => x.PlanlieferZeit);
                  y.Map(x => x.Preis);
                  y.Map(x => x.ProduktId);
              });
            
           
        }
    }
}
            
