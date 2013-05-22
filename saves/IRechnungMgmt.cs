using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;

namespace Dummys
{
    public interface IRechnungMgmt
    {
        bool RechnungAnlegen(AuftragTyp auftragTyp);

    }
}
