using DevPratica.Locacao.Infra.Entity;
using DevPratica.Locacao.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPratica.Locacao.Negocio.ClienteNegocio
{
    public class ClienteNegocio : IClienteNegocio
    {
        private readonly AppDbContext _appDbContext;
        public ClienteNegocio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task Incluir(Cliente cliente)
        {
            await _appDbContext.Clientes.AddAsync(cliente);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Cliente>> ObterLista()
        {
            return await _appDbContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> ObterPorCPF(string cpf)
        {
            return await _appDbContext.Clientes.SingleAsync(x => x.CPF == cpf);
        }
    }
}
