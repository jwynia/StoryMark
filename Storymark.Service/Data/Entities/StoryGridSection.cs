using System;
using System.Collections.Generic;
using NHibernate.Envers.Configuration.Attributes;

namespace Storymark.Service.Data.Entities
{
	[Audited]
	public class StoryGridSection
    {
	    public virtual Guid Id { get; protected set; }
		public virtual StoryGridCommandment IncitingIncident { get; set; }
		public virtual StoryGridCommandment Complication { get; set; }
		public virtual StoryGridCommandment Crisis { get; set; }
		public virtual StoryGridCommandment Climax { get; set; }
		public virtual StoryGridCommandment Resolution { get; set; }
		public virtual GlobalStoryGrid GlobalStoryGrid { get; set; }
	    public virtual IList<Scene> Scenes { get; set; }
	}
}