using System;
using System.Collections.Generic;
using NHibernate.Envers.Configuration.Attributes;

namespace Storymark.Service.Data.Entities
{
	[Audited]
	public class StoryGridCommandment
	{
		public virtual Guid Id { get; protected set; }
		public virtual string Content { get; set; }
		public virtual int ExternalCharge { get; set; }
		public virtual int InternalCharge { get; set; }
		public virtual StoryGridSection StoryGridSection { get; set; }
		public virtual Scene Scene { get; set; }
	}
}