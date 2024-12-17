using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using social.Dtos;
using social.Models;

namespace social.Services
{
    public class AuthService
    {
        public AuthService(
            UserManager<AppUser> userManager,
            IConfiguration configuration,
            SignInManager<AppUser> signInManager
        )
        {
            _userManger = userManager;
            _configuration = configuration;
            _signInManger = signInManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        }

        private readonly UserManager<AppUser> _userManger;
        private readonly SignInManager<AppUser> _signInManger;
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;

        public async Task<IdentityResult> RegisterAsync(RegisterDTO dto)
        {
            try
            {
                var appUser = new AppUser() { UserName = dto.Username, Email = dto.Email };
                var createdUser = await _userManger.CreateAsync(appUser, dto.Password!);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManger.AddToRoleAsync(appUser, "User");
                    return createdUser;
                }
                return createdUser;
            }
            catch (Exception e)
            {
                return IdentityResult.Failed(
                    errors: [new IdentityError() { Description = e.Message }]
                );
            }
        }

        public string GenerateToken(AppUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName!),
                new Claim(ClaimTypes.Role, "User"),
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = creds,
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<string> Login(LoginDTO dto)
        {
            var user =
                await _userManger.Users.FirstOrDefaultAsync(x =>
                    string.Equals(
                        x.UserName,
                        dto.Username,
                        StringComparison.CurrentCultureIgnoreCase
                    )
                ) ?? throw new Exception(message: "User was not found");
            var result = await _signInManger.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded)
            {
                throw new Exception(message: "Login was not successful");
            }
            return GenerateToken(new AppUser() { UserName = dto.Username });
        }
    }
}
