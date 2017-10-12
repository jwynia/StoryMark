using System;
using FluentNHibernate.Automapping;

namespace Storymark.Service.Data.Configuration
{
    internal class StorymarkAutoMappingConfiguration : DefaultAutomappingConfiguration, IAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace == "Storymark.Service.Data.Entities";
        }
    }
}