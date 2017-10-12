using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Storymark.Service.Services.Chapters;
using Storymark.Service.Services.Characters;
using Storymark.Service.Services.GlobalStoryGrids;
using Storymark.Service.Services.Locations;
using Storymark.Service.Services.Manuscripts;
using Storymark.Service.Services.Notes;
using Storymark.Service.Services.ProjectMenu;
using Storymark.Service.Services.Projects;
using Storymark.Service.Services.Scenes;

namespace Storymark.Service
{
	public class AutofacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);
			builder.RegisterModule<SqlServerAutofacModule>();
			//builder.RegisterModule<SqliteAutofacModule>();
			
			builder.RegisterType<ProjectService>().As<IProjectService>();
			builder.RegisterType<ManuscriptService>().As<IManuscriptService>();
			builder.RegisterType<ChapterService>().As<IChapterService>();
		    builder.RegisterType<SceneService>().As<ISceneService>();
		    builder.RegisterType<CharacterService>().As<ICharacterService>();
		    builder.RegisterType<LocationService>().As<ILocationService>();
		    builder.RegisterType<NoteService>().As<INoteService>();
			builder.RegisterType<ProjectMenuService>().As<IProjectMenuService>();
			builder.RegisterType<GlobalStoryGridService>().As<IGlobalStoryGridService>();
		}
	}
}
