using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;
using NHibernate;
using WaWiSubSystem.ProduktKomponente;

namespace WaWiSubSystem.NachbestellungsKomponente
{



    public class NachbestellungsFassade : INachbestellungMgmt
    {
        
        private NachbestellungsLogik NachbestellungsLogik;
        private IProduktMgmt produktManager;


        public NachbestellungsFassade(ISessionFactory sessionFactory, IProduktMgmt produktManager)
        {
            this.produktManager = produktManager;
            this.NachbestellungsLogik = new NachbestellungsLogik(sessionFactory);
        }


        public EinkaufInfoSatzTyp EinkaufsInfoSatzTypErstellen(DateTime gueltigAb, DateTime gueltigBis, TimeSpan planlieferZeit, int normalMenge, float preis)
        {
            return this.NachbestellungsLogik.EinkaufsInfoSatzErstellen(gueltigAb, gueltigBis, planlieferZeit, normalMenge, preis).GibTransprotObjekt();
        }

        public BestellungTyp ProdukteBestellen(string Produktnumer)
        {
            BestellungTyp bestellungTyp= this.NachbestellungsLogik.ProdukteBestellen(Produktnumer);
            return bestellungTyp;
        }
    }
}
