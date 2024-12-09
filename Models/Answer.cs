namespace social.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; } = default!;
        public int? PostId { get; set; }
        public Post? Post { get; set; }
        public List<Vote> Votes { get; set; } = [];
        public int VotesCount { get; set; }
    }
}
