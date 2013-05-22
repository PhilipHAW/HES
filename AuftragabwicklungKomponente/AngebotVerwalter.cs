using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NullTypen.TransportTypen;
using NullTypen;




namespace AuftragabwicklungKomponente
{
    internal sealed class AngebotVerwalter
    {

        private ISessionFactory sessionFactory;

        internal AngebotVerwalter(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }


        internal Angebot AngebotErstellen(string angebotId, string kundennummer, AdressTyp lieferadresse, AdressTyp rechnungsadresse, IDictionary<ProduktTyp, int> posten, DateTime gueltigAb, DateTime gueltigBis)
        {

            Angebot angebot = new Angebot(angebotId, kundennummer, lieferadresse, rechnungsadresse, posten, gueltigAb, gueltigBis);


            //persist the new angebot
            using (ISession session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
#if DEBUG
                    Console.WriteLine("Speichern von: {0}", angebot);
#endif
                    session.Save(angebot);
                    transaction.Commit();
                }
            }
            return angebot;
        }


        internal Angebot GetAngebot(string angebotId)
        {

            //angebot aus der datenbank rausholen
            Angebot angebot;

            using (var session = sessionFactory.OpenSession())
            {


                using (session.BeginTransaction())
                {   //angebot aus der datenbank rausholen anhand der angebotsnummer
                    angebot = session.Get<Angebot>(Int32.Parse(angebotId.Substring(3)));
                }

#if DEBUG
                Console.WriteLine("Geladen: {0}", angebot);
#endif
            }

            return angebot;
        }


        internal void DeleteAngebot(Angebot angebot)
        {


            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
#if DEBUG
                    Console.WriteLine("Löschen von: {0}", angebot);
#endif
                    session.Delete(angebot);
                    transaction.Commit();
                }
            }


        }
    }
}
