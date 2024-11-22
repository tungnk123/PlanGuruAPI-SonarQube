using Application.Comments.Command;
using Application.Common.Interface.Persistence;
using Domain.Entities;
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
        private readonly ICommentRepository _commentRepository;

        public CommentsController(ISender mediator, ICommentRepository commentRepository)
        {
            _mediator = mediator;
            _commentRepository = commentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto createCommentDto)
        {
            var command = new CreateCommentCommand(createCommentDto.PostId, createCommentDto.UserId, createCommentDto.Message);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(Guid id)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpGet("test/get-all")]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _commentRepository.GetAllCommentsAsync();
            return Ok(comments);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(Guid id, [FromBody] UpdateCommentDto updateCommentDto)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            comment.Message = updateCommentDto.Message;
            // Update other properties if needed

            await _commentRepository.UpdateCommentAsync(comment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            await _commentRepository.DeleteCommentAsync(id);
            return NoContent();
        }

        [HttpGet("posts/{postId}/comments")]
        public async Task<IActionResult> GetCommentsByPostId(Guid postId, [FromQuery] Guid? parentCommentId = null)
        {
            var comments = await _commentRepository.GetCommentsByPostIdAsync(postId, parentCommentId);
            var commentDtos = comments.Select(c => new CommentDto
            {
                CommentId = c.CommentId,
                UserId = c.UserId,
                Name = c.User.Name,
                Avatar = c.User.Avatar,
                Message = c.Message,
                NumberOfUpvote = c.CommentUpvotes.Count,
                NumberOfDevote = c.CommentDevotes.Count,
                ReplyComment = new List<CommentDto>()
            }).ToList();

            return Ok(commentDtos);
        }

        [HttpPost("upvote")]
        public async Task<IActionResult> UpvoteComment([FromBody] UpvoteDto upvoteDto)
        {
            var commentUpvote = new CommentUpvote
            {
                UserId = upvoteDto.UserId,
                CommentId = upvoteDto.TargetId
            };

            await _commentRepository.AddCommentUpvoteAsync(commentUpvote);
            var response = new
            {
                status = "success",
                message = "Upvote comment successfully"
            };

            return Ok(response);
        }

        [HttpPost("devote")]
        public async Task<IActionResult> DevoteComment([FromBody] DevoteDto devoteDto)
        {
            var commentDevote = new CommentDevote
            {
                UserId = devoteDto.UserId,
                CommentId = devoteDto.TargetId
            };

            await _commentRepository.AddCommentDevoteAsync(commentDevote);
            var response = new
            {
                status = "success",
                message = "Devote comment successfully"
            };

            return Ok(response);
        }

    }
}
