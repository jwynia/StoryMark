using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Services.Projects
{
	internal class ProjectService : BaseService, IProjectService
	{
        public ProjectService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        Project IProjectService.Retrieve(Guid id, Guid personId)
		{
			using (var session = _sessionFactory.OpenSession())
			{
				var project = session.Query<Project>().Fetch(x=>x.Owner).FirstOrDefault(x => x.Id == id && x.Owner.Id == personId);
				return project;
			}

		}

	    List<Project> IProjectService.AllProjectsByOwner(Guid personId)
		{
			using (var session = _sessionFactory.OpenSession())
			{
				var project = session.Query<Project>().Fetch(x => x.Owner).OrderBy(x=>x.Title).Where(x => x.Owner.Id == personId).ToList();
				return project;
			}
		}

	    Guid IProjectService.Add(Project newProject, Guid personId)
		{
			using (var session = _sessionFactory.OpenSession())
			{
				using (var transaction = session.BeginTransaction())
				{
					var owner = session.Query<Person>().FirstOrDefault(x => x.Id == personId);
                    newProject.Owner = owner;
					var projectId = session.Save(newProject);
				    transaction.Commit();
					return (Guid) projectId;
				}
			}
		}

	    Project IProjectService.Update(Project inputProject, Guid personId)
		{
			using (var session = _sessionFactory.OpenSession())
			{
				if (IsPersonOwner(inputProject.Id, personId, session))
				{
					using (var transaction = session.BeginTransaction())
					{
						var project = session.Query<Project>().Fetch(x => x.Owner)
						                     .First(x => x.Id == inputProject.Id && x.Owner.Id == personId);
						project.Title = inputProject.Title;
						project.ProjectType = inputProject.ProjectType;
						session.Update(project);
						transaction.Commit();
						return project;
					}
				}
				else
				{
					throw new UnauthorizedAccessException("Unauthorized.");
				}
			}
		}

	    void IProjectService.Delete(Guid id, Guid personId)
		{
			using (var session = _sessionFactory.OpenSession())
			{
				if (IsPersonOwner(id, personId, session))
				{
					using (var transaction = session.BeginTransaction())
					{
						var project = session.Query<Project>().Fetch(x => x.Owner)
						                     .FirstOrDefault(x => x.Id == id && x.Owner.Id == personId);

						session.Delete(project);
						transaction.Commit();
					}
				}
				else
				{
					throw new UnauthorizedAccessException("Unauthorized.");
				}
			}
		}

		private bool IsPersonOwner(Guid projectId, Guid personId, ISession session)
		{
			return session.Query<Project>().Any(x => x.Id == projectId && x.Owner.Id == personId);
		}
	}
}
