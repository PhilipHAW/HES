using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NullTypen.TransportTypen;
using WaWiSubSystem.WaWiVerwaltungKomponente;
using NullTypen;
using Rechnungskomponente;
using AuslieferungsKomponente;

namespace AuftragabwicklungKomponente
{
    internal class AuftragabwicklungLogik
    {

        private AngebotVerwalter AngebotVerwalter { get; set; }
        private AuftragVerwalter AuftragVerwalter { get; set; }
        private IWaWiFassade WaWiFassade { get; set; }
        private IRechnungMgmt RechnungMgmt { get; set; }
        private IAuslieferungsMgmt AuslieferungsMgmt { get; set; }


        private ISessionFactory sessionFactory;

        internal AuftragabwicklungLogik(ISessionFactory sessionFactory, IWaWiFassade waWiFassade)
        {
            this.sessionFactory = sessionFactory;
            this.WaWiFassade = waWiFassade;

            this.AngebotVerwalter = new AngebotVerwalter(sessionFactory);
            this.AuftragVerwalter = new AuftragVerwalter(sessionFactory);
        }


        /// <summary>
        /// Erstellt 
        /// </summary>
        /// <param name="kundennummer"></param>
        /// <param name="lieferadresse"></param>
        /// <param name="rechnungsadresse"></param>
        /// <param name="posten"></param>
        /// <param name="gueltigAb"></param>
        /// <param name="gueltigBis"></param>
        /// <returns></returns>
        internal Angebot AngebotErstellen(string kundennummer, AdressTyp lieferadresse, AdressTyp rechnungsadresse, IDictionary<ProduktTyp, int> posten, DateTime gueltigAb, DateTime gueltigBis)
        {

            return this.AngebotVerwalter.AngebotErstellen(GetNextIdForType<Angebot>(), kundennummer, lieferadresse, rechnungsadresse, posten, gueltigAb, gueltigBis);
        }






        /// <summary>
        /// Erstellt einen Auftrag aus einem zuvor erstellten Angebot.
        /// </summary>
        /// <param name="angebotId"></param>
        /// <param name="beauftragtAm"></param>
        /// <returns></returns>
        internal Auftrag AuftragErstellen(string angebotId, DateTime beauftragtAm)
        {

            Angebot angebot = this.AngebotVerwalter.GetAngebot(angebotId);

            // Triggert von Verandanfrage bei WaWi-Subsystem und gibt aus den zurückkommenden Lieferdaten das späteste zurück.
            DateTime spaetestesLieferdatum = this.VersandanfrageTriggern(angebot);


            Auftrag auftrag = this.AuftragVerwalter.AuftragErstellen(angebot, GetNextIdForType<Auftrag>(), beauftragtAm, spaetestesLieferdatum);

            //informiere AuslieferungsKomponente und Rechnungskomponente und setzt auftrag.IstLieferbar = true 
            //wenn alles heute lieferbar ist 
            this.Auslieferung_RechnungTriggern(auftrag, spaetestesLieferdatum);

            return auftrag;
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
        internal Auftrag AuftragErstellen(string kundennummer, AdressTyp lieferadresse, AdressTyp rechnungsadresse, IDictionary<ProduktTyp, int> posten, DateTime beauftragtAm)
        {

            //14 Tage auf die gegenwertige DateTime rechnen um das Proxy-Angebot für die Auftragsabwicklung valide zu hatlen
            DateTime gueltigBis = DateTime.Today.Add(new TimeSpan(14, 0, 0, 0));

            Angebot angebot = this.AngebotErstellen(kundennummer, lieferadresse, rechnungsadresse, posten, DateTime.Now, gueltigBis);

            // Triggert von Verandanfrage bei WaWi-Subsystem und gibt aus den zurückkommenden Lieferdaten das späteste zurück.
            DateTime spaetestesLieferdatum = this.VersandanfrageTriggern(angebot);

            Auftrag auftrag = this.AuftragVerwalter.AuftragErstellen(angebot, GetNextIdForType<Auftrag>(), beauftragtAm, spaetestesLieferdatum);

            //informiere AuslieferungsKomponente und Rechnungskomponente und setzt auftrag.IstLieferbar = true 
            //wenn alles heute lieferbar ist 
            this.Auslieferung_RechnungTriggern(auftrag, spaetestesLieferdatum);

            return auftrag;
        }




        /// <summary>
        /// Triggert Verandanfrage bei WaWi-Subsystem und gibt aus den zurückkommenden Lieferdaten das späteste zurück.
        /// </summary>
        /// <param name="angebot"></param>
        /// <returns>Das späteste Datum, das ein Posten (Produkt) hat bis es ausgeliefert werden kann, sprich im Lager vorätig ist.</returns>
        private DateTime VersandanfrageTriggern(Angebot angebot)
        {
            //Posten umwandeln in andere Repräesntation zum aus der Komponenten rausgeben
            IDictionary<int, int> produktnr_Anzahl = new Dictionary<int, int>();
            IList<Posten> postenListe = angebot.Posten;


            foreach (Posten posten in postenListe)
            {
                produktnr_Anzahl.Add(posten.Produkt.ProduktId, posten.Menge);
            }

            //Versandanfrage machen
            IList<Produkt_LieferdatumTyp> produkt_LieferdatumList = this.VersandAnfrage(produktnr_Anzahl);

            //spätestes Lieferdatum finden
            DateTime spaetestesLieferdatum = DateTime.Today;
            foreach (Produkt_LieferdatumTyp produkt_Lieferdatum in produkt_LieferdatumList)
            {
                if (spaetestesLieferdatum < produkt_Lieferdatum.AusliferbarAb)
                {
                    spaetestesLieferdatum = produkt_Lieferdatum.AusliferbarAb;
                }
            }
            return spaetestesLieferdatum;
        }


        /// <summary>
        /// Informiert AuslieferungsKomponente und Rechnungskomponente und setzt auftrag.IstLieferbar = true 
        /// wenn spätestesLieferdatum == DateTime.Today is, sprich alles "heute" lieferbar ist.
        /// </summary>
        /// <param name="auftrag"></param>
        /// <param name="spaetestesLieferdatum">Hier muss darauf geachtet werden, dass das Datum mit der Uhrzeit 00:00:00 versehen ist um den Vergleich mit DateTime.Today 
        /// zu ermöglichen. Ist dies nicht der Fall, wird ein Datum das von Heute einer späteren Urzeit bewirken, dass die Mehtode den Auftrag als nicht lieferbar wertet.</param>
        internal void Auslieferung_RechnungTriggern(Auftrag auftrag, DateTime spaetestesLieferdatum)
        {
            //wenn alles heute lieferbar ist, informiere AuslieferungsKomponente und Rechnungskomponente
            if (DateTime.Today.Equals(spaetestesLieferdatum))
            {
                //Auftrag auf lieferbar == true
                auftrag.SetLieferbar();

                this.AuslieferungsMgmt.AuslieferungTransportErstellen(auftrag.GibTransportTyp());
                this.RechnungMgmt.RechnungAnlegen(auftrag.GibTransportTyp());
            }
        }


        /// <summary>
        /// Generates the highest used Id +1 (next unused Id) for an object of type E, 
        /// by looking up the Database for objects of the same type. The returned Id has an prefix created 
        /// from the first three characters of the class name of E.
        /// </summary>
        /// 
        /// <typeparam name="E">E is a type of a class implementing the IHasId interface.</typeparam>
        /// <returns>A string consisting of the class name of E (just the first three characters if 
        /// class name is longer then three, if not string gets filled up with '_' characters) concatenated with the next highest unused Id. 
        /// Returns 1 if there is no other object of type E in the database.</returns>
        private string GetNextIdForType<E>() where E : IHasId
        {

            int highestId = 0;
            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {

                    var allIdObjects = session.CreateCriteria(typeof(E)).List<E>();


                    foreach (IHasId IdObject in allIdObjects)
                    {
                        // get the number of the id, by cutting dwon the first 3 characters
                        int id = Int32.Parse(IdObject.GetCustomId().Substring(3));

                        if (highestId < id)
                        {
                            highestId = id;
                        }
                    }

                }
                int nextId = highestId++;


                //build the id string
                StringBuilder idString = new StringBuilder(typeof(E).Name);

                //fill idString up with "_" to a length of 3 if necessary 
                while (idString.Length < 3)
                {
                    idString.Append("_");
                }

                //just use the first 3 characters
                idString = new StringBuilder(idString.ToString(0, 3));
                //append the new id
                idString.Append(nextId);

                return nextId.ToString();
            }
        }



        //List<BestandsTyp>:  für jedes im Auftrag enthaltene Produkt das geschätzte Datum bis Produkt lieferbar
        internal IList<Produkt_LieferdatumTyp> VersandAnfrage(IDictionary<int, int> produktnr_Anzahl)
        {

            return this.WaWiFassade.VersandAnfrage(produktnr_Anzahl);
        }


        /// <summary>
        /// Markiert einen den Aufrtag mit der zughörigen Auftragsnummer als abgeschlossen.
        /// </summary>
        /// <param name="Auftragsnummer"></param>
        /// <returns>True, wenn Auftrag gefunden und markiert, False sonst.</returns>
        internal bool AuftragAbschliessen(string auftragId)
        {
           return this.AuftragVerwalter.AuftragAbschliessen(auftragId);
          
        }







        //FRIEDHOF
        //-----------------------------------------------------------------------------
        //-----------------------------------------------------------------------------
        //-----------------------------------------------------------------------------
        //-----------------------------------------------------------------------------
        //-----------------------------------------------------------------------------


        //-----------------------------------------------------------------------------
        //-----------------------------------------------------------------------------

        /*
        /// <summary>
        /// Berechntet die nächst höchste Id für den entsprechenden typen und gibt sie zurück.
        /// </summary>
        /// <returns></returns>
        private string GetNextAngebotId()
        {

            int highestId = 0;
            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {

                    var alleAngebote = session.CreateCriteria(typeof(Angebot)).List<Angebot>();


                    foreach (Angebot angebot in alleAngebote)
                    {

                        int angebotId = Int32.Parse(angebot.AngebotsId.Substring(3));

                        if (highestId < angebotId)
                        {
                            highestId = angebotId;
                        }
                    }

                }
            }


            int nextId = highestId++;
            StringBuilder sb = new StringBuilder("Ang");
            sb.Append(nextId);

            return nextId.ToString();

        }


        /// <summary>
        /// berechntet die nächst höchste Id für den entsprechenden typen und gibt sie zurück
        /// </summary>
        /// <returns></returns>
        private string GetNextAuftragId()
        {



            int highestId = 0;
            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {

                    var alleAuftraege = session.CreateCriteria(typeof(Auftrag)).List<Auftrag>();


                    foreach (Auftrag angebot in alleAuftraege)
                    {

                        int auftragId = Int32.Parse(angebot.AuftragId.Substring(3));

                        if (highestId < auftragId)
                        {
                            highestId = auftragId;
                        }
                    }

                }
            }


            int nextId = highestId++;
            StringBuilder sb = new StringBuilder("Auf");
            sb.Append(nextId);

            return nextId.ToString();

        }

        */




    }
}
