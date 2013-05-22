using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Rechnungskomponente.Mappings
{
    public class ZahlungseingangMap : ClassMap<Zahlungseingang>
    {
        public ZahlungseingangMap() {
            Id(x => x.id);
            Map(x => x.eingangsDatum);
            Map(x=> x.betrag);
        }
    }
}
