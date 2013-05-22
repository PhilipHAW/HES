using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullTypen.TransportTypen
{
    public class PostenTyp
    {

        public virtual ProduktTyp ProduktTyp { get; private set; }
        public virtual int Menge { get; private set; }



        public PostenTyp(ProduktTyp produktTyp, int menge)
        {
            this.ProduktTyp = produktTyp;
            this.Menge = menge;
        }




        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("\nPostenTyp mit Produkt: ");
            sb.Append(this.ProduktTyp);
            sb.Append(" und der Menge: ");
            sb.Append(this.Menge);



            return sb.ToString();
        }

    }
}
