using System.ComponentModel.DataAnnotations;

namespace social.Dtos
{
    public readonly record struct AnswerDTO : IBaseDTO
    {
        [MinLength(10, ErrorMessage = "Answer is too short to post")]
        [MaxLength(5 * 1000, ErrorMessage = "Answer is too long to post")]
        public string Content { get; init; }
    }

    public record PostAnswerDTO(int Id, string Content, int VotesCount);

    public record AnswerGetDTO(
        [Required] int Id,
        [MinLength(10, ErrorMessage = "Answer is too short to post")]
        [MaxLength(5 * 1000, ErrorMessage = "Answer is too long to post")]
            string Content,
        int PostId,
        [Required] PostDto Post
    ) : IBaseDTO;
}
