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

        public ProduktTyp getProdukt(int produktNummer)
        {
            throw new NotImplementedException();
        }

        public Produkt_LieferdatumTyp GetLieferDatumFuer(int produktNummer, int anzahl)
        {
            return this.produktBusinessLogic.GetLieferDatumFuer(produktNummer, anzahl);
        }

        public bool ProduktEingegangen(int produktNummer, int anzahl)
        {
            throw new NotImplementedException();
        }


        public int ProduktErstellen( string name, int lagerbestand, IList<EinkaufInfoSatzTyp> einkaufsInfoSaetze, float preis)
        {
            return this.produktBusinessLogic.ProduktErstellen( name, lagerbestand, einkaufsInfoSaetze, preis).ProduktId;
        }





    }
}
