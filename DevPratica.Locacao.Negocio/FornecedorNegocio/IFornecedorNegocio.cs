using DevPratica.Locacao.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPratica.Locacao.Negocio.FornecedorNegocio
{
    public interface IFornecedorNegocio
    {
        Task Incluir(Fornecedor fornecedor);

        Task<Fornecedor> ObterPorCNPJ(string cnpj);

        Task<List<Fornecedor>> ObterLista();

    }
}
