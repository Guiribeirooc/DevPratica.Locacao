using DevPratica.Locacao.Modelo;
using DevPratica.Locacao.Negocio.FornecedorNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevPratica.Locacao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorNegocio _fornecedorNegocio;

        public FornecedorController(IFornecedorNegocio fornecedorNegocio)
        {
            _fornecedorNegocio = fornecedorNegocio;
        }

        [HttpPost]
        public async Task Incluir([FromBody] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                await _fornecedorNegocio.Incluir(fornecedor);
            }
        }

        [HttpGet]
        public async Task<List<Fornecedor>> Get()
        {
            return await _fornecedorNegocio.ObterLista();
        }

        [HttpGet("ObterPorCNPJ")]
        public async Task<Fornecedor> ObterPorCNPJ([FromQuery] string cnpj)
        {
            return await _fornecedorNegocio.ObterPorCNPJ(cnpj);
        }
    }
}
