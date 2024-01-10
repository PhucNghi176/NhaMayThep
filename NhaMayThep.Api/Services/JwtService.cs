using Microsoft.IdentityModel.Tokens;
using NhaMayThep.Application.Common.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NhaMayThep.Api.Services
{
    internal class JwtService : IJwtService
    {
        public string CreateToken(string userName, IList<string> roles = null)
        {
            var claims = new List<Claim>
            {
                //new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, userName),
                new Claim(JwtRegisteredClaimNames.Email, userName)
            };

            if (roles != null)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HRM Nh@ M@y Th3p!!!"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "test",
                audience: "api",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}