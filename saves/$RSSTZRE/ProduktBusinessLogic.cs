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



        public Produkt_LieferdatumTyp GetLieferDatumFuer(string produktNummer, int anzahl)
        {

            Produkt produkt = produktVerwalter.LoadProdukt(produktNummer);

            TimeSpan planlieferZeit = produkt.EinkaufsInfoSatz.PlanlieferZeit;


            //gegenwärtiges Datum plus planlieferzeit = lieferdatum
            return new Produkt_LieferdatumTyp(produkt.GibTransprotObjekt(), DateTime.Today.Add(planlieferZeit));

        }


        public Produkt ProduktErstellen(string produktId, string name, int lagerbestand, EinkaufsInfoSatzTyp einkaufsInfoSatz)
        {
            return this.produktVerwalter.ProduktErstellen(produktId, name, lagerbestand, einkaufsInfoSatz);
        }

    }
}
