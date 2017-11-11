using System;
using System.Configuration;
using System.IO;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Envers.Configuration.Attributes;
using NHibernate.Tool.hbm2ddl;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Data.Configuration
{
	public class SqlServerNHibernateConfigurator
	{

		public static ISessionFactory BuildSessionFactory()
		{
		    var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
			
			return Fluently.Configure()
			               .Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2012
			                                         .ConnectionString(connectionString)
			                        )
			               .Mappings(m =>
				                         m.AutoMappings.Add(CreateAutomappings))
			               .ExposeConfiguration(SetupConfiguration)
			               .BuildSessionFactory();
		}
		static AutoPersistenceModel CreateAutomappings()
		{
		    // This is the actual automapping - use AutoMap to start automapping,
			// then pick one of the static methods to specify what to map (in this case
			// all the classes in the assembly that contains Employee), and then either
			// use the Setup and Where methods to restrict that behaviour, or (preferably)
			// supply a configuration instance of your definition to control the automapper.
		    IAutomappingConfiguration mapper = new StorymarkAutoMappingConfiguration();
		    return AutoMap.AssemblyOf<Person>(cfg: mapper)
			              .Conventions.AddFromAssemblyOf<PrimaryKeyGeneratorConvention>();
		}
		private static void SetupConfiguration(NHibernate.Cfg.Configuration config)
		{
			//var resetDb = bool.Parse( ConfigurationManager.AppSettings["ResetDb"]);
			config.IntegrateWithEnvers(new AttributeConfiguration());
			var update = new SchemaUpdate(config);
			update.Execute(true, true);

			//bool clearDatabase = resetDb;
			//var filename = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")+".sql";
			//new SchemaExport(config)
			//	//.SetOutputFile( Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(),filename))
			//	.Create(false, clearDatabase);

		}
		private static void LogAutoMigration(string sql)
		{
			using (var file = new FileStream(@Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(),"schema.sql"), FileMode.Append))
			{
				using (var sw = new StreamWriter(file))
				{
					sw.Write(sql);
				}
			}
		}
	}
}