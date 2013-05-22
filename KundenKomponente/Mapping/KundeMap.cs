using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundenKomponente.Mapping
{
    class KundeMap : ClassMap<Kunde>
    {

        public KundeMap()
        {
            Id(x => x.Id);
            Map(x => x.VorName);
            Map(x => x.NachName);
            Map(x => x.KundenNummer);
            HasMany(x => x.LieferAdressen)
                .KeyColumn("Id")
                .Table("AdressTyp")
                .Component(y =>
                {
                    y.Map(x => x.Name);
                    y.Map(x => x.Straße);
                    y.Map(x => x.HausNummer);
                    y.Map(x => x.Postleitzahl);
                });
        }
    }
}
