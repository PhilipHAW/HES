using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;
using WaWiSubSystem.ProduktKomponente;
using WaWiSubSystem.LagerLogKomponente;

namespace WaWiSubSystem.WaWiVerwaltungKomponente
{
    public class WaWiVerwaltungLogik
    {



        private IProduktMgmt produktManager;
        private ILagerLogMgmt lagerLogManager;

        public WaWiVerwaltungLogik(IProduktMgmt produktManager, ILagerLogMgmt lagerLogManager)
        {
            this.produktManager = produktManager;
            this.lagerLogManager = lagerLogManager;
        }



        public IList<Produkt_LieferdatumTyp> VersandAnfrage(IDictionary<int, int> produktnr_AnzahlDict)
        {
            IList<Produkt_LieferdatumTyp> ret_produkt_LieferdatumTypList = new List<Produkt_LieferdatumTyp>();


            foreach (KeyValuePair<int, int> produktnr_Anzahl in produktnr_AnzahlDict)
            {

                //Lieferadatum holen
                Produkt_LieferdatumTyp p_LTyp = produktManager.GetLieferDatumFuer(produktnr_Anzahl.Key, produktnr_Anzahl.Value);
                // in return Liste stecken
                ret_produkt_LieferdatumTypList.Add(p_LTyp);


                //wenn das Produkt heute lieferbar ist
                if (p_LTyp.AusliferbarAb.Equals(DateTime.Today))
                {
                    //WarenAusgangsmeldung verfassen
                    this.lagerLogManager.WarenAusgangsmeldung(produktnr_Anzahl.Key, produktnr_Anzahl.Value);
                }
            }
#if DEBUG
            Console.WriteLine("Versandandfrage von WaWiVerwaltungsLogik an ProduktKomponente getätigt...");
#endif





            return ret_produkt_LieferdatumTypList;
        }
    }
}
