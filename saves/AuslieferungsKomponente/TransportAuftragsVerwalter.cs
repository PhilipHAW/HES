using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using AuslieferungsKomponente.Entitäten;

namespace AuslieferungsKomponente
{
    public class TransportAuftragsVerwalter
    {
        private ISessionFactory sessionFactory;


        public TransportAuftragsVerwalter(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;

        }

        /// <summary>
        /// Erstellt ein TransportAuftrag
        /// </summary>
        /// <param name="transportAuftragNummer"></param>
        /// <param name="lieferDatum"></param>
        /// <param name="transportDienstleister">Ist ein String der den transportDienstleister darstellt </param>
        /// <param name="lieferung">Es wird eine Entität von Liefertung erwartet</param>
        /// <returns></returns>
        internal TransportAuftrag TransportErstellen(int transportAuftragNummer, DateTime lieferDatum, string transportDienstleister, Lieferung lieferung)
        {
            TransportAuftrag transportAuftrag = new TransportAuftrag(transportAuftragNummer, lieferDatum, transportDienstleister, lieferung);

            //persist the new angebot
            using (ISession session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
#if DEBUG
                    Console.WriteLine("Speichern von: {0}", transportAuftrag);
#endif
                    session.Save(transportAuftrag);
                    transaction.Commit();
                }
            }


            return transportAuftrag;
        }


        /// <summary>
        /// Erstellt eine neue TransportAuftragsNummer
        /// </summary>
        /// <returns>Gibt eine Int Zahl zurück</returns>
        internal int NeueTransportAuftragsNummer()
        {
            int highestUsedId = 0;
            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {

                    var transportAuftraege = session.CreateCriteria(typeof(TransportAuftrag)).List<TransportAuftrag>();

                    foreach (var transportAuftrag in transportAuftraege)
                    {
                        if (transportAuftrag.transportAuftragNummer > highestUsedId)
                        { highestUsedId = transportAuftrag.transportAuftragNummer; }
                    }
                }
            }
            highestUsedId += 1;
            return highestUsedId;
        }


        /// <summary>
        /// Gibt ein TransportAuftrag zurück der Aufgund der transportAuftragNummer aus der DB geholt wurde
        /// </summary>
        /// <param name="transportAuftragNummer">Ist ein int der eindeutig einem TransportAuftrag zugewiesen wurde </param>
        /// <returns>Gibt ein TransportAuftrag zurück</returns>
        internal TransportAuftrag getTransportAuftrag(int transportAuftragNummer)
        {
            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {

                    var alleAuftraege = session.CreateCriteria(typeof(TransportAuftrag)).List<TransportAuftrag>();


                    foreach (TransportAuftrag transportAuftrag in alleAuftraege)
                    {
                        if (transportAuftrag.transportAuftragNummer.Equals(transportAuftragNummer))
                        {
#if DEBUG
                            Console.WriteLine("TransportAuftrag mit der TransportAuftragsnummer: {0} (gesuchte Id: {1}) geladen...", transportAuftrag.transportAuftragNummer, transportAuftragNummer);
#endif
                            return transportAuftrag;
                        }
                    }


                    throw new Exception("TransportAuftrag nicht gefunden.");


                }
            }
        }





        internal void persistiereTransportAuftrag(TransportAuftrag transportAuftrag)
        {
            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    session.Update(transportAuftrag);
                    transaction.Commit();

                }
            }
        }
    }
}
