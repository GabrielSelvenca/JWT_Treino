using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtBearer_Treino.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace JwtBearer_Treino.Services
{
    public class TokenService
    {
        public string Generate(Usuario usuario)
        {
            // Cria uma instância do JwtSecurityTokenHandler
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(Configuration.PrivateKey);
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(usuario),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(1),
            };

            // Gera um token
            var token = handler.CreateToken(tokenDescriptor);

            // Gera uma string do token
            var strToken = handler.WriteToken(token);

            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(Usuario usuario)
        {
            var ci = new ClaimsIdentity();

            ci.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()));
            ci.AddClaim(new Claim(ClaimTypes.Name, usuario.Nome));
            ci.AddClaim(new Claim(ClaimTypes.Email, usuario.Email));

            return ci;
        }
    }
}
