using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen;
using NullTypen.TransportTypen;

namespace KundenKomponente
{
    internal class Kunde
    {
        public virtual int Id { get; protected set; }
        public virtual string VorName { get; protected set; }
        public virtual string NachName { get; protected set; }
        public virtual IList<AdressTyp> LieferAdressen { get; protected set; }
        public virtual int KundenNummer { get; protected set; }


        internal Kunde(int kundenNummer, string vorName, string nachName, IList<AdressTyp> lieferAdressen)
        {
            this.VorName = vorName;
            this.NachName = nachName;
            this.LieferAdressen = lieferAdressen;
            this.KundenNummer = kundenNummer;
        }


        public KundenTyp GibTransportObjekt()
        {
            return new KundenTyp(KundenNummer, VorName, NachName, LieferAdressen);

        }

    }
}
