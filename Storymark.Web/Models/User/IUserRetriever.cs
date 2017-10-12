using Storymark.Service.Data.Entities;

namespace Storymark.Web.Models.User
{
	public interface IUserRetriever
	{
		Person GetCurrentUser(string userId, string email, string fullName);
	}
}