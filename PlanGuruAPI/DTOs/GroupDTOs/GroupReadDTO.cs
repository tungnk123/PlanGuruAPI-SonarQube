namespace PlanGuruAPI.DTOs.GroupDTOs
{
    public class GroupReadDTO
    {
        public Guid Id { get; set; }
        public Guid MasterUserId { get; set; }
        public string GroupName { get; set; }       
        public string Description { get; set; }
        public string GroupImage { get; set; }
        public bool IsJoined { get; set; }      
        public int NumberOfMembers { get; set; }
        public int NumberOfPosts { get; set; }      
    }
}
