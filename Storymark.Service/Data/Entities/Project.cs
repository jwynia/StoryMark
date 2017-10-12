using System;
using System.Collections.Generic;
using AutoMapper;
using NHibernate.Envers.Configuration.Attributes;
using Storymark.Service.Data.ViewModels;

namespace Storymark.Service.Data.Entities
{
	[Audited]
	public class Project
	{
		public virtual Guid Id { get; protected set; }
		public virtual string Title { get; set; }
		public virtual string ProjectType { get; set; }
		public virtual Manuscript Manuscript { get; set; }
        public virtual GlobalStoryGrid GlobalStoryGrid { get; set; }
		public virtual Folder RootFolder { get; set; }
		public virtual Person Owner { get; set; }
        public virtual IList<Project> SubProjects { get; set; }
	}
}