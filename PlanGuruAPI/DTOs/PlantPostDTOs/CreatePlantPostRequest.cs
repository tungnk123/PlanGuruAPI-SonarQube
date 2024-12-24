namespace PlanGuruAPI.DTOs.PlantPostDTOs
{
    public record CreatePlantPostRequest(
        string Title,
        string Description,
        Guid UserId,
        string Tag,
        string Background,
        List<string> Images
    );

}
