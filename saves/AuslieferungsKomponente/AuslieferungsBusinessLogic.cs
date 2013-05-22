using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuslieferungsKomponente.Entitäten;
using NullTypen.TransportTypen;
using NHibernate;

namespace AuslieferungsKomponente
{
    public class AuslieferungsBusinessLogic
    {
        private const string transportDienstleister = "DHL";
        private LieferungsVerwalter auslieferungsVerwalter;
        private TransportAuftragsVerwalter transportAuftragsVerwalter;

        public AuslieferungsBusinessLogic( LieferungsVerwalter auslieferungsVerwalter, TransportAuftragsVerwalter transportAuftragsVerwalter)
        {
            this.auslieferungsVerwalter = auslieferungsVerwalter;
            this.transportAuftragsVerwalter = transportAuftragsVerwalter;
        }


        /// <summary>
        /// Erstellt eine Lieferung und ein TransportAuftrag und erstellt die OneToOne beziehung zwischen 
        /// Lieferung und TransportAuftrag
        /// </summary>
        /// <param name="auftragTyp"> Ist ein AuftragTyp</param>
        /// <returns>Gibt True zurück wenn das Erstellen erfolgreich war </returns>
        internal bool AuslieferungTransportErstellen(AuftragTyp auftragTyp)
        {
            Lieferung  lieferung = this.auslieferungsVerwalter.LieferungErstellen(this.NeueLieferungNummer());
            TransportAuftrag transportAuftrag = this.transportAuftragsVerwalter.TransportErstellen(this.NeueTransportAuftragsNummer(), auftragTyp.LetzterPostenLieferbar, transportDienstleister, lieferung);
           lieferung.setzeTransportAuftrag(transportAuftrag);
            return true;
        }

        /// <summary>
        /// Erstellt eine neue Liefernummer die noch nicht existiert
        /// </summary>
        /// <returns>Gibt eine Int Zahl zurück</returns>
        public int NeueLieferungNummer() {
           return auslieferungsVerwalter.NeueLieferungNummer();
        } 


        /// <summary>
        /// Erstellt eine neue TransportAuftragsNummer
        /// </summary>
        /// <returns>Gibt eine Int Zahl zurück</returns>
        public int NeueTransportAuftragsNummer(){
            return transportAuftragsVerwalter.NeueTransportAuftragsNummer();
        }

        /// <summary>
        /// Setzt das Ausgangsdatum des TransportAuftrags auf ein bestimmtes Datum
        /// </summary>
        /// <param name="ausgangsDatum"> Datum eines AusgangsDatum</param>
        /// <param name="transportAuftragNummer">TransportAuftragsNummer </param>
        public void SetzeAusgangsDatum(DateTime ausgangsDatum, int transportAuftragNummer) {
            TransportAuftrag transportAuftrag = transportAuftragsVerwalter.getTransportAuftrag(transportAuftragNummer);
            transportAuftrag.SetzeAusgangsDatum(ausgangsDatum);
            transportAuftragsVerwalter.persistiereTransportAuftrag(transportAuftrag);
        }
        /// <summary>
        /// Gibt wieder ob ein eine Lieferung erfolgt ist 
        /// </summary>
        /// <param name="wert">Wert ist ein Boolwert</param>
        /// <param name="transportAuftragNummer">TransportAuftragsNummer</param>
        public void SetzeLieferungErfogtAuf(bool wert, int transportAuftragNummer) {
            TransportAuftrag transportAuftrag = transportAuftragsVerwalter.getTransportAuftrag(transportAuftragNummer);
            transportAuftrag.SetzeLieferungErfogtAuf(wert);
            transportAuftragsVerwalter.persistiereTransportAuftrag(transportAuftrag);

        }
        
    }
}
