using PlanGuruAPI.DTOs.QuizDTOs;

namespace Infrastructure.Services.Interfaces;

public interface IQuizManager
{
    Task<QuizResponse> CreateQuizAsync(CreateQuizRequest request);
    Task<QuizResponse> GetQuizAsync(GetQuizRequest request);
    Task<QuizResponse> EditQuizAsync(EditQuizRequest request);
    Task<ListQuizzesResponse> ListQuizzesAsync(ListQuizzesRequest request);
    Task<QuizPlayResponse> GetQuizForPlayAsync(GetQuizRequest request);
    Task<ValidateAnswerResponse> ValidateAnswerAsync(ValidateAnswerRequest request);
}
