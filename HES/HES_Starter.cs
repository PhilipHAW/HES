using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using AuftragabwicklungKomponente;
using HESFassadeKomponente;
using System.IO;

namespace HES
{
    class HES_Starter
    {
        static void Main(string[] args)
        {

            var sessionFactory = CreateSessionFactory();
            IHESFassade fassade = ComponentFactory.BuildComponents(sessionFactory);
            
            //fassade.

        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                //.Database(SQLiteConfiguration.Standard.UsingFile("test.db"))
                .Database(SQLiteConfiguration.Standard.UsingFile("test.db").ShowSql)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HES_Starter>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }


        private static void BuildSchema(Configuration config)
        {
           
            // delete the existing db on each run
            if (File.Exists("test.db"))
                File.Delete("test.db");
            
            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
              .Create(false, true);
        }
    }
}
