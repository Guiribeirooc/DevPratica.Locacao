using DevPratica.Locacao.Modelo.DTO;
using DevPratica.Locacao.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace DevPratica.Locacao.Servico
{
    public class ApiToken : IApiToken
    {

        private readonly IOptions<DadosBase> _dadosBase;
        private readonly IOptions<LoginResposta> _loginResposta;
        private readonly HttpClient _httpClient;

        public ApiToken(IOptions<DadosBase> dadosBase, IOptions<LoginResposta> loginResposta, HttpClient httpClient)
        {
            _dadosBase = dadosBase;
            _loginResposta = loginResposta;
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<string> Obter()
        {
            if (_loginResposta.Value.Autenticado == false)
                await ObterToken();

            else
            {
                if (DateTime.Now >= _loginResposta.Value.DataExpiracao)
                    await ObterToken();
            }

            return _loginResposta.Value.Token;
        }

        private async Task ObterToken()
        {
            LoginRequisicao loginRequisicao = new LoginRequisicao();
            loginRequisicao.Usuario = _dadosBase.Value.API_USUARIO;
            loginRequisicao.Senha = _dadosBase.Value.API_SENHA;

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}login", loginRequisicao);

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                LoginResposta loginResposta = JsonConvert.DeserializeObject<LoginResposta>(conteudo);

                if (loginResposta.Autenticado)
                {
                    _loginResposta.Value.Autenticado = loginResposta.Autenticado;
                    _loginResposta.Value.Usuario = loginResposta.Usuario;
                    _loginResposta.Value.DataExpiracao = loginResposta.DataExpiracao;
                    _loginResposta.Value.Token = loginResposta.Token;
                }
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
