using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullTypen
{
    public class AdressTyp
    {
        public virtual string Name { get; private set; }
        public virtual string Straße { get; private set; }
        public virtual string HausNummer { get; private set; }
        public virtual int Postleitzahl { get; private set; }


        public AdressTyp(string name, string straße, string hausNr, int pLZ)
        {
            this.Name = name;
            this.Straße = straße;
            this.HausNummer = hausNr;
            this.Postleitzahl = pLZ;

        }



    }
}
