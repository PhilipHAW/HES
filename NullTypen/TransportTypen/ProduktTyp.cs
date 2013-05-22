using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullTypen.TransportTypen
{
    public class ProduktTyp
    {

        public int ProduktId { get; private set; }
        public string Name { get; private set; }
        public int Lagerbestand { get; private set; }
        public IList<EinkaufInfoSatzTyp> EinkaufsInfoSaetze { get; private set; }
        public virtual float Preis { get; private set; }


        public ProduktTyp(int produktId, string name, int lagerbestand, IList<EinkaufInfoSatzTyp> einkaufsInfoSaetze, float preis)
        {

            this.ProduktId = produktId;
            this.Name = name;
            this.Lagerbestand = lagerbestand;
            this.EinkaufsInfoSaetze = einkaufsInfoSaetze;
            this.Preis = preis;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("\nProduktTyp: ");
            sb.Append(this.Name);
            sb.Append(" mit ProduktId: ");
            sb.Append(this.ProduktId);
            sb.Append(" Lagerbestand: ");
            sb.Append(this.Lagerbestand);
            int i = 0;
            foreach (EinkaufInfoSatzTyp eISTyp in EinkaufsInfoSaetze)
            {
                sb.Append(i + ". EinkaufsInfoSatz: ");
                sb.Append(this.EinkaufsInfoSaetze);
                i++;
            }





            return sb.ToString();
        }
    }
}
