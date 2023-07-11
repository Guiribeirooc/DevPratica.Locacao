using DevPratica.Locacao.Modelo;
using DevPratica.Locacao.Negocio.FornecedorNegocio;
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

                if (fornecedor.Email != null)
                    await EnviarEmail(fornecedor.Email, fornecedor.RazaoSocial);
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

        [HttpPut]
        public async Task Put([FromBody] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
                await _fornecedorNegocio.Alterar(fornecedor);
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
