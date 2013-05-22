using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using WaWiSubSystem.NachbestellungsKomponente;

namespace WaWiSubSystem.NachbestellungsKomponente
{
    class EinkaufsInfoSatzVerwalter
    {
        private ISessionFactory sessionFactory;

        public EinkaufsInfoSatzVerwalter(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        internal EinkaufsInfoSatz EinkaufsInfoSatzErstellen(DateTime gueltigAb, DateTime gueltigBis, TimeSpan planlieferZeit, int normalMenge, float preis)
        {
            EinkaufsInfoSatz eISatz = new EinkaufsInfoSatz(gueltigAb, gueltigBis, planlieferZeit, normalMenge, preis);

#if DEBUG
            Console.WriteLine("Speichern von: {0}", eISatz);
#endif

            

            //persist the new auftrag
            using (ISession session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(eISatz);
                    transaction.Commit();
                }
            }

            return eISatz;
        }


    }
}
