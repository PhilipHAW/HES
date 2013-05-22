using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullTypen.TransportTypen;
using NullTypen;

namespace Rechnungskomponente
{




    public class RechnungClass
    {
        public virtual int id { get; protected set; }
        public virtual int rechnungsNummer { get; set; }
        //public virtual AdressTyp rechnungsAdresse { get; set; }
       public virtual DateTime rechnungsDatum { get; set; }
        public virtual DateTime lieferDatum { get; set; }
        public virtual float mwst { get; set; }
        public virtual float gesamtPreis { get; set; }
        public virtual float nettoPreis { get; set; }
        public virtual float bruttoPreis { get; set; }
        public virtual float versandKosten { get; set; }
       // public virtual IList<PostenTyp> postenList { get; set; }
        public virtual string auftragsID { get; set; }
        public virtual bool bezahlt { get; set; }
        public virtual IList<Zahlungseingang> zahlungseingangList { get; set; }

        private RechnungClass() { }

        //public RechnungClass(int rechnungsNummer, AdressTyp rechnungsAdresse, DateTime rechnungsDatum, DateTime lieferDatum, Double mwst, Double gesamtPreis, Double nettoPreis, Double bruttoPreis, Double versandKosten, IList<PostenTyp> postenList)
        //{
        //    this.rechnungsNummer = rechnungsNummer;
        //    //this.rechnungsAdresse = rechnungsAdresse;
        //   // this.rechnungsDatum = rechnungsDatum;
        //    this.lieferDatum = lieferDatum;
        //    this.mwst = mwst;
        //    this.gesamtPreis = gesamtPreis;
        //    this.nettoPreis = nettoPreis;
        //    this.bruttoPreis = bruttoPreis;
        //    this.versandKosten = versandKosten;
        //   // this.postenList = postenList;

        //}

        public RechnungClass(int rechnungsNummer, DateTime rechnungsDatum,  float mwst, float nettoPreis, float bruttoPreis, string auftragsID)
        {
            
            this.rechnungsNummer = rechnungsNummer;
            //this.rechnungsAdresse = rechnungsAdresse;
             this.rechnungsDatum = rechnungsDatum;
            this.lieferDatum = lieferDatum;
            this.mwst = mwst;
            this.gesamtPreis = gesamtPreis;
            this.nettoPreis = nettoPreis;
            this.bruttoPreis = bruttoPreis;
            this.versandKosten = versandKosten;
            // this.postenList = postenList;
            this.auftragsID = auftragsID;

        }


        public void ZahlungseingangBuchen(Zahlungseingang zahlungsengang)
        {
            this.zahlungseingangList.Add(zahlungsengang);

        }

    }
}
