using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using AutoMapper;
using Storymark.Service.Data.Entities;
using Storymark.Service.Data.ViewModels;
using Storymark.Web.Models;
using Storymark.Web.Models.User;

namespace Storymark.Web.Controllers.Api
{
	[Authorize]
    public class BaseWebApiController : ApiController
    {
	    private IUserRetriever _userRetriever;
        protected IMapper Mapper;
	    public BaseWebApiController(IUserRetriever userRetriever)
	    {
		    _userRetriever = userRetriever;
			var userId = ClaimsPrincipal.Current.FindFirst("user_id")?.Value;
		    _userRetriever = userRetriever;
		    if (userId != null)
		    {

			    var fullName = ClaimsPrincipal.Current.FindFirst("name")?.Value;
			    var email = ClaimsPrincipal.Current.FindFirst("email")?.Value;
			    CurrentUser = _userRetriever.GetCurrentUser(userId, email, fullName);
		    }
	        Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();

        }

	    public Person CurrentUser { get; set; }
    }
}
