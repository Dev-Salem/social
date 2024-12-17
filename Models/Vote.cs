namespace social.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public VoteType Type { get; set; }
        public int? PostId { get; set; }
        public Post? Post { get; set; }

        public enum VoteType
        {
            Positive,
            Negative,
        }
    }
}
