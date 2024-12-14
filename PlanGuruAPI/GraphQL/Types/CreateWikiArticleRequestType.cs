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
            Field(x => x.SectionName);
            Field(x => x.Content, nullable: true);
            Field<ListGraphType<StringGraphType>>("imageUrls");
        }
    }
}