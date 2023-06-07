using DevPratica.Locacao.Modelo.DTO;

namespace DevPratica.Locacao.Negocio.GeradorTokenNegocio
{
    public interface IGeradorTokenNegocio
    {
        Task<LoginResposta> GerarToken(LoginResposta loginResposta);
    }
}
