namespace DevPratica.Locacao.Servico
{
    public interface IApiToken
    {
        Task<string> Obter();
    }
}
