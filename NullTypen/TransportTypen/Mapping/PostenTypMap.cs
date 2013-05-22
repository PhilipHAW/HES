using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace NullTypen.TransportTypen.Mapping
{
    class PostenTypMap : ComponentMap<PostenTyp>
    {
        public PostenTypMap() 
        {
            Component(x => x.ProduktTyp);
            Map(x => x.Menge);
        }
    }
}
