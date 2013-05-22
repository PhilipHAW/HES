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


        public virtual int ProduktId { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual int Lagerbestand { get; protected set; }
        public virtual IList<EinkaufInfoSatzTyp> EinkaufsInfoSaetze { get; protected set; }
        public virtual float Preis { get; protected set; }

        /// <summary>
        /// Constructor for NHibernate
        /// </summary>
        private Produkt() { }



        public Produkt(int produktId, string name, int lagerbestand, IList<EinkaufInfoSatzTyp> einkaufsInfoSaetze, float preis)
        {

            this.ProduktId = produktId;
            this.Name = name;
            this.Lagerbestand = lagerbestand;
            this.EinkaufsInfoSaetze = einkaufsInfoSaetze;
            this.Preis = preis;

        }




        public ProduktTyp GibTransprotObjekt()
        {

            return new ProduktTyp(this.ProduktId, this.Name, this.Lagerbestand, this.EinkaufsInfoSaetze, this.Preis);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("\nProdukt: ");
            sb.Append(this.Name);
            sb.Append(" mit ProduktId: ");
            sb.Append(this.ProduktId);
            sb.Append(" Lagerbestand: ");
            sb.Append(this.Lagerbestand);
            int i = 0;
            foreach (EinkaufInfoSatzTyp eISTyp in EinkaufsInfoSaetze)
            {
                sb.Append(i +". EinkaufsInfoSatz: ");
                sb.Append(this.EinkaufsInfoSaetze);
                i++;
            }





            return sb.ToString();
        }
    }
}
