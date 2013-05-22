using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;

namespace AuslieferungsKomponente.Entitäten 
{
   public class TransportAuftrag
    {
        public virtual int id { get; protected set; }
        public virtual int transportAuftragNummer { get; set; }
        public virtual DateTime ausgangsDatum { get; set; }
        public virtual bool lieferungErfolgt {get; set;}
        public virtual DateTime lieferDatum { get; set; }
        public virtual string transportDienstleister { get; set; }
        public virtual Lieferung lieferung { get; set; }
        

        public TransportAuftrag(int transportAuftragNummer, DateTime lieferDatum, string transportDienstleister, Lieferung lieferung)
        {
            this.transportAuftragNummer = transportAuftragNummer;
            this.lieferDatum = lieferDatum;
            this.transportDienstleister = transportDienstleister;
            this.lieferung = lieferung;
            this.lieferungErfolgt = false;
            this.ausgangsDatum = DateTime.Now;
        }

        private TransportAuftrag() { }

       /// <summary>
       /// Setzt das Ausgangsdatum auf eine bestimmtes Datum
       /// </summary>
       /// <param name="ausgangsDatum">Ist ein Datum</param>
 
       public void SetzeAusgangsDatum(DateTime ausgangsDatum) {
            this.ausgangsDatum = ausgangsDatum;
        }
        /// <summary>
        /// Wird aufgerufen wenn eine Lieferung erfolgt ist
        /// </summary>
        /// <param name="wert"> Ist ein Bool wert</param>
        public void SetzeLieferungErfogtAuf(bool wert) {
            this.lieferungErfolgt = wert;
        }

    }
}
