using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullTypen.TransportTypen
{
    public class AngebotTyp
    {
        public virtual string AngebotId { get; private set; }
        public virtual DateTime GueltigAb { get; private set; }
        public virtual DateTime GueltigBis { get; private set; }

        public virtual IList<PostenTyp> Posten { get; private set; }

        public virtual string Kundennummer { get; private set; }
        public virtual AdressTyp Lieferadresse { get; private set; }
        public virtual AdressTyp Rechnungsadresse { get; private set; }

        public virtual float GesamtPreisNetto { get; protected set; }


        /// <summary>
        /// Konstruiert ein Angebot.
        /// </summary>
        /// <param name="angebotId">Die Id muss einmalig sein.</param>
        /// <param name="kundennummer"></param>
        /// <param name="lieferadresse"></param>
        /// <param name="rechnungsadresse"></param>
        /// <param name="posten">Liste von Posten</param>
        /// <param name="gueltigAb">Ab wann das Angebot gültig ist.</param>
        /// <param name="gueltigBis">Bis wann das Produkt gültig ist.</param>
        public AngebotTyp(string angebotId, string kundennummer, AdressTyp lieferadresse, AdressTyp rechnungsadresse, IList<PostenTyp> posten, DateTime gueltigAb, DateTime gueltigBis, float gesamtPreisNetto)
        {
            this.AngebotId = angebotId;
            this.Kundennummer = kundennummer;
            this.Lieferadresse = lieferadresse;
            this.Rechnungsadresse = rechnungsadresse;
            this.GueltigAb = gueltigAb;
            this.GueltigBis = gueltigBis;
            this.Posten = posten;
            this.GesamtPreisNetto = gesamtPreisNetto;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("\nAngebotTyp ");
            sb.Append(this.AngebotId);
            sb.Append(" GueltigAb: ");
            sb.Append(this.GueltigAb);
            sb.Append(" GueltigBis: ");
            sb.Append(this.GueltigBis);
            sb.Append(" Posten: ");
            sb.Append(this.Posten);
            sb.Append(" Kundennummer: ");
            sb.Append(this.Kundennummer);




            return sb.ToString();
        }

    }
}
