using GraphQL.Types;
using PlanGuruAPI.DTOs.WikiDTOs;

namespace PlanGuruAPI.GraphQL.Types
{
    public class UpdateWikiArticleRequestType : InputObjectGraphType<UpdateWikiArticleRequest>
    {
        public UpdateWikiArticleRequestType()
        {
            Name = "UpdateWikiArticleRequest";
            Field(x => x.Title).Description("The title of the wiki article.");
            Field(x => x.Description, nullable: true).Description("The description of the wiki article.");
            Field(x => x.ThumbnailImageUrl, nullable: true).Description("The thumbnail image URL of the wiki article.");
            Field<ListGraphType<ContentSectionRequestType>>("contentSections", "The content sections of the wiki article.");
            Field<ListGraphType<IdGraphType>>("productIds", "The IDs of the products attached to the wiki article.");
        }
    }
}
