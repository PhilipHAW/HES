using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;
using WaWiSubSystem.ProduktKomponente;

namespace WaWiSubSystem.WaWiVerwaltungKomponente
{
    public class Produkt_LieferDatum
    {

        // Id for NHibernate
        public virtual int Id { get; protected set; }


        public virtual ProduktTyp Produkt { get; protected set; }
        /// <summary>
        /// Ab wann das Produkt voraussichtlich ausliefervabr ist
        /// </summary>
        public virtual DateTime AusliferbarAb{ get; protected set; }


        /// <summary>
        /// Hält für ein Produkt die Vorraussichtlichen auslieferungstermin.
        /// </summary>
        /// <param name="produkt"></param>
        /// <param name="auslieferbarAb">Ab wann Produkt vorausichtlich aulieferbar.</param>
        public Produkt_LieferDatum(ProduktTyp produkt, DateTime auslieferbarAb)
        {
            this.Produkt = produkt;
            this.AusliferbarAb = auslieferbarAb;
        }


        public Produkt_LieferdatumTyp GibTransportObjekt() {
            return new Produkt_LieferdatumTyp(this.Produkt, this.AusliferbarAb);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("\nProduktnr_Anzahl: ");
            sb.Append(" mit Produkt: ");
            sb.Append(this.Produkt);
            sb.Append(" AusliferbarAb: ");
            sb.Append(this.AusliferbarAb);





            return sb.ToString();
        }

    }
}
