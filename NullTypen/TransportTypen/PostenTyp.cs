using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullTypen.TransportTypen
{
    public class PostenTyp
    {

        // Id for NHibernate
        public virtual int Id { get; private set; }

        public virtual int ProduktId { get; private set; }
        public virtual int Menge { get; private set; }
        public virtual float NettoPreis { get; private set; }
        public virtual string ProduktName { get; private set; }

        public PostenTyp(int produktId, float nettoPreis, string produktName, int menge)
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

    }
}
