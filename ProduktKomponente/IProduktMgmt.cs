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



        ProduktTyp getProdukt(int produktNummer);

        Produkt_LieferdatumTyp GetLieferDatumFuer(int produktNummer, int anzahl);

        bool ProduktEingegangen(int produktNummer, int anzahl);

        int ProduktErstellen(string name, int lagerbestand, IList<EinkaufInfoSatzTyp> einkaufsInfoSaetze, float preis);
    }
}
