using System;
using System.Collections.Generic;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Services.Scenes
{
	public interface ISceneService
	{
		Scene Retrieve(Guid id, Guid personId);
	    List<Scene> AllForProject(Guid projectId, Guid personId);
        List<Scene> AllForChapter(Guid chapterId, Guid personId);
        Guid Add(Scene newEntity, Guid folderId, Guid personId);
	    Scene Update(Scene input, Guid personId);
	    void Delete(Guid id, Guid personId);
    }
}
