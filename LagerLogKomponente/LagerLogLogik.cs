using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace WaWiSubSystem.LagerLogKomponente
{
    internal class LagerLogLogik
    {
        private ISessionFactory sessionFactory;
        private WarenAusgangsMeldungVerwalter warenAusgangsverwalter;

        public LagerLogLogik(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
            this.warenAusgangsverwalter = new WarenAusgangsMeldungVerwalter(sessionFactory);
        }


        internal WarenAusgangsMeldung WareAuslagern(int produktnumer, int anzahl, DateTime datum)
        {
            return this.warenAusgangsverwalter.ErstelleWarenAusgangsMeldung(produktnumer, anzahl, datum);
        }




    }
}
