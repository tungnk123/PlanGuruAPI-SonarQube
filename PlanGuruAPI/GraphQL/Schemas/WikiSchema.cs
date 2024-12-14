using GraphQL.Types;
using PlanGuruAPI.GraphQL.Mutations;
using PlanGuruAPI.GraphQL.Queries;

namespace PlanGuruAPI.GraphQL.Schemas
{
    public class WikiSchema : Schema
    {
        public WikiSchema(WikiQuery query, WikiMutation mutation)
        {
            Query = query;
            Mutation = mutation;
        }
    }
}
