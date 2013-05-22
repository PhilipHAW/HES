using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullTypen;
using NullTypen.TransportTypen;

namespace KundenKomponente
{
    public interface IKundenMgmt
    {

        int KundenAnlegen(string vorName, string nachName, IList<AdressTyp> lieferAdressen);

        KundenTyp GetKunde(int kundenNummer);

        bool ExistiertKunde(int kundenNummer);


    }
}