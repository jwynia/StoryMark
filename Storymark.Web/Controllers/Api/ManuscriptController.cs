using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Storymark.Service.Data.Entities;
using Storymark.Service.Data.ViewModels;
using Storymark.Service.Services.Manuscripts;
using Storymark.Web.Models.User;

namespace Storymark.Web.Controllers.Api
{
    [Authorize]
    public class ManuscriptController : BaseWebApiController
    {
        private readonly IManuscriptService _manuscriptService;

        public ManuscriptController(IManuscriptService manuscriptService,IUserRetriever userRetriever) : base(userRetriever)
        {
            _manuscriptService = manuscriptService;
        }

        [HttpGet]
		[Route("api/Manuscript/{id}")]
		public ManuscriptViewModel Get(Guid id)
        {
            var manuscript = _manuscriptService.Retrieve(id,this.CurrentUser.Id);
            return Mapper.Map<ManuscriptViewModel>(manuscript);
        }

        [HttpGet]
        public List<ManuscriptViewModel> GetAllForProject(Guid projectId)
        {
            List<Manuscript> manuscripts = _manuscriptService.AllForProject(projectId, this.CurrentUser.Id);
            return manuscripts.Select(x => Mapper.Map<ManuscriptViewModel>(x)).ToList();
        }

        [HttpPost]
        [Route("api/Manuscript/New/{projectId}")]
        public Guid New(Guid projectId)
        {
			var newManuscript = new Manuscript();
			var newManuscriptId = _manuscriptService.Add(newManuscript,projectId, this.CurrentUser.Id);
            return newManuscriptId;
        }
        [HttpPut]
        [Route("api/Manuscript/{manuscriptId}")]
        public ManuscriptViewModel Put(ManuscriptViewModel input, Guid manuscriptId)
        {
            var mapped = Mapper.Map<Manuscript>(input);
            var manuscript = _manuscriptService.Update(mapped, this.CurrentUser.Id);
            return Mapper.Map<ManuscriptViewModel>(manuscript);
        }
    }

   
}