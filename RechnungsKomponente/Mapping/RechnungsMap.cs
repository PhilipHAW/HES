using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;


namespace Rechnungskomponente.Mappings
{
    public class RechnungsMap : ClassMap<RechnungClass>
    {
        public RechnungsMap()
        {
            Id(x => x.id);
            Map(x => x.rechnungsNummer);
            Component(x => x.rechnungsAdresse, m =>
            {
                m.Map(y => y.HausNummer).Not.Nullable();
                m.Map(y => y.Name).Not.Nullable();
                m.Map(y => y.Postleitzahl).Not.Nullable();
                m.Map(y => y.Straße).Not.Nullable();
            });
            Map(x => x.rechnungsDatum);
            Map(x => x.lieferDatum);
            Map(x => x.mwst);
            Map(x => x.gesamtPreis);
            Map(x => x.bruttoPreis);
            Map(x => x.nettoPreis);
            Map(x => x.versandKosten);
            Map(x => x.bezahlt);
            HasMany(x => x.postenList)
                .KeyColumn("id")
                .Table("PostenTyp")
                .Component(y =>
                {
                    y.Map(x => x.ProduktTyp);
                    y.Map(x => x.Menge);
                });
            HasMany(x => x.zahlungseingangList).Inverse().Cascade.All();



        }
    }
}
