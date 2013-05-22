using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuslieferungsKomponente.Entitäten
{
  
    public class Lieferung
    {
        public virtual int id { get; protected set; }
        public virtual int lieferNummer { get; protected set; }
        public virtual TransportAuftrag transportAuftrag { get; protected set; }
        public virtual bool LieferungErfolgt { get; set; }

        public Lieferung(int lieferNummer)
        {
            this.lieferNummer = lieferNummer;
            
        }
        /// <summary>
        /// Leerer Konstruktor für Hibernate
        /// </summary>
        private Lieferung() { }

        /// <summary>
        /// Übergibt der Lieferung ein TransportAuftrag 
        /// </summary>
        /// <param name="transportAuftrag"> Ist die Entität TransportAuftrag</param>
        public void setzeTransportAuftrag(TransportAuftrag transportAuftrag) {
            this.transportAuftrag = transportAuftrag;
        }
    }
}
