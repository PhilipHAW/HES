using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using AuftragabwicklungKomponente;
using WaWiSubSystem.WaWiVerwaltungKomponente;
using WaWiSubSystem.ProduktKomponente;
using WaWiSubSystem.LagerLogKomponente;
using WaWiSubSystem.NachbestellungsKomponente;
using AuslieferungsKomponente;
using Rechnungskomponente;
using KundenKomponente;
using HESFassadeKomponente;
using Communication;

namespace HES
{
    public class ComponentFactory
    {






        //muss statt void die AAI-Kompnente zurückgeben
        public static IHESFassade BuildComponents(ISessionFactory sessionFactory)
        {
            ICommunication communication = new Communication.Communication();
            IProduktMgmt produktKomponente = new ProduktFassade(sessionFactory);
            IProduktDetails produktDetailsKomponente = new ProduktFassade(sessionFactory);
            INachbestellungMgmt nachbestellungsKomponente = new NachbestellungsFassade(sessionFactory, produktKomponente);
            ILagerLogMgmt lagerLogKompomente = new LagerLogFassade(sessionFactory);
            IWaWiFassade waWiVerwaltungsKomponente = new WaWiVerwaltungFassade(produktKomponente, lagerLogKompomente, nachbestellungsKomponente);
            IRechnungMgmt rechnungsKomponente = new RechnungFassade(sessionFactory);
            IAuslieferungsMgmt auslieferungsKomponente = new AuslieferungsFassade(sessionFactory);
            IKundenMgmt kundenKomponente = new KundenFassade(sessionFactory);
            IAuftragMgmt auftragabwicklungKomponente = new AuftragabwicklungFassade(sessionFactory, waWiVerwaltungsKomponente);
            IHESFassade hESFassade = new HESFassade(kundenKomponente, auftragabwicklungKomponente, produktDetailsKomponente, rechnungsKomponente);

            return hESFassade;
        }







    }
}
