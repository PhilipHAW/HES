using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;

namespace WaWiSubSystem.NachbestellungsKomponente
{
    internal class EinkaufsInfoSatz
    {
        public virtual int Id { get; protected set; }

        public virtual DateTime GueltigAb { get; protected set; }
        public virtual DateTime GueltigBis { get; protected set; }
        //new TimeSpan(14, 0, 0, 0)
        public virtual TimeSpan PlanlieferZeit { get; protected set; }
        public virtual int NormalMenge { get; protected set; }
        public virtual float Preis { get; protected set; }
        public virtual Lieferant Lieferant { get; protected set; }

        /// <summary>
        /// Constructor for NHibernate
        /// </summary>
        private EinkaufsInfoSatz() { }

        public EinkaufsInfoSatz(DateTime gueltigAb, DateTime gueltigBis, TimeSpan planlieferZeit, int normalMenge, float preis, Lieferant lieferant)
        {
            this.GueltigAb = gueltigAb;
            this.GueltigBis = gueltigBis;
            this.PlanlieferZeit = planlieferZeit;
            this.NormalMenge = normalMenge;
            this.Preis = preis;
            this.Lieferant = lieferant;
        }





        public EinkaufsInfoSatzTyp GibTransprotObjekt()
        {

            return new EinkaufsInfoSatzTyp(this.GueltigAb, this.GueltigBis, this.PlanlieferZeit, this.NormalMenge, this.Preis, this.Lieferant.GibTransportObjekt());
        }




    }
}
