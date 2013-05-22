using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;
using NullTypen;

namespace AuslieferungsKomponente.Entitäten
{

    public class Lieferung
    {
        public virtual int id { get; protected set; }
        public virtual int lieferNummer { get; protected set; }
        public virtual TransportAuftrag transportAuftrag { get; protected set; }
        public virtual bool LieferungErfolgt { get; set; }
        public virtual string AuftragId { get; protected set; }
        public virtual AdressTyp Lieferadresse { get; protected set; }
        
        


        public Lieferung(int lieferNummer, string auftragId )
        {
            this.lieferNummer = lieferNummer;
            this.AuftragId = auftragId;
            
            
            
        }
        /// <summary>
        /// Leerer Konstruktor für Hibernate
        /// </summary>
        private Lieferung() { }

        /// <summary>
        /// Übergibt der Lieferung ein TransportAuftrag 
        /// </summary>
        /// <param name="transportAuftrag"> Ist die Entität TransportAuftrag</param>
        public void setzeTransportAuftrag(TransportAuftrag transportAuftrag)
        {
            this.transportAuftrag = transportAuftrag;
        }
    }
}
