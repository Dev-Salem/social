namespace social.Helpers
{
    public class PostQueryObject : IBaseQueryObject
    {
        public string? Title { get; set; } = null!;
        public string? Content { get; set; } = null!;
        public string? SortBy { get; set; } = null!;
        public bool IsDescending { get; set; } = true;
        public int PageSize { get; set; } = 3;
        public int PageNumber { get; set; } = 1;
    }
}
