using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;
using NHibernate;
using NachbarSysteme.TrasnportDienstleisterMock;

namespace AuslieferungsKomponente
{
    public class AuslieferungsFassade : IAuslieferungsMgmt
    {

        private readonly ITransportDienstleisterMgmt transportdienstleisterManager;
        private readonly LieferungsVerwalter lieferungsVerwalter;
        private readonly TransportAuftragsVerwalter transportAuftragsVerwalter;
        private readonly AuslieferungsBusinessLogic auslieferungsBusinessLogic;

        public AuslieferungsFassade(ISessionFactory sessionFactory, ITransportDienstleisterMgmt transportDienstleisterManager)
        {
            this.transportdienstleisterManager = transportdienstleisterManager;
            this.lieferungsVerwalter = new LieferungsVerwalter(sessionFactory);
            this.transportAuftragsVerwalter = new TransportAuftragsVerwalter(sessionFactory);
            this.auslieferungsBusinessLogic = new AuslieferungsBusinessLogic(lieferungsVerwalter, transportAuftragsVerwalter, transportDienstleisterManager);

        }


        /// <summary>
        /// Erstellt eine Lieferung und ein TransportAuftrag und erstellt die OneToOne beziehung zwischen 
        /// Lieferung und TransportAuftrag
        /// </summary>
        /// <param name="auftragTyp"> Ist ein AuftragTyp</param>
        /// <returns>Gibt True zurück wenn das Erstellen erfolgreich war </returns>
        public Boolean AuslieferungTransportErstellen(AuftragTyp auftragTyp)
        {

            return this.auslieferungsBusinessLogic.AuslieferungTransportErstellen(auftragTyp);
        }




        public bool IstLieferungErfolgtFür(string auftragNummer)
        {
            return this.auslieferungsBusinessLogic.istLieferungErfolgtFür(auftragNummer);
        }





        public void HoleErfolgreicheLieferungenVonTransportdiensleisterUndSetzeBeiIhnenAusgeliefertAufTrue()
        {
           this.auslieferungsBusinessLogic.HoleErfolgreicheLieferungenVonTransportdiensleisterUndSetzeBeiIhnenAusgeliefertAufTrue();
    }
}
