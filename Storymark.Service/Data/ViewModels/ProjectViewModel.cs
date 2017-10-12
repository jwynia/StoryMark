using System;
using AutoMapper;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Data.ViewModels
{
	public class ProjectViewModel
	{
	    public ProjectViewModel()
	    {
	        
	    }
	    public ProjectViewModel(Project project)
	    {
	        Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectViewModel>());
	        Mapper.Map<Project, ProjectViewModel>(project, this);
        }
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string ProjectType { get; set; }
	}
}