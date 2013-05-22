using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NullTypen.TransportTypen;

namespace WaWiSubSystem.ProduktKomponente.Mapping
{
    class ProduktMap : ClassMap<Produkt>
    {

        public ProduktMap()
        {
            Id(x => x.Id);

            Map(x => x.Name).Not.Nullable();
            Map(x => x.ProduktId).Not.Nullable();
            Map(x => x.Lagerbestand).Not.Nullable();
            Map(x => x.Preis).Not.Nullable();
            HasMany(x => x.EinkaufsInfoSaetze)
               .KeyColumn("id")
               .Table("EinkaufsInfoSatzTyp")
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
