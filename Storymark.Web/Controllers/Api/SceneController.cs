using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Storymark.Service.Data.Entities;
using Storymark.Service.Data.ViewModels;
using Storymark.Service.Services.Scenes;
using Storymark.Web.Models.User;

namespace Storymark.Web.Controllers.Api
{
    [Authorize]
    public class SceneController : BaseWebApiController
    {
        private readonly ISceneService _sceneService;

        public SceneController(IUserRetriever userRetriever,ISceneService sceneService) : base(userRetriever)
        {
            _sceneService = sceneService;
        }

		[HttpGet]
		[Route("api/Scene/{sceneId}")]
		public SceneViewModel Get(Guid sceneId)
		{
			var scene = _sceneService.Retrieve(sceneId, this.CurrentUser.Id);
			return Mapper.Map<SceneViewModel>(scene);
		}

		[HttpGet]
		[Route("api/Scene/GetForChapter/{chapterId}")]
		public List<SceneViewModel> GetForChapter(Guid chapterId)
		{
			var scenes = _sceneService.AllForChapter(chapterId, this.CurrentUser.Id);
			return scenes.Select(x => Mapper.Map<SceneViewModel>(x)).ToList();
		}

		[HttpPost]
		[Route("api/NewScene/{chapterId}")]
		public Guid Post(Guid chapterId)
		{
			var newScene = new Scene(){Title = "New Scene"};
			var updated = _sceneService.Add(newScene, chapterId, this.CurrentUser.Id);
			return updated;
		}
		[HttpPost]
		[Route("api/Scene/Update")]
		public SceneViewModel Update(SceneViewModel input)
		{
			var updated = _sceneService.Update(Mapper.Map<Scene>(input), this.CurrentUser.Id);
			return Mapper.Map<SceneViewModel>(updated);
		}
	}
}