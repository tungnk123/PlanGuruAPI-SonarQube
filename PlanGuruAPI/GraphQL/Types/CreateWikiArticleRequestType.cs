using GraphQL.Types;
using PlanGuruAPI.DTOs.WikiDTOs;

namespace PlanGuruAPI.GraphQL.Types
{
    public class CreateWikiArticleRequestType : InputObjectGraphType<CreateWikiArticleRequest>
    {
        public CreateWikiArticleRequestType()
        {
            Name = "CreateWikiArticleRequest";
            Field(x => x.Title);
            Field(x => x.Description, nullable: true);
            Field(x => x.ThumbnailImageUrl, nullable: true);
            Field(x => x.AuthorId);
            Field<ListGraphType<ContentSectionRequestType>>("contentSections");
            Field<ListGraphType<IdGraphType>>("productIds");
        }
    }

    public class ContentSectionRequestType : InputObjectGraphType<ContentSectionRequest>
    {
        public ContentSectionRequestType()
        {
            Name = "ContentSectionRequest";
            Field(x => x.SectionName).Description("The name of the content section.");
            Field(x => x.Content, nullable: true).Description("The content of the section.");
            Field<ListGraphType<StringGraphType>>("imageUrls", "The list of image URLs in the section.");
        }
    }
}