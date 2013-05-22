using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NullTypen.TransportTypen;
using NullTypen;

namespace Rechnungskomponente
{
    internal class RechnungVerwalter
    {
       
        private ISessionFactory sessionFactory;

        internal RechnungVerwalter(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        ///// <summary>
        ///// Legt eine Rechnung an für einen Auftrag. Wird an die Verwalterklasse weitergeleitet
        ///// </summary>
        ///// <param name="Auftragsnummer"> Ist ein AuftragTyp der alle für die Rechnug wichtigen Bestandteile enthält</param>
        ///// <returns>
        ///// Gibt ein true beim Erfolgsafall zurück und ein false bei einem Fehler
        ///// </returns>

        //public bool RechnungAnlegen(int rechnungsNummer, String rechnungsAdresse, DateTime rechnungsDatum, DateTime lieferDatum, Double mwst, Double gesamtPreis, Double nettoPreis, Double bruttoPreis, Double versandKosten, List<PostenTyp> postenList)
        //{
        //    rechnung = new RechnungClass(rechnungsNummer, rechnungsAdresse, rechnungsDatum, lieferDatum, mwst, gesamtPreis, nettoPreis, bruttoPreis, versandKosten, postenList);
        //    this.RechnungPersistieren(rechnung);
        //    return true;
        //}

        /// <summary>
        /// Legt eine Rechnung an für einen Auftrag. Wird an die Verwalterklasse weitergeleitet
        /// </summary>
        /// <param name="Auftragsnummer"> Ist ein AuftragTyp der alle für die Rechnug wichtigen Bestandteile enthält</param>
        /// <returns>
        /// Gibt ein true beim Erfolgsafall zurück und ein false bei einem Fehler
        /// </returns>

        public bool RechnungAnlegen(int rechnungsNummer,  DateTime rechnungsDatum, float mwst,  float nettoPreis, float bruttoPreis,  string auftragsID)
        {
            RechnungClass rechnung = new RechnungClass(rechnungsNummer, rechnungsDatum,  mwst, nettoPreis, bruttoPreis, auftragsID);
            this.RechnungPersistieren(rechnung);
            return true;
        }


        /// <summary>
        /// Persistiert die Rechnung und der ProduktTyp
        /// </summary>
        /// <param name="rechnung"> Ist eine Rechnung</param>
        public void RechnungPersistieren(RechnungClass rechnung)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
#if DEBUG
                    Console.WriteLine("Speichern von: {0}", rechnung);
#endif
                    session.Save(rechnung);
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Erstellt bzw. sucht in der DB
        /// eine einmalige Rechnungsnummer und gibt sie zurück 
        /// </summary>
        /// <returns></returns> 
        public int GetNeueRechnungsNummer()
        {
            int highestUsedId = 0;
            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {

                    var rechnungen = session.CreateCriteria(typeof(RechnungClass)).List<RechnungClass>();

                    foreach (var rechnung in rechnungen)
                    {
                        if (rechnung.rechnungsNummer > highestUsedId)
                        { highestUsedId = rechnung.rechnungsNummer; }
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

        /// <summary>
        /// Gibt eine Rechnung mit einer einer bestimmten Rechnungsnummer zurück aus der DB 
        /// </summary>
        /// <param name="rechnungsnummer"></param>
        /// <returns></returns>
        public RechnungClass GetRechnungMit(int rechnungsnummer)
        {
            RechnungClass rechnung;
            using (var session = sessionFactory.OpenSession())
            {


                using (session.BeginTransaction())
                {   //rechnung aus der datenbank rausholen anhand der angebotsnummer
                    rechnung = session.Get<RechnungClass>(rechnungsnummer);
                }

#if DEBUG
                Console.WriteLine("Geladen: {0}", rechnung);
#endif
            }

            return rechnung;
        }




    }
}
