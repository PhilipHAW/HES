using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NachbarSysteme.TrasnportDienstleisterMock
{
    public interface ITransportDienstleisterMgmt
    {
        /// <summary>
        /// Gibt eine Liste von AuftragsIds zurück, derern zugehörigen Aufträge am vorherigen Tag ausgeliefert wurden.
        /// </summary>
        /// <param name="auftragNummer"></param>
        /// <returns>Listen von AUftragsnummern, die ausgeliefert wurden.</returns>
        IList<string> GetAusgelieferteAufträgeVonGestern();

        /// <summary>
        /// Gibt eine Liste von AuftragsIds zurück, derern zugehörigen Aufträge am angegebenen Datum ausgeliefert wurden.
        /// </summary>
        /// <param name="datum">Das Datum zu dem die Aufträge zurückgegeben werden sollen.</param>
        /// <returns>Listen von AUftragsnummern, die ausgeliefert wurden.</returns>
        IList<string> GetAusgelieferteAufträgeVomDatum(DateTime datum);


    }
}
