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

            if (firstUser == null || secondUser == null)
            {
                Console.WriteLine("No users found.");
                return;
            }

            // Seed Products for the first user
            for (int i = 0; i < 5; i++)
            {
                Product product = new Product()
                {
                    Id = Guid.NewGuid(),
                    SellerId = firstUser.UserId,
                    ProductName = $"Product {i + 1}",
                    Description = $"This is the description for product {i + 1}.",
                    Price = (double)(10.0m * (i + 1))
                };
                context.Products.Add(product);

                var productImage = new ProductImages()
                {
                    Image = "https://i.pinimg.com/736x/9b/43/6b/9b436bbce92234ee89b256fba63df0f0.jpg",
                    Product = product,
                    ProductId = product.Id,
                };
                var productImage2 = new ProductImages()
                {
                    Image = "https://i.pinimg.com/736x/f5/8f/46/f58f46b81a286a6b12bea10deea92b3b.jpg",
                    Product = product,
                    ProductId = product.Id,
                };
                var productImage3 = new ProductImages()
                {
                    Image = "https://i.pinimg.com/736x/f0/b6/ee/f0b6eebcd3dd3cf0d08671b7dd241f71.jpg",
                    Product = product,
                    ProductId = product.Id,
                };
                context.ProductImages.AddRange(new List<ProductImages> { productImage, productImage2, productImage3 });


            }

            // Seed Products for the second user
            for (int i = 0; i < 5; i++)
            {
                Product product = new Product()
                {
                    Id = Guid.NewGuid(),
                    SellerId = secondUser.UserId,
                    ProductName = $"Product {i + 1}",
                    Description = $"This is the description for product {i + 1}.",
                    Price = (double)(10.0m * (i + 1))
                };
                context.Products.Add(product);

                var productImage = new ProductImages()
                {
                    Image = "https://i.pinimg.com/736x/21/0d/be/210dbe387d331ee694d581aabcb58b75.jpg",
                    Product = product,
                    ProductId = product.Id,
                };
                var productImage2 = new ProductImages()
                {
                    Image = "https://i.pinimg.com/736x/2c/89/60/2c89601a6464389a56b09d9fab358282.jpg",
                    Product = product,
                    ProductId = product.Id,
                };
                var productImage3 = new ProductImages()
                {
                    Image = "https://i.pinimg.com/736x/ab/c3/91/abc3919bbc7e1cf901e6fc2251beca15.jpg",
                    Product = product,
                    ProductId = product.Id,
                };
                context.ProductImages.AddRange(new List<ProductImages> { productImage, productImage2, productImage3 });


            }
            context.SaveChanges();
        }
    }
}
