using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Services.Manuscripts
{
	internal class ManuscriptService : BaseService, IManuscriptService
	{
	    public ManuscriptService(ISessionFactory sessionFactory) : base(sessionFactory)
	    {
	    }

	    Manuscript IManuscriptService.Retrieve(Guid id, Guid personId)
		{
			using (var session = _sessionFactory.OpenSession())
			{
				var manuscript = session.Query<Manuscript>()
				                         .FirstOrDefault(x => x.Id == id && x.Project.Owner.Id == personId);
				return manuscript;
			}
		}

	    public List<Manuscript> AllForProject(Guid projectId, Guid personId)
	    {
	        using (var session = _sessionFactory.OpenSession())
	        {
	            var manuscripts = session.Query<Manuscript>().Where(x => x.Project.Id == projectId && x.Project.Owner.Id == personId).ToList();
	            return manuscripts;
	        }
        }

	    Guid IManuscriptService.Add(Manuscript newManuscript, Guid projectId, Guid personId)
		{
		    using (var session = _sessionFactory.OpenSession())
		    {
		        using (var transaction = session.BeginTransaction())
		        {
					var project = session.Query<Project>().Fetch(x => x.Owner).First(x => x.Id == projectId &&  x.Owner.Id == personId);
					newManuscript.Title = project.Title + " Manuscript";
					newManuscript.Project = project;
					var manuscriptId = session.Save(newManuscript) as Guid?;
					project.Manuscript = newManuscript;
					session.Update(project);
		            transaction.Commit();
		            return (Guid)manuscriptId;
		        }
		    }
        }

	    Manuscript IManuscriptService.Update(Manuscript input, Guid personId)
		{
		    using (var session = _sessionFactory.OpenSession())
		    {
		        using (var transaction = session.BeginTransaction())
		        {
		           
		            session.Update(input);
		            transaction.Commit();
		            var savedManuscript = session.Query<Manuscript>().First(x => x.Id == input.Id);
                    return savedManuscript;
		        }
		    }
        }

	    void IManuscriptService.Delete(Guid id, Guid personId)
		{
			throw new NotImplementedException();
		}
	}
}