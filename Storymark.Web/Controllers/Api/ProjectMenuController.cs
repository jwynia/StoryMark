using System;
using System.Collections.Generic;
using System.Web.Http;
using Storymark.Service.Data.ViewModels;
using Storymark.Service.Services.ProjectMenu;
using Storymark.Web.Models.User;

namespace Storymark.Web.Controllers.Api
{
    [Authorize]
    public class ProjectMenuController : BaseWebApiController
    {
		private readonly IProjectMenuService _projectMenuService;

		public ProjectMenuController(IUserRetriever userRetriever, IProjectMenuService projectMenuService) : base(userRetriever)
        {
			this._projectMenuService = projectMenuService;
		}

        [HttpGet]
        public List<MenuItemViewModel> Get()
        {
	        var menuItems = _projectMenuService.Retrieve(CurrentUser.Id);
	        return menuItems;

        }

        [HttpGet]
        [Route("api/ProjectMenu/AllForManuscript/{id}")]
        public List<MenuItemViewModel> AllForManuscript(Guid id)
        {
            var menuItems = _projectMenuService.RetrieveForManuscript(id, CurrentUser.Id);
            return menuItems;
        }

        private static List<MenuItemViewModel> getHardCodedMenu()
	    {
		    var list = new List<MenuItemViewModel>();

		    var scene1 = new MenuItemViewModel
		                 {
			                 ItemType = MenuItemTypes.Scene,
			                 Title = "Scene 1",
			                 Id = Guid.NewGuid()
		                 };
		    var scene2 = new MenuItemViewModel
		                 {
			                 ItemType = MenuItemTypes.Scene,
			                 Title = "Scene 2",
			                 Id = Guid.NewGuid()
		                 };

		    var chapter1 = new MenuItemViewModel
		                   {
			                   ItemType = MenuItemTypes.Chapter,
			                   Title = "Chapter 1",
			                   Id = Guid.NewGuid(),
			                   ChildItems = new List<MenuItemViewModel>
			                                {
				                                scene1,
				                                scene2
			                                }
		                   };
		    var chapter2 = new MenuItemViewModel
		                   {
			                   ItemType = MenuItemTypes.Chapter,
			                   Title = "Chapter 2",
			                   Id = Guid.NewGuid()
		                   };
		    var chapter3 = new MenuItemViewModel
		                   {
			                   ItemType = MenuItemTypes.Chapter,
			                   Title = "Chapter 3",
			                   Id = Guid.NewGuid()
		                   };
		    var masterpieceManuscript = new MenuItemViewModel
		                                {
			                                ItemType = MenuItemTypes.Manuscript,
			                                Title = "My Book: A Masterpiece",
			                                Id = Guid.NewGuid(),
			                                ChildItems = new List<MenuItemViewModel>
			                                             {
				                                             chapter1,
				                                             chapter2,
				                                             chapter3
			                                             }
		                                };
		    var note1 = new MenuItemViewModel
		                {
			                ItemType = MenuItemTypes.Note,
			                Title = "Notes",
			                Id = Guid.NewGuid()
		                };


		    var notesFolder = new MenuItemViewModel
		                      {
			                      ItemType = MenuItemTypes.Folder,
			                      Title = "Notes",
			                      Id = Guid.NewGuid(),
			                      ChildItems = new List<MenuItemViewModel>
			                                   {
				                                   note1
			                                   }
		                      };
		    list.Add(new MenuItemViewModel
		             {
			             ItemType = MenuItemTypes.Project,
			             Title = "The Great American Novel Project",
			             Id = Guid.NewGuid(),
			             ChildItems = new List<MenuItemViewModel>
			                          {
				                          masterpieceManuscript,
				                          notesFolder
			                          }
		             });
		    return list;
	    }
    }
}