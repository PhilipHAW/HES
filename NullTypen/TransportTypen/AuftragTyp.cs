using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullTypen.TransportTypen
{
    public class AuftragTyp
    {
        public string AuftragId { get; private set; }

        //wenn Angebotsnummer == "Ang-1" dann kein Angebot zu dem Auftrag
        public AngebotTyp AngebotTyp { get; private set; }
        /// <summary>
        /// istLieferbar wird true, wenn tatsächlich alle Posten vorätig sind. Dies ist unabhängig von LetzterPostenLieferbar, 
        /// da dieser Wert nur ein Schätzwert ist, wann die Ware rausgehen kann.
        /// </summary>
        public bool IstLieferbar { get; private set; }
        public virtual DateTime LieferDatum { get; private set; }
        public bool IstAbgeschlossen { get; private set; }
        public DateTime BeauftragtAm { get; private set; }
        /// <summary>
        /// Datum das angibt wann vorraussichtlich der zuletzt eingehende Posten dieses Auftrags lieferbar ist
        /// </summary>
        public virtual DateTime LetzterPostenLieferbar { get; private set; }


        /// <summary>
        /// Constructor only for NHibernate reasons.
        /// </summary>
        private AuftragTyp() { }

        public AuftragTyp(string auftragId, AngebotTyp angebot, DateTime beauftragtAm, DateTime letzterPostenLieferbar, bool istLieferbar, DateTime lieferDatum)
        {

            this.AuftragId = auftragId;
            this.AngebotTyp = angebot;
            this.BeauftragtAm = beauftragtAm;
            this.LetzterPostenLieferbar = letzterPostenLieferbar;
            this.IstLieferbar = istLieferbar;
            this.LieferDatum = lieferDatum;
        }


        public IList<PostenTyp> GetPosten()
        {
            return AngebotTyp.Posten;
        }


        public float GetGesamtPreisNetto()
        {
            return this.AngebotTyp.GesamtPreisNetto;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("\nAuftragTyp ");
            sb.Append(this.AuftragId);
            sb.Append(" mit Angebot: ");
            sb.Append(this.AngebotTyp);
            sb.Append(" istLieferbar: ");
            sb.Append(this.IstLieferbar);
            sb.Append(" IstAbgeschlossen: ");
            sb.Append(this.IstAbgeschlossen);
            sb.Append(" BeauftragtAm: ");
            sb.Append(this.BeauftragtAm);



            return sb.ToString();
        }
    }
}
