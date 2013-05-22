using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;

namespace AuslieferungsKomponente
{
    public interface IAuslieferungsMgmt
    {
     
        /// <summary>
        /// Ist das Interface für die Fassade 
        /// </summary>
        /// <param name="auftragTyp"> Ist ein AuftragsTyp</param>
        /// <returns></returns>
        Boolean AuslieferungTransportErstellen(AuftragTyp auftragTyp);



        bool IstLieferungErfolgtFür(string auftragNummer);


        void HoleErfolgreicheLieferungenVonTransportdiensleisterUndSetzeBeiIhnenAusgeliefertAufTrue();
    }
}
