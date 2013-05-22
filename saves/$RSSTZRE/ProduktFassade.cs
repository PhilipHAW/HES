using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;
using NHibernate;

namespace WaWiSubSystem.ProduktKomponente
{
    public class ProduktFassade : IProduktMgmt, IProduktDetails
    {

        private ProduktBusinessLogic produktBusinessLogic;



        public ProduktFassade(ISessionFactory sessionFactory)
        {
            
            this.produktBusinessLogic = new ProduktBusinessLogic(sessionFactory);
        }


        public IList<ProduktTyp> GetAlleProdukte()
        {
            throw new NotImplementedException();
        }

        public IList<ProduktTyp> GetAlleProdukteVomTyp(Enum produktTyp)
        {
            throw new NotImplementedException();
        }

        public ProduktTyp getProdukt(string produktNummer)
        {
            throw new NotImplementedException();
        }

        public Produkt_LieferdatumTyp GetLieferDatumFuer(string produktNummer, int anzahl)
        {
           return this.produktBusinessLogic.GetLieferDatumFuer( produktNummer,  anzahl);
        }

        public bool ProduktEingegangen(string produktNummer, int anzahl)
        {
            throw new NotImplementedException();
        }


        public ProduktTyp ProduktErstellen(string produktId, string name, int lagerbestand, EinkaufsInfoSatzTyp einkaufsInfoSatz)
        {
            return this.produktBusinessLogic.ProduktErstellen(produktId, name, lagerbestand, einkaufsInfoSatz).GibTransprotObjekt() ;
        }
    }
}
