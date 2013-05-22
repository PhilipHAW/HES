using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuftragabwicklungKomponente
{
    /// <summary>
    /// Interface that guarantees that the implementing class has a CustomId and a getter to the NHibernate generated Id.
    /// Implementing this Interface lets you use utility mehtods of the NHibernateUtilities.
    /// </summary>
    public interface IHasId
    {



        string GetCustomId();


        
    }
}
