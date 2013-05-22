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
    internal class KundenLogik
    {

        KundenVerwalter kundenVerwalter;

        public KundenLogik(ISessionFactory sessionFactory)
        {
            this.kundenVerwalter = new KundenVerwalter(sessionFactory);
        }

        public int KundenAnlegen(string vorname, string nachname, IList<AdressTyp> lieferadressen)
        {
            int KundenNrAlt = this.kundenVerwalter.getHoechsteKundenNr();
            return kundenVerwalter.KundenAnlegen(KundenNrAlt++, vorname, nachname, lieferadressen);
        }

        public KundenTyp getKunde(int kundenNummer)
        {
            return this.kundenVerwalter.getKunde(kundenNummer).GibTransportObjekt();

        }

        internal bool ExistiertKunde(int kundenNummer)
        {
          return  kundenVerwalter.ExistiertKunde(kundenNummer);
        }
    }
}
