using Domain.Entities.ECommerce;
using GraphQL.Types;
namespace PlanGuruAPI.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("ID của sản phẩm.");
            Field(x => x.ProductName).Description("Tên sản phẩm.");
            Field(x => x.Quantity).Description("Số lượng sản phẩm.");
            Field(x => x.Price).Description("Giá sản phẩm.");
            Field(x => x.Description, nullable: true).Description("Mô tả sản phẩm.");
            Field<ListGraphType<StringGraphType>>("productImageUrls", "Danh sách URL hình ảnh của sản phẩm.");
            Field(x => x.SellerId, type: typeof(IdGraphType)).Description("ID của người bán.");
        }
    }
}
