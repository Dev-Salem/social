using System.ComponentModel.DataAnnotations;
using social.Models;

namespace social.Dtos
{
    public readonly record struct PostDto : IBaseDTO
    {
        public PostDto(
            int id,
            DateTime createdAt,
            int votesCount,
            int views,
            string title,
            string content,
            List<TagGetDTO> tags
        )
        {
            Id = id;
            CreatedAt = createdAt;
            VotesCount = votesCount;
            Views = views;
            Title = title;
            Tags = tags;
            Content = content;
        }

        [Required]
        public int Id { get; init; }
        public DateTime CreatedAt { get; init; }

        public int VotesCount { get; init; }
        public int Views { get; init; }

        [MinLength(10, ErrorMessage = "Title is too short")]
        [MaxLength(5 * 50, ErrorMessage = "Title is too long")]
        public string Title { get; init; }

        [MinLength(10, ErrorMessage = "Post is too short")]
        [MaxLength(5 * 1000, ErrorMessage = "Post is too long")]
        public string Content { get; init; }
        public List<TagGetDTO> Tags { get; init; }
        public List<PostAnswerDTO> Answers { get; init; }
    }
}
