using System;
using System.Collections.Generic;
using NHibernate.Envers.Configuration.Attributes;

namespace Storymark.Service.Data.Entities
{
	[Audited]
	public class GlobalStoryGrid
    {
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }

		public virtual string ExternalGenre { get; set; }
		public virtual string ExternalValueAtStake { get; set; }
		public virtual string InternalGenre { get; set; }
		public virtual string InternalValueAtStake { get; set; }
		public virtual string ObligatoryScenesAndConventions { get; set; }
		public virtual string PointOfView { get; set; }
		public virtual string ObjectsOfDesire { get; set; }
		public virtual string ControllingIdeaTheme { get; set; }
		public virtual StoryGridSection BeginningHook { get; set; }
		public virtual StoryGridSection MiddleBuild { get; set; }
		public virtual StoryGridSection EndingPayoff { get; set; }
		
		public virtual Project Project { get; set; }
	}
}