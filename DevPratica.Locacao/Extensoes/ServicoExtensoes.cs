using DevPratica.Locacao.Modelo.DTO;
using DevPratica.Locacao.Models;
using DevPratica.Locacao.Servico;

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
