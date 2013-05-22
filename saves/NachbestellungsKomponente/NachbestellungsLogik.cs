using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NachbestellungsKomponente;
using NHibernate;

namespace WaWiSubSystem.NachbestellungsKomponente
{
    internal class NachbestellungsLogik
    {
        private ISessionFactory sessionFactory;
        private EinkaufsInfoSatzVerwalter einkaufsInfosatzVerwalter;

        public NachbestellungsLogik(ISessionFactory sessionFactory)
        {
            
            this.sessionFactory = sessionFactory;
            this.einkaufsInfosatzVerwalter = new EinkaufsInfoSatzVerwalter(sessionFactory);
        }
    }
}
