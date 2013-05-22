using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;
using WaWiSubSystem.ProduktKomponente;
using WaWiSubSystem.LagerLogKomponente;
using WaWiSubSystem.NachbestellungsKomponente;

namespace WaWiSubSystem.WaWiVerwaltungKomponente
{
    public class WaWiVerwaltungFassade : IWaWiFassade
    {


        private WaWiVerwaltungLogik waWiVerwaltungLogik;
        private INachbestellungMgmt nachbestellungManager;
        private ILagerLogMgmt lagerLogManager;
        private IProduktMgmt produktManager;

        public WaWiVerwaltungFassade(IProduktMgmt produktManager, ILagerLogMgmt lagerLogManager, INachbestellungMgmt nachbestellungManager)
        {
            this.waWiVerwaltungLogik = new WaWiVerwaltungLogik(produktManager, lagerLogManager);
            this.nachbestellungManager = nachbestellungManager;
            this.lagerLogManager = lagerLogManager;
            this.produktManager = produktManager;

            this.erzeugeTestDaten();

        }


        private void erzeugeTestDaten()
        {
            Console.WriteLine("#################################");
            IList<EinkaufInfoSatzTyp> eISatzList = new List<EinkaufInfoSatzTyp>();
            EinkaufInfoSatzTyp eISatzTyp = nachbestellungManager.EinkaufsInfoSatzTypErstellen(DateTime.Today, DateTime.Today.Add(new TimeSpan(14, 0, 0, 0)), new TimeSpan(14, 0, 0, 0), 50, 150.00F);
            eISatzList.Add(eISatzTyp);
            Console.WriteLine(this.produktManager.ProduktErstellen("hdd200", 50, eISatzList, 200.00F));
            Console.WriteLine(this.produktManager.ProduktErstellen("hostbox", 10, eISatzList, 80.00F));
            Console.ReadLine();
        }


        public IList<Produkt_LieferdatumTyp> VersandAnfrage(IDictionary<int, int> produktnr_AnzahlDict)
        {
            return waWiVerwaltungLogik.VersandAnfrage(produktnr_AnzahlDict);
        }

        /// <summary>
        /// keine ahnung wozu der bullshit hier da ist
        /// </summary>
        /// <param name="Produktnumer"></param>
        /// <param name="Anzahl"></param>
        /// <returns></returns>
        //public bool WareAuslagern(string Produktnumer, int Anzahl)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
