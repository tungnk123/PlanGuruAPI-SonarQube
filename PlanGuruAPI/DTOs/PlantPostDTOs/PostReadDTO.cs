﻿namespace PlanGuruAPI.DTOs.PlantPostDTOs
{
    public class PostReadDTO
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string UserNickName { get; set; }
        public string UserAvatar { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Tag { get; set; }
        public string Background { get; set; }
        public int NumberOfUpvote { get; set; }
        public int NumberOfDevote { get; set; }
        public int NumberOfComment { get; set; }
        public int NumberOfShare { get; set; }
        public string CreatedDate { get; set; }
        public string Title { get; set; }           

    }
}
