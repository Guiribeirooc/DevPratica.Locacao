using DevPratica.Locacao.Infra.Entity;
using DevPratica.Locacao.Modelo;
using Microsoft.EntityFrameworkCore;

namespace DevPratica.Locacao.Negocio.EquipamentoNegocio
{
    public class EquipamentoNegocio : IEquipamentoNegocio
    {
        private readonly AppDbContext _appDbContext;
        public EquipamentoNegocio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Alterar(Equipamento equipamento)
        {
            equipamento.DataAlteracao = DateTime.Now;

            _appDbContext.Equipamentos.Update(equipamento);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Incluir(Equipamento equipamento)
        {
            equipamento.DataInclusao = DateTime.Now;
            equipamento.DataAlteracao = null;

            await _appDbContext.Equipamentos.AddAsync(equipamento);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<List<Equipamento>> ObterLista()
        {
            return await _appDbContext.Equipamentos.ToListAsync();
        }
        public async Task<Equipamento> ObterPorDescricao(string descricao)
        {
            return await _appDbContext.Equipamentos.SingleAsync(x => x.Descricao == descricao);
        }
        public async Task<Equipamento> ObterPorId(int id)
        {
            return await _appDbContext.Equipamentos.SingleAsync(x => x.Id == id);
        }
    }
}
