using System;
using System.Collections.Generic;
using NHibernate.Envers.Configuration.Attributes;

namespace Storymark.Service.Data.Entities
{
	[Audited]
	public class Location
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Title { get; set; }
        public virtual int SortOrder { get; set; }
        public virtual IList<Scene> Scenes { get; set; }
        public virtual Folder Folder { get; set; }
        public virtual Guid Folder_id { get; set; }
    }
}