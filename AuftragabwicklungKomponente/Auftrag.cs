using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;


namespace AuftragabwicklungKomponente
{
    internal class Auftrag : IHasId
    {

        /// <summary>
        /// Id for NHibernate
        /// </summary>

        public virtual int Id { get; protected set; }

        /// <summary>
        /// Id for internal affairs & more
        /// </summary>
        public virtual string AuftragId { get; protected set; }

        public virtual Angebot Angebot { get; protected set; }
        /// <summary>
        /// istLieferbar wird true, wenn tatsächlich alle Posten vorätig sind. Dies ist unabhängig von LetzterPostenLieferbar, 
        /// da dieser Wert nur ein Schätzwert ist, wann die Ware rausgehen kann.
        /// </summary>
        public virtual bool IstLieferbar { get; protected set; }
        public virtual bool IstAbgeschlossen { get; set; }
        public virtual DateTime BeauftragtAm { get; protected set; }
        /// <summary>
        /// Das Datum, ab wann der Auftrag ausgeliefert werden darf.
        /// </summary>
        public virtual DateTime LieferDatum { get; protected set; }

        /// <summary>
        /// Datum das angibt wann VORAUSSICHTLICH der zuletzt eingehende Posten dieses Auftrags lieferbar ist
        /// </summary>
        public virtual DateTime LetzterPostenLieferbar { get; protected set; }



        /// <summary>
        /// Constructor for NHibernate
        /// </summary>
        private Auftrag() { }


        internal Auftrag(Angebot angebot, string auftragId, DateTime beauftragtAm, DateTime letzterPostenLieferbar, bool istLieferbar = false)
        {

            this.AuftragId = auftragId;
            this.Angebot = angebot;
            this.BeauftragtAm = beauftragtAm;
            this.LetzterPostenLieferbar = letzterPostenLieferbar;
            this.IstLieferbar = istLieferbar;


            //Auftrag kann nicht abgeschlossen sein wenn er gerade erzeugt wurde
            IstAbgeschlossen = false;


        }


        internal AuftragTyp GibTransportTyp()
        {

            return new AuftragTyp(this.AuftragId, this.Angebot.GibTransportObjekt(), this.BeauftragtAm, this.LetzterPostenLieferbar, this.IstLieferbar, this.LieferDatum);
        }



        internal IList<PostenTyp> GetPosten()
        {
            return Angebot.GibTransportObjekt().Posten;
        }





        public string GetCustomId()
        {
            return AuftragId;
        }


        /// <summary>
        /// Setzt den Auftrag auf auslieferbar == true und setzt auch das aktuelle Datum als Lieferdatum
        /// </summary>
        public void SetLieferbar()
        {
            this.IstLieferbar = true;
            this.LieferDatum = DateTime.Today;

        }

        public float GetGesamtPreisNetto()
        {
            return this.Angebot.GesamtPreisNetto;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("\nAuftrag ");
            sb.Append(this.AuftragId);
            sb.Append(" mit Angebot: ");
            sb.Append(this.Angebot);
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
