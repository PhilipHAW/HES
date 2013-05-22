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

        public virtual int ProduktId { get; protected set; }
        public virtual int Menge { get; protected set; }
        public virtual float NettoPreis { get; protected set; }
        public virtual string ProduktName { get; protected set; }




        /// <summary>
        /// Constructor for NHibernate
        /// </summary>
        private Posten() { }

        public Posten(int produktId, float nettoPreis, string produktName, int menge)
        {
            this.ProduktId = produktId;
            this.Menge = menge;
            this.NettoPreis = nettoPreis;
            this.ProduktName = produktName;
        }



        


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("\nPosten mit Produkt: ");
            sb.Append(this.ProduktId);
            sb.Append(" ProduktName: ");
            sb.Append(this.ProduktName);
            sb.Append(" NettoPreis: ");
            sb.Append(this.NettoPreis);
            sb.Append(" und der Menge: ");
            sb.Append(this.Menge);



            return sb.ToString();
        }

        internal PostenTyp GibTransportObjekt()
        {
            return new PostenTyp(this.ProduktId, this.NettoPreis, this.ProduktName, this.Menge);
        }
    }
}
