using DevPratica.Locacao.Infra.Entity;
using DevPratica.Locacao.Modelo;
using Microsoft.EntityFrameworkCore;

namespace DevPratica.Locacao.Negocio.ClienteNegocio
{
    public class ClienteNegocio : IClienteNegocio
    {
        private readonly AppDbContext _appDbContext;
        public ClienteNegocio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Alterar(Cliente cliente)
        {
            cliente.DataAlteracao = DateTime.Now;

            _appDbContext.Clientes.Update(cliente);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task EmailEnviado(string cpf)
        {
            Cliente cliente = await _appDbContext.Clientes.SingleAsync(x => x.CPF.Equals(cpf));
            cliente.EmailEnviado = true;
            cliente.DataAlteracao = DateTime.Now;

            _appDbContext.Clientes.Update(cliente);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Incluir(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Email))
                cliente.EmailEnviado = true;
            else
                cliente.EmailEnviado = false;

            cliente.DataInclusao = DateTime.Now;
            cliente.DataAlteracao = null;

            await _appDbContext.Clientes.AddAsync(cliente);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<List<Cliente>> ObterLista()
        {
            return await _appDbContext.Clientes.ToListAsync();
        }

        public async Task<List<Cliente>> ObterListaEmailNaoEnviados()
        {
            return await _appDbContext.Clientes.Where(x => x.EmailEnviado.Equals(false)).ToListAsync();
        }

        public async Task<Cliente> ObterPorCPF(string cpf)
        {
            return await _appDbContext.Clientes.SingleAsync(x => x.CPF == cpf);
        }
    }
}
