using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace WaWiSubSystem.LagerLogKomponente
{
    public class LagerLogFassade : ILagerLogMgmt
    {

        private LagerLogLogik lagerLoggingLogik;


        public LagerLogFassade(ISessionFactory sessionFactory)
        {
            this.lagerLoggingLogik = new LagerLogLogik(sessionFactory);
        }

        /// <summary>
        /// Warenausgangsmeldung erstellen mit gegenwärtigem Datum aus DateTime.Now.
        /// </summary>
        /// <param name="produktnumer"></param>
        /// <param name="anzahl"></param>
        /// <returns></returns>
        public bool WarenAusgangsmeldung(int produktnumer, int anzahl)
        {
            return this.WarenAusgangsmeldung(produktnumer, anzahl, DateTime.Now);
        }

        /// <summary>
        /// Warenausgangsmeldung erstellen.
        /// </summary>
        /// <param name="produktnumer"></param>
        /// <param name="anzahl"></param>
        /// <param name="datum"></param>
        /// <returns></returns>
        public bool WarenAusgangsmeldung(int produktnumer, int anzahl, DateTime datum)
        {
            WarenAusgangsMeldung wAM = this.lagerLoggingLogik.WareAuslagern(produktnumer, anzahl, datum);
#if DEBUG
            Console.WriteLine("Ware ausgelagert siehe: {0}", wAM);
#endif
            return true;
        }

        public bool WarenEingangsmeldung(int produktnumer, int anzahl)
        {
            throw new NotImplementedException();
        }
    }
}
