using System;
using System.Collections.Generic;
using NHibernate;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Services.Locations
{
    internal class LocationService :BaseService, ILocationService
    {
        public LocationService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        Location ILocationService.Retrieve(Guid id, Guid personId)
        {
            throw new NotImplementedException();
        }

        List<Location> ILocationService.AllForProject(Guid projectId, Guid personId)
        {
            throw new NotImplementedException();
        }

        Guid ILocationService.Add(Location newEntity, Guid folderId, Guid personId)
        {
            throw new NotImplementedException();
        }

        Location ILocationService.Update(Location input, Guid personId)
        {
            throw new NotImplementedException();
        }

        void ILocationService.Delete(Guid id, Guid personId)
        {
            throw new NotImplementedException();
        }
    }
}