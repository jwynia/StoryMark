using System;

namespace Storymark.Service.Data.ViewModels
{
	public class ChapterViewModel
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public int SortOrder { get; set; }
	}
}