using System;
using System.Collections.Generic;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Services.Projects
{
	public interface IProjectService
	{
		Project Retrieve(Guid id, Guid personId);
		List<Project> AllProjectsByOwner(Guid personId);
		Guid Add(Project newProject, Guid personId);
		Project Update(Project inputProject, Guid personId);
		void Delete(Guid id, Guid personId);
	}
}