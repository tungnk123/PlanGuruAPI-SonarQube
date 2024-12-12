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
            Field<WikiType>(
                "wiki",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context => wikiRepository.GetByIdAsync(context.GetArgument<Guid>("id"))
            );

            Field<ListGraphType<WikiType>>(
                "wikis",
                resolve: context => wikiRepository.GetAllAsync()
            );
        }
    }
}
