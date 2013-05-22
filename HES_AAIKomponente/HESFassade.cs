using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KundenKomponente;
using AuftragabwicklungKomponente;
using NullTypen;
using NullTypen.TransportTypen;
using WaWiSubSystem.ProduktKomponente;
using Rechnungskomponente;

namespace HESFassadeKomponente
{
    public class HESFassade : IHESFassade
    {

        private IKundenMgmt kundenManager;
        private IAuftragMgmt auftragManager;
        private IProduktDetails produktDetailsManager;
        private IRechnungMgmt rechnungManager;

        public HESFassade(IKundenMgmt kundenMgmt, IAuftragMgmt auftragMgmt, IProduktDetails produktDetailsManager, IRechnungMgmt rechnungManager)
        {
            this.kundenManager = kundenMgmt;
            this.auftragManager = auftragMgmt;
            this.produktDetailsManager = produktDetailsManager;
            this.rechnungManager = rechnungManager;
        }

        public int KundeErstellen(string vorName, string nachName, IList<AdressTyp> adressen)
        {
            return kundenManager.KundenAnlegen(vorName, nachName, adressen);
        }


        public KundenTyp GetKunde(int kundenNummer)
        {
            return kundenManager.GetKunde(kundenNummer);
        }


        /// <summary>
        /// Erstellt ein Angebot.
        /// </summary>
        /// <param name="kundennummer"></param>
        /// <param name="lieferadresse"></param>
        /// <param name="rechnungsadresse"></param>
        /// <param name="posten">Dictionary das als Key die Produkte und als value die Anzahl des jeweiligen Produkts hält</param>
        /// <param name="gueltigAb">ab wann das Angebot gültig ist</param>
        /// <param name="gueltigBis">bis wann das Angebot gültig ist</param>
        public string AngebotErstellen(string kundenNummer, AdressTyp lieferAdresse, AdressTyp rechnungsAdresse, IDictionary<ProduktTyp, int> posten, DateTime gueltigAb, DateTime gueltigBis)
        {
            return auftragManager.AngebotErstellen(kundenNummer, lieferAdresse, rechnungsAdresse, posten, gueltigAb, gueltigBis);
        }



        /// <summary>
        /// Erstellt einen Auftrag aus einem zuvor erstellten Angebot, mit dem Aktuellen Datum als Auftragsdatum.
        /// </summary>
        /// <param name="angebotsnummer"></param>
        /// <returns>Die Auftragsnummer des neuen Auftrags</returns>
        public String AuftragErstellen(string AngebotsNummer)
        {
            return auftragManager.AuftragErstellen(AngebotsNummer);
        }




        /// <summary>
        /// Erstellt einen Auftrag aus einem zuvor erstellten Angebot
        /// </summary>
        /// <param name="angebotsnummer"></param>
        /// <param name="beauftragtAm"></param>
        /// <returns></returns>
        public string AuftragErstellen(string angebotsnummer, DateTime beauftragtAm)
        {
            return auftragManager.AuftragErstellen(angebotsnummer, beauftragtAm);
        }


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
        public string AuftragErstellen(string kundennummer, AdressTyp lieferadresse, AdressTyp rechnungsadresse, Dictionary<ProduktTyp, int> posten)
        {
            return auftragManager.AuftragErstellen(kundennummer, lieferadresse, rechnungsadresse, posten);
        }


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
        public string AuftragErstellen(string kundennummer, AdressTyp lieferadresse, AdressTyp rechnungsadresse, Dictionary<ProduktTyp, int> posten, DateTime beauftragtAm)
        {
            return auftragManager.AuftragErstellen(kundennummer, lieferadresse, rechnungsadresse, posten, beauftragtAm);
        }


        /// <summary>
        /// Markiert einen den Aufrtag mit der zughörigen Auftragsnummer als abgeschlossen.
        /// </summary>
        /// <param name="auftragsnummer"></param>
        /// <returns>True, wenn Auftrag gefunden und markiert, False sonst.</returns>
        public bool AuftragAbschliessen(string auftragsnummer)
        {
            return auftragManager.AuftragAbschliessen(auftragsnummer);
        }



    }
}
