using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;

namespace WaWiSubSystem.ProduktKomponente
{
    public interface IProduktMgmt
    {

        IList<ProduktTyp> GetAlleProdukte();

        IList<ProduktTyp> GetAlleProdukteVomTyp(Enum produktTyp);

        //TODO: diese Methode muss wieder einkommentiert werden
        //IList<ProduktTyp> GetAlleProdukteVomTyp(Enum Hersteller);



        ProduktTyp getProdukt(string produktNummer);

        Produkt_LieferdatumTyp GetLieferDatumFuer(string produktNummer, int anzahl);

        bool ProduktEingegangen(string produktNummer, int anzahl);
    }
}
