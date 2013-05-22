using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullTypen.TransportTypen
{
    public class KundenTyp
    {

        public int Id { get; private set; }
        public string VorName { get; private set; }
        public string NachName { get; private set; }
        public IList<AdressTyp> LieferAdressen { get; private set; }
        public int KundenNummer { get; private set; }

        public KundenTyp(int kundenNummer, string vorName, string nachName, IList<AdressTyp> lieferAdressen)
        {
            this.KundenNummer = kundenNummer;
            this.VorName = vorName;
            this.NachName = nachName;
            this.LieferAdressen = lieferAdressen;


        }

    }
}
