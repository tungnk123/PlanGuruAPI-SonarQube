using AutoMapper;
using Domain.Entities.ECommerce;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanGuruAPI.DTOs.OrderDTOs;

namespace PlanGuruAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly PlanGuruDBContext _context;
        private readonly IMapper _mapper;

        public OrderController(PlanGuruDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listOrder = await _context.Orders.ToListAsync();
            return Ok(_mapper.Map<List<OrderReadDTO>>(listOrder));
        }
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(Guid orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);   
            if(order == null)
            {
                return NotFound("Can't find this order");
            }
            return Ok(_mapper.Map<OrderReadDTO>(order));
        }
        [HttpGet("users/{userId}")]
        public async Task<IActionResult> GetListOrderByUserId(Guid userId)
        {
            var checkUser = await _context.Users.FindAsync(userId); 
            if(checkUser == null)
            {
                return BadRequest("This user is not exist");
            }
            var listOrder = await _context.Orders.Where(p => p.UserId == userId).ToListAsync();
            return Ok(_mapper.Map<List<OrderReadDTO>>(listOrder));
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderCreateDTO order)
        {
            var checkUser = await _context.Users.FindAsync(order.UserId);
            if (checkUser == null)
            {
                return BadRequest("This user is not exist");
            }
            var checkProduct = await _context.Products.FindAsync(order.ProductId);
            if (checkProduct == null)
            {
                return BadRequest("This product is not exist");
            }
            var newOrder = _mapper.Map<Order>(order);   
            newOrder.Id = Guid.NewGuid();   
            newOrder.TotalPrice = order.Quantity * checkProduct.Price;
            newOrder.Status = "Pending";
            newOrder.CreatedAt = DateTime.Now;
            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<OrderReadDTO>(newOrder));
        }
        [HttpPost("confirmOrder")]
        public async Task<IActionResult> ConfirmOrder(Guid orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if(order == null)
            {
                return BadRequest("This order is not exist");
            }
            order.Status = "Confirmed";
            await _context.SaveChangesAsync();
            return Ok("Confirm order successfully");
        }
        [HttpPost("markAsFailedOrder")]
        public async Task<IActionResult> FailedOrder(Guid orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return BadRequest("This order is not exist");
            }
            order.Status = "Failed";
            await _context.SaveChangesAsync();
            return Ok("Mark this order failed successfully");
        }
        [HttpPost("markAsSuccessOrder")]
        public async Task<IActionResult> SuccessOrder(Guid orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return BadRequest("This order is not exist");
            }
            order.Status = "Success";
            await _context.SaveChangesAsync();
            return Ok("Mark this order success successfully");
        }
    }
}
