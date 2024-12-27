using Domain.DTOs.QuizDTOs;
using Grpc.Core;
using Infrastructure.Services.Interfaces;

namespace Infrastructure.Services.Grpc;

public class QuizManagerClient : IQuizManager
{
    private readonly CallInvoker _callInvoker;

    public QuizManagerClient(CallInvoker callInvoker)
    {
        _callInvoker = callInvoker;
    }

    public async Task<QuizResponse> CreateQuizAsync(CreateQuizRequest request)
    {
        var method = new Method<CreateQuizRequest, QuizResponse>(
            MethodType.Unary,
            "quiz.QuizManager",
            "CreateQuiz",
            Marshallers.Create(
                input => SerializeRequest(input),
                QuizResponse.Parser.ParseFrom));

        return await _callInvoker.AsyncUnaryCall(method, null, default, request);
    }

    public async Task<QuizResponse> GetQuizAsync(GetQuizRequest request)
    {
        var method = new Method<GetQuizRequest, QuizResponse>(
            MethodType.Unary,
            "quiz.QuizManager",
            "GetQuiz",
            Marshallers.Create(
                input => SerializeRequest(input),
                QuizResponse.Parser.ParseFrom));

        return await _callInvoker.AsyncUnaryCall(method, null, default, request);
    }

    public async Task<QuizResponse> EditQuizAsync(EditQuizRequest request)
    {
        var method = new Method<EditQuizRequest, QuizResponse>(
            MethodType.Unary,
            "quiz.QuizManager",
            "EditQuiz",
            Marshallers.Create(
                input => SerializeRequest(input),
                QuizResponse.Parser.ParseFrom));

        return await _callInvoker.AsyncUnaryCall(method, null, default, request);
    }

    public async Task<ListQuizzesResponse> ListQuizzesAsync(ListQuizzesRequest request)
    {
        var method = new Method<ListQuizzesRequest, ListQuizzesResponse>(
            MethodType.Unary,
            "quiz.QuizManager",
            "ListQuizzes",
            Marshallers.Create(
                input => SerializeRequest(input),
                ListQuizzesResponse.Parser.ParseFrom));

        return await _callInvoker.AsyncUnaryCall(method, null, default, request);
    }

    public async Task<QuizPlayResponse> GetQuizForPlayAsync(GetQuizRequest request)
    {
        var method = new Method<GetQuizRequest, QuizPlayResponse>(
            MethodType.Unary,
            "quiz.QuizManager",
            "GetQuizForPlay",
            Marshallers.Create(
                input => SerializeRequest(input),
                QuizPlayResponse.Parser.ParseFrom));

        return await _callInvoker.AsyncUnaryCall(method, null, default, request);
    }

    public async Task<ValidateAnswerResponse> ValidateAnswerAsync(ValidateAnswerRequest request)
    {
        var method = new Method<ValidateAnswerRequest, ValidateAnswerResponse>(
            MethodType.Unary,
            "quiz.QuizManager",
            "ValidateAnswer",
            Marshallers.Create(
                input => SerializeRequest(input),
                ValidateAnswerResponse.Parser.ParseFrom));

        return await _callInvoker.AsyncUnaryCall(method, null, default, request);
    }

    private byte[] SerializeRequest<T>(T request)
    {
        using var stream = new MemoryStream();
        // Implement serialization logic here based on your needs
        return stream.ToArray();
    }
}
