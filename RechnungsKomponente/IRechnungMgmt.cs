using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;

namespace Rechnungskomponente
{
    public interface IRechnungMgmt
    {
        Boolean RechnungAnlegen(AuftragTyp auftragTyp);

    }
}
