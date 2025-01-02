using Domain.Entities.ECommerce;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static partial class SeedData
    {
        public static void SeedProducts(PlanGuruDBContext context)
        {
            Console.WriteLine("Seeding Products...");
            // get the two first users
            var firstUser = context.Users.FirstOrDefault();
            var secondUser = context.Users.Skip(1).FirstOrDefault();
            var thirdUser = context.Users.Skip(3).FirstOrDefault();

            if (firstUser == null || secondUser == null || thirdUser == null)
            {
                Console.WriteLine("No users found.");
                return;
            }

            firstUser.IsHavePremium = true;
            secondUser.IsHavePremium = true;
            thirdUser.IsHavePremium = true;

            context.SaveChanges();

            var plantImages1 = new List<string>
                        {
                     "https://locat.com.vn/ShowTopicSubImage.aspx?id=37509",
                     "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAIVAsOayz_MtPEAcGeJJNjegA6ue4Rw5MjA&s",
                     "https://caycanh.garden1900.com/wp-content/uploads/2020/10/cay-trau-ba-lo-thuy-sinh-cay-trau-ba-la-thung-thuy-sinh-garden1900.jpg",
                     "https://caycanhgovap.com/wp-content/uploads/2020/09/C707543B-035A-42B6-BB45-AFF43B9317F9.jpeg",
                     "https://caycanhhanoi.com/wp-content/uploads/2020/07/tuoi-than-hop-cay-gi-de-tien-vao-nhu-nuoc-1.jpg",
                     "https://vuontungtoanjp.vn/wp-content/uploads/sites/7/2023/09/bo-tu-linh-cay-canh-2.jpg",
                     "https://cdn-images.kiotviet.vn/greensculpture/fca645bfbda44fba8cbba8adba71e467.jpg",
                     "https://nguoiduatin.mediacdn.vn/upload/4-2024/images/2024-12-05/4-cay-canh-mang-phu-quy-tai-loc-vao-nha-ngay-Tet-cai-cuoi-cung-khong-ai-ngo-toi-batch_v2-44678cc37f6c23a2125714b8fbaa6786_1440w-1733339896-560-width740height823.jpg",
                     "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRm3sJgu6DenGVL8Bgbzbzf2eQGTsrrfR4wI5L4CywSV-lSwzsi",
                     "https://product.hstatic.net/200000815931/product/kimnganbinhmowgarden-800x800_f29e08ed68e84dba93013c012b21ffff_large.jpg"
                        };
            var plantImages2 = new List<string>
                        {
                    "https://locat.com.vn/ShowTopicSubImage.aspx?id=37509",
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAIVAsOayz_MtPEAcGeJJNjegA6ue4Rw5MjA&s",
                    "https://greenvibes.vn/wp-content/uploads/2023/07/monstera-40061.jpg",
                    "https://cobtainlife.com/storage/photos/Product/Cay%20noi%20that,%20phong%20thuy/21.jpg",
                    "https://caycanhhanoi.com/wp-content/uploads/2020/07/tuoi-than-hop-cay-gi-de-tien-vao-nhu-nuoc-1.jpg",
                    "https://i.pinimg.com/736x/f6/f1/aa/f6f1aa89b7638c33ada4b91e5d9ee657.jpg",
                    "https://cdn-images.kiotviet.vn/greensculpture/fca645bfbda44fba8cbba8adba71e467.jpg",
                    "https://nguoiduatin.mediacdn.vn/upload/4-2024/images/2024-12-05/4-cay-canh-mang-phu-quy-tai-loc-vao-nha-ngay-Tet-cai-cuoi-cung-khong-ai-ngo-toi-batch_v2-44678cc37f6c23a2125714b8fbaa6786_1440w-1733339896-560-width740height823.jpg",
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQK_3ymmDzVm9mo6-2Lvzuog2D-85Jjs5kWcGnbIbfpMWnKlKvJ",
                    "https://product.hstatic.net/200000815931/product/kimnganbinhmowgarden-800x800_f29e08ed68e84dba93013c012b21ffff_large.jpg"
                        };
            var plantImages3 = new List<string>
                        {
                    "https://huge-germany.com/wp-content/uploads/2022/09/1-cay-trau-ba-dd.jpg",
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTb3ReAwW8KuM9V1hSTm3jFeHJ7zgqfJxPj9Q&s",
                    "https://wedecorvietnam.com/upload/21/18/18/cay-trau-ba-la-xe-thumb--n1.jpg",
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTtbO2jwVcHXIfeyE_JmhW2Ee6TX7_wFxgJ4wvL6B4XUQJ9Ra5k",
                    "https://locat.com.vn/hinh-hoa-tuoi/cay-de-ban/9554_suu-tai-loc.jpg",
                    "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTO1hJjXNoIfTFDalpGJW8HtZjEcpy54861_6eqgFsfETakDc2D8aFV2fVUvn5DS8mj1JmEN_mKTBIXyh1UtvHK5o10Lp2gkNxP-SsPGg",
                    "https://cdn-images.kiotviet.vn/greensculpture/fca645bfbda44fba8cbba8adba71e467.jpg",
                    "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSVUFv1NRRJPQsInchtH_qE7wIpljec3y2cIPRdPTL3xr7eElyI",
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQK_3ymmDzVm9mo6-2Lvzuog2D-85Jjs5kWcGnbIbfpMWnKlKvJ",
                    "https://caycanhannam.com//upload/ckfinder/images/cay-kieng-de-ban-gia-re-thu-duc-1(1).jpg"
                        };

            // Seed Products for the first user
            for (int i = 0; i < 10; i++)
            {
                Product product = new Product()
                {
                    Id = Guid.NewGuid(),
                    SellerId = firstUser.UserId,
                    ProductName = i switch
                    {
                        0 => "Lucky Money Tree",
                        1 => "Golden Pothos in Water",
                        2 => "Mini Monstera Plant",
                        3 => "White Cactus",
                        4 => "Brown Succulent",
                        5 => "Japanese Palm",
                        6 => "Red Anthurium",
                        7 => "Small ZZ Plant",
                        8 => "Golden Areca Palm",
                        9 => "Mini Snake Plant",
                        _ => $"Product {i + 1}"
                    },
                    Description = i switch
                    {
                        0 => "The Lucky Money Tree brings good fortune, perfect for office desks.",
                        1 => "Golden Pothos in water is easy to care for and purifies the air.",
                        2 => "Mini Monstera Plant, an excellent choice for home decor.",
                        3 => "White Cactus with unique shapes, great as a gift.",
                        4 => "Compact Brown Succulent, ideal for study or work desks.",
                        5 => "Premium Japanese Palm, brings a natural feeling to any space.",
                        6 => "Red Anthurium - the perfect choice for birthday gifts.",
                        7 => "Small ZZ Plant symbolizes wealth and prosperity.",
                        8 => "Golden Areca Palm improves air quality and Feng Shui.",
                        9 => "Mini Snake Plant, a favorite for desk decoration.",
                        _ => $"This is the description for product {i + 1}."
                    },
                    Price = (double)(10.0m * (i + 1)),
                    Quantity = 10
                };
                context.Products.Add(product);

                // Add product images
                var productImage = new ProductImages()
                {
                    Image = plantImages1[i],
                    Product = product,
                    ProductId = product.Id,
                };
                var productImage2 = new ProductImages()
                {
                    Image = plantImages2[i],
                    Product = product,
                    ProductId = product.Id,
                };
                var productImage3 = new ProductImages()
                {
                    Image = plantImages3[i],
                    Product = product,
                    ProductId = product.Id,
                };
                context.ProductImages.AddRange(new List<ProductImages> { productImage, productImage2, productImage3 });
            }


            // Seed Products for the second user
            // Seed Products for the first user
            for (int i = 0; i < 10; i++)
            {
                Product product = new Product()
                {
                    Id = Guid.NewGuid(),
                    SellerId = secondUser.UserId,
                    ProductName = i switch
                    {
                        0 => "Lucky Money Tree",
                        1 => "Golden Pothos in Water",
                        2 => "Mini Monstera Plant",
                        3 => "White Cactus",
                        4 => "Brown Succulent",
                        5 => "Japanese Palm",
                        6 => "Red Anthurium",
                        7 => "Small ZZ Plant",
                        8 => "Golden Areca Palm",
                        9 => "Mini Snake Plant",
                        _ => $"Product {i + 1}"
                    },
                    Description = i switch
                    {
                        0 => "The Lucky Money Tree brings good fortune, perfect for office desks.",
                        1 => "Golden Pothos in water is easy to care for and purifies the air.",
                        2 => "Mini Monstera Plant, an excellent choice for home decor.",
                        3 => "White Cactus with unique shapes, great as a gift.",
                        4 => "Compact Brown Succulent, ideal for study or work desks.",
                        5 => "Premium Japanese Palm, brings a natural feeling to any space.",
                        6 => "Red Anthurium - the perfect choice for birthday gifts.",
                        7 => "Small ZZ Plant symbolizes wealth and prosperity.",
                        8 => "Golden Areca Palm improves air quality and Feng Shui.",
                        9 => "Mini Snake Plant, a favorite for desk decoration.",
                        _ => $"This is the description for product {i + 1}."
                    },
                    Price = (double)(10.0m * (i + 1)),
                    Quantity = 10
                };
                context.Products.Add(product);

                // Add product images
                var productImage = new ProductImages()
                {
                    Image = plantImages1[i],
                    Product = product,
                    ProductId = product.Id,
                };
                var productImage2 = new ProductImages()
                {
                    Image = plantImages2[i],
                    Product = product,
                    ProductId = product.Id,
                };
                var productImage3 = new ProductImages()
                {
                    Image = plantImages3[i],
                    Product = product,
                    ProductId = product.Id,
                };
                context.ProductImages.AddRange(new List<ProductImages> { productImage, productImage2, productImage3 });
            }

            // Seed Products for the first user
            for (int i = 0; i < 10; i++)
            {
                Product product = new Product()
                {
                    Id = Guid.NewGuid(),
                    SellerId = thirdUser.UserId,
                    ProductName = i switch
                    {
                        0 => "Lucky Money Tree",
                        1 => "Golden Pothos in Water",
                        2 => "Mini Monstera Plant",
                        3 => "White Cactus",
                        4 => "Brown Succulent",
                        5 => "Japanese Palm",
                        6 => "Red Anthurium",
                        7 => "Small ZZ Plant",
                        8 => "Golden Areca Palm",
                        9 => "Mini Snake Plant",
                        _ => $"Product {i + 1}"
                    },
                    Description = i switch
                    {
                        0 => "The Lucky Money Tree brings good fortune, perfect for office desks.",
                        1 => "Golden Pothos in water is easy to care for and purifies the air.",
                        2 => "Mini Monstera Plant, an excellent choice for home decor.",
                        3 => "White Cactus with unique shapes, great as a gift.",
                        4 => "Compact Brown Succulent, ideal for study or work desks.",
                        5 => "Premium Japanese Palm, brings a natural feeling to any space.",
                        6 => "Red Anthurium - the perfect choice for birthday gifts.",
                        7 => "Small ZZ Plant symbolizes wealth and prosperity.",
                        8 => "Golden Areca Palm improves air quality and Feng Shui.",
                        9 => "Mini Snake Plant, a favorite for desk decoration.",
                        _ => $"This is the description for product {i + 1}."
                    },
                    Price = (double)(10.0m * (i + 1)),
                    Quantity = 10
                };
                context.Products.Add(product);

                // Add product images
                var productImage = new ProductImages()
                {
                    Image = plantImages1[i],
                    Product = product,
                    ProductId = product.Id,
                };
                var productImage2 = new ProductImages()
                {
                    Image = plantImages2[i],
                    Product = product,
                    ProductId = product.Id,
                };
                var productImage3 = new ProductImages()
                {
                    Image = plantImages3[i],
                    Product = product,
                    ProductId = product.Id,
                };
                context.ProductImages.AddRange(new List<ProductImages> { productImage, productImage2, productImage3 });
            }


            context.SaveChanges();
        }
    }
}
