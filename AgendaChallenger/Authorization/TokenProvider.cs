using AgendaChallenger.Entities;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace AgendaChallenger.Authorization
{
    internal sealed class TokenProvider(IConfiguration configuration)
    {
        public string Create(Usuario usuario)
        {
            string secretKey = configuration["Jwt:Key"]!;
            var sercurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(sercurityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity([
                
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, Convert.ToString(usuario.Id)),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Name, Convert.ToString(usuario.Nome))
                ]),
                Expires = DateTime.UtcNow.AddMinutes(configuration.GetValue<int>("Jwt:ExpiracaoEmMinutos")),
                SigningCredentials = credentials,
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"]
            };

            var handler = new JsonWebTokenHandler();
            string token = handler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}
