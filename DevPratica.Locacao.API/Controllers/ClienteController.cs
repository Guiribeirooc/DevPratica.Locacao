using DevPratica.Locacao.Modelo;
using DevPratica.Locacao.Negocio.ClienteNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Text;

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

                if(cliente.Email != null)
                    await EnviarEmail(cliente.Email, cliente.Nome);

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

        private async Task EnviarEmail(string email, string nome)
        {
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("turma2@devpratica.com.br");
            mensagem.To.Add(email);
            mensagem.Subject = "Bem=Vindo!!!";
            mensagem.IsBodyHtml = true;
            mensagem.Body = EmailBoasVindas(nome);

            var smptCliente = new SmtpClient("smtp.kinghost.net")
            {
                Port = 587,
                Credentials = new NetworkCredential("turma2@devpratica.com.br", "Senha@senha10"),
                EnableSsl = false,
            };

            smptCliente.Send(mensagem);
        }

        private string EmailBoasVindas(string nome)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<p>Parabéns <b>{nome},</b></p>");
            sb.Append($"<p>Seja muito bem-vindo a <b>G&R Locação.</b></p>");
            sb.Append($"<p>Estamos muito felizes de você fazer parte da <b>G&R Locação</b></p>");
            sb.Append($"<br>");
            sb.Append($"<p>Grande abraço</p>");
            return sb.ToString();
        }
    }
}
