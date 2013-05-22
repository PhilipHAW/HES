using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankMock
{
    public interface IHAPSARBankMgmt
    {
        /// <summary>
        /// Gibt ein Idictionary von RechnungsNummern und eingegangenen Betrag zurück, die am vorherigen Tag eingegangen sind.
        /// </summary>
        /// <param name="auftragNummer"></param>
        /// <returns>Dictionary von  RechnungsNummern und eingegangenen Betrag , die eingegangen sind.</returns>
        IDictionary<int, float> GetZahlungsEingängeVonGestern();

        /// <summary>
        /// Gibt ein Dictionary von RechnungsNummern und eingegangenen Betrag zurück, die am am angegebenen Datum eingegangen sind.
        /// </summary>
        /// <param name="datum">Das Datum zu dem die Zahlungseingänge abagerufen werden sollen.</param>
        /// <returns>Dictionary von  RechnungsNummern und eingegangenen Betrag , die eingegangen sind.</returns>
        IDictionary<int, float> GetZahlungsEingängeVomDatum(DateTime datum);

    }
}
