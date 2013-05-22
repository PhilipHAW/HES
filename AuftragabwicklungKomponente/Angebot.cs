using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;
using NullTypen;


namespace AuftragabwicklungKomponente
{
    internal class Angebot : IHasId
    {
        /// <summary>
        /// Id for NHibernate
        /// </summary>
        public virtual int Id { get; protected set; }


        public virtual string AngebotId { get; protected set; }


        public virtual DateTime GueltigAb { get; protected set; }
        public virtual DateTime GueltigBis { get; protected set; }

        public virtual IList<Posten> Posten { get; protected set; }

        public virtual string Kundennummer { get; protected set; }
        public virtual AdressTyp Lieferadresse { get; protected set; }
        public virtual AdressTyp Rechnungsadresse { get; protected set; }

        public virtual float GesamtPreisNetto { get; protected set; }





        /// <summary>
        /// empty constructor for NHibernate
        /// </summary>
        private Angebot() { }

        /// <summary>
        /// Konstruiert ein Angebot.
        /// </summary>
        /// <param name="kundennummer"></param>
        /// <param name="lieferadresse"></param>
        /// <param name="rechnungsadresse"></param>
        /// <param name="posten">Posten ist ein Dictionary, das als key das Produkt und als value die angebotene Menge hält.</param>
        /// <param name="gueltigAb">Ab wann das Angebot gültig ist.</param>
        /// <param name="gueltigBis">Bis wann das Produkt gültig ist.</param>
        public Angebot(string angebotId, string kundennummer, AdressTyp lieferadresse, AdressTyp rechnungsadresse, IDictionary<ProduktTyp, int> posten, DateTime gueltigAb, DateTime gueltigBis)
        {
            this.AngebotId = angebotId;
            this.Kundennummer = kundennummer;
            this.Lieferadresse = lieferadresse;
            this.Rechnungsadresse = rechnungsadresse;
            this.GueltigAb = gueltigAb;
            this.GueltigBis = gueltigBis;

            foreach (KeyValuePair<ProduktTyp, int> produkt_menge in posten)
            {
                this.Posten.Add(new Posten(produkt_menge.Key, produkt_menge.Value));
                this.GesamtPreisNetto += produkt_menge.Key.Preis;
            }


        }


        public AngebotTyp GibTransportObjekt()
        {
            IList<PostenTyp> postenTypen = new List<PostenTyp>();

            //neue Liste mit Transporttypen von Posten erstellen (sicher ist sicher ^^)
            foreach (Posten posten in Posten)
            {
                postenTypen.Add(posten.GibTransportObjekt());
            }

            return new AngebotTyp(this.AngebotId, this.Kundennummer, this.Lieferadresse, this.Rechnungsadresse, postenTypen, this.GueltigAb, this.GueltigBis, this.GesamtPreisNetto);
        }


        public string GetCustomId()
        {
            return AngebotId;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("\nAngebot ");
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
