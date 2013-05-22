using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaWiSubSystem.LagerLogKomponente
{
    public interface ILagerLogMgmt
    {
        bool WarenAusgangsmeldung(int produktnumer, int anzahl);

        bool WarenEingangsmeldung(int produktnumer, int anzahl);
    }
}
