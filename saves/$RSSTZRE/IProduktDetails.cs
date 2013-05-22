using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;

namespace WaWiSubSystem.ProduktKomponente
{
    interface IProduktDetails
    {
        IList<ProduktTyp> GetAlleProdukte();

        IList<ProduktTyp> GetAlleProdukteVomTyp(Enum produktTyp);

        //TODO: diese Methode muss wieder einkommentiert werden
        //IList<ProduktTyp> GetAlleProdukteVomTyp(Enum Hersteller);



        ProduktTyp getProdukt(string produktNummer);


    }
}
