using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Services.Chapters
{
	internal class ChapterService : BaseService,IChapterService
    {
        public ChapterService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        Chapter IChapterService.Retrieve(Guid id, Guid personId)
		{
			using (var session = _sessionFactory.OpenSession())
			{
				var chapter = session.Query<Chapter>().FirstOrDefault(x => x.Id == id && x.Manuscript.Project.Owner.Id == personId);
				return chapter;
			}
		}

	    List<Chapter> IChapterService.AllForManuscript(Guid manuscriptId, Guid personId)
		{
		    using (var session = _sessionFactory.OpenSession())
		    {
		        var chapters = session.Query<Chapter>().Where(x => x.Manuscript.Id == manuscriptId && x.Manuscript.Project.Owner.Id == personId).OrderBy(x=>x.SortOrder).ToList();
		        return chapters;
		    }
        }

	    Guid IChapterService.Add(Chapter newChapter, Guid manuscriptId, Guid personId)
		{
		    using (var session = _sessionFactory.OpenSession())
		    {
		        using (var transaction = session.BeginTransaction())
		        {
		            var manuscript = session.Query<Manuscript>().Fetch(x => x.Chapters)
		                .First(x => x.Id == manuscriptId && x.Project.Owner.Id == personId);
					int highestSort = 0;
							                
		            if (session.Query<Chapter>().Count(x=>x.Manuscript.Id == manuscriptId) > 0)
		            {
		                highestSort = session.Query<Chapter>().OrderBy(x=>x.SortOrder).Where(x => x.Manuscript.Id == manuscriptId).ToList().Last().SortOrder;
		            }		                
		            
					newChapter.SortOrder = highestSort + 1;
					newChapter.Title = "Chapter " + newChapter.SortOrder;

                    var chapterId = session.Save(newChapter) as Guid?;
		           		            
		            manuscript.Chapters.Add(newChapter);
                    session.Update(manuscript);
                    transaction.Commit();
		            return (Guid) chapterId;
		        }
		    }
        }

	    Chapter IChapterService.Update(Chapter inputChapter, Guid personId)
		{
			using (var session = _sessionFactory.OpenSession())
			{
				using (var transaction = session.BeginTransaction())
				{
					var chapter = session.Query<Chapter>().First(x => x.Id == inputChapter.Id && x.Manuscript.Project.Owner.Id == personId);
					chapter.Title = inputChapter.Title;
					chapter.SortOrder = inputChapter.SortOrder;
					session.Update(chapter);
					transaction.Commit();
					return chapter;
				}
			}
		}

	    void IChapterService.Delete(Guid id, Guid personId)
		{
			throw new NotImplementedException();
		}
	}
}
