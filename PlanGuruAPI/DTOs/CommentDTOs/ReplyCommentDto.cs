namespace PlanGuruAPI.DTOs.CommentDTOs
{
    public class ReplyCommentDto
    {
        public Guid ParentCommentId { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
    }
}
