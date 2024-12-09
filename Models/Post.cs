namespace social.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
        public List<Tag> Tags { get; set; } = [];
        public List<Vote> Votes { get; set; } = [];
        public List<Answer> Answers { get; set; } = [];
        public int VotesCount { get; set; }
        public int Views { get; set; }
    }
}
