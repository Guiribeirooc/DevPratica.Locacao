using DevPratica.Locacao.Modelo;

namespace DevPratica.Locacao.Negocio.ClienteNegocio
{
    public interface IClienteNegocio
    {
        Task Incluir(Cliente cliente);

        Task<Cliente> ObterPorCPF(string cpf);

        Task<List<Cliente>> ObterLista();
    }
}
