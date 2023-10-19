using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Security
{
    public static class SecurityToken
    {
        public static string BuildToken(string username, int idPerson, int idUser, int userType, string securityKey)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, username),
                new Claim("IdUser", idUser.ToString()),
                new Claim("IdPerson", idPerson.ToString()),
                new Claim("Perfil", userType.ToString()),
                new Claim("DateGenerated", DateTime.UtcNow.AddHours(-5).ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Token expiration time -- 1 day
            var expiration = DateTime.UtcNow.AddHours(-5).AddDays(1);

            JwtSecurityToken token = new(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}