using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuslieferungsKomponente.Entitäten
{
    public class LieferPosten
    {

        public virtual int ProduktId { get; protected set; }
        public virtual int Menge { get; protected set; }


        public LieferPosten(int produktId, int menge)
        {
            this.ProduktId = produktId;
            this.Menge = menge;
        }


    }
}
