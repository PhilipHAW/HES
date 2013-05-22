using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NullTypen.TransportTypen;

namespace WaWiSubSystem.ProduktKomponente
{
    internal class ProduktVerwalter
    {

        private ISessionFactory sessionFactory;

        public ProduktVerwalter(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }


        public Produkt ProduktErstellen(string produktId, string name, int lagerbestand, EinkaufsInfoSatzTyp einkaufsInfoSatz)
        {

            Produkt produkt = new Produkt(produktId, name, lagerbestand, einkaufsInfoSatz);


            //persist the new produkt
            using (ISession session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
#if DEBUG
                    Console.WriteLine("Speichern von: {0}", produkt);
#endif

                    session.Save(produkt);
                }
            }



            return produkt;
        }


        public Produkt LoadProdukt(string produktId)
        {

            //angebot aus der datenbank rausholen
            Produkt produkt;

            using (var session = sessionFactory.OpenSession())
            {


                using (session.BeginTransaction())
                {   //angebot aus der datenbank rausholen anhand der angebotsnummer
                    produkt = session.Get<Produkt>(produktId);
                }

#if DEBUG
                Console.WriteLine("Geladen: {0}", produkt);
#endif
            }

            return produkt;
        }


        internal void DeleteAngebot(Produkt produkt)
        {


            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
#if DEBUG
                    Console.WriteLine("Löschen von: {0}", produkt);
#endif
                    session.Delete(produkt);
                }
            }


        }

    }
}
