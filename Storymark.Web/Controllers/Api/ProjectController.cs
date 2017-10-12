using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Storymark.Service.Data.Entities;
using Storymark.Service.Data.ViewModels;
using Storymark.Service.Services.Projects;
using Storymark.Web.Models;
using Storymark.Web.Models.User;

namespace Storymark.Web.Controllers.Api
{
    [Authorize]
    public class ProjectController : BaseWebApiController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IUserRetriever userRetriever, IProjectService projectService) : base(userRetriever)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("api/Project/AllByCurrentOwner/")]
        public List<ProjectViewModel> Get()
        {
            var projects = _projectService.AllProjectsByOwner(this.CurrentUser.Id);
            return projects.Select(x => new ProjectViewModel(x)).ToList();
        }

        [HttpGet]
        [Route("api/Project/{id}")]
        public ProjectViewModel Get(Guid id)
        {
            var project = _projectService.Retrieve(id, this.CurrentUser.Id);
            return new ProjectViewModel(project);
        }

	    [HttpPost]
	    [Route("api/Project/")]
		public Guid Insert(ProjectViewModel input)
	    {
            var mapped = Mapper.Map<Project>(input);
            var newProject = mapped;
			var projectId = _projectService.Add(newProject, CurrentUser.Id);
		    return projectId;
	    }

	    [HttpPost]
	    [Route("api/Project/Update")]
	    public ProjectViewModel Update(ProjectViewModel input)
	    {
		    var mapped = Mapper.Map<Project>(input);
		    var projectUpdate = mapped;
		    var project = _projectService.Update(projectUpdate, CurrentUser.Id);
			return Mapper.Map <ProjectViewModel>(project);
	    }

		[HttpPost]
        [Route("api/Project/New")]
        public Guid New()
        {
            var projectId = _projectService.Add(new Project(){Title = "New Project"}, CurrentUser.Id);
            return projectId;
        }

      
	}
}
