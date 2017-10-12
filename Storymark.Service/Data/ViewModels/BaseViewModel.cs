namespace Storymark.Service.Data.ViewModels
{
    public class BaseViewModel
    {
        public string SiteName { get { return "Site Name"; } }
        public UserViewModel CurrentUser { get; set; }
    }
}