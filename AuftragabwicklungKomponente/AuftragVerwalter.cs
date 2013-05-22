using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NullTypen.TransportTypen;




namespace AuftragabwicklungKomponente
{
    internal class AuftragVerwalter
    {

        private ISessionFactory sessionFactory;

        public AuftragVerwalter(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }


        internal Auftrag AuftragErstellen(Angebot angebot, string auftragId, DateTime beauftragtAm, DateTime letzterPostenLieferbar, bool istLieferbar = false)
        {
            Auftrag auftrag = new Auftrag(angebot, auftragId, beauftragtAm, letzterPostenLieferbar, istLieferbar);

#if DEBUG
            Console.WriteLine("Speichern von: {0}", auftrag);
#endif

            //persist the new auftrag
            using (ISession session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(auftrag);
                    transaction.Commit();
                }
            }


            return auftrag;
        }



        internal void DeleteAuftrag(Angebot auftrag)
        {


            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(auftrag);
                    transaction.Commit();
#if DEBUG
                    Console.WriteLine("Gelöscht: {0}", auftrag);
#endif
                }
            }


        }


        internal Auftrag LoadAuftrag(string auftragId)
        {
            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {

                    var alleAuftraege = session.CreateCriteria(typeof(Auftrag)).List<Auftrag>();


                    foreach (Auftrag auftrag in alleAuftraege)
                    {
                        if (auftrag.AuftragId.Equals(auftragId))
                        {
#if DEBUG
                            Console.WriteLine("Auftrag mit der Auftragsnummer: {0} (gesuchte Id: {1}) geladen...", auftrag.AuftragId, auftragId);
#endif
                            return auftrag;
                        }
                    }


                    throw new Exception("Auftrag nicht gefunden.");


                }
            }

        }




        internal bool AuftragAbschliessen(string auftragId)
        {
            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction =session.BeginTransaction())
                {

                    var alleAuftraege = session.CreateCriteria(typeof(Auftrag)).List<Auftrag>();


                    foreach (Auftrag auftrag in alleAuftraege)
                    {
                        if (auftrag.AuftragId.Equals(auftragId))
                        {
                            auftrag.IstAbgeschlossen = true;
                            session.Update(auftrag);
                            transaction.Commit();
#if DEBUG
                            Console.WriteLine("Auftrag mit der Auftragsnummer: {0} (gesuchte AuftragsId: {1}) wurde als abgeschlossen = {2} markiert", auftrag.AuftragId, auftragId, auftrag.IstAbgeschlossen);
#endif
                            return true;
                        }
                    }
                    throw new Exception("Kein Auftrag mit der AuftragId: " + auftragId + " gefunden");
                }
            }
        }
    }
}
