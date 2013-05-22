using System;
using System.Collections.Generic;
using System.Linq;a
using System.Text;
using WaWiSubSystem.WaWiVerwaltungKomponente;
using NullTypen.TransportTypen;


namespace WaWiSubSystem.WaWiVerwaltungKomponente
{
    public interface IWaWiFassade
    {

        IList<Produkt_LieferdatumTyp> VersandAnfrage(IDictionary<int, int> produktnr_Anzahl_Dict);








        //?????????????????????????
        //-------Lagerbestand ausreichend
        /// <summary>
        /// Im Fehlerfall wird eine Exception innerhalb des Aufrufs gehandelt und geloggt, 
        /// zusammen mit der Auftragsnummer. Ein Techniker mit der Behebung des Fehlers beauftragt. 
        /// Dieser muss dann auch nicht behandelte Aufträge nachträglich in die Bearbeitung geben.
        /// Die Methode gibt dann ein false zurück.
        /// </summary>
        /// <param name="Produktnumer"></param>
        /// <param name="Anzahl"></param>
        /// <returns></returns>
        //bool WareAuslagern(string Produktnumer, int Anzahl);

    }
}
