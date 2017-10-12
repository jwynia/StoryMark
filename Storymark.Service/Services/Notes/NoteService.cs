using System;
using System.Collections.Generic;
using NHibernate;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Services.Notes
{
    internal class NoteService : BaseService, INoteService
    {
        public NoteService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        Note INoteService.Retrieve(Guid id, Guid personId)
        {
            throw new NotImplementedException();
        }

        List<Note> INoteService.AllForProject(Guid projectId, Guid personId)
        {
            throw new NotImplementedException();
        }

        Guid INoteService.Add(Note newEntity, Guid folderId, Guid personId)
        {
            throw new NotImplementedException();
        }

        Location INoteService.Update(Note input, Guid personId)
        {
            throw new NotImplementedException();
        }

        void INoteService.Delete(Guid id, Guid personId)
        {
            throw new NotImplementedException();
        }
    }
}