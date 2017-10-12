using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Storymark.Service.Data.Entities;
using Storymark.Service.Data.ViewModels;
using Storymark.Service.Services.Chapters;
using Storymark.Web.Models.User;

namespace Storymark.Web.Controllers.Api
{
    [Authorize]
    public class ChapterController : BaseWebApiController
    {
        private readonly IChapterService _chapterService;

        public ChapterController(IUserRetriever userRetriever,IChapterService chapterService) : base(userRetriever)
        {
            _chapterService = chapterService;
        }

        [HttpGet]
		[Route("api/Chapter/{chapterId}")]
		public ChapterViewModel Get(Guid chapterId)
        {
            var chapter = _chapterService.Retrieve(chapterId, this.CurrentUser.Id);
            return Mapper.Map<ChapterViewModel>(chapter);
        }

        [HttpGet]
        [Route("api/Chapter/GetForManuscript/{manuscriptId}")]
        public List<ChapterViewModel> GetForManuscript(Guid manuscriptId)
        {
            var chapters = _chapterService.AllForManuscript(manuscriptId, this.CurrentUser.Id);
            return chapters.Select(x => Mapper.Map<ChapterViewModel>(x)).ToList();
        }

        [HttpPost]
        [Route("api/NewChapter/{manuscriptId}")]
        public Guid Post(Guid manuscriptId)
        {
			var newChapter = new Chapter();
            var updated = _chapterService.Add(Mapper.Map<Chapter>(newChapter),manuscriptId, this.CurrentUser.Id);
            return updated;
        }
        [HttpPost]
        [Route("api/Chapter/{chapterId}")]
        public ChapterViewModel Update(ChapterViewModel input,Guid chapterId)
        {
            input.Id = chapterId;
            var updated = _chapterService.Update(Mapper.Map<Chapter>(input), this.CurrentUser.Id);
            return Mapper.Map<ChapterViewModel>(updated);
        }

    }
}