using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace AuftragabwicklungKomponente.Mapping
{
    class PostenMap : ClassMap<Posten>
    {


        public PostenMap()
        {

            Id(x => x.Id);
            Map(x => x.Menge).Not.Nullable();
            References(x => x.Angebot);
            Component(x => x.Produkt, m =>
            {
                m.Map(x => x.Name).Not.Nullable();
                m.Map(x => x.ProduktId).Not.Nullable();
                m.Map(x => x.Lagerbestand).Not.Nullable();
                m.HasMany(x => x.EinkaufsInfoSaetze)
                    .KeyColumn("Id")
                    .Table("EinkaufsInfoSatzTyp")
                    .Component(y =>
                {
                    y.Map(x => x.GueltigAb);
                    y.Map(x => x.GueltigBis);
                    //y.Map(x => x.Lieferant).Not.Nullable();
                    y.Map(x => x.NormalMenge).Not.Nullable();
                    y.Map(x => x.PlanlieferZeit).Not.Nullable();
                    y.Map(x => x.Preis).Not.Nullable();
                });
            });



        }

    }
}
