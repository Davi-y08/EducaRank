using EducaRank.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EducaRank.Infrastructure.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateTokenAluno(Aluno aluno) 
        {
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!);

            var clains = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, aluno.Id),
                new Claim("rm", aluno.Rm.ToString()),
                new Claim("nome", aluno.Nome),
                new Claim(ClaimTypes.Role, "Aluno")
            };

            var signInCredentials = new 
                SigningCredentials(new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature);

            var configToken = new SecurityTokenDescriptor
            {
                SigningCredentials = signInCredentials,
                Expires = DateTime.UtcNow.AddDays(1),
                Subject = new ClaimsIdentity(clains),
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"]
            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(configToken);

            return handler.WriteToken(token);
        }

        public string GenerateTokenProfessor(Professor professor)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!);

            var clains = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, professor.Id),
                new Claim("rm", professor.Rm.ToString()),
                new Claim("nome", professor.Nome),
                new Claim(ClaimTypes.Role, "Professor")
            };

            var signInCredentials = new
                SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var configToken = new SecurityTokenDescriptor
            {
                SigningCredentials = signInCredentials,
                Expires = DateTime.UtcNow.AddDays(1),
                Subject = new ClaimsIdentity(clains),
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"]
            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(configToken);

            return handler.WriteToken(token);
        }
    }
}
