using System;
using System.Collections.Generic;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Services.Manuscripts
{
	public interface IManuscriptService
	{
		Manuscript Retrieve(Guid id, Guid personId);
	    List<Manuscript> AllForProject(Guid projectId, Guid personId);
		Guid Add(Manuscript newManuscript, Guid projectId, Guid personId);
		Manuscript Update(Manuscript input, Guid personId);
		void Delete(Guid id, Guid personId);
	}
}
