using DevPratica.Locacao.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPratica.Locacao.Negocio.ClienteNegocio
{
    public interface IClienteNegocio
    {
        Task Incluir(Cliente cliente);

        Task<Cliente> ObterPorCPF(string cpf);

        Task<List<Cliente>> ObterLista();
    }
}
