namespace Domain.DTOs.QuizDTOs;

public class CreateQuizRequest
{
    public string Topic { get; set; }
    public int NumberOfQuestions { get; set; }
}

public class GetQuizRequest
{
    public string QuizId { get; set; }
}

public class EditQuizRequest
{
    public string QuizId { get; set; }
    public Quiz Quiz { get; set; }
}

public class ListQuizzesRequest
{
    public int PageSize { get; set; }
    public string PageToken { get; set; }
}

public class ListQuizzesResponse
{
    public List<QuizSummary> Quizzes { get; set; }
    public string NextPageToken { get; set; }
}

public class QuizSummary
{
    public string QuizId { get; set; }
    public string Topic { get; set; }
    public int QuestionCount { get; set; }
    public string CreatedAt { get; set; }
}

public class Quiz
{
    public string QuizId { get; set; }
    public string Topic { get; set; }
    public List<Question> Questions { get; set; }
    public string CreatedAt { get; set; }
    public string CreatedBy { get; set; }
}

public class Question
{
    public string QuestionId { get; set; }
    public string Content { get; set; }
    public List<string> Options { get; set; }
    public int CorrectOptionIndex { get; set; }
}

public class QuizResponse
{
    public Quiz Quiz { get; set; }
}

public class QuizPlayResponse
{
    public string QuizId { get; set; }
    public string Topic { get; set; }
    public List<PlayQuestion> Questions { get; set; }
}

public class PlayQuestion
{
    public string QuestionId { get; set; }
    public string Content { get; set; }
    public List<string> Options { get; set; }
}

public class ValidateAnswerRequest
{
    public string QuizId { get; set; }
    public string QuestionId { get; set; }
    public int SelectedOptionIndex { get; set; }
}

public class ValidateAnswerResponse
{
    public bool IsCorrect { get; set; }
    public string Feedback { get; set; }
}
