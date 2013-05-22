using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NullTypen.TransportTypen;

namespace WaWiSubSystem.NachbestellungsKomponente
{
    internal class NachbestellungsLogik
    {
        private ISessionFactory sessionFactory;
        private EinkaufsInfoSatzVerwalter einkaufsInfosatzVerwalter;
        private BestellungsVerwalter bestellungsVerwalter;

        public NachbestellungsLogik(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.einkaufsInfosatzVerwalter = new EinkaufsInfoSatzVerwalter(sessionFactory);
            this.bestellungsVerwalter = new BestellungsVerwalter(sessionFactory);
        }

        internal EinkaufsInfoSatz EinkaufsInfoSatzErstellen(DateTime gueltigAb, DateTime gueltigBis, TimeSpan planlieferZeit, int normalMenge, float preis)
        {
          return this.einkaufsInfosatzVerwalter.EinkaufsInfoSatzErstellen(gueltigAb, gueltigBis, planlieferZeit, normalMenge, preis);
        }


        internal BestellungTyp ProdukteBestellen(string Produktnumer)
        {
            BestellungTyp bestellungTyp = this.bestellungsVerwalter.ProdukteBestellen(Produktnumer);
            return bestellungTyp;
        }
    }
}
