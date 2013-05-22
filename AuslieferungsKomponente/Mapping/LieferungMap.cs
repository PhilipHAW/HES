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
        public LieferungMap()
        {
            Id(x => x.id);
            Map(x => x.lieferNummer);
            Map(x => x.LieferungErfolgt);
            HasOne(x => x.transportAuftrag).PropertyRef(x => x.lieferung);
            Map(x => x.AuftragId);
            Map(x => x.Lieferadresse);
            Map(x => x.Lieferdatum);
            HasMany(x => x.Posten)
                .KeyColumn("id")
                .Table("Posten")
                .Component(y =>
                {
                    y.Map(x => x.Menge);
                    y.Map(x => x.ProduktId);
                });
        }
    }
}
