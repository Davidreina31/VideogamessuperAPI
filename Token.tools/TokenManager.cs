using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Token.tools
{
    public class TokenManager
    {
        private IConfiguration _config;

        public TokenManager(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateJwt(TokenData data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            // Création de la date d'expiration du token
            DateTime experationDate = DateTime.Now.AddMinutes(double.Parse(_config["Jwt:LifeTime"]));

            // Création des credentials
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            // Création des "claims" qui contient les informations du token
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name, data.UserName),
                new Claim("UserId", data.UserId.ToString()),
                new Claim(ClaimTypes.Role, data.Role)
            };

            // Génération du token via les outils JWT (package: System.IdentityModel.Tokens.Jwt)
            JwtSecurityToken token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: experationDate,
                    signingCredentials: credentials
                );

            // Renvoyer le token générer
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public TokenData GetData(ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            if (!principal.HasClaim(c => c.Type == ClaimTypes.Name)
                    && !principal.HasClaim(c => c.Type == "UserId")
                    && !principal.HasClaim(c => c.Type == ClaimTypes.Role))
                throw new SecurityTokenException("Missing claim !");

            return new TokenData()
            {
                UserId = ExtractClaim<int>(principal, "UserId"),
                UserName = ExtractClaim(principal, ClaimTypes.Name),
                Role = ExtractClaim(principal, ClaimTypes.Role)
            };
        }

        private string ExtractClaim(ClaimsPrincipal principal, string typeClaim)
        {
            return principal.Claims.SingleOrDefault(c => c.Type == typeClaim)?.Value;
        }

        private T ExtractClaim<T>(ClaimsPrincipal principal, string typeClaim)
        {
            string valueClaim = ExtractClaim(principal, typeClaim);
            return (T)Convert.ChangeType(valueClaim, typeof(T));
        }

    }
}
