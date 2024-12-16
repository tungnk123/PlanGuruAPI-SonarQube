using AutoMapper;
using Domain.Entities.ECommerce;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanGuruAPI.DTOs.ProductDTOs;

namespace PlanGuruAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly PlanGuruDBContext _context;
        private readonly IMapper _mapper;

        public ProductController(PlanGuruDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var listProduct = await _context.Products.Include(p => p.ProductImages).ToListAsync();
            return Ok(_mapper.Map<List<ProductReadDTO>>(listProduct));
        }
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            var product = await _context.Products.FindAsync(productId); 
            if(product == null)
            {
                return NotFound("Can't find this product");
            }
            return Ok(_mapper.Map<ProductReadDTO>(product));
        }
        [HttpGet("shop/{userId}")]
        public async Task<IActionResult> GetProductByShopId(Guid userId)
        {
            var listProduct = await _context.Products.Where(p => p.SellerId == userId).Include(p => p.ProductImages).ToListAsync();
            return Ok(_mapper.Map<List<ProductReadDTO>>(listProduct));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateDTO product)
        {
            var user = await _context.Users.FindAsync(product.SellerId);
            if(user == null)
            {
                return BadRequest("Can't find this user");
            }
            if(product.WikiId != null)
            {
                var wiki = await _context.Wikis.FindAsync(product.WikiId);  
                if(wiki == null)
                {
                    return BadRequest("Can't find wiki page");
                }
            }
            var newProduct = _mapper.Map<Product>(product);
            newProduct.Id = Guid.NewGuid();
            await _context.Products.AddAsync(newProduct);

            foreach (var image in product.ProductImage)
            {
                var productImage = new ProductImages()
                {
                    Image = image,
                    ProductId = newProduct.Id,
                    Product = newProduct
                };
                await _context.ProductImages.AddAsync(productImage);   
            }
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<ProductReadDTO>(newProduct));
        }
    }
}
