using DevPratica.Locacao.Modelo.DTO;
using DevPratica.Locacao.Negocio.GeradorTokenNegocio;

namespace DevPratica.Locacao.Negocio.LoginNegocio
{
    public class LoginNegocio : ILoginNegocio
    {
        private readonly IGeradorTokenNegocio _geradorTokenNegocio;

        public LoginNegocio(IGeradorTokenNegocio geradorTokenNegocio)
        {
            _geradorTokenNegocio = geradorTokenNegocio;
        }

        public async Task<LoginResposta> Login(LoginRequisicao loginRequisicao)
        {
            LoginResposta loginResposta = new LoginResposta();
            loginResposta.Autenticado = false;
            loginResposta.Usuario = loginRequisicao.Usuario;
            loginResposta.Token = "";
            loginResposta.DataExpiracao = null;

            if (loginRequisicao.Usuario == "UsuarioLocacao" && loginRequisicao.Senha == "SenhaLocacao")
            {
                loginResposta = await _geradorTokenNegocio.GerarToken(loginResposta);
            }

            return loginResposta;
        }
    }
}
