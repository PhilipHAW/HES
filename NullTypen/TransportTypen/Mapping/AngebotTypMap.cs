using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NullTypen.Mapping;

namespace NullTypen.TransportTypen.Mapping
{
    class AngebotTypMap : ComponentMap<AngebotTyp>
    {

        public AngebotTypMap() 
        {
            Map(x => x.AngebotId);
            Map(x => x.GesamtPreisNetto);
            Map(x => x.GueltigAb);
            Map(x => x.GueltigBis);
            Map(x => x.Kundennummer);
            Component(x => x.Lieferadresse);
            Component(x => x.Rechnungsadresse);
            HasMany(x => x.Posten)
              .Component(y =>
              {
                  y.Map(z => z.Menge);
              });

        }


    }
}
