using System;
using System.Collections.Generic;
using System.Linq;

namespace Storymark.Service.Data.ViewModels
{
	public class MenuItemViewModel
	{
		public MenuItemViewModel()
		{
			ChildItems = new List<MenuItemViewModel>();
		}
		public string ItemType { get; set; }
		public Guid Id { get; set; }
		public string Title { get; set; }
		public List<MenuItemViewModel> ChildItems { get; set; }
		public bool IsExpanded { get; set; }
		public bool IsSelected { get; set; }

		public bool HasChildItems
		{
			get { return ChildItems.Any(); }
		}
	}

	public static class MenuItemTypes
	{
		public static string Project = "Project";
		public static string Manuscript = "Manuscript";
		public static string Chapter = "Chapter";
		public static string Scene = "Scene";
		public static string Note = "Note";
		public static string Folder = "Folder";
		public static string Character = "Character";
		public static string Location = "Location";
		public static string StoryIdea = "Story Idea";
		public static string GlobalStoryGrid = "Global Story Grid";
	}
}