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
        /// <summary>
        /// ist erstmal auf -1 solange nicht gesetzt
        /// </summary>
        public virtual int ProduktId { get; protected set; }

        /// <summary>
        /// Constructor for NHibernate
        /// </summary>
        private EinkaufsInfoSatz() { }

        internal EinkaufsInfoSatz(DateTime gueltigAb, DateTime gueltigBis, TimeSpan planlieferZeit, int normalMenge, float preis)
        {
            this.GueltigAb = gueltigAb;
            this.GueltigBis = gueltigBis;
            this.PlanlieferZeit = planlieferZeit;
            this.NormalMenge = normalMenge;
            this.Preis = preis;
            this.ProduktId = -1;


        }



        public void SetzeProduktId(int id)
        {
            this.ProduktId = id;
        }


        public EinkaufInfoSatzTyp GibTransprotObjekt()
        {

            return new EinkaufInfoSatzTyp(this.GueltigAb, this.GueltigBis, this.PlanlieferZeit, this.NormalMenge, this.Preis);
        }




    }
}
