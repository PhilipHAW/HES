using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NachbestellungsKomponente;

namespace WaWiSubSystem.NachbestellungsKomponente
{

    

    public class NachbestellungsFassade
    {

        private NachbestellungsLogik nachbestellungsLogik;

        public NachbestellungsFassade(ISessionFactory sessionFactory) 
        {
            this.nachbestellungsLogik = new NachbestellungsLogik(sessionFactory);
        }

    }
}
