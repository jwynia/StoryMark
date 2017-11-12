using System;
using System.Collections.Generic;
using System.Linq;
using Html2Markdown;
using HtmlAgilityPack;
using Markdig;
using NHibernate;
using NHibernate.Linq;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Services.Scenes
{
	internal class SceneService : BaseService, ISceneService
	{
        public SceneService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }
	    Scene ISceneService.Retrieve(Guid id, Guid personId)
	    {
	        using (var session = _sessionFactory.OpenSession())
	        {
	            var scene = session.Query<Data.Entities.Scene>().FirstOrDefault(x => x.Id == id && x.Chapter.Manuscript.Project.Owner.Id == personId);

	            if (scene?.Content != null)
	            {
	                var originalContent = scene.Content;
	                scene.Content = Markdown.ToHtml(originalContent);
                }
	            
                return scene;
	        }
        }

	    List<Scene> ISceneService.AllForProject(Guid projectId, Guid personId)
	    {
	        using (var session = _sessionFactory.OpenSession())
	        {
	            
	                var scenes = session.Query<Scene>().Fetch(x=>x.Chapter).Fetch(x=>x.Chapter.Manuscript).Where(x => x.Chapter.Manuscript.Project.Id == projectId)
	                    .OrderBy(x => x.Chapter.SortOrder).ThenBy(x => x.SortOrder).ToList();
	                return scenes;
	            
	        }
	    }

	    public List<Scene> AllForChapter(Guid chapterId, Guid personId)
	    {
	        using (var session = _sessionFactory.OpenSession())
	        {

	            var scenes = session.Query<Scene>().Fetch(x=>x.Chapter).Where(x => x.Chapter.Id == chapterId).OrderBy(x => x.SortOrder).ToList();
	            return scenes;

	        }
        }

	    Guid ISceneService.Add(Scene newEntity, Guid chapterId, Guid personId)
	    {
	        using (var session = _sessionFactory.OpenSession())
	        {
	            using (var transaction = session.BeginTransaction())
	            {
	                var chapter = session.Query<Chapter>().FirstOrDefault(x => x.Id == chapterId);
                    chapter.Scenes.Add(newEntity);
	                newEntity.Chapter = chapter;
	                var newId = session.Save(newEntity) as Guid?;
                    session.Update(chapter);
                    transaction.Commit();
	                return (Guid) newId;
	            }
	        }
        }

	    Scene ISceneService.Update(Scene input, Guid personId)
	    {
	        using (var session = _sessionFactory.OpenSession())
	        {
				if(input.Content == null)
				{
					input.Content = String.Empty;
				}
	            var converter = new Converter();
	            HtmlDocument htmlDoc = new HtmlDocument();
	            htmlDoc.LoadHtml(input.Content);
	            var textContent = htmlDoc.DocumentNode.InnerText;
	            char[] delimiters = new char[] { ' ', '\r', '\n' };
	           
                using (var transaction = session.BeginTransaction())
	            {
	                var scene = session.Query<Data.Entities.Scene>().FirstOrDefault(x => x.Id == input.Id && x.Chapter.Manuscript.Project.Owner.Id == personId);
	                scene.BeginTime = input.BeginTime;
	                scene.Content = converter.Convert(input.Content);
	                scene.Duration = input.Duration;
                    scene.WordCount = textContent.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
	                scene.PolarityShift = input.PolarityShift;
	                scene.SortOrder = input.SortOrder;
	                scene.Title = input.Title;
	                scene.TurningPoint = input.TurningPoint;
	                scene.StoryEvent = input.StoryEvent;
	                scene.ValueShift = input.ValueShift;
                    session.Update(scene);
                    transaction.Commit();
	                return scene;
                }
	        }
        }

	    void ISceneService.Delete(Guid id, Guid personId)
	    {
	        throw new NotImplementedException();
	    }
	}
}