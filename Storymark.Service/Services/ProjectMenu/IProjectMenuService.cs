using System;
using System.Collections.Generic;
using Storymark.Service.Data.ViewModels;

namespace Storymark.Service.Services.ProjectMenu
{
	public interface IProjectMenuService
	{
		List<MenuItemViewModel> Retrieve(Guid currentUserId);
	    List<MenuItemViewModel> RetrieveForManuscript(Guid manuscriptId, Guid userId);
    }
}