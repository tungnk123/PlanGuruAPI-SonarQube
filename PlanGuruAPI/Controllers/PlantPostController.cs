using Application.PlantPosts.Command.CreatePost;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanGuruAPI.DTOs.PlantPostDTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PlanGuruAPI.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PlantPostController : ControllerBase
    {
        private readonly PlanGuruDBContext _context;
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public PlantPostController(PlanGuruDBContext context, ISender mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;

        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePlantPostRequest request)
        {
            var command = _mapper.Map<CreatePlantPostCommand>(request);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlantPosts()
        {
            return Ok(await _context.Posts.ToListAsync());
        }

    }
}
