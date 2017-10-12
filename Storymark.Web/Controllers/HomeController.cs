using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using Storymark.Web.Models.User;

namespace Storymark.Web.Controllers
{
	[Authorize]
	public class HomeController : BaseWebController
	{
		public HomeController(IUserRetriever userRetriever) : base(userRetriever)
		{
		}

		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";
			ViewBag.Name = ClaimsPrincipal.Current.FindFirst("name")?.Value;
			ViewBag.UserId = ClaimsPrincipal.Current.FindFirst("user_id")?.Value;
			return View();
		}
		
	}
}
