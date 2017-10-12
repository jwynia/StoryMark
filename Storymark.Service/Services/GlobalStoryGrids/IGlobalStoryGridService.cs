using System;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Services.GlobalStoryGrids
{
	public interface IGlobalStoryGridService
	{
		Data.Entities.GlobalStoryGrid Retrieve(Guid id, Guid currentUserId);
		Guid Add(GlobalStoryGrid newGlobalStoryGrid, Guid projectId, Guid currentUserId);
		GlobalStoryGrid Update(GlobalStoryGrid updated, Guid currentUserId);
	}
}