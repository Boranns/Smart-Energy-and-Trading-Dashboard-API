using SmartEnergyAPI.Entities;
using SmartEnergyAPI.Repositories;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace SmartEnergyAPI.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;
        private readonly IConfiguration _config;
        private readonly PasswordHasher<User> _hasher = new PasswordHasher<User>();

        public UserService(UserRepository repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        public async Task<User?> RegisterAsync(string name, string email, string password, string role = "User")
        {
            var existingUser = await _repository.GetByEmailAsync(email);
            if (existingUser != null)
                return null;

            var user = new User
            {
                Name = name,
                Email = email,
                Role = role
            };

            user.PasswordHash = _hasher.HashPassword(user, password);

            await _repository.AddAsync(user);
            return user;
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var user = await _repository.GetByEmailAsync(email);
            if (user == null) return null;

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (result == PasswordVerificationResult.Failed)
                return null;

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

