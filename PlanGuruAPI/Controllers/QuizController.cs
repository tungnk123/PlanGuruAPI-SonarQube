using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.DTOs.QuizDTOs;

namespace PlanGuruAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly IQuizManager _quizService;

    public QuizController(IQuizManager quizService)
    {
        _quizService = quizService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizRequest request)
    {
        try
        {
            var response = await _quizService.CreateQuizAsync(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{quizId}")]
    public async Task<IActionResult> GetQuiz(string quizId)
    {
        try
        {
            var request = new GetQuizRequest { QuizId = quizId };
            var response = await _quizService.GetQuizAsync(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("GetListQuizzes")]
    public async Task<List<QuizResponse>> GetQuizzesAsync(List<string> quizIds)
    {
        var quizResponses = new List<QuizResponse>();
        foreach (var quizId in quizIds)
        {
            var request = new GetQuizRequest { QuizId = quizId };
            var response = await _quizService.GetQuizAsync(request);
            quizResponses.Add(response);
        }
        return quizResponses;
    }


    [HttpPut("{quizId}")]
    public async Task<IActionResult> EditQuiz(string quizId, [FromBody] Quiz quiz)
    {
        try
        {
            var request = new EditQuizRequest 
            { 
                QuizId = quizId,
                Quiz = quiz
            };
            var response = await _quizService.EditQuizAsync(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetQuizList([FromQuery] int pageSize = 10, [FromQuery] string pageToken = null)
    {
        try
        {
            var request = new ListQuizzesRequest
            {
                PageSize = pageSize,
                PageToken = pageToken
            };
            var response = await _quizService.ListQuizzesAsync(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{quizId}/play")]
    public async Task<IActionResult> GetQuizForPlay(string quizId)
    {
        try
        {
            var request = new GetQuizRequest { QuizId = quizId };
            var response = await _quizService.GetQuizForPlayAsync(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{quizId}/validate")]
    public async Task<IActionResult> ValidateAnswer([FromBody] ValidateAnswerRequest request)
    {
        try
        {
            var response = await _quizService.ValidateAnswerAsync(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
