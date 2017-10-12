using System.IO;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Data.Configuration
{
    public class SqlLiteNHibernateConfigurator
    {
        private const string DbFile = "Data.Sqlite.db";
        public static ISessionFactory BuildSessionFactory()
        {
            return Fluently.Configure()
                 .Database(SQLiteConfiguration.Standard
                     .UsingFile(DbFile))
                 .Mappings(m =>
                     m.AutoMappings.Add(CreateAutomappings))
                .ExposeConfiguration(BuildSchema)
                 .BuildSessionFactory();
        }
        static AutoPersistenceModel CreateAutomappings()
        {
            // This is the actual automapping - use AutoMap to start automapping,
            // then pick one of the static methods to specify what to map (in this case
            // all the classes in the assembly that contains Employee), and then either
            // use the Setup and Where methods to restrict that behaviour, or (preferably)
            // supply a configuration instance of your definition to control the automapper.
            return AutoMap.AssemblyOf<Person>(new AutomappingConfiguration())
                .Conventions.Add<CascadeConvention>();
        }
        private static void BuildSchema(NHibernate.Cfg.Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists(DbFile))
            {
                File.Delete(DbFile);
            }

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
                .Create(false, true);
        }
    }
}