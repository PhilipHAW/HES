using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;
using NHibernate;

namespace WaWiSubSystem.ProduktKomponente
{
    internal class ProduktBusinessLogic
    {
        private ProduktVerwalter produktVerwalter;

        public ProduktBusinessLogic(ISessionFactory sessionFactory)
        {
            this.produktVerwalter = new ProduktVerwalter(sessionFactory);
        }



        public Produkt_LieferdatumTyp GetLieferDatumFuer(int produktNummer, int anzahl)
        {

            Produkt produkt = produktVerwalter.LoadProdukt(produktNummer);
            //TODO: ist hier für prototyp-zwecke hartgecoded, müsste später noch angepasst werden...
            TimeSpan planlieferZeit = produkt.EinkaufsInfoSaetze[0].PlanlieferZeit;


            //gegenwärtiges Datum plus planlieferzeit = lieferdatum
            return new Produkt_LieferdatumTyp(produkt.GibTransprotObjekt(), DateTime.Today.Add(planlieferZeit));

        }


        public Produkt ProduktErstellen( string name, int lagerbestand, IList<EinkaufInfoSatzTyp> einkaufsInfoSaetze, float preis)
        {
            int produktId = this.produktVerwalter.GetNeueProduktNummer();

            foreach (EinkaufInfoSatzTyp eISatzTyp in einkaufsInfoSaetze)
            { 
                eISatzTyp.SetzeProduktId(produktId);
            }

            return this.produktVerwalter.ProduktErstellen(produktId, name, lagerbestand, einkaufsInfoSaetze, preis);
        }

    }
}
