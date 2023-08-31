namespace DevPratica.Locacao.Comum.Servico
{
    public interface IApiToken
    {
        Task<string> Obter();
    }
}
