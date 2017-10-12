using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Storymark.Service.Data.Entities;
using Storymark.Web.Models.User;

namespace Storymark.Web.Controllers
{
	public class BaseWebController : Controller
	{
		private readonly IUserRetriever _userRetriever;

		public BaseWebController(IUserRetriever userRetriever)
		{
			var userId = ClaimsPrincipal.Current.FindFirst("user_id")?.Value;
			_userRetriever = userRetriever;
			if (userId != null)
			{
				
				var fullName = ClaimsPrincipal.Current.FindFirst("name")?.Value;
				var email = ClaimsPrincipal.Current.FindFirst("email")?.Value;
				CurrentUser = _userRetriever.GetCurrentUser(userId,email, fullName);
			}
		}

		public Person CurrentUser { get; set; }
	}
}