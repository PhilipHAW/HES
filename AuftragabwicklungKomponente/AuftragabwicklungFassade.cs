using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NullTypen.TransportTypen;
using WaWiSubSystem.WaWiVerwaltungKomponente;
using NullTypen;


namespace AuftragabwicklungKomponente
{
    public class AuftragabwicklungFassade : IAuftragMgmt
    {
        #region Properties

        private AuftragabwicklungLogik AuftragabwicklungsLogik { get; set; }
       

        #endregion





        #region Consructor

        public AuftragabwicklungFassade(ISessionFactory sessionFactory, IWaWiFassade waWiFassade)
        {
            this.AuftragabwicklungsLogik = new AuftragabwicklungLogik(sessionFactory, waWiFassade);
           
        }

        #endregion

        /// <summary>
        /// Erstellt ein Angebot.
        /// </summary>
        /// <param name="kundennummer"></param>
        /// <param name="lieferadresse"></param>
        /// <param name="rechnungsadresse"></param>
        /// <param name="posten">Dictionary das als Key die Produkte und als value die Anzahl des jeweiligen Produkts hält</param>
        /// <param name="gueltigAb">ab wann das Angebot gültig ist</param>
        /// <param name="gueltigBis">bis wann das Angebot gültig ist</param>
        public string AngebotErstellen(string kundennummer, AdressTyp lieferadresse, AdressTyp rechnungsadresse, IDictionary<ProduktTyp, int> posten, DateTime gueltigAb, DateTime gueltigBis)
        {

            return this.AuftragabwicklungsLogik.AngebotErstellen(kundennummer, lieferadresse, rechnungsadresse, posten, gueltigAb, gueltigBis).AngebotId;
        }


        /// <summary>
        /// Erstellt einen Auftrag aus einem zuvor erstellten Angebot, mit dem Aktuellen Datum als Auftragsdatum.
        /// </summary>
        /// <param name="angebotsnummer"></param>
        /// <returns>Die Auftragsnummer des neuen Auftrags</returns>
        public string AuftragErstellen(string angebotsnummer)
        {
            return this.AuftragErstellen(angebotsnummer, DateTime.Now);
        }


        /// <summary>
        /// Erstellt einen Auftrag aus einem zuvor erstellten Angebot
        /// </summary>
        /// <param name="angebotsnummer"></param>
        /// <param name="beauftragtAm"></param>
        /// <returns></returns>
        public string AuftragErstellen(string angebotsnummer, DateTime beauftragtAm)
        {
            return this.AuftragabwicklungsLogik.AuftragErstellen(angebotsnummer, beauftragtAm).AuftragId;
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
            return this.AuftragErstellen(kundennummer, lieferadresse, rechnungsadresse, posten, DateTime.Now);
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
            return AuftragabwicklungsLogik.AuftragErstellen(kundennummer, lieferadresse, rechnungsadresse, posten, beauftragtAm).AuftragId;
        }


        /// <summary>
        /// Markiert einen den Aufrtag mit der zughörigen Auftragsnummer als abgeschlossen.
        /// </summary>
        /// <param name="auftragsnummer"></param>
        /// <returns>True, wenn Auftrag gefunden und markiert, False sonst.</returns>
        public bool AuftragAbschliessen(string auftragsnummer)
        {
            return this.AuftragabwicklungsLogik.AuftragAbschliessen(auftragsnummer);
        }
    }
}
