using DevPratica.Locacao.Modelo.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DevPratica.Locacao.Negocio.GeradorTokenNegocio
{
    public class GeradorTokenNegocio : IGeradorTokenNegocio
    {
        private readonly string _secreto;
        public GeradorTokenNegocio()
        {
            _secreto = Environment.GetEnvironmentVariable("JWT_SECRETO");
        }
        public async Task<LoginResposta> GerarToken(LoginResposta loginResposta)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Convert.FromBase64String(_secreto);

            var claimsIdendity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, loginResposta.Usuario)
            });

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdendity,
                Issuer = "EmitenteDoJWT",
                Audience = "DestinatarioDoJWT",
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = signingCredentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            loginResposta.Autenticado = true;
            loginResposta.DataExpiracao = tokenDescriptor.Expires;
            loginResposta.Token = tokenHandler.WriteToken(token);

            return loginResposta;
        }
    }
}
