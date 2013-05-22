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


        public Produkt ProduktErstellen(int produktId, string name, int lagerbestand, IList<EinkaufInfoSatzTyp> einkaufsInfoSaetze, float preis)
        {

            Produkt produkt = new Produkt(produktId, name, lagerbestand, einkaufsInfoSaetze, preis);


            //persist the new produkt
            using (ISession session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
#if DEBUG
                    Console.WriteLine("Speichern von: {0}", produkt);
#endif
                    session.Save(produkt);
                    transaction.Commit();
                }
            }



            return produkt;
        }


        public Produkt LoadProdukt(int produktId)
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


        internal void DeleteProdukt(Produkt produkt)
        {


            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
#if DEBUG
                    Console.WriteLine("Löschen von: {0}", produkt);
#endif
                    session.Delete(produkt);
                    transaction.Commit();
                }
            }


        }

        /// <summary>
        /// Erstellt bzw. sucht in der DB
        /// eine einmalige Rechnungsnummer und gibt sie zurück 
        /// </summary>
        /// <returns></returns> 
        public int GetNeueProduktNummer()
        {
            int highestUsedId = 0;
            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {

                    var produkte = session.CreateCriteria(typeof(Produkt)).List<Produkt>();

                    foreach (var produkt in produkte)
                    {
                        if (produkt.ProduktId > highestUsedId)
                        { highestUsedId = produkt.ProduktId; }
                    }
                }
            }
            highestUsedId += 1;
            return highestUsedId;


            /*  
             using (ISession session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {


                  try
                {
                    return session.Query<RechnungClass>().Max(x => x.rechnungsNummer);

                }
                catch { 
                    return 1; 
                }
                    
                }
            }
        }
            */

        }

    }
}
