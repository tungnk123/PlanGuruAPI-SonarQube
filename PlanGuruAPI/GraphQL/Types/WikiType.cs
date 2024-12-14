using Domain.Entities.WikiService;
using GraphQL.Types;

namespace PlanGuruAPI.GraphQL.Types
{
    public class WikiType : ObjectGraphType<Wiki>
    {
        public WikiType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("ID của bài viết.");
            Field(x => x.Title).Description("Tiêu đề của bài viết.");
            Field(x => x.Description, nullable: true).Description("Mô tả của bài viết.");
            Field<ListGraphType<ContentSectionType>>("contentSections", "Các phần nội dung");
            Field(x => x.ThumbnailImageUrl, nullable: true).Description("Ảnh thumbnail.");
            Field<ListGraphType<ProductType>>("attachedProducts", "Sản phẩm đính kèm.");
        }
    }

    public class ContentSectionType : ObjectGraphType<ContentSection>
    {
        public ContentSectionType()
        {
            Field(x => x.SectionName).Description("Tên phần nội dung.");
            Field(x => x.Content, nullable: true).Description("Nội dung.");
            Field<ListGraphType<StringGraphType>>("imageUrls", "Danh sách URL hình ảnh.");
        }
    }
}
