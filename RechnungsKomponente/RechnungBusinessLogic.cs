using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NullTypen.TransportTypen;

namespace Rechnungskomponente
{
    class RechnungBusinessLogic
    {
        private RechnungVerwalter rechnungVerwalter;

        public RechnungBusinessLogic(ISessionFactory sessionFactory)
        {
            this.rechnungVerwalter = new RechnungVerwalter(sessionFactory);
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
           // return this.rechnungVerwalter.RechnungAnlegen(this.GetNeueRechnungsNummer(), this.GetRechnungsDatum(), auftragTyp.LieferDatum, 0.0F, this.BerechneGesamtpreis(auftragTyp.GetGesamtPreisNetto(), 0.0F), auftragTyp.GetGesamtPreisNetto(), this.BerechneBruttoPreis(auftragTyp.GetGesamtPreisNetto()), 0.0F, auftragTyp.GetPosten());
            return this.rechnungVerwalter.RechnungAnlegen(this.GetNeueRechnungsNummer(), this.GetRechnungsDatum(), this.BerechneMwst(auftragTyp.GetGesamtPreisNetto()), auftragTyp.GetGesamtPreisNetto(), this.BerechneBruttoPreis(auftragTyp.GetGesamtPreisNetto()), auftragTyp.AuftragId);

        }


        /// <summary>
        /// Gibt den Bruttpreis inklusive der Versandkosten wieder
        /// </summary>
        /// <param name="nettoPreis"> Ist der Nettopreis</param>
        /// <param name="versandPreis">Sind die Versandgebühren</param>
        /// <returns> Gibt die Gesamtsumme in Double zurück</returns>
        private float BerechneGesamtpreis(float nettoPreis, float versandPreis)
        {

            float bruttoPreis = this.BerechneBruttoPreis(nettoPreis);
            return bruttoPreis + versandPreis;

        }
        /// <summary>     
        /// Berechnet aus dem Nettopreis den Bruttopreis
        /// </summary>
        /// <param name="preisNetto"></param>
        /// <returns> Gibt den Bruttopreis zurück als Double</returns>
        private float BerechneBruttoPreis(float preisNetto)
        {
            return preisNetto + this.BerechneMwst(preisNetto);
        }

        /// <summary>
        /// Berechnet die Mwst von einem Nettopreis
        /// </summary>
        /// <param name="gesamtPreisNetto"></param>
        /// <returns>Gibt die Mwst eines Netttopreises zurück als Double</returns>
        private float BerechneMwst(float gesamtPreisNetto)
        {
            return (gesamtPreisNetto / 100 * GetMwst());
        }


        /// <summary>
        /// Angabe der Mwst
        /// </summary>
        /// <param name="gesamtPreisNetto"></param>
        /// <returns>Gibt die Mwst zurück als Double</returns>
        private float GetMwst()
        {
            return 19;
        }

        /// <summary>
        /// Erstellt ein Datum für die Rechnug
        /// </summary>
        /// <returns> Gibt ein DateTime zurück von der Aufrufzeit</returns>
        private DateTime GetRechnungsDatum()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// Erstellt eine neue Rechungsnummer 
        /// </summary>
        /// <returns> Gibt einen int die die Rechnungsnummer repräsentiert</returns>
        private int GetNeueRechnungsNummer()
        {
            return this.rechnungVerwalter.GetNeueRechnungsNummer();
        }


        /// <summary>
        /// Setzt eine Rechnung auf Bezahlt
        /// </summary>
        /// <param name="rechnungsNummer"> Ist ein Int der die Rechnungsnummer wiederspiegelt</param>
        public void SetzeRechnungAufBezahlt(int rechnungsNummer)
        {

            RechnungClass rechnung = this.rechnungVerwalter.GetRechnungMit(rechnungsNummer);
            rechnung.bezahlt = true;
            this.rechnungVerwalter.RechnungPersistieren(rechnung);


        }

        /// <summary>
        /// Verbucht Zahlungeingänge zur einer Rechnung
        /// </summary>
        /// <param name="rechnungsNummer"></param>
        /// <param name="eingngangsDatum"></param>
        /// <param name="betrag"></param>
        public void ZahlungeingangBuchenFür(int rechnungsNummer, DateTime eingngangsDatum, float betrag)
        {

            Zahlungseingang zahlungseingang = new Zahlungseingang(eingngangsDatum, betrag);
            RechnungClass rechnung = this.rechnungVerwalter.GetRechnungMit(rechnungsNummer);
            rechnung.ZahlungseingangBuchen(zahlungseingang);
            this.rechnungVerwalter.RechnungPersistieren(rechnung);


        }



    }
}
