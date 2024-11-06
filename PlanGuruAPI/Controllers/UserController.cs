using Application.Users.Command.SetNameAndAvatar;
using Application.Users.Command.SignUp;
using Application.Users.Common;
using Application.Users.Querry.Login;
using AutoMapper;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanGuruAPI.DTOs;
using System.Diagnostics.Eventing.Reader;

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
            var loginResult = await _mediator.Send(querry); 
            return Ok(loginResult);
        }
        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp(SignUpRequest signUpRequest)
        {
            var command = _mapper.Map<SignUpCommand>(signUpRequest);
            var signUpResult = await _mediator.Send(command);       
            return Ok(signUpResult);
        }
        [HttpPost("setNameAndAvatar")]
        public async Task<IActionResult> SetNameAndAvatar(SetNameAndAvatarRequest setNameAndAvatarRequest)
        {
            var command = _mapper.Map<SetNameAndAvatarCommand>(setNameAndAvatarRequest);
            var result = await _mediator.Send(command);
            return Ok(result);      
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await _context.Users.ToListAsync());
        }
    }
}
