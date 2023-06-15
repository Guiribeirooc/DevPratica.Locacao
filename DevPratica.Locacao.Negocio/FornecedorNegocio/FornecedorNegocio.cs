using DevPratica.Locacao.Infra.Entity;
using DevPratica.Locacao.Modelo;
using Microsoft.EntityFrameworkCore;

namespace DevPratica.Locacao.Negocio.FornecedorNegocio
{
    public class FornecedorNegocio : IFornecedorNegocio
    {
        private readonly AppDbContext _appDbContext;
        public FornecedorNegocio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async  Task Alterar(Fornecedor fornecedor)
        {
            fornecedor.DataAlteracao = DateTime.Now;

            _appDbContext.Fornecedores.Update(fornecedor);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Incluir(Fornecedor fornecedor)
        {
            fornecedor.DataInclusao = DateTime.Now;
            fornecedor.DataAlteracao = null;

            await _appDbContext.Fornecedores.AddAsync(fornecedor);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<List<Fornecedor>> ObterLista()
        {
            return await _appDbContext.Fornecedores.ToListAsync();
        }
        public async Task<Fornecedor> ObterPorCNPJ(string cnpj)
        {
            return await _appDbContext.Fornecedores.SingleAsync(x => x.CNPJ == cnpj);
        }
    }
}
