using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace AuftragabwicklungKomponente.Mapping
{
    class AuftragMap : ClassMap<Auftrag>
    {



        public AuftragMap()
        {
            Id(x => x.Id);

            Map(x => x.AuftragId).Not.Nullable();
            HasOne(x => x.Angebot);
            Map(x => x.IstLieferbar).Not.Nullable();
            Map(x => x.IstAbgeschlossen).Not.Nullable();
            Map(x => x.BeauftragtAm).Not.Nullable();
            Map(x => x.LetzterPostenLieferbar).Not.Nullable();
        }

    }
}
