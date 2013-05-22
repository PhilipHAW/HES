using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullTypen.TransportTypen
{
    public class Produkt_LieferdatumTyp
    {

        
        // Id for NHibernate
        public virtual int Id { get; protected set; }


        public virtual ProduktTyp Produkt { get; private set; }
        /// <summary>
        /// Ab wann das Produkt voraussichtlich ausliefervabr ist
        /// </summary>
        public virtual DateTime AusliferbarAb{ get; private set; }


        /// <summary>
        /// Hält für ein Produkt die Vorraussichtlichen auslieferungstermin.
        /// </summary>
        /// <param name="produkt"></param>
        /// <param name="auslieferbarAb">Ab wann Produkt vorausichtlich aulieferbar.</param>
        public Produkt_LieferdatumTyp(ProduktTyp produkt, DateTime auslieferbarAb)
        {
            this.Produkt = produkt;
            this.AusliferbarAb = auslieferbarAb;
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("\nProduktnr_AnzahlTyp: ");
            sb.Append(" mit Produkt: ");
            sb.Append(this.Produkt);
            sb.Append(" AusliferbarAb: ");
            sb.Append(this.AusliferbarAb);





            return sb.ToString();
        }

    }
}
