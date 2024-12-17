namespace PlanGuruAPI.DTOs.UserDTOs
{
    public record SignUpRequest(string email, string password, string name, string avatar);
}
