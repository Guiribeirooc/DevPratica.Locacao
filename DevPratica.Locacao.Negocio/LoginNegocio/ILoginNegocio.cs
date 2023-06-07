using DevPratica.Locacao.Modelo.DTO;

namespace DevPratica.Locacao.Negocio.LoginNegocio
{
    public interface ILoginNegocio
    {
        Task<LoginResposta> Login(LoginRequisicao loginRequisicao);
    }
}
