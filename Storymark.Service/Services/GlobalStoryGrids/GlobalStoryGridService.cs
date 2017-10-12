using System;
using System.Linq;
using AutoMapper;
using NHibernate;
using NHibernate.Linq;
using Storymark.Service.Data.Entities;

namespace Storymark.Service.Services.GlobalStoryGrids
{
    internal class GlobalStoryGridService : BaseService, IGlobalStoryGridService
    {
        public GlobalStoryGridService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        GlobalStoryGrid IGlobalStoryGridService.Retrieve(Guid id, Guid currentUserId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session.Query<GlobalStoryGrid>()
                    .Fetch(x => x.BeginningHook).ThenFetch(x => x.Climax)
                    .Fetch(x => x.BeginningHook).ThenFetch(x => x.Complication)
                    .Fetch(x => x.BeginningHook).ThenFetch(x => x.Crisis)
                    .Fetch(x => x.BeginningHook).ThenFetch(x => x.IncitingIncident)
                    .Fetch(x => x.BeginningHook).ThenFetch(x => x.Resolution)
                    .Fetch(x => x.MiddleBuild).ThenFetch(x => x.Climax)
                    .Fetch(x => x.MiddleBuild).ThenFetch(x => x.Complication)
                    .Fetch(x => x.MiddleBuild).ThenFetch(x => x.Crisis)
                    .Fetch(x => x.MiddleBuild).ThenFetch(x => x.IncitingIncident)
                    .Fetch(x => x.MiddleBuild).ThenFetch(x => x.Resolution)
                    .Fetch(x => x.EndingPayoff).ThenFetch(x => x.Climax)
                    .Fetch(x => x.EndingPayoff).ThenFetch(x => x.Complication)
                    .Fetch(x => x.EndingPayoff).ThenFetch(x => x.Crisis)
                    .Fetch(x => x.EndingPayoff).ThenFetch(x => x.IncitingIncident)
                    .Fetch(x => x.EndingPayoff).ThenFetch(x => x.Resolution)
                    .FirstOrDefault(x => x.Id == id && x.Project.Owner.Id == currentUserId);
            }
        }

        Guid IGlobalStoryGridService.Add(GlobalStoryGrid newGlobalStoryGrid, Guid projectId, Guid currentUserId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var project = session.Query<Project>().Single(x => x.Id == projectId);
                    newGlobalStoryGrid.Project = project;
                    newGlobalStoryGrid.Title = project.Title + " Story Grid";
                    newGlobalStoryGrid.BeginningHook = CreateStoryGridSection(session);
                    newGlobalStoryGrid.MiddleBuild = CreateStoryGridSection(session);
                    newGlobalStoryGrid.EndingPayoff = CreateStoryGridSection(session);

                    var id = session.Save(newGlobalStoryGrid);
                    transaction.Commit();
                    return (Guid) id;
                }
            }
        }

        private static StoryGridSection CreateStoryGridSection(ISession session)
        {
            StoryGridSection section = new StoryGridSection();

            section.IncitingIncident = CreateStoryGridCommandment(session);
            section.Complication = CreateStoryGridCommandment(session);
            section.Crisis = CreateStoryGridCommandment(session);
            section.Climax = CreateStoryGridCommandment(session);
            section.Resolution = CreateStoryGridCommandment(session);

            session.Save(section);
            return section;
        }

        private static StoryGridCommandment CreateStoryGridCommandment(ISession session)
        {
            StoryGridCommandment climax = new StoryGridCommandment();
            session.Save(climax);
            return climax;
        }

        GlobalStoryGrid IGlobalStoryGridService.Update(GlobalStoryGrid updated, Guid currentUserId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var existing = session.Query<GlobalStoryGrid>().First(x => x.Id == updated.Id);
                    existing.Title = updated.Title;
                    existing.ControllingIdeaTheme = updated.ControllingIdeaTheme;
                    existing.ExternalGenre = updated.ExternalGenre;
                    existing.ExternalValueAtStake = updated.ExternalValueAtStake;
                    existing.InternalGenre = updated.InternalGenre;
                    existing.InternalValueAtStake = updated.InternalValueAtStake;
                    existing.ObjectsOfDesire = updated.ObjectsOfDesire;
                    existing.PointOfView = updated.PointOfView;
                    existing.ObligatoryScenesAndConventions = updated.ObligatoryScenesAndConventions;

	                UpdateSection(updated.BeginningHook, existing.BeginningHook);
	                UpdateSection(updated.MiddleBuild, existing.MiddleBuild);
	                UpdateSection(updated.EndingPayoff, existing.EndingPayoff);

					session.Update(existing);
                    transaction.Commit();
                    return existing;
                }
            }
        }

	    private static void UpdateSection(StoryGridSection updated, StoryGridSection existing)
	    {
		    existing.IncitingIncident.Content = updated.IncitingIncident.Content;
		    existing.IncitingIncident.ExternalCharge = updated.IncitingIncident.ExternalCharge;
		    existing.IncitingIncident.InternalCharge = updated.IncitingIncident.InternalCharge;

			existing.Complication.Content = updated.Complication.Content;
		    existing.Complication.ExternalCharge = updated.Complication.ExternalCharge;
		    existing.Complication.InternalCharge = updated.Complication.InternalCharge;


			existing.Crisis.Content = updated.Crisis.Content;
		    existing.Crisis.ExternalCharge = updated.Crisis.ExternalCharge;
		    existing.Crisis.InternalCharge = updated.Crisis.InternalCharge;

			existing.Climax.Content = updated.Climax.Content;
		    existing.Climax.ExternalCharge = updated.Climax.ExternalCharge;
		    existing.Climax.InternalCharge = updated.Climax.InternalCharge;

			existing.Resolution.Content = updated.Resolution.Content;
		    existing.Resolution.ExternalCharge = updated.Resolution.ExternalCharge;
		    existing.Resolution.InternalCharge = updated.Resolution.InternalCharge;

		}
	}
}