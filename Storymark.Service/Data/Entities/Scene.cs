using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;
using NHibernate.Envers.Configuration.Attributes;
using Storymark.Service.Data.Configuration;

namespace Storymark.Service.Data.Entities
{
	[Audited]
	public class Scene
	{
		public virtual Guid Id { get; protected set; }
		public virtual string Title { get; set; }
        public virtual int SortOrder { get; set; }
        [StringLength(10000)]
        public virtual string Content { get; set; }
        public virtual int WordCount { get; set; }
        public virtual string StoryEvent { get; set; }
        public virtual string ValueShift { get; set; }
        public virtual string PolarityShift { get; set; }
        public virtual string TurningPoint { get; set; }
        public virtual string BeginTime { get; set; }
        public virtual string Duration { get; set; }       
        public virtual string IncitingEvent { get; set; }
        public virtual string ProgressiveComplication { get; set; }
        public virtual string Crisis { get; set; }
        public virtual string Climax { get; set; }
        public virtual string Resolution { get; set; }
	    public virtual IList<Character> OnStageCharacters { get; set; }
        public virtual IList<Character> OffStageCharacters { get; set; }
        public virtual Character POVCharacter { get; set; }
        public virtual Location Location { get; set; }
        public virtual Chapter Chapter { get; set; }       
        public virtual Manuscript Manuscript { get; set; }
		public virtual GlobalStoryGrid GlobalStoryGrid { get; set; }
    }

    //public class SceneMap : ClassMap<Scene>
    //{
    //    public SceneMap()
    //    {
    //        Id(x => x.Id);
    //        Map(x => x.Title);
    //        Map(x => x.SortOrder);
    //        Map(x => x.Content).Length(4000);
    //        Map(x => x.WordCount);
    //        Map(x => x.StoryEvent);
    //        Map(x => x.ValueShift);
    //        Map(x => x.TurningPoint);
    //        Map(x => x.PolarityShift);
    //        Map(x => x.BeginTime);
    //        Map(x => x.Duration);
    //        Map(x => x.IncitingEvent);
    //        Map(x => x.ProgressiveComplication);
    //        Map(x => x.Crisis);
    //        Map(x => x.Resolution);
    //        HasManyToMany(x => x.OnStageCharacters);
    //        HasManyToMany(x => x.OffStageCharacters);
    //        HasOne(x => x.POVCharacter);
    //        HasOne(x => x.Chapter);
    //        HasOne(x => x.Manuscript);
    //        HasOne(x => x.GlobalStoryGrid);

    //    }
    //}


}