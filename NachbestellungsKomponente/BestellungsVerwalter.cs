using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;
using NHibernate;

namespace WaWiSubSystem.NachbestellungsKomponente
{
   public class BestellungsVerwalter
    {

       private ISessionFactory sessionFactory;


       internal BestellungsVerwalter(ISessionFactory sessionFactory)
       {
           this.sessionFactory = sessionFactory;
       
       }
       
       
       internal BestellungTyp ProdukteBestellen(string Produktnumer)
        {
            throw new NotImplementedException();
        }
    }
}
