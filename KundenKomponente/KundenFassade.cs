using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullTypen;
using NullTypen.TransportTypen;

namespace KundenKomponente
{
    public class KundenFassade : IKundenMgmt
    {

        KundenLogik kundenLogik;

        public KundenFassade(ISessionFactory sessionFactory)
        {
            this.kundenLogik = new KundenLogik(sessionFactory);
        }

        public int KundenAnlegen(string vorName, string nachName, IList<AdressTyp> lieferAdressen)
        {
            return this.kundenLogik.KundenAnlegen(vorName, nachName, lieferAdressen);
        }

        public KundenTyp GetKunde(int kundenNummer)
        {
            return this.kundenLogik.getKunde(kundenNummer);
        }

        bool ExistiertKunde(int kundenNummer)
        {
            return kundenLogik.ExistiertKunde(kundenNummer);
        }

    }
}
