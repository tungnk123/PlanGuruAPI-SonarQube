using GraphQL.Types;
using PlanGuruAPI.GraphQL.Mutations;
using PlanGuruAPI.GraphQL.Queries;

namespace PlanGuruAPI.GraphQL.Schemas
{
    public class WikiSchema : Schema
    {
        public WikiSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<WikiQuery>();
            Mutation = provider.GetRequiredService<WikiMutation>();
        }
    }
}
