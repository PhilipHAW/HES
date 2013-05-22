using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;
using NHibernate;

namespace WaWiSubSystem.LagerLogKomponente
{
    internal class WarenAusgangsMeldungVerwalter
    {

        private ISessionFactory sessionFactory;

        public WarenAusgangsMeldungVerwalter(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }



        internal WarenAusgangsMeldung ErstelleWarenAusgangsMeldung(int produktNummer, int anzahl, DateTime datum)
        {

            WarenAusgangsMeldung wAM = new WarenAusgangsMeldung(produktNummer, anzahl, datum);


#if DEBUG
            Console.WriteLine("Speichern von: {0}", wAM);
#endif

            //persist the new auftrag
            using (ISession session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(wAM);
                    transaction.Commit();
                }
            }


            return wAM;
        }






    }
}
