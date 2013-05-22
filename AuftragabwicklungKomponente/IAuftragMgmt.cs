using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;
using NullTypen;

namespace AuftragabwicklungKomponente
{
    public interface IAuftragMgmt
    {

        /// <summary>
        /// Erstellt ein Angebot.
        /// </summary>
        /// <param name="kundennummer"></param>
        /// <param name="lieferadresse"></param>
        /// <param name="rechnungsadresse"></param>
        /// <param name="posten">Dictionary das als Key die Produkte und als value die Anzahl des jeweiligen Produkts hält</param>
        /// <param name="gueltigAb">ab wann das Angebot gültig ist</param>
        /// <param name="gueltigBis">bis wann das Angebot gültig ist</param>
        string AngebotErstellen(string kundennummer, AdressTyp lieferadresse, AdressTyp rechnungsadresse, IDictionary<ProduktTyp, int> posten, DateTime gueltigAb, DateTime gueltigBis);


        /// <summary>
        /// Erstellt einen Auftrag aus einem zuvor erstellten Angebot, mit dem Aktuellen Datum als Auftragsdatum.
        /// </summary>
        /// <param name="angebotsnummer"></param>
        /// <returns>Die Auftragsnummer des neuen Auftrags</returns>
        string AuftragErstellen(string angebotsnummer);


        /// <summary>
        /// Erstellt einen Auftrag aus einem zuvor erstellten Angebot
        /// </summary>
        /// <param name="angebotsnummer"></param>
        /// <param name="beauftragtAm"></param>
        /// <returns></returns>
        string AuftragErstellen(string angebotsnummer, DateTime beauftragtAm);


        /// <summary>
        /// Nutzbar wenn kein Angebot vorliegt, sondern direkt Beauftragt wird,
        /// Mehtode legt intern ein Proxy-Angebot an das vom Moment der Erstellung 14 Tage gültig ist.
        /// Mit dem aktuellen Datum als Auftragsdatum.
        /// </summary>
        /// <param name="kundennummer"></param>
        /// <param name="lieferadresse"></param>
        /// <param name="rechnungsadresse"></param>
        /// <param name="posten"></param>
        /// <returns></returns>
        string AuftragErstellen(string kundennummer, AdressTyp lieferadresse, AdressTyp rechnungsadresse, Dictionary<ProduktTyp, int> posten);


        /// <summary>
        /// Nutzbar wenn kein Angebot vorliegt, sondern direkt Beauftragt wird,
        /// Mehtode legt intern ein Proxy-Angebot an das vom Moment der Erstellung 14 Tage gültig ist
        /// </summary>
        /// <param name="kundennummer"></param>
        /// <param name="lieferadresse"></param>
        /// <param name="rechnungsadresse"></param>
        /// <param name="posten"></param>
        /// <param name="beauftragtAm"></param>
        /// <returns></returns>
        string AuftragErstellen(string kundennummer, AdressTyp lieferadresse, AdressTyp rechnungsadresse, Dictionary<ProduktTyp, int> posten, DateTime beauftragtAm);


        /// <summary>
        /// Markiert einen den Aufrtag mit der zughörigen Auftragsnummer als abgeschlossen.
        /// </summary>
        /// <param name="Auftragsnummer"></param>
        /// <returns>True, wenn Auftrag gefunden und markiert, False sonst.</returns>
        bool AuftragAbschliessen(string auftragsnummer);
    }
}
