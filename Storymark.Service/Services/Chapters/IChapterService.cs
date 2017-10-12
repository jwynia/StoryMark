using System;
using System.Collections.Generic;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Services.Chapters
{
	public interface IChapterService
	{
		Chapter Retrieve(Guid id, Guid personId);
		List<Chapter> AllForManuscript(Guid manuscriptId, Guid personId);
		Guid Add(Chapter newChapter, Guid manuscriptId, Guid personId);
		Chapter Update(Chapter input, Guid personId);
		void Delete(Guid id, Guid personId);
	}
}