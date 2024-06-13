using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestAgileSoft.Domain.Entities;
using TestAgileSoft.Domain.Ports;

namespace TestAgileSoft.Infrastructure.Adapters
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly IConfiguration _config;

        public JwtGenerator(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.NameId, user.UserName!)
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("KeyJwt").Value!));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = credential
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
