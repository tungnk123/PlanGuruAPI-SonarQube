namespace PlanGuruAPI.DTOs
{
    public record SetNameAndAvatarRequest(Guid userId, string name, string avatar);
}
