using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IdentityModel.Services;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storymark.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login(string returnUrl)
        {
	        if (string.IsNullOrEmpty(returnUrl) || !this.Url.IsLocalUrl(returnUrl))
	        {
		        returnUrl = "/";
	        }

	        // you can use this for the 'authParams.state' parameter
	        // in Lock, to provide a return URL after the authentication flow.
	        ViewBag.State = "ru=" + HttpUtility.UrlEncode(returnUrl);

	        return this.View();
		}
	    public RedirectResult Logout()
	    {
		    // Clear the session cookie
		    FederatedAuthentication.SessionAuthenticationModule.SignOut();

		    // Redirect to Auth0's logout endpoint
		    var returnTo = Url.Action("Index", "Home", null, protocol: Request.Url.Scheme);
		    return this.Redirect("/");
	    }
	}
}