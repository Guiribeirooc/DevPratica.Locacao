using DevPratica.Locacao.Modelo.DTO;
using DevPratica.Locacao.Negocio.LoginNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevPratica.Locacao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginNegocio _loginNegocio;

        public LoginController(ILoginNegocio loginNegocio)
        {
            _loginNegocio = loginNegocio;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResposta>> Login([FromBody] LoginRequisicao loginRequisicao)
        {
            return Ok(await _loginNegocio.Login(loginRequisicao));
        }
    }
}
