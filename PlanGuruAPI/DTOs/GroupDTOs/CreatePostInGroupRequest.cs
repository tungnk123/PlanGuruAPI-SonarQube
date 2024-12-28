namespace PlanGuruAPI.DTOs.GroupDTOs
{
    public record CreatePostInGroupRequest(
        string Title,
        string Description,
        Guid UserId,
        Guid GroupId,
        List<string> Images,            
        string Tag,
        string Background);
}
