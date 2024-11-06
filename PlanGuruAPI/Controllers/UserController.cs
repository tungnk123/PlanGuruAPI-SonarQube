using Application.Users.Common;
using Application.Users.Querry;
using AutoMapper;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanGuruAPI.DTOs;

namespace PlanGuruAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PlanGuruDBContext _context;
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public UserController(PlanGuruDBContext context, ISender mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var querry = _mapper.Map<LoginQuerry>(loginRequest);
            LoginResult loginResult = await _mediator.Send(querry); 
            return Ok(loginResult);
        }
    }
}
