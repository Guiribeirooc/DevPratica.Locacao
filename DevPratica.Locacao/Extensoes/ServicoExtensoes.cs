using DevPratica.Locacao.Comum.Modelo;
using DevPratica.Locacao.Comum.Servico;
using DevPratica.Locacao.Modelo.DTO;

namespace DevPratica.Locacao.Extensoes
{
    public static class ServicoExtensoes
    {
        public static void ConfigurarServicos(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IApiToken, ApiToken>();
            services.AddScoped<LoginResposta>();
        }

        public static void ConfigurarAPI(this IServiceCollection services, IConfiguration configuration) 
        {
            services.Configure<DadosBase>(configuration.GetSection("DadosBase"));
        }
    }
}
