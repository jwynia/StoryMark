using Autofac;
using NHibernate;
using Storymark.Service.Data.Configuration;

namespace Storymark.Service
{
	public class SqlServerAutofacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);
			builder.Register(x => SqlServerNHibernateConfigurator.BuildSessionFactory()).SingleInstance();
			// Register ISession as instance per web request
			builder.Register(x => x.Resolve<ISessionFactory>().OpenSession()).InstancePerLifetimeScope();
		}
	}
}