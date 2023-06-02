using DevPratica.Locacao.Infra.Entity;
using DevPratica.Locacao.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPratica.Locacao.Negocio.FornecedorNegocio
{
    public class FornecedorNegocio : IFornecedorNegocio
    {
        private readonly AppDbContext _appDbContext;
        public FornecedorNegocio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Incluir(Fornecedor fornecedor)
        {
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
