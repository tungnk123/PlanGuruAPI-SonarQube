using Application.Common.Interface.Persistence;
using GraphQL;
using GraphQL.Types;
using PlanGuruAPI.GraphQL.Types;

namespace PlanGuruAPI.GraphQL.Queries
{
    public class WikiQuery : ObjectGraphType
    {
        public WikiQuery(IWikiRepository wikiRepository)
        {
            FieldAsync<WikiType>(
                "wiki",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: async context =>
                {
                    var wiki = await wikiRepository.GetByIdAsync(context.GetArgument<Guid>("id"));
                    return wiki;

                }
            );

            FieldAsync<ListGraphType<WikiType>>(
                "wikis",
                resolve: async context => {
                    var wikis = await wikiRepository.GetAllAsync();
                    return wikis;

                }
            );
        }
    }
}
