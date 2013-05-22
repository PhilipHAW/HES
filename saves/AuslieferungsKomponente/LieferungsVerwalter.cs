using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuslieferungsKomponente.Entitäten;
using NHibernate;

namespace AuslieferungsKomponente
{
    public class LieferungsVerwalter
    {


        private ISessionFactory sessionFactory;


        public LieferungsVerwalter(ISessionFactory sessionFactory) 
        {
            this.sessionFactory = sessionFactory;
        
        }
       
        /// <summary>
        /// Erstellt eine Lieferung 
        /// </summary>
        /// <param name="lieferungNummer"> Ist eine Nummer die auf genau eine Lieferung verweist</param>
        /// <returns> Gibt eine Lieferung zurück</returns>
        internal Lieferung LieferungErstellen(int lieferungNummer)
        {
            Lieferung lieferung = new Lieferung(lieferungNummer);

            //persist the new angebot
            using (ISession session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
#if DEBUG
                    Console.WriteLine("Speichern von: {0}", lieferung);
#endif
                    session.Save(lieferung);
                    transaction.Commit();
                }
            }

            return lieferung;
        }
        

        /// <summary>
        /// Erstellt eine neue Liefernummer die noch nicht existiert
        /// </summary>
        /// <returns>Gibt eine Int Zahl zurück</returns>
        internal int NeueLieferungNummer()
        {
            int highestUsedId = 0;
            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {

                    var lieferungen = session.CreateCriteria(typeof(Lieferung)).List<Lieferung>();

                    foreach (var lieferung in lieferungen)
                    {
                        if (lieferung.lieferNummer > highestUsedId)
                        { highestUsedId = lieferung.lieferNummer; }
                    }
                }
            }
            highestUsedId += 1;
            return highestUsedId;
        }



       
    }
}
