namespace PlanGuruAPI.DTOs.WikiDTOs
{
    public class AddQuizToWikiRequest
    {
        public string QuizId { get; set; }
        public Guid WikiId { get; set; }
    }
}
