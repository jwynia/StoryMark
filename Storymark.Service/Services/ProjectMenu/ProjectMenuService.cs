using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using Storymark.Service.Data.Entities;
using Storymark.Service.Data.ViewModels;

namespace Storymark.Service.Services.ProjectMenu
{
	internal class ProjectMenuService : BaseService, IProjectMenuService
	{
		public ProjectMenuService(ISessionFactory sessionFactory) : base(sessionFactory)
		{
			
		}

		List<MenuItemViewModel> IProjectMenuService.Retrieve(Guid currentUserId)
		{
			var menuItems = new List<MenuItemViewModel>();
			using (var session = _sessionFactory.OpenSession())
			{
				var projects = session.Query<Project>()
										.Where(x => x.Owner.Id == currentUserId)
										.OrderBy(x => x.Title)
										.ToList();
				menuItems.AddRange(projects.Select(x=>new MenuItemViewModel(){Id = x.Id,IsExpanded = false,ItemType = MenuItemTypes.Project,Title = x.Title}));
				foreach (var project in menuItems)
				{
					Populate(project, session);
				}
			}
			return menuItems;
		}

	    public List<MenuItemViewModel> RetrieveForManuscript(Guid manuscriptId, Guid userId)
	    {
	        var menuItems = new List<MenuItemViewModel>();
	        using (var session = _sessionFactory.OpenSession())
	        {
	            var manuscripts = session.Query<Manuscript>()
	                .Where(x => x.Project.Owner.Id == userId)
	                .OrderBy(x => x.Title)
	                .ToList();
	            menuItems.AddRange(manuscripts.Select(x => new MenuItemViewModel() { Id = x.Id, IsExpanded = false, ItemType = MenuItemTypes.Manuscript, Title = x.Title }));
	            foreach (var item in menuItems)
	            {
	                Populate(item, session);
	            }
	        }
	        return menuItems;
        }

	    private void Populate(MenuItemViewModel parentMenuItem, ISession session)
		{
			switch (parentMenuItem.ItemType)
			{
				case "Project":
					var manuscript = session.Query<Manuscript>().FirstOrDefault(x => x.Project.Id == parentMenuItem.Id);
					if (manuscript != null)
					{
						parentMenuItem.ChildItems.Add(new MenuItemViewModel(){Id = manuscript.Id,IsExpanded = false,ItemType = MenuItemTypes.Manuscript,Title = manuscript.Title});
					}
					var globalStoryGrid = session.Query<GlobalStoryGrid>().FirstOrDefault(x => x.Project.Id == parentMenuItem.Id);
					if (globalStoryGrid != null)
					{
						parentMenuItem.ChildItems.Add(new MenuItemViewModel() { Id = globalStoryGrid.Id, IsExpanded = false, ItemType = MenuItemTypes.GlobalStoryGrid, Title = "Global Story Grid" });
					}
					var folder = session.Query<Folder>().FirstOrDefault(x => x.Project.Id == parentMenuItem.Id);
					if (folder != null)
					{
						parentMenuItem.ChildItems.Add(new MenuItemViewModel() { Id = folder.Id, IsExpanded = false, ItemType = MenuItemTypes.Folder, Title = folder.Title });
					}
					break;
				case "Folder":
					var subFolder = session.Query<Folder>().FirstOrDefault(x => x.Folders.Any(f=>f.Id == parentMenuItem.Id));
					if (subFolder != null)
					{
						parentMenuItem.ChildItems.Add(new MenuItemViewModel() { Id = subFolder.Id, IsExpanded = false, ItemType = MenuItemTypes.Folder, Title = subFolder.Title });
					}
					break;
				case "Manuscript":
					var chapters = session.Query<Chapter>().Where(x => x.Manuscript.Id == parentMenuItem.Id).ToList();
					if (chapters.Any())
					{
						parentMenuItem.ChildItems.AddRange(chapters.Select(x=>new MenuItemViewModel() { Id = x.Id, IsExpanded = false, ItemType = MenuItemTypes.Chapter, Title = x.Title }));
					}
					break;
				case "Chapter":
					var scenes = session.Query<Scene>().Where(x => x.Chapter.Id == parentMenuItem.Id).ToList();
					if (scenes.Any())
					{
						parentMenuItem.ChildItems.AddRange(scenes.Select(x => new MenuItemViewModel() { Id = x.Id, IsExpanded = false, ItemType = MenuItemTypes.Scene, Title = x.Title }));
					}
					break;

			}
			foreach (var childItem in parentMenuItem.ChildItems)
			{
				Populate(childItem,session);
			}
		}
	}
}
