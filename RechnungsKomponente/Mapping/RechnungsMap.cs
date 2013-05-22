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
            
            Map(x => x.rechnungsDatum);
            Map(x => x.lieferDatum);
            Map(x => x.mwst);
            Map(x => x.gesamtPreis);
            Map(x => x.bruttoPreis);
            Map(x => x.nettoPreis);
            Map(x => x.versandKosten);
            Map(x => x.bezahlt);
            Map(x => x.auftragsID);
            HasMany(x => x.zahlungseingangList).Inverse().Cascade.All();



        }
    }
}
