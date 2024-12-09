using System.ComponentModel.DataAnnotations;

namespace social.Dtos
{
    public struct PostRequestBody(string title, string content) : IBaseDTO
    {
        [Required]
        [MinLength(10, ErrorMessage = "Title is too short")]
        [MaxLength(5 * 50, ErrorMessage = "Title is too long")]
        public required string Title { get; set; } = title;

        [Required]
        [MinLength(10, ErrorMessage = "Post is too short")]
        [MaxLength(5 * 1000, ErrorMessage = "Post is too long")]
        public required string Content { get; set; } = content;
        public List<int> TagIds { get; set; } = [];
    }
}
