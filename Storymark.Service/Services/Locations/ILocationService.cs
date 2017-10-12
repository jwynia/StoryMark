using System;
using System.Collections.Generic;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Services.Locations
{
    public interface ILocationService
    {
        Location Retrieve(Guid id, Guid personId);
        List<Location> AllForProject(Guid projectId, Guid personId);
        Guid Add(Location newEntity, Guid folderId, Guid personId);
        Location Update(Location input, Guid personId);
        void Delete(Guid id, Guid personId);
    }
}