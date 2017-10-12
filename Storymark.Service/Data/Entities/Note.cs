using System;
using NHibernate.Envers.Configuration.Attributes;

namespace Storymark.Service.Data.Entities
{
	[Audited]
	public class Note
	{
		public virtual Guid Id { get; protected set; }
		public virtual string Title { get; set; }
        public virtual int SortOrder { get; set; }
        public virtual string Content { get; set; }
        public virtual Folder Folder { get; set; }
	    public virtual Guid Folder_id { get; set; }
    }
}