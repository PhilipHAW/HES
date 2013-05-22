using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rechnungskomponente
{
    public class Zahlungseingang
    {
        public virtual int id {get; protected set;}
        public virtual DateTime eingangsDatum { get; set; }
        public virtual Double betrag { get; set; }


        private Zahlungseingang() { }
        public Zahlungseingang(DateTime eingangsDatum, Double betrag) {
            this.eingangsDatum = eingangsDatum;
            this.betrag = betrag;
        }



    }
}
