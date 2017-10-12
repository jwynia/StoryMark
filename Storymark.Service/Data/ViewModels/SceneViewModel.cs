using System;

namespace Storymark.Service.Data.ViewModels
{
    public class SceneViewModel
    {
        public Guid Id { get; set; }
	    public string Title { get; set; }
	    public string Content { get; set; }
		public Guid ChapterId { get; set; }
		public Guid ManuscriptId { get; set; }
		public int SortOrder { get; set; }
		public int WordCount { get; set; }
    }
}