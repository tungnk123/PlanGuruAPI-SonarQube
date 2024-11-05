using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PlanGuruAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PlanGuruDBContext _context;

        public UserController(PlanGuruDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllUser()
        {
            return Ok(_context.Users);  
        }
    }
}
