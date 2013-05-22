using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace NullTypen.Mapping
{
    class AdressCompnentMap : ComponentMap<AdressTyp>
    {

        public AdressCompnentMap() 
        {
            Map(x => x.HausNummer);
            Map(x => x.Straße);
            Map(x => x.Name);
            Map(x => x.Postleitzahl);
        }

    }
}
