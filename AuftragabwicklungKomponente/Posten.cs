using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;


namespace AuftragabwicklungKomponente
{
    internal class Posten
    {

        // Id for NHibernate
        public virtual int Id { get; protected set; }

        public virtual ProduktTyp Produkt { get; protected set; }
        public virtual int Menge { get; protected set; }




        /// <summary>
        /// Constructor for NHibernate
        /// </summary>
        private Posten() { }

        public Posten(ProduktTyp produkt, int menge)
        {
            this.Produkt = produkt;
            this.Menge = menge;
        }



        public PostenTyp GibTransportObjekt()
        {
            return new PostenTyp(Produkt, Menge);
        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("\nPosten mit Produkt: ");
            sb.Append(this.Produkt);
            sb.Append(" und der Menge: ");
            sb.Append(this.Menge);



            return sb.ToString();
        }
    }
}
