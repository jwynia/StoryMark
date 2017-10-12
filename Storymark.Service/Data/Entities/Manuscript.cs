using System;
using System.Collections.Generic;
using NHibernate.Envers.Configuration.Attributes;

namespace Storymark.Service.Data.Entities
{
	[Audited]
	public class Manuscript
	{
		public virtual Guid Id { get; protected set; }
		public virtual string Title { get; set; }
		public virtual Project Project { get; set; }
	    public virtual IList<Chapter> Chapters { get; set; }
	}
}