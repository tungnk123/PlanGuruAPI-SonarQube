using Application.Common.Interface.Persistence;
using Domain.Entities.WikiService;
using GraphQL;
using GraphQL.Types;
using PlanGuruAPI.DTOs.WikiDTOs;
using PlanGuruAPI.GraphQL.Types;

namespace PlanGuruAPI.GraphQL.Mutations
{
    public class WikiMutation : ObjectGraphType
    {
        public WikiMutation(IWikiRepository wikiRepository)
        {
            FieldAsync<WikiType>(
                "createWiki",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CreateWikiArticleRequestType>> { Name = "wiki" }
                ),
                resolve: async context =>
                {
                    var wikiInput = context.GetArgument<CreateWikiArticleRequest>("wiki");
                    var wiki = new Wiki
                    {
                        Title = wikiInput.Title,
                        Description = wikiInput.Description,
                        ThumbnailImageUrl = wikiInput.ThumbnailImageUrl,
                        ContentSections = wikiInput.ContentSections.Select(cs => new ContentSection
                        {
                            SectionName = cs.SectionName,
                            Content = cs.Content,
                            ImageUrls = cs.ImageUrls.ToList()
                        }).ToList()
                    };
                    await wikiRepository.AddWikiAsync(wiki);
                    return wiki;
                });
        }
    }
}
