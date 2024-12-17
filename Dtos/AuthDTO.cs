using System.ComponentModel.DataAnnotations;

namespace social.Dtos
{
    public struct RegisterDTO() : IBaseDTO
    {
        [Required]
        [MinLength(3)]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(8)]
        public required string Password { get; set; }
    }

    public struct UserDTO() : IBaseDTO
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Token { get; set; }
    }

    public struct LoginDTO() : IBaseDTO
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        [MinLength(8)]
        public required string Password { get; set; }
    }
}
