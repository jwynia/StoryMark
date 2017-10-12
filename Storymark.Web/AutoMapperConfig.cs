using AutoMapper;
using Storymark.Service.Data.Entities;
using Storymark.Service.Data.ViewModels;

namespace Storymark.Web
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration MapperConfiguration;

        public static void RegisterMappings()
        {
            MapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<Project, ProjectViewModel>().ReverseMap();
                cfg.CreateMap<Manuscript, ManuscriptViewModel>().ReverseMap();
                cfg.CreateMap<Chapter, ChapterViewModel>().ReverseMap();
                cfg.CreateMap<Scene, SceneViewModel>().ReverseMap();
				cfg.CreateMap<GlobalStoryGrid,GlobalStoryGridViewModel>().ReverseMap();
				cfg.CreateMap<StoryGridSection,StoryGridSectionViewModel>().ReverseMap();
				cfg.CreateMap<StoryGridCommandment, StoryGridCommandmentViewModel>().ReverseMap();
				cfg.CreateMap<StoryGridCommandment, StoryGridCommandmentViewModel>().ReverseMap();
			});
        }
    }
}