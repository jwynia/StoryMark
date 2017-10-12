using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Storymark.Service.Data.Entities;

namespace Storymark.Web.Models.User
{
	public class UserRetriever : IUserRetriever
	{
		private readonly ISessionFactory _sessionFactory;

		public UserRetriever(ISessionFactory sessionFactory)
		{
			_sessionFactory = sessionFactory;
		}
		public Person GetCurrentUser(string userId, string email, string fullName)
		{
			using (var session = _sessionFactory.OpenSession())
			{
				var existing = session.Query<Person>().FirstOrDefault(x => x.ExternalUserId == userId);
				if (existing == null)
				{
					using (var transaction = session.BeginTransaction())
					{
						var person = new Person();
						person.Email = email;
						person.FullName = fullName;
						person.ExternalUserId = userId;
						session.SaveOrUpdate(person);
						transaction.Commit();
						return person;
					}
				}
				else
				{
					return existing;
				}
			}
		}
	}
}