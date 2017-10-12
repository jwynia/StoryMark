using System;
using System.Collections.Generic;
using NHibernate.Envers.Configuration.Attributes;

namespace Storymark.Service.Data.Entities
{
	[Audited]
	public class Folder
	{
		public virtual Guid Id { get; protected set; }
		public virtual string Title { get; set; }
        public virtual int SortOrder { get; set; }
		public virtual Project Project { get; set; }
		public virtual ISet<Note> Notes { get; set; }
		public virtual ISet<Folder> Folders { get; set; }
        public virtual ISet<Character> Characters { get; set; }
        public virtual ISet<Location> Locations { get; set; }
		public virtual ISet<StoryIdea> StoryIdeas { get; set; }
	}
}