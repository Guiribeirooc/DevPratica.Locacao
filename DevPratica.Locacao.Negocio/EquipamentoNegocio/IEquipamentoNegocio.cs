using DevPratica.Locacao.Modelo;

namespace DevPratica.Locacao.Negocio.EquipamentoNegocio
{
    public interface IEquipamentoNegocio
    {
        Task Incluir(Equipamento equipamento);

        Task<Equipamento> ObterPorDescricao(string descricao);

        Task<List<Equipamento>> ObterLista();
    }
}
