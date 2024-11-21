using Application.Comments.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanGuruAPI.DTOs.CommentDTOs;

namespace PlanGuruAPI.Controllers
{
    [ApiController]
    [Route("api/posts/comments")]
    public class CommentsController : ControllerBase
    {
        private readonly ISender _mediator;

        public CommentsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto createCommentDto)
        {
            var command = new CreateCommentCommand(createCommentDto.PostId, createCommentDto.UserId, createCommentDto.Message);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
