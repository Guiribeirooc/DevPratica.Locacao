using DevPratica.Locacao.Comum.Modelo;
using DevPratica.Locacao.Comum.Servico;
using DevPratica.Locacao.Modelo;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mail;
using System.Text;

namespace DevPratica.Locacao.EnviarEmail
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IOptions<DadosBase> _dadosBase;
        private readonly IApiToken _apiToken;
        private readonly HttpClient _httpClient;

        public Worker(ILogger<Worker> logger,
                      IOptions<DadosBase> dadosBase,
                      IApiToken apiToke,
                      IHttpClientFactory httpClient)
        {
            _logger = logger;
            _dadosBase = dadosBase;
            _apiToken = apiToke;
            _httpClient = httpClient.CreateClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                List<Cliente> clientes = await ObertListaEmailsNaoEnviados();

                foreach (var cliente in clientes)
                {
                    await EnviarEmail(cliente.Email, cliente.Nome);
                    await EmailEnviado(cliente.CPF);
                }

                await Task.Delay(1000, stoppingToken);
            }
        }

        public async Task<List<Cliente>> ObertListaEmailsNaoEnviados()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Cliente/ObertListaEmailsNaoEnviados");

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<Cliente>>(await response.Content.ReadAsStringAsync());
            else
                throw new Exception(response.ReasonPhrase);
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

        private async Task EmailEnviado(string cpf)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Cliente/EmailEnviado", cpf);

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ReasonPhrase);
        }

    }
}