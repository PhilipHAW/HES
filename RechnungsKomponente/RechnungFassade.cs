using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;
using NHibernate;

namespace Rechnungskomponente
{
    public class RechnungFassade : IRechnungMgmt
    {

        private readonly RechnungBusinessLogic rechnungBusinessLogic;



        public RechnungFassade(ISessionFactory sessionFactory)
        {
            this.rechnungBusinessLogic = new RechnungBusinessLogic(sessionFactory);
        }



        /// <summary>
        /// Legt eine Rechnung an für einen Auftrag. Wird an die Verwalterklasse weitergeleitet
        /// </summary>
        /// <param name="Auftragsnummer"> Ist ein AuftragTyp der alle für die Rechnug wichtigen Bestandteile enthält</param>
        /// <returns>
        /// Gibt ein true beim Erfolgsafall zurück und ein false bei einem Fehler
        /// </returns>

        public bool RechnungAnlegen(AuftragTyp auftragTyp)
        {
            return this.rechnungBusinessLogic.RechnungAnlegen(auftragTyp);
        }


        /*
        /// <summary>
        /// warum den hier rausgeben ?
        /// </summary>
        /// <returns></returns>
         public RechnungVerwalter getRechnungVerwalter() {
             return this.rechnungVerwalter;
         }*/


        /// <summary>
        /// Setzt eine Rechnung auf Bezahlt
        /// </summary>
        /// <param name="rechnungsNummer"> Ist ein Int der die Rechnungsnummer wiederspiegelt</param>
        public void SetzeRechnungAufBezahlt(int rechnungsNummer)
        {
            this.rechnungBusinessLogic.SetzeRechnungAufBezahlt(rechnungsNummer);
        }
    }
}
