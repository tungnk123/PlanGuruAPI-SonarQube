using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PlanGuruAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly QuizService _quizService;

    public QuizController(QuizService quizService)
    {
        _quizService = quizService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateQuiz(string topic, int numberOfQuestions)
    {
        try
        {
            var quiz = await _quizService.CreateQuizAsync(topic, numberOfQuestions);
            return Ok(quiz);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetQuizList(int pageSize = 10, string? pageToken = null)
    {
        try
        {
            var quizzes = await _quizService.GetQuizListAsync(pageSize, pageToken);
            return Ok(quizzes);
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
            var quiz = await _quizService.GetQuizForPlayAsync(quizId);
            return Ok(quiz);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{quizId}/validate")]
    public async Task<IActionResult> ValidateAnswer(string quizId, string questionId, int selectedOptionIndex)
    {
        try
        {
            var isCorrect = await _quizService.ValidateAnswerAsync(quizId, questionId, selectedOptionIndex);
            return Ok(new { isCorrect });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
