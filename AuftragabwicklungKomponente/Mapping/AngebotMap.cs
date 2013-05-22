using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace AuftragabwicklungKomponente.Mapping
{

    class AngebotMap : ClassMap<Angebot>
    {

        public AngebotMap()
        {

            
            Id(x => x.Id);

            Map(x => x.AngebotId).Not.Nullable();
            Map(x => x.GueltigAb).Not.Nullable();
            Map(x => x.GueltigBis).Not.Nullable();
            HasMany(x => x.Posten).Cascade.SaveUpdate();
            Map(x => x.Kundennummer).Not.Nullable();
            Map(x => x.Lieferadresse).Not.Nullable();
            Map(x => x.Rechnungsadresse).Not.Nullable();
            Map(x => x.GesamtPreisNetto).Not.Nullable();
                      
        }
    }
}
