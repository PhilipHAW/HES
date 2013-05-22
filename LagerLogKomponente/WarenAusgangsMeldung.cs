using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;

namespace WaWiSubSystem.LagerLogKomponente
{
    internal class WarenAusgangsMeldung
    {
        /// <summary>
        /// Id for NHibernate
        /// </summary>
        public virtual int Id { get; protected set; }


        public virtual DateTime Datum { get; protected set; }
        public virtual int Produktnummer { get; protected set; }
        public virtual int Anzahl { get; protected set; }





        /// <summary>
        /// Constructor for NHibernate
        /// </summary>
        private WarenAusgangsMeldung() { }



        internal WarenAusgangsMeldung(int produktNummer, int anzahl, DateTime datum)
        {
            this.Produktnummer = produktNummer;
            this.Datum = datum;
            this.Anzahl = anzahl;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("\nWarenAusgangsMeldung vom ");
            sb.Append(this.Datum);
            sb.Append(" für das Produkt: ");
            sb.Append(this.Produktnummer);
            sb.Append(" in der Menge: ");
            sb.Append(this.Anzahl);


            return sb.ToString();
        }


    }
}
