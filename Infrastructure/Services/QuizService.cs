using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

public class QuizService
{
    private readonly QuizManager.QuizManagerClient _client;

    public QuizService(IConfiguration configuration)
    {
        var serviceUrl = configuration["GrpcServices:QuizService"] ?? "http://localhost:5000";
        var channel = GrpcChannel.ForAddress(serviceUrl);
        _client = new QuizManager.QuizManagerClient(channel);
    }

    public async Task<Quiz> CreateQuizAsync(string topic, int numberOfQuestions)
    {
        var request = new CreateQuizRequest 
        { 
            Topic = topic, 
            NumberOfQuestions = numberOfQuestions 
        };
        
        var response = await _client.CreateQuizAsync(request);
        return response.Quiz;
    }

    public async Task<List<QuizSummary>> GetQuizListAsync(int pageSize = 10, string? pageToken = null)
    {
        var request = new ListQuizzesRequest 
        { 
            PageSize = pageSize
        };
        if (!string.IsNullOrEmpty(pageToken))
        {
            request.PageToken = pageToken;
        }
        
        var response = await _client.ListQuizzesAsync(request);
        return response.Quizzes.ToList();
    }

    public async Task<QuizPlayResponse> GetQuizForPlayAsync(string quizId)
    {
        var request = new GetQuizRequest { QuizId = quizId };
        return await _client.GetQuizForPlayAsync(request);
    }

    public async Task<bool> ValidateAnswerAsync(string quizId, string questionId, int selectedOptionIndex)
    {
        var request = new ValidateAnswerRequest 
        { 
            QuizId = quizId, 
            QuestionId = questionId, 
            SelectedOptionIndex = selectedOptionIndex 
        };
        
        var response = await _client.ValidateAnswerAsync(request);
        return response.IsCorrect;
    }
}
