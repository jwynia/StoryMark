using System;
using System.Collections.Generic;
using NHibernate;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Services.Characters
{
    internal class CharacterService : BaseService, ICharacterService
    {
        public CharacterService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        Character ICharacterService.Retrieve(Guid id, Guid personId)
        {
            throw new NotImplementedException();
        }

        List<Character> ICharacterService.AllForProject(Guid projectId, Guid personId)
        {
            throw new NotImplementedException();
        }

        Guid ICharacterService.Add(Character newCharacter, Guid folderId, Guid personId)
        {
            throw new NotImplementedException();
        }

        Chapter ICharacterService.Update(Character input, Guid personId)
        {
            throw new NotImplementedException();
        }

        void ICharacterService.Delete(Guid id, Guid personId)
        {
            throw new NotImplementedException();
        }
    }
}