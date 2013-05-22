using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullTypen;

namespace KundenKomponente
{
    internal class KundenVerwalter
    {

        
        private ISessionFactory sessionFactory;

        internal KundenVerwalter(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }


        public int KundenAnlegen(int kundenNr, string vorname, string nachname, IList<AdressTyp> lieferadressen)
        {

            Kunde neuKunde = new Kunde(kundenNr, vorname, nachname, lieferadressen);
            
            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

#if DEBUG
                    Console.WriteLine("Speichern von: {0}", neuKunde);
#endif
                    session.Save(neuKunde);

                    transaction.Commit();
                }
            }
            return neuKunde.KundenNummer;
        }


        public Kunde getKunde(int kundenNummer)
        {
            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    var kunden = session.CreateCriteria(typeof(Kunde)).List<Kunde>();

                    foreach (var kunde in kunden)
                    {
                        if (kunde.KundenNummer == kundenNummer)
                        { return kunde; }
                    }
                }
            }

            throw new Exception("Kunde mit der Kundennummer: " + kundenNummer + "nicht gefunden...");
           
        }

        public int getHoechsteKundenNr()
        {

            int highestUsedId = 0;
            using (var session = sessionFactory.OpenSession())
            {

                using (session.BeginTransaction())
                {

                    var kunden = session.CreateCriteria(typeof(Kunde)).List<Kunde>();

                    foreach (var kunde in kunden)
                    {
                        if (kunde.KundenNummer > highestUsedId)
                        { highestUsedId = kunde.KundenNummer; }
                    }
                }
            }
            highestUsedId += 1;
            return highestUsedId;
        }


        internal bool ExistiertKunde(int kundenNummer)
        {
            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    var kunden = session.CreateCriteria(typeof(Kunde)).List<Kunde>();

                    foreach (var kunde in kunden)
                    {
                        if (kunde.KundenNummer == kundenNummer)
                        { return true; }
                    }
                }
            }

            return false;

        }
    }

}