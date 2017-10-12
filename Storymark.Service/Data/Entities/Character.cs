using System;
using System.Collections.Generic;
using NHibernate.Envers.Configuration.Attributes;

namespace Storymark.Service.Data.Entities
{
	[Audited]
	public class Character
    {
        public virtual Guid Id { get; protected set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
		public virtual string PhysicalDescription { get; set; }
        public virtual IList<Scene> OnStageScenes { get; set; }
	    public virtual IList<Scene> OffStageScenes { get; set; }
		public virtual Folder Folder { get; set; }
        public virtual Guid Folder_id { get; set; }
    }
}