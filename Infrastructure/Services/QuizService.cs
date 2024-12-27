using Grpc.Net.Client;
using Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using PlanGuruAPI.DTOs.QuizDTOs;

namespace Infrastructure.Services;

public class QuizService : IQuizManager
{
    private readonly IQuizManager _client;

    public QuizService(IConfiguration configuration)
    {
        var serviceUrl = configuration["GrpcServices:QuizService"] ?? "http://localhost:5000";
        var channel = GrpcChannel.ForAddress(serviceUrl);
        _client = new QuizManager.QuizManagerClient(channel);
    }

    public async Task<QuizResponse> CreateQuizAsync(CreateQuizRequest request)
    {
        return await _client.CreateQuizAsync(request);
    }

    public async Task<QuizResponse> GetQuizAsync(GetQuizRequest request)
    {
        return await _client.GetQuizAsync(request);
    }

    public async Task<QuizResponse> EditQuizAsync(EditQuizRequest request)
    {
        return await _client.EditQuizAsync(request);
    }

    public async Task<ListQuizzesResponse> ListQuizzesAsync(ListQuizzesRequest request)
    {
        return await _client.ListQuizzesAsync(request);
    }

    public async Task<QuizPlayResponse> GetQuizForPlayAsync(GetQuizRequest request)
    {
        return await _client.GetQuizForPlayAsync(request);
    }

    public async Task<ValidateAnswerResponse> ValidateAnswerAsync(ValidateAnswerRequest request)
    {
        return await _client.ValidateAnswerAsync(request);
    }
}
