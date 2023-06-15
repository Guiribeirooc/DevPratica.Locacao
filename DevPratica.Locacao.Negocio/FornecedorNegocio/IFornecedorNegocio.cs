using DevPratica.Locacao.Modelo;

namespace DevPratica.Locacao.Negocio.FornecedorNegocio
{
    public interface IFornecedorNegocio
    {
        Task Incluir(Fornecedor fornecedor);
        Task<Fornecedor> ObterPorCNPJ(string cnpj);
        Task<List<Fornecedor>> ObterLista();
        Task Alterar (Fornecedor fornecedor);
    }
}
