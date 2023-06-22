using DevPratica.Locacao.Modelo;
using DevPratica.Locacao.Negocio.ClienteNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevPratica.Locacao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteNegocio _clienteNegocio;
        public ClienteController(IClienteNegocio clienteNegocio)
        {
            _clienteNegocio = clienteNegocio;
        }

        [HttpPost]
        public async Task Incluir([FromBody] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                await _clienteNegocio.Incluir(cliente);
            }
        }

        [HttpGet]
        public async Task<List<Cliente>> Get()
        {
            return await _clienteNegocio.ObterLista();
        }

        [HttpGet("ObterPorCPF")]
        public async Task<Cliente> ObterPorCPF([FromQuery] string cpf)
        {
            return await _clienteNegocio.ObterPorCPF(cpf);
        }

        [HttpPut]
        public async Task Put([FromBody] Cliente cliente)
        {
            if (ModelState.IsValid)
                await _clienteNegocio.Alterar(cliente);      
        }
    }
}
