using System;
using System.Collections.Generic;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Services.Characters
{
    public interface ICharacterService
    {
        Character Retrieve(Guid id, Guid personId);
        List<Character> AllForProject(Guid projectId, Guid personId);
        Guid Add(Character newCharacter, Guid folderId, Guid personId);
        Chapter Update(Character input, Guid personId);
        void Delete(Guid id, Guid personId);
    }
}