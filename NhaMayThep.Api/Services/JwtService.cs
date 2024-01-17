using IdentityModel;
using Microsoft.IdentityModel.Tokens;
using NhaMayThep.Application.Common.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NhaMayThep.Api.Services
{
    internal class JwtService : IJwtService
    {
        public string CreateToken(string email, string ID, string roles)
        {
            var claims = new List<Claim>
            {
                //new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtClaimTypes.Subject, ID),
                new Claim(JwtClaimTypes.Email, email)
            };

            if (roles != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, roles));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HRM Nh@ M@y Th3p!!!"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               // issuer: "test",
               // audience: "api",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}