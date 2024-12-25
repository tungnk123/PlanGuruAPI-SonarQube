namespace PlanGuruAPI.DTOs.WikiDTOs
{
    public class ContentDiffResult
    {
        public string OriginalContent { get; set; }
        public string ContributionContent { get; set; }
        public List<DiffLine> DiffLines { get; set; }
    }

    public class DiffLine
    {
        public string Content { get; set; }
        public DiffType Type { get; set; }
    }

    public enum DiffType
    {
        Unchanged,
        Added,
        Deleted
    }
}
