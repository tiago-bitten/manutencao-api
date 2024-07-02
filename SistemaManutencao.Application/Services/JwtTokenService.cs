using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SistemaManutencao.Application.Services
{
    public class JwtTokenService : IAuthService
    {
        private readonly string _secret;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expirationInMinutes;

        public JwtTokenService(IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            _secret = jwtSettings["Secret"];
            _issuer = jwtSettings["Issuer"];
            _audience = jwtSettings["Audience"];
            _expirationInMinutes = int.Parse(jwtSettings["ExpirationInMinutes"]);
        }

        public string GenerateTokenAsync(Usuario usuario)
        {
            var key = Encoding.ASCII.GetBytes(_secret);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserId", usuario.Id.ToString()),
                    new Claim("Ativo", usuario.Ativo.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim("TenantId", usuario.EmpresaId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_expirationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _issuer,
                Audience = _audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Guid GetEmpresaId(string authHeader)
        {
            var token = ResolveToken(authHeader);
            var jsonToken = GetJsonToken(token);
            var tenantId = jsonToken?.Claims.First(claim => claim.Type == "TenantId").Value;

            return Guid.Parse(tenantId);
        }

        public Guid GetUserId(string authHeader)
        {
            var token = ResolveToken(authHeader);
            var jsonToken = GetJsonToken(token);
            var userId = jsonToken?.Claims.First(claim => claim.Type == "UserId").Value;

            if (userId == null)
                throw new SecurityTokenException("EX10015: Token inválido");

            return Guid.Parse(userId);
        }

        public string ResolveToken(string authHeader)
        {
            if (authHeader == null || !authHeader.StartsWith("Bearer "))
                throw new SecurityTokenException($"EX10016: Token inválido");

            return authHeader[7..];
        }

        public bool ValidateToken(string token)
        {
            var key = Encoding.ASCII.GetBytes(_secret);

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _issuer,
                    ValidateAudience = true,
                    ValidAudience = _audience,
                    ValidateLifetime = true
                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private JwtSecurityToken GetJsonToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            return handler.ReadToken(token) as JwtSecurityToken;
        }
    }
}
