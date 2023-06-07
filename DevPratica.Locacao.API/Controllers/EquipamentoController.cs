using DevPratica.Locacao.Modelo;
using DevPratica.Locacao.Negocio.EquipamentoNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevPratica.Locacao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EquipamentoController : ControllerBase
    {
        private readonly IEquipamentoNegocio _equipamentoNegocio;
        public EquipamentoController(IEquipamentoNegocio equipamentoNegocio)
        {
            _equipamentoNegocio = equipamentoNegocio;
        }

        [HttpPost]
        public async Task Incluir([FromBody] Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                await _equipamentoNegocio.Incluir(equipamento);
            }
        }

        [HttpGet]
        public async Task<List<Equipamento>> Get()
        {
            return await _equipamentoNegocio.ObterLista();
        }

        [HttpGet("ObterPorDescrição")]
        public async Task<Equipamento> ObterPorId([FromQuery] string descricao)
        {
            return await _equipamentoNegocio.ObterPorDescricao(descricao);
        }
    }
}
