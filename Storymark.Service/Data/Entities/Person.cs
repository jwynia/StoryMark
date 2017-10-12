using System;
using NHibernate.Envers.Configuration.Attributes;

namespace Storymark.Service.Data.Entities
{
	[Audited]
	public class Person
    {
        public virtual Guid Id { get; protected set; }
        public virtual string FullName { get; set; }
        public virtual string Email { get; set; }
        public virtual string ExternalUserId { get; set; }
    }
}