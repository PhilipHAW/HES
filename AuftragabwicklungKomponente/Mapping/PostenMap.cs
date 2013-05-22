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
            Map(x => x.ProduktId).Not.Nullable();
            Map(x => x.NettoPreis).Not.Nullable();
            Map(x => x.ProduktName).Not.Nullable();
            Map(x => x.Menge).Not.Nullable();
        }

    }
}
