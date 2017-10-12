using System;
using System.Collections.Generic;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Services.Notes
{
    public interface INoteService
    {
        Note Retrieve(Guid id, Guid personId);
        List<Note> AllForProject(Guid projectId, Guid personId);
        Guid Add(Note newEntity, Guid folderId, Guid personId);
        Location Update(Note input, Guid personId);
        void Delete(Guid id, Guid personId);
    }
}