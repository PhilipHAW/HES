using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullTypen.TransportTypen
{
    public class EinkaufInfoSatzTyp
    {

        public virtual DateTime GueltigAb { get; private set; }
        public virtual DateTime GueltigBis { get; private set; }
        //new TimeSpan(14, 0, 0, 0)
        public virtual TimeSpan PlanlieferZeit { get; private set; }
        public virtual int NormalMenge { get; private set; }
        public virtual float Preis { get; private set; }
        //public virtual LieferantTyp Lieferant { get; private set; }
        public virtual int ProduktId { get; private set; }


        public EinkaufInfoSatzTyp(DateTime gueltigAb, DateTime gueltigBis, TimeSpan planlieferZeit, int normalMenge, float preis)
        {
            this.GueltigAb = gueltigAb;
            this.GueltigBis = gueltigBis;
            this.PlanlieferZeit = planlieferZeit;
            this.NormalMenge = normalMenge;
            this.Preis = preis;
            //this.Lieferant = lieferant;
        }


        public void SetzeProduktId(int id)
        {
            this.ProduktId = id;
        }

    }
}
