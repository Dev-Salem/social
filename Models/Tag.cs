
namespace social.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public List<Post> Posts {get; set;} = [];
    }
}