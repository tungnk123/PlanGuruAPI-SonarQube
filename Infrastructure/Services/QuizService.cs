using Grpc.Net.Client;
using Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.DTOs.QuizDTOs;

namespace Infrastructure.Services;

public class QuizServices : IQuizManager
{
    private readonly QuizService.QuizManager.QuizManagerClient _client;

    public QuizServices(IConfiguration configuration)
    {
        var serviceUrl = configuration["GrpcServices:QuizService"] ?? "https://localhost:7217";
        var channel = GrpcChannel.ForAddress(serviceUrl);
        _client = new QuizService.QuizManager.QuizManagerClient(channel);
    }

    public async Task<QuizResponse> CreateQuizAsync(CreateQuizRequest request)
    {
        var grpcRequest = new QuizService.CreateQuizRequest
        {
            Topic = request.Topic,
            NumberOfQuestions = request.NumberOfQuestions
        };
        
        var response = await _client.CreateQuizAsync(grpcRequest);
        return MapToQuizResponse(response);
    }

    public async Task<QuizResponse> GetQuizAsync(GetQuizRequest request)
    {
        var grpcRequest = new QuizService.GetQuizRequest
        {
            QuizId = request.QuizId
        };
        
        var response = await _client.GetQuizAsync(grpcRequest);
        return MapToQuizResponse(response);
    }

    public async Task<QuizResponse> EditQuizAsync(EditQuizRequest request)
    {
        var grpcRequest = new QuizService.EditQuizRequest
        {
            QuizId = request.QuizId,
            Quiz = MapToGrpcQuiz(request.Quiz)
        };
        
        var response = await _client.EditQuizAsync(grpcRequest);
        return MapToQuizResponse(response);
    }

    public async Task<ListQuizzesResponse> ListQuizzesAsync(ListQuizzesRequest request)
    {
        var grpcRequest = new QuizService.ListQuizzesRequest
        {
            PageSize = request.PageSize,
            PageToken = request.PageToken
        };
        
        var response = await _client.ListQuizzesAsync(grpcRequest);
        return MapToListQuizzesResponse(response);
    }

    public async Task<QuizPlayResponse> GetQuizForPlayAsync(GetQuizRequest request)
    {
        var grpcRequest = new QuizService.GetQuizRequest
        {
            QuizId = request.QuizId
        };
        
        var response = await _client.GetQuizForPlayAsync(grpcRequest);
        return MapToQuizPlayResponse(response);
    }

    public async Task<ValidateAnswerResponse> ValidateAnswerAsync(ValidateAnswerRequest request)
    {
        var grpcRequest = new QuizService.ValidateAnswerRequest
        {
            QuizId = request.QuizId,
            QuestionId = request.QuestionId,
            SelectedOptionIndex = request.SelectedOptionIndex
        };
        
        var response = await _client.ValidateAnswerAsync(grpcRequest);
        return new ValidateAnswerResponse
        {
            IsCorrect = response.IsCorrect,
            Feedback = response.Feedback
        };
    }

    private QuizResponse MapToQuizResponse(QuizService.QuizResponse grpcResponse)
    {
        return new QuizResponse
        {
            Quiz = MapToQuiz(grpcResponse.Quiz)
        };
    }

    private Quiz MapToQuiz(QuizService.Quiz grpcQuiz)
    {
        return new Quiz
        {
            QuizId = grpcQuiz.QuizId,
            Topic = grpcQuiz.Topic,
            Questions = grpcQuiz.Questions.Select(MapToQuestion).ToList(),
            CreatedAt = grpcQuiz.CreatedAt,
            CreatedBy = grpcQuiz.CreatedBy
        };
    }

    private Question MapToQuestion(QuizService.Question grpcQuestion)
    {
        return new Question
        {
            QuestionId = grpcQuestion.QuestionId,
            Content = grpcQuestion.Content,
            Options = grpcQuestion.Options.ToList(),
            CorrectOptionIndex = grpcQuestion.CorrectOptionIndex
        };
    }

    private QuizService.Quiz MapToGrpcQuiz(Quiz quiz)
    {
        var grpcQuiz = new QuizService.Quiz
        {
            QuizId = quiz.QuizId,
            Topic = quiz.Topic,
            CreatedAt = quiz.CreatedAt,
            CreatedBy = quiz.CreatedBy
        };
        grpcQuiz.Questions.AddRange(quiz.Questions.Select(MapToGrpcQuestion));
        return grpcQuiz;
    }

    private QuizService.Question MapToGrpcQuestion(Question question)
    {
        var grpcQuestion = new QuizService.Question
        {
            QuestionId = question.QuestionId,
            Content = question.Content,
            CorrectOptionIndex = question.CorrectOptionIndex
        };
        grpcQuestion.Options.AddRange(question.Options);
        return grpcQuestion;
    }

    private ListQuizzesResponse MapToListQuizzesResponse(QuizService.ListQuizzesResponse grpcResponse)
    {
        return new ListQuizzesResponse
        {
            Quizzes = grpcResponse.Quizzes.Select(MapToQuizSummary).ToList(),
            NextPageToken = grpcResponse.NextPageToken
        };
    }

    private QuizSummary MapToQuizSummary(QuizService.QuizSummary grpcSummary)
    {
        return new QuizSummary
        {
            QuizId = grpcSummary.QuizId,
            Topic = grpcSummary.Topic,
            QuestionCount = grpcSummary.QuestionCount,
            CreatedAt = grpcSummary.CreatedAt
        };
    }

    private QuizPlayResponse MapToQuizPlayResponse(QuizService.QuizPlayResponse grpcResponse)
    {
        return new QuizPlayResponse
        {
            QuizId = grpcResponse.QuizId,
            Topic = grpcResponse.Topic,
            Questions = grpcResponse.Questions.Select(MapToPlayQuestion).ToList()
        };
    }

    private PlayQuestion MapToPlayQuestion(QuizService.PlayQuestion grpcQuestion)
    {
        return new PlayQuestion
        {
            QuestionId = grpcQuestion.QuestionId,
            Content = grpcQuestion.Content,
            Options = grpcQuestion.Options.ToList()
        };
    }
}
