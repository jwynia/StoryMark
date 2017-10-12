using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storymark.Service.Data.ViewModels
{
	public class GlobalStoryGridViewModel
	{
	    public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
	    public virtual string ExternalGenre { get; set; }
	    public virtual string ExternalValueAtStake { get; set; }
	    public virtual string InternalGenre { get; set; }
	    public virtual string InternalValueAtStake { get; set; }
	    public virtual string ObligatoryScenesAndConventions { get; set; }
	    public virtual string PointOfView { get; set; }
	    public virtual string ObjectsOfDesire { get; set; }
	    public virtual string ControllingIdeaTheme { get; set; }
	    public virtual StoryGridSectionViewModel BeginningHook { get; set; }
	    public virtual StoryGridSectionViewModel MiddleBuild { get; set; }
	    public virtual StoryGridSectionViewModel EndingPayoff { get; set; }
	    public virtual Guid Project_id { get; set; }
    }

    public class StoryGridSectionViewModel
    {
        public virtual Guid Id { get; protected set; }
        public virtual StoryGridCommandmentViewModel IncitingIncident { get; set; }
        public virtual StoryGridCommandmentViewModel Complication { get; set; }
        public virtual StoryGridCommandmentViewModel Crisis { get; set; }
        public virtual StoryGridCommandmentViewModel Climax { get; set; }
        public virtual StoryGridCommandmentViewModel Resolution { get; set; }
    }



    public class StoryGridCommandmentViewModel
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Content { get; set; }
        public virtual int ExternalCharge { get; set; }
        public virtual int InternalCharge { get; set; }
    }
}
