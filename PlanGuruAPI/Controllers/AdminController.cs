using Application.Common.Interface.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanGuruAPI.DTOs.AdminDTOs;

namespace PlanGuruAPI.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IPlantPostRepository _planPostRepository;

        public AdminController(IPlantPostRepository plantPostRepository)
        {
            _planPostRepository = plantPostRepository;
        }
        [HttpPost("approvePost")]
        public async Task<IActionResult> ApprovePost([FromBody]ApprovePostRequest request)
        {
            var post = await _planPostRepository.GetPostByIdAsync(request.PostId);  
            await _planPostRepository.ApprovePostByAdmin(post);
            return Ok("Post approved");
        }
        [HttpGet("unApprovePosts")]
        public async Task<IActionResult> GetUnApprovePost()
        {
            var listPost = await _planPostRepository.GetUnApprovedPost();
            return Ok(listPost);
        }
        [HttpPost("unApprovePost")]
        public async Task<IActionResult> UnApprovePost([FromBody]ApprovePostRequest request)
        {
            var post = await _planPostRepository.GetPostByIdAsync(request.PostId);
            await _planPostRepository.DeletePostAsync(post.Id);
            return Ok("Post un approved");
        }
    }
}
