using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Storymark.Service.Data.Entities;
using Storymark.Service.Data.ViewModels;
using Storymark.Service.Services.GlobalStoryGrids;
using Storymark.Service.Services.Projects;
using Storymark.Web.Models;
using Storymark.Web.Models.User;

namespace Storymark.Web.Controllers.Api
{
    [Authorize]
    public class GlobalStoryGridController : BaseWebApiController
    {
        private readonly IGlobalStoryGridService _globalStoryGridService;

        public GlobalStoryGridController(IUserRetriever userRetriever, IGlobalStoryGridService globalStoryGridService) : base(userRetriever)
        {
            _globalStoryGridService = globalStoryGridService;
        }

       

        [HttpGet]
        [Route("api/GlobalStoryGrid/{id}")]
        public GlobalStoryGridViewModel Get(Guid id)
        {
            var storyGrid = _globalStoryGridService.Retrieve(id, this.CurrentUser.Id);
	        return Mapper.Map<GlobalStoryGridViewModel>(storyGrid);
        }

	   

	    [HttpPost]
	    [Route("api/GlobalStoryGrid/Update")]
	    public GlobalStoryGridViewModel Update(GlobalStoryGridViewModel input)
	    {
		    var mapped = Mapper.Map<GlobalStoryGrid>(input);
		    var updated = mapped;
		    _globalStoryGridService.Update(updated, CurrentUser.Id);
	        var storyGrid = _globalStoryGridService.Retrieve(updated.Id, this.CurrentUser.Id);

            return Mapper.Map <GlobalStoryGridViewModel>(storyGrid);
	    }

		[HttpPost]
        [Route("api/GlobalStoryGrid/New/{projectId}")]
        public Guid NewGlobalStoryGrid(Guid projectId)
		{
		    var newGlobalStoryGrid = new GlobalStoryGrid();
		    var id = _globalStoryGridService.Add(newGlobalStoryGrid,projectId, CurrentUser.Id);
		    return id;
		}

      
	}
}
