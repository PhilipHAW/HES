using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;

namespace WaWiSubSystem.ProduktKomponente
{
    internal class Produkt
    {

        // Id for NHibernate
        public virtual int Id { get; protected set; }


        public virtual string ProduktId { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual int Lagerbestand { get; protected set; }
        public virtual EinkaufsInfoSatzTyp EinkaufsInfoSatz { get; protected set; }

        /// <summary>
        /// Constructor for NHibernate
        /// </summary>
        private Produkt() { }



        public Produkt(string produktId, string name, int lagerbestand, EinkaufsInfoSatzTyp einkaufsInfoSatz)
        {

            this.ProduktId = produktId;
            this.Name = name;
            this.Lagerbestand = lagerbestand;
            this.EinkaufsInfoSatz = einkaufsInfoSatz;

        }




        public ProduktTyp GibTransprotObjekt()
        {

            return new ProduktTyp(this.ProduktId, this.Name, this.Lagerbestand, this.EinkaufsInfoSatz);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("\nProdukt: ");
            sb.Append(this.Name);
            sb.Append(" mit ProduktId: ");
            sb.Append(this.ProduktId);
            sb.Append(" Lagerbestand: ");
            sb.Append(this.Lagerbestand);
            sb.Append(" EinkaufsInfoSatz: ");
            sb.Append(this.EinkaufsInfoSatz);





            return sb.ToString();
        }
    }
}
