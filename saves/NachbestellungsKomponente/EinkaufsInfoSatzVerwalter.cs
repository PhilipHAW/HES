using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace NachbestellungsKomponente
{
    class EinkaufsInfoSatzVerwalter
    {
        private ISessionFactory sessionFactory;

        public EinkaufsInfoSatzVerwalter(ISessionFactory sessionFactory)
        {
            
            this.sessionFactory = sessionFactory;
        }
    }
}
