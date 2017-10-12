using System;
using System.Collections.Generic;
using NHibernate.Envers.Configuration.Attributes;

namespace Storymark.Service.Data.Entities
{
	[Audited]
	public class Chapter
	{
		public virtual Guid Id { get; protected set; }
		public virtual string Title { get; set; }
        public virtual int SortOrder { get; set; }
		public virtual Manuscript Manuscript { get; set; }
      	public virtual IList<Scene> Scenes { get; set; }
	}
}